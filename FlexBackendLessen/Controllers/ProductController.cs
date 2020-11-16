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
        private readonly IProductRepository _productRepository;


        public ProductController(ILogger<ProductController> logger, IProductRepository productRepository )
        {
            _logger = logger;
            _productRepository = productRepository;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _productRepository.GetProductWithCategories();
        }

        [HttpPost]
        public IActionResult Post(Product product)
        {
            if (ModelState.IsValid)
            {
                _productRepository.Add(product);
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
