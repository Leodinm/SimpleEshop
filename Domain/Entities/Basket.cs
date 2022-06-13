using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Basket
    {
        public string sessionId { get; set; } = new Guid().ToString();
        public List<BasketItem> BasketItems { get; set; }
    }


}
