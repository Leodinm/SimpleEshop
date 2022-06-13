using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public sealed class ProductNotFound : NotFoundException
    {
        public ProductNotFound(int productId)
            : base($"Product with the identifier {productId} was not found.")
        {
        }
    }
}
