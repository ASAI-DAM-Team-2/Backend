namespace AllergyApp
{
	using System;
	using System.Data.Entity;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Linq;

	public partial class AllergyAppDb : DbContext
	{
		public AllergyAppDb()
			: base("name=AllergyAppServer")
		{
		}

		public virtual DbSet<Allergen> Allergens { get; set; }
		public virtual DbSet<Dish> Dishes { get; set; }
		public virtual DbSet<Ingredient> Ingredients { get; set; }
		public virtual DbSet<Restaurant> Restaurants { get; set; }
		public virtual DbSet<Allergen_Dish> Allergen_Dish { get; set; }
		public virtual DbSet<Ingredient_Dish> Ingredient_Dish { get; set; }
		public virtual DbSet<database_firewall_rules> database_firewall_rules { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<database_firewall_rules>()
				.Property(e => e.start_ip_address)
				.IsUnicode(false);

			modelBuilder.Entity<database_firewall_rules>()
				.Property(e => e.end_ip_address)
				.IsUnicode(false);
		}
	}
}
