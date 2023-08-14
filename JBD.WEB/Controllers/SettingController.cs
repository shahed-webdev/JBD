using JBD.DATA.Enums;
using JBD.Service.Modules.Setting;
using JBD.ViewModel;
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

        TempData["ActiveTab"] = type.ToString();

        return RedirectToAction("Exclusion");
    }


    public async Task<IActionResult> GetProfitRatioList()
    {
        var result = await _settingService.GetSettingProfitRatioListAsync(User.Identity?.Name);
       
        if (result.IsFailed)
            return StatusCode(StatusCodes.Status500InternalServerError, result.Errors.First().Message);

        return Json(result.Value);
    }

    //POST: from ajax
    [HttpPost]
    public async Task<IActionResult> ProfitRatioAdd([FromBody] SettingProfitRatioVM model)
    {
        if (model == null) return StatusCode(StatusCodes.Status400BadRequest, new { Message = "Invalid data" });

        var addResult = await _settingService.AddSettingProfitRatioAsync(User.Identity?.Name, model);

        if (addResult.IsSuccess) return StatusCode(StatusCodes.Status201Created);

        return StatusCode(StatusCodes.Status400BadRequest, addResult.Errors[0]);
    }

    //POST: from ajax
    [HttpPost]
    public async Task<IActionResult> UpdateSettingProfitRatio([FromBody] SettingProfitRatioVM model)
    {
        if (model == null) return StatusCode(StatusCodes.Status400BadRequest, new { Message = "Invalid data" });

        var addResult = await _settingService.UpdateSettingProfitRatioAsync(User.Identity?.Name, model);

        if (addResult.IsSuccess) return StatusCode(StatusCodes.Status202Accepted);

        return StatusCode(StatusCodes.Status400BadRequest, addResult.Errors[0]);
    }

    

    [HttpPost]
    public async Task<IActionResult> DeleteProfitRatio(int id)
    {
        if (id == 0) return StatusCode(StatusCodes.Status400BadRequest, new { Message = "Invalid data" });

        var addResult = await _settingService.DeleteSettingProfitRatioAsync(User.Identity?.Name, id);

        if (addResult.IsSuccess) return StatusCode(StatusCodes.Status202Accepted);

        return StatusCode(StatusCodes.Status400BadRequest, addResult.Errors[0]);
    }

    public async Task<IActionResult> GetShippingFeeRatioList()
    {
        var result = await _settingService.GetSettingShippingFeeRatioListAsync(User.Identity?.Name);

        if (result.IsFailed)
            return StatusCode(StatusCodes.Status500InternalServerError, result.Errors.First().Message);

        return Json(result.Value);
    }

    //POST: from ajax
    [HttpPost]
    public async Task<IActionResult> ShippingFeeRatioAdd([FromBody] SettingShippingFeeRatioVM model)
    {
        if (model == null) return StatusCode(StatusCodes.Status400BadRequest, new { Message = "Invalid data" });

        var addResult = await _settingService.AddSettingShippingFeeRatioAsync(User.Identity?.Name, model);

        if (addResult.IsSuccess) return StatusCode(StatusCodes.Status201Created);

        return StatusCode(StatusCodes.Status400BadRequest, addResult.Errors[0]);
    }
    [HttpPost]
    public async Task<IActionResult> UpdateSettingShippingFeeRatio([FromBody] SettingShippingFeeRatioVM model)
    {
        if (model == null) return StatusCode(StatusCodes.Status400BadRequest, new { Message = "Invalid data" });

        var addResult = await _settingService.UpdateSettingShippingFeeRatioAsync(User.Identity?.Name, model);

        if (addResult.IsSuccess) return StatusCode(StatusCodes.Status201Created);

        return StatusCode(StatusCodes.Status400BadRequest, addResult.Errors[0]);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteShippingFeeRatio(int id)
    {
        if (id == 0) return StatusCode(StatusCodes.Status400BadRequest, new { Message = "Invalid data" });

        var addResult = await _settingService.DeleteSettingShippingFeeRatioAsync(User.Identity?.Name, id);

        if (addResult.IsSuccess) return StatusCode(StatusCodes.Status202Accepted);

        return StatusCode(StatusCodes.Status400BadRequest, addResult.Errors[0]);
    }

    public async Task<IActionResult> GetProfitAmazon()
    {
        var result = await _settingService.GetSettingProfitAmazonAsync(User.Identity?.Name);

        if (result.IsFailed)
            return StatusCode(StatusCodes.Status500InternalServerError, result.Errors.First().Message);

        return Json(result.Value);
    }
    [HttpPost]
    public async Task<IActionResult> SetSettingProfitAmazon([FromBody] SettingProfitAmazonVM model)
    {
        if (model == null) return StatusCode(StatusCodes.Status400BadRequest, new { Message = "Invalid data" });

        var addResult = await _settingService.SetSettingProfitAmazonAsync(User.Identity?.Name, model);

        if (addResult.IsSuccess) return StatusCode(StatusCodes.Status201Created);

        return StatusCode(StatusCodes.Status400BadRequest, addResult.Errors[0]);
    }

    public async Task<IActionResult> CalculatePriceWithProfit(decimal price, decimal size, decimal weight)
    {
        var result = await _settingService.CalculatePriceWithProfitAsync(User.Identity?.Name, price,size, weight);

        if (result.IsFailed)
            return StatusCode(StatusCodes.Status500InternalServerError, result.Errors[0]);

        return Json(result.Value);
    }
}