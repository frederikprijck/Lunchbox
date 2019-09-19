using Lunchbox.Models;
using Microsoft.EntityFrameworkCore;

namespace Lunchbox
{
    public class LunchboxContext : DbContext
    {
        public LunchboxContext(DbContextOptions<LunchboxContext> options) : base(options)
        {
        }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeStep> RecipeSteps { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Measurement> Measurements { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }

    }
}
