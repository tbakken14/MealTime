using Microsoft.AspNetCore.Mvc;
using MealTime.Models;
using System.Linq;

namespace MealTime.Controllers
{
    public class RecipesController : Controller
    {
        private readonly RecipeContext _db;

        public RecipesController(RecipeContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var recipes = _db.Recipes.ToList();
            return View(recipes);
        }
        /**
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Recipe recipe)
        {
            //_context
            return RedirectToAction(nameof(Index));
        }
        **/
    }
}