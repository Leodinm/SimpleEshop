using Application.Dto;
using Application.Persistence;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Products.Queries.GetProduct.GetProductsQuery
{
    public class GetProductsHandler : IRequestHandler<GetProductQuery, IReadOnlyList<ProductDto>>
    {
        private readonly IProductsRepository _productsRepository;
        private readonly IMapper _mapper;

        public GetProductsHandler(IProductsRepository productsRepository, IMapper mapper)
        {
            _productsRepository = productsRepository ?? throw new ArgumentNullException(nameof(productsRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IReadOnlyList<ProductDto>> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var listProduct = await _productsRepository.GetAllAsync();
            if (listProduct == null)
                return null;
            var listProductDto = _mapper.Map< IReadOnlyList<ProductDto>>(listProduct);
            return listProductDto;
        }
    }
}
