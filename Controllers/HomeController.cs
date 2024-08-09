using Microsoft.AspNetCore.Mvc;
using StackTraceParserWeb.Models;
using StackTraceParserWeb.Services;
using System.Diagnostics;

namespace StackTraceParserWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStackTraceParserService _stackTraceParserService;

        public HomeController(IStackTraceParserService stackTraceParserService)
        {
            _stackTraceParserService = stackTraceParserService;
        }

        [HttpPost]
        public IActionResult ParseStackTrace([FromForm] string stackTrace)
        {
            if (string.IsNullOrWhiteSpace(stackTrace))
            {
                ModelState.AddModelError("stackTrace", "Stack trace is required.");
                return View("Index"); 
            }

            var parsedHtml = _stackTraceParserService.ParseToHtml(stackTrace);
            return Content(parsedHtml, "text/html");
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult StatusCode(int code)
        {
            if (code == 404)
            {
                return View("404");
            }

            return View("Error"); 
        }
    }
}
