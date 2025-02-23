namespace Di.Play.Controllers;

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Models;

public class HomeController(
    ILogger<HomeController> logger,
    [FromKeyedServices("this")] IService thisService,
    [FromKeyedServices("that")]IService thatService) : Controller
{
    private ILogger<HomeController> Logger { get; } = logger;
    private IService ThisService { get; } = thisService;
    private IService ThatService { get; } = thatService;

    public IActionResult Index()
    {
        HomeViewModel model = new()
        {
            ThisString = ThisService.DoSomething(),
            ThatString = ThatService.DoSomething()
        };
        return View(model);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}