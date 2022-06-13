using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class BasketItem
    {
        public int Quantity { get; private set; }
        public string Name { get; set; }
        public string ProductName { get; set; }
        public int Stock { get; set; }
        public EshopStatusStock EshopStatusStock { get; private set; }


    }


}
