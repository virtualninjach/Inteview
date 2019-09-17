using Microsoft.AspNetCore.Mvc;
using InterviewMVC.Services;
using InterviewMVC.Models;

namespace InterviewMVC.Controllers
{
    public class ItunesController : Controller
    {
        private readonly ItunesService _itunesService = new ItunesService();

        public IActionResult Index(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // (Tristan): Return the result of the API request as a RootObject object to pass into the Itunes view.
            RootObject model = _itunesService.GetResults(id).Result;
            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }
    }
}