using System.Threading.Tasks;
using Amazon.SQS;
using Amazon.SQS.Model;
using System.Text.Json;

namespace ExternalApi
{
    public class SqsProducerService
    {
        private readonly IAmazonSQS _amazonSQS;

        public SqsProducerService(IAmazonSQS amazonSQS)
        {
            _amazonSQS = amazonSQS;
        }

        public async Task<bool> SendSqs(string pathParameter, SomeStuff stuff)
        {
            var sendMessageRequest = new SendMessageRequest()
            {
                QueueUrl = "testAws",
                MessageBody = JsonSerializer.Serialize(stuff)
            };

            await _amazonSQS.SendMessageAsync(sendMessageRequest);
            return true;
        }
    }
}
