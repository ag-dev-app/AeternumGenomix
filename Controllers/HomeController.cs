using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AeternumGenomix.Models;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace AeternumGenomix.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public ActionResult Valid()
        {
            return View("Index");
        }

        [Route("listkeys")]
        [HttpPost]
        public async Task<ActionResult> Valid(IFormFile jsonFile)
        {
            if (jsonFile != null)
            {
                string jsonString = "";
                StreamReader streamReader = new StreamReader(jsonFile.OpenReadStream());
                jsonString = await streamReader.ReadToEndAsync();

                JsonFieldsCollector fieldsCollector = new JsonFieldsCollector(jsonString);

                ViewData["name"] = jsonFile.FileName;
                ViewData["fields"] = fieldsCollector;

                return View("Privacy");

            }
            else
            {
                return View("Index");
            }
        }
    }
}
