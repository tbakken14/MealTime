using Microsoft.AspNetCore.Mvc;
using MealTime.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace MealTime.Controllers
{
    public class HomeController : Controller
    {
        private readonly MealTimeContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(UserManager<ApplicationUser> userManager, MealTimeContext db)
        {
            _userManager = userManager;
            _db = db;
        }
        [HttpGet("/")]
        public async Task<ActionResult> Index()
        {
            Ingredient[] ingredients = _db.Ingredients.ToArray();
            Dictionary<string, object[]> model = new Dictionary<string, object[]>();
            model.Add("ingredients", ingredients);
            string userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            ApplicationUser currentUser = await _userManager.FindByIdAsync(userId);
            if (currentUser != null)
            {
                Recipe[] recipes = _db.Recipes
                            .Where(entry => entry.User.Id == currentUser.Id)
                            .ToArray();
                model.Add("recipes", recipes);
            }
            return View(model);
        }
    }
}