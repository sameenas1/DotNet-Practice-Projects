
using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Draw()
        {
            Random rnd = new Random();
            int lotteryNumber = rnd.Next(100000, 999999); 

            ViewBag.LotteryNumber = lotteryNumber;
            return View();
        }
    }
}
