using JBD.DATA.Enums;
using JBD.Service.Modules.Setting;
using Microsoft.AspNetCore.Mvc;

namespace JBD.WEB.Controllers;

public class SettingController : Controller
{
    private readonly ISettingService _settingService;

    public SettingController(ISettingService settingService)
    {
        _settingService = settingService;
    }

    // GET
    public IActionResult ProfitCalculation()
    {
        return View();
    }    
    
    public async Task<IActionResult> Exclusion()
    { 
        var result = await _settingService.GetExcludeKeywordsAsync(User.Identity?.Name);
        var keyWorks = result.Value;
        return View(keyWorks);
    }

    [HttpPost]
    public async Task<IActionResult> Exclusion(ExcludeKeywordType type, string keywords)
    {
        var keys = keywords.Split('\n').ToList();
        var result = await _settingService.UpdateExcludeKeywordsByTypeAsync(User.Identity?.Name,type, keys);


        return RedirectToAction("Exclusion");
    }
}