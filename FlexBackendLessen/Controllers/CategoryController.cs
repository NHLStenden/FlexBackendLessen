using System.Collections.Generic;
using FlexBackendLessen.Models;
using FlexBackendLessen.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FlexBackendLessen.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return _categoryRepository.Get();
        }

    }
}
