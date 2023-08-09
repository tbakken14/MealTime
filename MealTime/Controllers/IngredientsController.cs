using Microsoft.AspNetCore.Mvc;
using MealTime.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MealTime.Controllers
{
    public class IngredientsController : Controller
    {
        private readonly MealTimeContext _db;

        public IngredientsController(MealTimeContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            return View(_db.Ingredients.ToList());
        }

        public ActionResult New()
        {
            return View(nameof(Create));
        }

        public ActionResult Create(Ingredient ingredient)
        {
            _db.Ingredients.Add(ingredient);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Details(int id)
        {
            Ingredient ingredient = _db.Ingredients
                .Include(model => model.RecipeIngredients)
                .ThenInclude(join => join.Recipe)
                .FirstOrDefault(model => model.IngredientId == id);
            return View(ingredient);
        }

        public ActionResult Edit(int id)
        {
            Ingredient ingredient = _db.Ingredients
                .FirstOrDefault(model => model.IngredientId == id);
            return View(nameof(Update), ingredient);
        }

        public ActionResult Update(Ingredient ingredient)
        {
            _db.Update(ingredient);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Delete(int id)
        {
            Ingredient ingredient = _db.Ingredients
                .FirstOrDefault(model => model.IngredientId == id);
            return View(ingredient);
        }

        public ActionResult Destroy(Ingredient ingredient)
        {
            _db.Remove(ingredient);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}