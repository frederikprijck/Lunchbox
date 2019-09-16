using System;
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
    }
}
