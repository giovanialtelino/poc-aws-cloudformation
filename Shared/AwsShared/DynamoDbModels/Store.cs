using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.DataModel;

namespace AwsShared.DynamoDbModels
{
    [DynamoDBTable("Store")]
    internal class Store
    {
        [DynamoDBHashKey]
        public string Id { get; set; }
        public string CityName { get; set; }
        public string PostalCode { get; set; }
        public int Number { get; set; }
    }
}
