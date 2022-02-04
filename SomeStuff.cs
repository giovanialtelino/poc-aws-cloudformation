using System;
using System.Text.Json.Serialization;
using Amazon.DynamoDBv2.Model;
using Amazon.DynamoDBv2.DataModel;

//POC, should not use the same model for the database and api

namespace ExternalApi
{
    [DynamoDBTable("SomeStuff")]
    public class SomeStuff
    {
        [JsonIgnore]
        [DynamoDBProperty]
        public DateTime ReceivedAt { get; set; }


        [JsonIgnore]
        [DynamoDBProperty]
        public Guid GeneralId { get; set; }


        [JsonPropertyName("data")]
        [DynamoDBProperty]
        public string Data { get; set; }


        [JsonPropertyName("personName")]
        [DynamoDBProperty]
        public string PersonName { get; set; }

        [JsonIgnore]
        [DynamoDBProperty]
        public string PathParameter { get; set; }


        [JsonIgnore]
        [DynamoDBHashKey]
        public string HashKey { get; private set; }

        public SomeStuff() { }

        public void GenerateHashKey()
        {
            HashKey = PathParameter + PersonName;
        }
    }

}
