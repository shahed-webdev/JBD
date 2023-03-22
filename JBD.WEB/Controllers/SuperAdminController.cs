using Microsoft.AspNetCore.Mvc;

namespace JBD.WEB.Controllers
{
    public class SuperAdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
