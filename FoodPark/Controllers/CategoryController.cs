using Core.Models;
using Core.Models.Dtos;
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace FoodPark.Controllers
{
    [Route("api/categories/")]
    public class CategoryController : Controller
    {
        private readonly IImageResourceService _imageResourceService;
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService, IImageResourceService imageResourceService)
        {
            _categoryService = categoryService;
            _imageResourceService = imageResourceService;
        }

        [Route("get")]
        public List<Category> Get()
        {
            List<Category> categories = _categoryService.Get();

            return categories;
        }

        [HttpPost]
        [Route("")]
        public void Save([FromForm] CategoryDto model)
        {
            IFormCollection httpRequest = HttpContext.Request.Form;
            string jeje = Convert.ToString(httpRequest["name"]);

            object value = string.Empty;
            foreach (string key in HttpContext.Request.Form.Keys)
            {
                value = HttpContext.Request.Form[key];
            }
 


            CategoryDto category = new CategoryDto
            {
                Name = ""
            };

            if (httpRequest.Files.Count > 0)
            {
                IFormFile postedFile = httpRequest.Files[0];

                //if (_imageResourceService.canSaveImage(postedFile, out urlImage))
                //{
                //    announcement.BinaryImage = urlImage;
                //}
            }

            _categoryService.Save(category);

        }
    }
}