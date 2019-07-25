using Core.Models;
using System.Collections.Generic;

namespace Core.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        List<Category> Get();
        Category Save(Category category);
    }
}
