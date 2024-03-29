using Core.Enums;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Mvc.Framework;
using Mvc.Models;

namespace Mvc.Controllers;

public class RootController(ICountryService service) : Controller
{
    [Route("/")]
    public IActionResult Index()
    {
        return View("/Views/Index.cshtml", new IndexViewModel
        {
            Layout = HXHelpers.IsHistoryRestoreRequest(Request.Headers) ? "/Views/Shared/_Layout.cshtml" : default,
            Countries = service.All(),
            Regions = Enum.GetNames(typeof(Region))
        });
    }

    [Route("/detail")]
    public IActionResult Detail(string cca3)
    {
        return View("/Views/Pages/Detail.cshtml", new DetailViewModel
        {
            Layout = HXHelpers.IsHistoryRestoreRequest(Request.Headers) ? "/Views/Shared/_Layout.cshtml" : default,
            Country = service.Get(cca3)
        });
    }
}