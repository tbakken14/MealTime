using Microsoft.AspNetCore.Mvc;

namespace MealTime.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}