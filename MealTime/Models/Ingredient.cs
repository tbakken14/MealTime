using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace MealTime.Models
{
    public class Ingredient
    {
        public int IngredientId { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string Name { get; set; }
        public List<RecipeIngredient> RecipeIngredients { get; }
    }
}