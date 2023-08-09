using Microsoft.EntityFrameworkCore;

namespace MealTime.Models
{
    public class MealTimeContext : DbContext
    {
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public MealTimeContext(DbContextOptions options) : base(options) { }
    }
}