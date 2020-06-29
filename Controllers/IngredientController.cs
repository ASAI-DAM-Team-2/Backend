using System;
using System.Data.Entity;
using System.Linq.Expressions;

namespace AllergyApp.Controllers
{
    public class IngredientController : CrudController<Ingredient>
    {
        public IngredientController() : base(EntityGetter, IdComparatorFactory, DataUpdater)
        {
        }

        private static DbSet<Ingredient> EntityGetter(AllergyAppDb context)
        {
            return context.Ingredients;
        }

        private static void DataUpdater(Ingredient oldData, Ingredient newData)
        {
            oldData.name = newData.name;
            oldData.picture = newData.picture;
        }

        private static Expression<Func<Ingredient, bool>> IdComparatorFactory(int id)
        {
            return (a) => a.ingredient_id == id;
        }
    }
}
