using Amazon.DynamoDBv2;
using DomainDrivenDesign.Example.Application.Common.Interfaces;
using DomainDrivenDesign.Example.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Example.Infrastructure.Persistence
{
    internal class DynamoDbItemRepository : IItemRepository
    {

        private readonly IAmazonDynamoDB _client;

        public DynamoDbItemRepository(IAmazonDynamoDB client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<Item>> GetAllAsync(CancellationToken cancelationToken = default)
        {
        }
    }
}
