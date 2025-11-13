using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AspnetTodoapp.Models;
using Htmx;

namespace AspnetTodoapp.Controllers;

public class HomeController : Controller
{
    [Route("/")]
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [Route("/privacy")]
    [HttpGet]
    public IActionResult Privacy()
    {
        if (Request.IsHtmx())
        {
            return PartialView();
        }
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
