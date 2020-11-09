using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlexBackendLessen.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FlexBackendLessen.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public partial class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly WebshopContext _db;

        public ProductController(ILogger<ProductController> logger, WebshopContext db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _db.Products.Include(x => x.Category);
        }

        [HttpPost]
        public IActionResult Post(Product product)
        {
            if (ModelState.IsValid)
            {
                _db.Products.Add(product);
                _db.SaveChanges();
                return Created($"Detail?productId=" +product.ProductId, product);
            }

            return UnprocessableEntity(ModelState);
            // int newProductId = Products.Max(x => x.ProductId) + 1;
            // Products.Add(product);
            // return newProductId;
        }

        //HttpPut HttpPatch

        //HttpDelete
    }
}
