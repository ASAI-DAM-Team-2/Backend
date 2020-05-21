using System;
using System.Data.Entity;
using System.Linq.Expressions;

namespace AllergyApp.Controllers
{
    public class AllergenController : CrudController<Allergen>
    {
        public AllergenController() : base(EntityGetter, IdComparatorFactory, DataUpdater)
        {
        }

        private static DbSet<Allergen> EntityGetter(AllergyAppDb context)
        {
            return context.Allergens;
        }

        private static void DataUpdater(Allergen oldData, Allergen newData)
        {
            oldData.name = newData.name;
            oldData.picture = newData.picture;
        }

        private static Expression<Func<Allergen, bool>> IdComparatorFactory(int id)
        {
            return (a) => a.allergen_id == id;
        }
    }
}
