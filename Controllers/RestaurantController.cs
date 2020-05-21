using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace AllergyApp.Controllers
{
    [Authorize]
    public class RestaurantController : CrudController<Restaurant>
    {
        // GET api/restaurant
        public IEnumerable<Restaurant> Get()
        {
            using (var entities = new AllergyAppDb())
            {
                return entities.Restaurants.ToList();
            }
        }

        // GET api/restaurant/5
        public IHttpActionResult Get(int id)
        {
            using (var entities = new AllergyAppDb())
            {
                var matchingRestaurants = entities.Restaurants.Where(r => r.restaurant_id == id);
                if (matchingRestaurants.Count() == 1)
                {
                    return Ok(matchingRestaurants.First());
                } else
                {
                    return BadRequest("No restaurant matches the provided Id");
                }
            }
        }

        [Route("api/Restaurant/{restaurantId:int}/Dish")]
        [HttpGet]
        public IHttpActionResult GetRestaurantDishes(int restaurantId)
        {
            using (var entities = new AllergyAppDb())
            { 
                if ( entities.Restaurants.Where(r => r.restaurant_id == restaurantId).Count() == 0)
                {
                    return BadRequest("No restaurant matches the provided Id");
                }
                
                return Ok(entities.Dishes.Where(d => d.restaurant_id == restaurantId).ToList());
            }
        }

        // POST api/restaurant
        public IHttpActionResult Post([FromBody]Restaurant restaurant)
        {
            using ( var entities = new AllergyAppDb())
            {
                var restaurants = entities.Restaurants;
                restaurant = restaurants.Add(restaurant);
                entities.SaveChanges();
                return Ok(restaurant);
            }
        }

        // PUT api/restaurant/5
        public IHttpActionResult Put(int id, [FromBody]Restaurant newData)
        {
            using ( var entities = new AllergyAppDb())
            {
                try
                {
                    var oldData = entities.Restaurants.First(r => r.restaurant_id == id);
                    oldData.name = newData.name;
                    oldData.adress = newData.adress;
                    oldData.company_id = newData.company_id;
                    oldData.plan_id = newData.plan_id;
                    entities.SaveChanges();
                    return Ok(newData);
                } catch (InvalidOperationException e) {
                    return BadRequest("No restaurant matches the provided Id");
                };
            }
        }

        // DELETE api/restaurant/5
        public IHttpActionResult Delete(int id)
        {
            using (var entities = new AllergyAppDb())
            {
                try
                {
                    entities.Restaurants.Remove(entities.Restaurants.First(r => r.restaurant_id == id));
                    entities.Dishes.RemoveRange(entities.Dishes.Where(d => d.restaurant_id == id));
                    entities.SaveChanges();
                    return Ok();
                }
                catch (InvalidOperationException e)
                {
                    return BadRequest("No restaurant matches the provided Id");
                }
            }
        }
    }
}
