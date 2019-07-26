using Core.Models;
using Core.Models.Dtos;
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
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

        [HttpPost]
        [Route("upload")]
        public IActionResult Upload()
        {
            try
            {
                var files = Request.Form.Files;
                var folderName = Path.Combine("StaticFiles", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
  
                if (!Directory.Exists(pathToSave))
                {
                    Directory.CreateDirectory(pathToSave);
                }

                if (files.Any(f => f.Length == 0))
                {
                    return BadRequest();
                }

                foreach (var file in files)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName); //you can add this path to a list and then return all dbPaths to the client if require

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }

                return Ok("All the files are successfully uploaded.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}