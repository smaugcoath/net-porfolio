using DomainDrivenDesign.Example.Application.Common.Interfaces;
using DomainDrivenDesign.Example.Application.Items.Queries.GetAll;
using DomainDrivenDesign.Example.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Example.Application.Items.EventHandlers
{
    public class GetAllItemsHandler : IRequestHandler<GetAllQuery, GetAllResponse>
    {
        private readonly IItemRepository _itemRepository;
        public GetAllItemsHandler(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository ?? throw new ArgumentNullException(nameof(itemRepository));
        }

        public async Task<GetAllResponse> Handle(GetAllQuery request, CancellationToken cancelationToken)
        {
            var items = await _itemRepository.GetAllAsync(cancelationToken);
            var response = CreateResponse(items);
            return response;
        }

        private static GetAllResponse CreateResponse(IEnumerable<Item> items)
        {
            var response = new GetAllResponse
            {
                Items = items.Select(x => new GetAllResponse.Item
                {
                    Id = x.Id.Id,
                    Details = x.Details,
                    IsDone = x.Status == Domain.Enums.EItemStatus.Active ? false : true
                })
            };

            return response;
        }
    }
}
