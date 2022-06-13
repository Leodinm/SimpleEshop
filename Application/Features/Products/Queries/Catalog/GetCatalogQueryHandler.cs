using Application.Dto;
using Application.Helpers;
using Application.Persistence;
using Application.Services;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Products.Queries.Catalog
{
 
    public class GetCatalogQueryHandler : IRequestHandler<GetCatalogQuery, PagedResponse<IReadOnlyList<Product>>>
    {

        private readonly IProductsRepository _productsRepository;
        private readonly IMapper _mapper;
        private readonly IUriService _uriservice;

        public GetCatalogQueryHandler(IProductsRepository productsRepository, IMapper mapper, IUriService uriservice)
        {
            _productsRepository = productsRepository;
            _mapper = mapper;
            _uriservice = uriservice;
        }

        //public GetCatalogQueryHandler(IProductsRepository productsRepository, IMapper mapper)
        //{
        //    _productsRepository = productsRepository ?? throw new ArgumentNullException(nameof(productsRepository));
        //    _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

        //}


        public async Task<PagedResponse<IReadOnlyList<Product>>> Handle(GetCatalogQuery request, CancellationToken cancellationToken)
        {



            var pagginationProducts = await _productsRepository.GetPagedReponseAsync(request.filter.PageNumber, request.filter.PageSize,
                 filter => (request.brandName != null) ? filter.Brand == request.brandName.ToUpper() : true
                       && (request.priceTo != null&& request.priceFrom != null) ?(filter.Price >= request.priceFrom) && (filter.Price <= request.priceTo) : true);

            var numberOfProducts = await _productsRepository.CountAsync(filter => (request.brandName != null) ? filter.Brand == request.brandName.ToUpper() : true
                                                          && (request.priceTo != null && request.priceFrom != null) ? (filter.Price >= request.priceFrom)
                                                          && (filter.Price <= request.priceTo) : true);

            var pagedReponse = PaginationHelper.CreatePagedReponse<Product>(pagginationProducts, request.filter, numberOfProducts, _uriservice, request.route);




            return pagedReponse;
        }
    }
}
