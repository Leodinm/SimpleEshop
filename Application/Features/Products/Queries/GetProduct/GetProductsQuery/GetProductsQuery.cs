using Application.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Queries.GetProduct.GetProductsQuery
{
    public record GetProductQuery() : IRequest <IReadOnlyList<ProductDto>>;
}
