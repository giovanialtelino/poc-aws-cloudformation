using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AwsShared.DynamoDbModels;
using Amazon.DynamoDBv2.DataModel;

namespace AwsShared.DynamoDbModels
{
    [DynamoDBTable("BurguerOrder")]
    internal class BurgerOrder
    {
        [DynamoDBHashKey]
        public Guid Id { get; set; }
        public DateTime OrderTime { get; set; }
        public Guid Store { get; set; }
        public bool Fullfiled { get; set; }
        public DateTime FullfilmentTime { get; set; }
        public DateTime PreparationStart { get; set; }
        public DateTime PreparationCompleted { get; set; }
        public List<Guid> Products { get; set; }
        public decimal Value { get; set; }
        public bool PaymentType { get; set; }
        public Guid Client { get; set; }
        public bool Cancelled { get; set; }
        public string Comment { get; set; }
    }
}
