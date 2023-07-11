using Microsoft.AspNetCore.Mvc;

namespace JBD.WEB.Controllers;

public class SettingController : Controller
{
    // GET
    public IActionResult ProfitCalculation()
    {
        return View();
    }    
    
    public IActionResult Exclusion()
    {
        return View();
    }
}