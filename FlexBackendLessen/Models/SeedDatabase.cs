using System;
using Bogus;

namespace FlexBackendLessen.Models
{
    public class SeedDatabase
    {
        public static void Seed(WebshopContext db)
        {
            Randomizer.Seed = new Random(321321);

            var catogryFaker = new Faker<Category>()
                .RuleFor(x => x.Name, faker => faker.Commerce.Categories(1)[0]);

            var categories = catogryFaker.Generate(10);

            var productFaker = new Faker<Product>()
                //.StrictMode(true)
                .RuleFor(x => x.Name, faker => faker.Commerce.ProductName())
                .RuleFor(x => x.Category, faker => faker.PickRandom(categories))
                .RuleFor(x => x.Price, faker => faker.Random.Decimal(1, 100));


            var products = productFaker.Generate(100);

            db.Products.AddRange(products);

            db.SaveChanges();
        }
    }
}
