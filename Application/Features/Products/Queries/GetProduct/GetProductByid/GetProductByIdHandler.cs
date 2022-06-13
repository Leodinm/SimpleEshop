using Application.Dto;
using Application.Persistence;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Products.Queries.GetProduct.GetProductByid
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ProductDto>
    {

        private readonly IProductsRepository _productsRepository;
        private readonly IMapper _mapper;
       

        public GetProductByIdHandler(IProductsRepository productsRepository, IMapper mapper)
        {
            _productsRepository = productsRepository ?? throw new ArgumentNullException(nameof(productsRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
           
        }

        public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var findproduct = await _productsRepository.GetByIdAsync(request.Id);
             if(findproduct==null)
                return null;
            var productdto = _mapper.Map<ProductDto>(findproduct);
            return productdto;
        }
    }
}
