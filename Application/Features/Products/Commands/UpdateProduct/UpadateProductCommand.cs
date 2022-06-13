using Domain.Enums;
using MediatR;
namespace Application.Features.Products.Commands.UpdateProduct
{
    public class UpadateProductCommand: IRequest
    {
        public int id { get; set; }
        public string Name { get;  set; }
       
        public string Description { get;  set; } 

        public decimal Price { get;  set; }
 
        public string Brand { get;  set; }
        public decimal DiscountedPrice { get;  set; }
        public int Stock { get;  set; }

        public EshopStatusStock EshopStatusStock { get;  set; }
    }
}
  

