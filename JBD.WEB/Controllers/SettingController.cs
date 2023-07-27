﻿using JBD.DATA.Enums;
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


    public async Task<IActionResult> GetProfitRatioList()
    {
        var result = await _settingService.GetSettingProfitRatioListAsync(User.Identity?.Name);
       
        if (result.IsFailed)
            return StatusCode(StatusCodes.Status500InternalServerError, result.Errors.First().Message);

        return Json(result.Value);
    }


    public async Task<IActionResult> GetShippingFeeRatioList()
    {
        var result = await _settingService.GetSettingShippingFeeRatioListAsync(User.Identity?.Name);

        if (result.IsFailed)
            return StatusCode(StatusCodes.Status500InternalServerError, result.Errors.First().Message);

        return Json(result.Value);
    }

    public async Task<IActionResult> GetProfitAmazon()
    {
        var result = await _settingService.GetSettingProfitAmazonAsync(User.Identity?.Name);

        if (result.IsFailed)
            return StatusCode(StatusCodes.Status500InternalServerError, result.Errors.First().Message);

        return Json(result.Value);
    }

    public async Task<IActionResult> CalculatePriceWithProfit(decimal price, decimal size, decimal weight)
    {
        var result = await _settingService.CalculatePriceWithProfitAsync(User.Identity?.Name, price,size, weight);

        if (result.IsFailed)
            return StatusCode(StatusCodes.Status500InternalServerError, result.Errors.First().Message);

        return Json(result.Value);
    }
}