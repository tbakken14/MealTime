using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace MealTime.Models
{
    public class RecipeIngredient
    {
        public int RecipeIngredientId { get; set; }
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }
        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }
    }
}