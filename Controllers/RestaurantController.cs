using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace AllergyApp.Controllers
{
    [Authorize]
    public class RestaurantController : ApiController
    {
        // GET api/restaurant
        public IEnumerable<Restaurant> Get()
        {
            using (AllergyAppDbEntities entities = new AllergyAppDbEntities())
            {
                return entities.Restaurants.ToList();
            }
        }

        // GET api/restaurant/5
        public IHttpActionResult Get(int id)
        {
            using ( AllergyAppDbEntities entities = new AllergyAppDbEntities())
            {
                var matchingRestaurants = entities.Restaurants.Where(r => r.restaurant_id == id);
                if (matchingRestaurants.Count() == 1)
                {
                    return Ok(matchingRestaurants.First());
                } else
                {
                    return BadRequest("Invalid restaurant Id");
                }
            }
        }

        [Route("api/restaurant/{restaurantId:int}/dish")]
        [HttpGet]
        public IHttpActionResult GetRestaurantDishes(int restaurantId)
        {
            using (AllergyAppDbEntities entities = new AllergyAppDbEntities())
            { 
                if ( entities.Restaurants.Where(r => r.restaurant_id == restaurantId).Count() == 0)
                {
                    return BadRequest("Invalid restaurant Id");
                }
                
                return Ok(entities.Dishes.Where(d => d.Restaurantrestaurant_id == restaurantId).ToList());
            }
        }

        // POST api/restaurant
        public IHttpActionResult Post([FromBody]Restaurant restaurant)
        {
            using ( var entities = new AllergyAppDbEntities())
            {
                var restaurants = entities.Restaurants;
                if ( restaurants.Where(r => r.restaurant_id == restaurant.restaurant_id).Count() != 0)
                {
                    return BadRequest("Restaurant with provided Id already exists");
                }
                restaurants.Add(restaurant);
                entities.SaveChanges();
                return Ok();
            }
        }

        // PUT api/restaurant/5
        public IHttpActionResult Put(Restaurant newData)
        {
            using ( var entities = new AllergyAppDbEntities())
            {
                try
                {
                    var oldData = entities.Restaurants.First(r => r.restaurant_id == newData.restaurant_id);
                    oldData.name = newData.name;
                    oldData.adress = newData.adress;
                    oldData.company_id = newData.company_id;
                    oldData.plan_id = newData.plan_id;
                    entities.SaveChanges();
                    return Ok();
                } catch (InvalidOperationException e) {
                    return BadRequest("No restaurant with provided Id");
                };
            }
        }

        // DELETE api/restaurant/5
        public IHttpActionResult Delete(int id)
        {
            using (var entities = new AllergyAppDbEntities())
            {
                try
                {
                    entities.Restaurants.Remove(entities.Restaurants.First(r => r.restaurant_id == id));
                    return Ok();
                }
                catch (InvalidOperationException e)
                {
                    return BadRequest("No restaurant with provided Id");
                }
            }
        }
    }
}
