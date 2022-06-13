using Application.Dto;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Queries.Catalog
{
    public  class GetCatalogQuery: IRequest<PagedResponse<IReadOnlyList<Product>>>
    {
        public Application.PaginationFilter.PaginationFilter filter { get; set; }
        public string? brandName { get; set; }

        public Decimal? priceFrom { get; set; }

        public Decimal? priceTo { get; set; }
        [BindNever]
        public string route { get; set; }


    }
}
