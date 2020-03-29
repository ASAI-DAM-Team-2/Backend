using Microsoft.EntityFrameworkCore;


namespace Allergen.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public DbSet<Items> AllItems { get; set; }
    }
}
