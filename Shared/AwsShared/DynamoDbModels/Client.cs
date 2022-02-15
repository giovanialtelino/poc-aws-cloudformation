using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.DataModel;

namespace AwsShared.DynamoDbModels
{
    [DynamoDBTable("Client")]
    internal class Client
    {
        [DynamoDBHashKey]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public string PhoneNumber { get; set; }
        public bool AllowPhoneContact { get; set; }
    }
}
