using System.ComponentModel.DataAnnotations.Schema;

namespace MealTime.Models
{
    public class Recipe
    {
        public int RecipeId { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string Name { get; set; }
        public int CookTime { get; set; }
    }
}