using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace MealTime.Models
{
    public class Recipe
    {
        public int RecipeId { get; set; }
        [Display(Name = "Name", Prompt = "Enter Name", Description = "Recipe Name")]
        [Column(TypeName = "varchar(255)")]
        [Required(ErrorMessage = "The item's description can't be empty!")]
        public string Name { get; set; }
        [Display(Name = "Cook Time", Prompt = "Enter Cook Time", Description = "Recipe Cook Time")]
        [Range(1, int.MaxValue, ErrorMessage = "Cook Time must be positive")]
        public int CookTime { get; set; }
        public List<RecipeIngredient> RecipeIngredients { get; }
        public ApplicationUser User { get; set; }
    }
}