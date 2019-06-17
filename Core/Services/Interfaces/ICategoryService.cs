using Core.Models;
using Core.Models.Dtos;
using System.Collections.Generic;

namespace Core.Services.Interfaces
{
    public interface ICategoryService
    {
        List<Category> Get();
        Category Save(CategoryDto category);
    }
}
