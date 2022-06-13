using Application.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Queries.GetProduct.GetProductByid
{
    public record GetProductByIdQuery(int Id) : IRequest<ProductDto>;
}
