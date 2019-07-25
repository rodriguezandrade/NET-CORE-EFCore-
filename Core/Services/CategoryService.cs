using Core.Models;
using Core.Models.Dtos;
using Core.Repositories.Interfaces;
using Core.Services.Interfaces;
using System.Collections.Generic;

namespace Core.Repositories
{
    public class CategoryService : ICategoryService
    {
        public readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public List<Category> Get()
        {
            var categories =  _categoryRepository.Get();

            return categories;
        }

        public Category Save (CategoryDto category)
        {
            var data = new Category
            {
                Name = category.Name
            };

            return  _categoryRepository.Save(data);
        }
    }
}
