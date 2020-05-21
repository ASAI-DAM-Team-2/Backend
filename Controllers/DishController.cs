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
			oldData.price = newData.price;
		}

		private static Expression<Func<Dish, bool>> IdComparatorFactory(int id)
		{
			return (d) => d.dish_id== id;
		}
	}

}