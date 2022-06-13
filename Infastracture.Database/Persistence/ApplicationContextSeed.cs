using Bogus;
using Domain.Entities;
using Domain.Enums;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infastracture.Database.Persistence
{
    public class ApplicationContextSeed
    {
        public static async Task SeedAsync(ApplicationContext orderContext, ILogger<ApplicationContextSeed> logger)
        {
            if (!orderContext.Product.Any())
            {
                orderContext.Product.AddRange(GetPreconfiguredProducts());
                await orderContext.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {DbContextName}", typeof(ApplicationContextSeed).Name);
            }
        }

        private static IEnumerable<Product> GetPreconfiguredProducts()
        {
            var brands = new[] { "Apple", "Samsung ", "Gucci", "Prada", "Addidas" };
            var faker = new Faker<Product>()
                            .RuleFor(p => p.Name, f => f.Commerce.ProductName())
                            .RuleFor(p => p.Description, f => f.Commerce.ProductDescription())
                            .RuleFor(p => p.Price, f => f.Finance.Amount(1, 150))
                            .RuleFor(p => p.Brand, f => f.PickRandom(brands).ToUpper())
                            .RuleFor(p => p.DiscountedPrice, (f, p) => f.Random.Decimal(0.8m, 1m) * p.Price)
                            .RuleFor(p => p.Stock, f => f.Random.Number(0, 8))
                            .RuleFor(p => p.EshopStatusStock, f => f.PickRandom<EshopStatusStock>());

            var products = faker.Generate(100);



                //.CustomInstantiator(f => new Product(f.Commerce.ProductName()
                //                                    , f.Commerce.ProductDescription()
                //                                    , f.Finance.Amount(1, 150)
                //                                    , f.PickRandom(brands).ToUpper()
                //                                    , f.Random.Number(0, 5)
                //                                    , f.PickRandom<EshopStatusStock>()
                //                                    , f.Random.Decimal(0.0m,0.3m)
                //                                    ))
                //                                       .Generate(100);


            return products;






        }
    }
}
