using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Inteview.Models;
using Inteview.Data;
using Inteview.ViewModels;

namespace Inteview.Controllers
{
    public class ItunesController : Controller
    {
        public async Task<IActionResult> Index(string id)
        {
            ItunesRepository ir = new ItunesRepository();
            ViewModels.RootObject iv = await ir.GetItnesInfo(id);
            
            return View(iv);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
