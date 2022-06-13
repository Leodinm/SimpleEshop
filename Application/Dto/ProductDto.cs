using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class ProductDto
    {
        public int Id { get;  set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public string Brand { get; private set; }
        public decimal DiscountedPrice { get; private set; }
        public int Stock { get; private set; }

        public EshopStatusStock EshopStatusStock { get; private set; }
    }
}
