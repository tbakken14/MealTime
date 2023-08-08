using Microsoft.AspNetCore.Mvc;
using MealTime.Models;

namespace MealTime.Controllers
{
    public class IngredientsController : Controller
    {
        private readonly RecipeContext _db;

        public IngredientsController(RecipeContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}