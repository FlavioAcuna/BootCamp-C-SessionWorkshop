using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SessionWorkshop.Models;

namespace SessionWorkshop.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost("dashboard")]
    public IActionResult Username(User newUser)
    {


        if (ModelState.IsValid)
        {
            HttpContext.Session.SetString("UserName", $"{newUser.Name}");
            string Username = HttpContext.Session.GetString("UserName");
            HttpContext.Session.SetInt32("initialNumber", 22);
            int? iniNumber = HttpContext.Session.GetInt32("initialNumber");
            return View("dashboard", newUser);
        }
        return View("index");
    }
    [HttpPost("SumaOne")]
    public IActionResult SumaOne()
    {
        int? numero = HttpContext.Session.GetInt32("initialNumber");
        numero += 1;
        HttpContext.Session.SetInt32("initialNumber", numero.Value);
        return View("Dashboard");
    }
    [HttpPost("RestaOne")]
    public IActionResult RestaOne()
    {
        int? numero = HttpContext.Session.GetInt32("initialNumber");
        numero -= 1;
        HttpContext.Session.SetInt32("initialNumber", numero.Value);
        return View("Dashboard");
    }

    public IActionResult DoubleNumber()
    {
        int? numero = HttpContext.Session.GetInt32("initialNumber");
        numero = numero * 2;
        HttpContext.Session.SetInt32("initialNumber", numero.Value);
        return View("Dashboard");
    }

    [HttpPost("RandomNumber")]
    public IActionResult RandomNumber()
    {
        Random rand = new Random();
        int? numero = HttpContext.Session.GetInt32("initialNumber");

        numero = numero + rand.Next(1, 11);
        Console.WriteLine(rand.Next(1, 11));
        HttpContext.Session.SetInt32("initialNumber", numero.Value);
        return View("Dashboard");
    }
    [HttpPost("CerrarSesion")]
    public IActionResult CerrarSesion()
    {
        HttpContext.Session.SetString("UserName", "");
        HttpContext.Session.SetInt32("initialNumber", 22);
        HttpContext.Session.Clear();
        return View("index");
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
}
