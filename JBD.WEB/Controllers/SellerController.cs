using Microsoft.AspNetCore.Mvc;

namespace JBD.WEB.Controllers
{
    public class SellerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
