using DomainDrivenDesign.Example.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Example.Application.Common.Interfaces
{
    public interface IItemRepository
    {
        Task<IEnumerable<Item>> GetAllAsync(CancellationToken cancelationToken = default);
    }
}
