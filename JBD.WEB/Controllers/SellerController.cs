using Microsoft.AspNetCore.Mvc;

namespace JBD.WEB.Controllers
{
    public class SellerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CsvDataUpload()
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
    }
}