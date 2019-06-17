using Core.Models;
using Core.Models.Dtos;
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Http;
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

        [HttpPost]
        [Route("")]
        public void Save([FromForm] CategoryDto model)
        {
            IFormCollection httpRequest = HttpContext.Request.Form;
            string name = HttpContext.Request.Form.Keys.ToString();

            CategoryDto category = new CategoryDto
            {
                Name = name
            };

            //if (httpRequest.Files.Count > 0)
            //{
            //    var postedFile = httpRequest.Files[0];
            //    byte[] urlImage;
            //    if (_announcementService.ConvertImage(postedFile, out urlImage))
            //    {
            //        announcement.BinaryImage = urlImage;
            //    }
            //}

            //_announcementService.SaveAnnouncement(announcement, splittedUsername);

        }
    }
}