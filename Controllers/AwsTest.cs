using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ExternalApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AwsTest : ControllerBase
    {
        private readonly ILogger<AwsTest> _logger;
        private readonly DynamoService _dynamoService;
        private readonly SqsProducerService _sqsProducerService;

        public AwsTest(ILogger<AwsTest> logger, DynamoService dynamoService, SqsProducerService sqsProducerService)
        {
            _logger = logger;
            _dynamoService = dynamoService;
            _sqsProducerService = sqsProducerService;
        }

        [HttpPost("tryAddNewStuff/{path_parameter}")]
        public async Task<string> Post([FromRoute] string path_parameter, [FromBody] SomeStuff stuff)
        {
            //check if there is any equal message from the same path and user in dynamobDb
            var InDynamobDb = await AlreadyInDyanmob(path_parameter, stuff.PersonName);

            if (InDynamobDb) return "Data already registered";

            var addedToSqs = await SendToSqs(path_parameter, stuff);

            if (addedToSqs)
            {
                if (await AddToDynamoDb(path_parameter, stuff))
                {
                    return "Data registered";
                }
                else
                {
                    return "HUGE FATAL ERROR, CRY";
                }
            }
            else
            {
                return "FATAL ERROR, GO HOME";
            }
        }

        private async Task<bool> AlreadyInDyanmob(string pathParameter, string personName)
        {
            return await _dynamoService.AlreadyInTheDatabase(pathParameter, personName);
        }

        private async Task<bool> SendToSqs(string pathParameter, SomeStuff stuff)
        {
            return await _sqsProducerService.SendSqs(pathParameter, stuff);
        }

        private async Task<bool> AddToDynamoDb(string pathParameter, SomeStuff stuff)
        {
            return await _dynamoService.SaveInTheDatabase(pathParameter, stuff);
        }
    }
}
