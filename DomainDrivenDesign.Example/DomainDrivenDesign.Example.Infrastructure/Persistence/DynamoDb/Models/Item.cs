using Amazon.DynamoDBv2.DataModel;
using DomainDrivenDesign.Example.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Example.Infrastructure.Persistence.DynamoDb.Models
{
    [DynamoDBTable("Items")]
    public class Item
    {
        [DynamoDBProperty("Id")]
        [DynamoDBHashKey]
        public int Id { get; set; }

        [DynamoDBRangeKey]
        [DynamoDBProperty("Title")]
        public string Title { get; set; }

        [DynamoDBProperty("Details")]
        public string Details { get; set; }

        [DynamoDBProperty("Status")]
        public EItemStatus Status { get; set; } = EItemStatus.Active;
    }
}
