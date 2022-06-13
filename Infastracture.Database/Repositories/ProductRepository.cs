using Application.Persistence;
using Domain.Entities;
using Infastracture.Database.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infastracture.Database.Repositories
{

    public class ProductRepository : RepositoryBase<Product>, IProductsRepository
    {
        public ProductRepository(ApplicationContext dbContext) : base(dbContext)
        {
        }

    }
}
