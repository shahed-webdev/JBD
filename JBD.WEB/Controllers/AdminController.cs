using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using FluentResults.Extensions.AspNetCore;
using JBD.Service;

namespace JBD.WEB.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly IProductService _productService;

        public AdminController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
           return View();
        }
        public async Task<IActionResult> CsvDataUpload()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CsvDataUpload(IFormFile? file)
        {
            if (file == null) return BadRequest();

            var data = new List<string>();
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                while (reader.Peek() >= 0)
                {
                    var line = reader.ReadLine();
                    if (!string.IsNullOrEmpty(line))
                        data.Add(line);

                    // do something with the line of data
                }
            }

            return Ok(data);
        }

        public async Task<IActionResult> ExhibitProduct()
        {
            var products = await _productService.FetchProductsAsync(User.Identity?.Name);
            //return products.ToActionResult();
            return View(products.Value);
        }

        public async Task<IActionResult> ProductDetails(int id)
        {
            var product = await _productService.GetProductByUserIdAsync(User.Identity?.Name, id);
            //return products.ToActionResult();
            return View(product.Value);
        }


    }
}
