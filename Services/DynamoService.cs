using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;

namespace ExternalApi
{
    public class DynamoService
    {
        private readonly DynamoDBContext _dynamoDbContext;

        public DynamoService(IAmazonDynamoDB iAmazonDynamoDB)
        {
            _dynamoDbContext = new DynamoDBContext(iAmazonDynamoDB);
        }

        public async Task<bool> AlreadyInTheDatabase(string pathParameter, string personName)
        {
            var stuff = new SomeStuff { PathParameter = pathParameter, PersonName = personName };
            stuff.GenerateHashKey();

            var result = await _dynamoDbContext.LoadAsync<SomeStuff>(stuff);

            if (result == null)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> SaveInTheDatabase(string pathParameter, SomeStuff stuff)
        {

            stuff.GenerateHashKey();
            await _dynamoDbContext.SaveAsync<SomeStuff>(stuff);

            return true;
        }
    }
}
