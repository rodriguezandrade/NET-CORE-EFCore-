using Core.Models;
using Core.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Core.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        protected ModelContext ModelContext { get; set; }
        public CategoryRepository(ModelContext modelContext)
        {
            ModelContext = modelContext;
        }

        public List<Category> Get()
        {
            return ModelContext.Set<Category>().ToList();
        }
    }
}
