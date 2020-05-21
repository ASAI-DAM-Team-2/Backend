using System;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Web.Http;

namespace AllergyApp.Controllers
{
	[Authorize]
	public class DishController : CrudController<Dish>
	{
		public DishController() : base(EntityGetter, IdComparatorFactory, DataUpdater)
		{
		}

		private static DbSet<Dish> EntityGetter(AllergyAppDb context)
		{
			return context.Dishes;
		}

		private static void DataUpdater(Dish oldData, Dish newData)
		{
			oldData.name = newData.name;
			oldData.picture = newData.picture;
			oldData.title = newData.title;
			oldData.description = newData.description;
			oldData.restaurant_id = newData.restaurant_id;
		}

		private static Expression<Func<Dish, bool>> IdComparatorFactory(int id)
		{
			return (d) => d.dish_id== id;
		}

		///// <summary>
		///// Get all available dishes.
		///// </summary>
		///// <returns>Returns a list of all dishes in the system</returns>
		//public IEnumerable<Dish> Get()
		//{
		//	using (var entities = new AllergyAppDb())
		//	{
		//		return entities.Dishes.ToList();
		//	}
		//}

		///// <summary>
		///// Get details of the dish that matches the provided id.
		///// </summary>
		///// <param name="dishId"></param>
		///// <returns>Details of the matching dish</returns>
		//public IHttpActionResult Get(int id)
		//{
		//	Console.WriteLine("Get dish by id");
		//	using ( var entities = new AllergyAppDb()) 
		//	{
		//		try
		//		{
		//			return Ok(entities.Dishes.Where(d => d.dish_id == id).First());
		//		}
		//		catch ( InvalidOperationException e )
		//		{
		//			return BadRequest("No dish matches the provided Id");
		//		}
		//	}
		//}

		//public IHttpActionResult Post([FromBody]Dish dish)
		//{
		//	using (var entities = new AllergyAppDb())
		//	{
		//		var dishes = entities.Dishes;
		//		dish = dishes.Add(dish);
		//		entities.SaveChanges();
		//		return Ok(dish);
		//	}
		//}


		//// PUT api/dish/5
		//public IHttpActionResult Put(int id, [FromBody]Dish newData)
		//{
		//	using (var entities = new AllergyAppDb())
		//	{
		//		try
		//		{
		//			var oldData = entities.Dishes.First(d => d.dish_id == id);

		//			if ( oldData.dish_id != newData.dish_id)
		//			{
		//				return BadRequest("Cannot change dish id");
		//			}

		//			oldData.name = newData.name;
		//			oldData.picture = newData.picture;
		//			oldData.title = newData.title;
		//			oldData.description = newData.description;
		//			oldData.restaurant_id = newData.restaurant_id;
		//			entities.SaveChanges();
		//			return Ok(newData);
		//		}
		//		catch (InvalidOperationException e)
		//		{
		//			return BadRequest("No dish matches the provided Id");
		//		};
		//	}
		//}

		//// DELETE api/dish/5
		//public IHttpActionResult Delete(int id)
		//{
		//	using (var entities = new AllergyAppDb())
		//	{
		//		try
		//		{
		//			entities.Dishes.Remove(entities.Dishes.Where(d => d.dish_id == id).First());
		//			entities.SaveChanges();
		//			return Ok();
		//		}
		//		catch (InvalidOperationException e)
		//		{
		//			return BadRequest("No dish matches the provided Id");
		//		}
		//	}
		//}
	}

}