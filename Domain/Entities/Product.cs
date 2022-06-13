using Domain.Common;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Microsoft.EntityFrameworkCore.Index(nameof(Price))]
    public class Product : EntityBase
    {
        [StringLength(50)]
        public string  Name { get; private set; }
        [StringLength(300)]
        public string Description { get; private set; }
        
        public decimal Price { get; private set; }
        [StringLength(50)]
        public string? Brand { get; private set; }
        public decimal? DiscountedPrice { get; private set; }
        public int Stock { get; private set; }

        public EshopStatusStock EshopStatusStock { get; private set; }
    }
}

//empty constructor for dbset ef core
//public Product() 
//{ }

//public Product(string Name,string Description,decimal Price,string Brand ,int Stock, EshopStatusStock EshopStatusStock,decimal coupon=0m)
//{
//    this.Name = Name;
//    this.Description = Description;
//    this.Price = Price;
//    this.Brand = Brand; 
//    this.Stock = Stock;
//    this.EshopStatusStock = EshopStatusStock;
//    Discounte(coupon);




// }


//private void Discounte(decimal coupon)
//{

//    DiscountedPrice = Price - Price * coupon;

//}


