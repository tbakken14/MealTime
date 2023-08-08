using System.ComponentModel.DataAnnotations.Schema;

namespace MealTime.Models
{
    public class Ingredient
    {
        public int IngredientId { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string Name { get; set; }

    }
}