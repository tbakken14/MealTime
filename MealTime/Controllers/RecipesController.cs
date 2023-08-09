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
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Recipe recipe)
        {
            _db.Recipes.Add(recipe);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var recipe = _db.Recipe.Find(id);
            return View(recipe);
        }

        [HttpPost]
        public IActionResult Edit(int id, Recipe recipe)
        {
            _db.Update(recipe);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            var recipe = _db.Recipe.Find(id);
            return View(recipe);
        }
        public IActionResult Delete(int? id)
        {
            var recipe = _db.Recipe.Find(id);
            return View(recipe);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var recipe = _context.Recipe.Find(id);
            _db.Engineers.Remove(recipe);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}