using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Http;

namespace AllergyApp.Controllers
{
    [Authorize]
    public class RestaurantController : CrudController<Restaurant>
    {
        public RestaurantController() : base(EntityGetter, IdComparatorFactory, DataUpdater)
        {
        }

        private static DbSet<Restaurant> EntityGetter(AllergyAppDb context)
        {
            return context.Restaurants;
        }

        private static void DataUpdater(Restaurant oldData, Restaurant newData)
        {
            oldData.name = newData.name;
            oldData.adress = newData.adress;
            oldData.company_id = newData.company_id;
            oldData.plan_id = newData.plan_id;
        }

        private static Expression<Func<Restaurant, bool>> IdComparatorFactory(int id)
        {
            return (r) => r.restaurant_id == id;
        }

        [Route("api/Restaurant/{restaurantId:int}/Dish")]
        [HttpGet]
        public IHttpActionResult GetRestaurantDishes(int restaurantId)
        {
            using (var entities = new AllergyAppDb())
            {
                if (entities.Restaurants.Where(r => r.restaurant_id == restaurantId).Count() == 0)
                {
                    return BadRequest("No restaurant matches the provided Id");
                }

                return Ok(entities.Dishes.Where(d => d.restaurant_id == restaurantId).ToList());
            }
        }

    }
}
