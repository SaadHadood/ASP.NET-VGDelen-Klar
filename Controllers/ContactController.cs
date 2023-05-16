using Microsoft.AspNetCore.Mvc;
using WebApp.Services;
using WebApp.ViewModels;

namespace WebApp.Controllers;

public class ContactController : Controller
{
    private readonly ContactFormService _contactFormService;

    public ContactController(ContactFormService contactFormService)
    {
        _contactFormService = contactFormService;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task <IActionResult> Index(ContactFormViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            if (await _contactFormService.CreateAsync(viewModel))
            return RedirectToAction("index", "home");
        }

        return View(viewModel);
    }
}
