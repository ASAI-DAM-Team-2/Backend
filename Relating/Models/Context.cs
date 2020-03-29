using Microsoft.EntityFrameworkCore;


namespace Relating.Models
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
