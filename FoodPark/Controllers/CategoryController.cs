using Core.Models;
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FoodPark.Controllers
{
    [Route("api/categories/")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [Route("get")]
        public List<Category> Get()
        {
            List<Category> categories = _categoryService.Get();

            return categories;
        }
    }
}