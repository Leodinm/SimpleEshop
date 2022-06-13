using Application.Dto;
using Application.Features.Products.Commands.AddProduct;
using Application.Features.Products.Commands.UpdateProduct;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AddProductCommand, Product>();
            CreateMap<Product, ProductDto>();
            CreateMap<UpadateProductCommand, Product>();


        }
    }
}
