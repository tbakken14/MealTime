using Microsoft.AspNetCore.Mvc;
using MealTime.Models;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace MealTime.Controllers
{
    [Authorize]
    public class RecipesController : Controller
    {
        private readonly MealTimeContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public RecipesController(UserManager<ApplicationUser> userManager, MealTimeContext db)
        {
            _userManager = userManager;
            _db = db;
        }
        public async Task<ActionResult> Index()
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            ApplicationUser currentUser = await _userManager.FindByIdAsync(userId);
            List<Recipe> userRecipes = _db.Recipes
                                .Where(entry => entry.User.Id == currentUser.Id)
                                .ToList();
            return View(userRecipes);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Recipe recipe)
        {
            if (!ModelState.IsValid)
            {
                //Add error
                return View();
            }
            else
            {
                string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                ApplicationUser currentUser = await _userManager.FindByIdAsync(userId);
                recipe.User = currentUser;
                _db.Recipes.Add(recipe);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public IActionResult Edit(int id)
        {
            var recipe = _db.Recipes.Find(id);
            return View("Update", recipe);
        }

        [HttpPost]
        public IActionResult Update(Recipe recipe)
        {
            _db.Update(recipe);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            var recipe = _db.Recipes
                .Include(model => model.RecipeIngredients.OrderBy(m => m.Ingredient.Name))
                .ThenInclude(join => join.Ingredient)
                .FirstOrDefault(model => model.RecipeId == id);
            return View(recipe);
        }
        public IActionResult Delete(int id)
        {
            var recipe = _db.Recipes.Find(id);
            return View(recipe);
        }

        public IActionResult Destroy(Recipe recipe)
        {
            _db.Recipes.Remove(recipe);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public ActionResult AddIngredient(int id)
        {
            Recipe recipe = _db.Recipes
                .FirstOrDefault(model => model.RecipeId == id);
            ViewBag.IngredientId = new SelectList(_db.Ingredients, "IngredientId", "Name");
            return View(recipe);
        }

        [HttpPost]
        public ActionResult AddIngredient(Recipe recipe, int ingredientId)
        {
#nullable enable
            RecipeIngredient? recipeIngredient = _db.RecipeIngredients
                .FirstOrDefault(model => (model.IngredientId == ingredientId && model.RecipeId == recipe.RecipeId));
#nullable disable
            if (recipeIngredient == null && ingredientId != 0)
            {
                _db.RecipeIngredients.Add(new RecipeIngredient() { IngredientId = ingredientId, RecipeId = recipe.RecipeId });
                _db.SaveChanges();
            }
            return RedirectToAction("Details", new { id = recipe.RecipeId });
        }
    }
}