using Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FoodPark.Controllers
{
    [Route("api/stores/")]
    public class StoreController : Controller
    {
        private readonly ModelContext _context;

        public StoreController(ModelContext context)
        {
            _context = context;
        }


        [Route("get")]
        public IEnumerable<Store> Get()
        {
            IEnumerable<Store> stores = new List<Store>() {
                 new Store()
                 {
                     FullName= "test"
                 }
            };

            return stores;
        }

    }
}