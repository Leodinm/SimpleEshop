using Application.Dto;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Commands.AddProduct
{
    public class AddProductCommand: IRequest<ProductDto>
    {
        public string name{ get; set; }
        public string description{ get; set; }
        public Decimal price{ get; set; }
        public string brand{ get; set; }
        public Decimal discountedprice { get; set; }
        public int stock{ get; set; }
        public EshopStatusStock eshopStatusStock { get; set; }

     



        // public string Name{ get; set; }

    }
}
