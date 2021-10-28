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
    internal class ItemRepository : IItemRepository
    {
        public async Task<IEnumerable<Item>> GetAllAsync(CancellationToken cancelationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
