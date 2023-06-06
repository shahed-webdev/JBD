using JBD.DATA.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using JBD.ViewModel.Modules.Auth;

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