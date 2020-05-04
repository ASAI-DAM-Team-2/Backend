using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace AllergyApp.Controllers
{
	[Authorize]
	public class DishController : ApiController
	{

		public IEnumerable<Dish> Get()
		{
			using (var entities = new AllergyAppDbEntities())
			{
				return entities.Dishes.ToList();
			}
		}

		public IEnumerable<Dish> Get(int dishId)
		{
			using ( var entities = new AllergyAppDbEntities()) 
			{
				return entities.Dishes.Where(d => d.dish_id == dishId).ToList();
			}
		}


	}
}