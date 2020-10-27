using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FlexBackendLessen.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<ProductController> _logger;

        private static List<Product> Products { get; set; } = new List<Product>()
        {
            new Product() { ProductId = 1, Description = "Product 1"},
            new Product() { ProductId = 2, Description = "Product 2"}
        };

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return Products;
        }

        [HttpPost]
        public int Post(Product product)
        {
            int newProductId = Products.Max(x => x.ProductId) + 1;
            Products.Add(product);
            return newProductId;
        }

        //HttpPut HttpPatch

        //HttpDelete

        public class Product
        {
            [Key]
            public int ProductId { get; set; }

            [Required, MinLength(3)]
            public string Description { get; set; }
        }
    }
}
