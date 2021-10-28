using DomainDrivenDesign.Example.Application.Items.Queries.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Example.Web.Api.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemsController : ControllerBase
    {
        private readonly ILogger<ItemsController> _logger;
        private readonly IMediator _mediator;

        public ItemsController(ILogger<ItemsController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<GetAllResponse> GetAll(CancellationToken cancellationToken)
        {
            var query = new GetAllQuery();
            var response = await _mediator.Send(query, cancellationToken);
            return response;
        }
    }
}
