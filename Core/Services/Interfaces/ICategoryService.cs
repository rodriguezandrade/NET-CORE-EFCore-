using Core.Models;
using System.Collections.Generic;

namespace Core.Services.Interfaces
{
    public interface ICategoryService
    {
        List<Category> Get();
    }
}
