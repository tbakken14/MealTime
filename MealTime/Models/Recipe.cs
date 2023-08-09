using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace MealTime.Models
{
    public class Recipe
    {
        public int RecipeId { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string Name { get; set; }
        public int CookTime { get; set; }
        public List<RecipeIngredient> RecipeIngredients { get; }
    }
}