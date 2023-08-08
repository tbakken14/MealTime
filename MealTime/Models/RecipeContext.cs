using Microsoft.EntityFrameworkCore;

namespace MealTime.Models
{
    public class RecipeContext : DbContext
    {
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public RecipeContext(DbContextOptions options) : base(options) { }
    }
}