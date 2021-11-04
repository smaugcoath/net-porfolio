using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using DomainDrivenDesign.Example.Infrastructure.Persistence.DynamoDb.Models;
using ServiceStack.Aws.DynamoDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Example.Infrastructure.Persistence.DynamoDb
{
    internal class DynamoDbMigrationService
    {
        private readonly IAmazonDynamoDB _amazonDynamoDB;
        private readonly IPocoDynamo _pocoDynamoDB;

        public DynamoDbMigrationService(IAmazonDynamoDB amazonDynamoDB, IPocoDynamo pocoDynamoDB)
        {
            _amazonDynamoDB = amazonDynamoDB ?? throw new ArgumentNullException(nameof(amazonDynamoDB));
            _pocoDynamoDB = pocoDynamoDB ?? throw new ArgumentNullException(nameof(pocoDynamoDB));
        }

        private async Task Migrate()
        {
            //PocoDynamo

            _pocoDynamoDB.RegisterTable<Item>();

            _pocoDynamoDB.InitSchema();

            //string tableName = "ProductCatalog";
            //var request = CreateRequest(tableName);

            //var response = await _amazonDynamoDB.CreateTableAsync(request);

            //await WaitUntilTableIsReady(response);


        }

        private static CreateTableRequest CreateRequest(string tableName)
        {
            var request = new CreateTableRequest
            {
                TableName = tableName,
                AttributeDefinitions = new List<AttributeDefinition>()
                  {
                    new AttributeDefinition
                    {
                      AttributeName = "Id",
                      AttributeType = "N"
                    }
                  },
                KeySchema = new List<KeySchemaElement>()
                  {
                    new KeySchemaElement
                    {
                      AttributeName = "Id",
                      KeyType = "HASH"  //Partition key
                    }
                  },
                ProvisionedThroughput = new ProvisionedThroughput
                {
                    ReadCapacityUnits = 1,
                    WriteCapacityUnits = 1
                }
            };

            return request;
        }

        private async Task WaitUntilTableIsReady(CreateTableResponse createTableResponse)
        {
            const string ActiveStatus = "ACTIVE";
            string status;

            do
            {
                await Task.Delay(5000);
                var describeTableRequest = new DescribeTableRequest
                {
                    TableName = createTableResponse.TableDescription.TableName
                };

                var describeTableResponse = await _amazonDynamoDB.DescribeTableAsync(describeTableRequest);
                status = describeTableResponse.Table.TableStatus;

            } while (status != ActiveStatus);
        }
    }
    
}
