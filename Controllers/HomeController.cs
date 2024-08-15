using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BrunoTeste.Models;

namespace BrunoTeste.Controllers;

public class HomeController : BaseController
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        if (_logado)
        {
            return View(new HomeViewModel()
            {
                Username = _username
            });
        }
        else
        {
            return RedirectToAction("Index", "Login");
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
