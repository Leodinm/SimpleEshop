using Application.Dto;
using Application.Features.Products.Queries.Catalog;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleEshop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {

        private readonly IMediator _mediator;

        public CatalogController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet(Name = "GetCatalog")]
        [ProducesResponseType(typeof(ProductDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetProducts([FromQuery] GetCatalogQuery catalog,CancellationToken cancellationToken)
        {
            var products = await _mediator.Send(new GetCatalogQuery()
            {
                filter = catalog.filter,
                brandName = catalog.brandName
                ,
                priceFrom = catalog.priceFrom,
                priceTo = catalog.priceTo,
                route = Request.Path.Value
            }, cancellationToken); ;

            if (products == null) return NotFound();

            return Ok(products);
        }

    }
}
