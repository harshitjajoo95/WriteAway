using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySpace.Entities.ViewModel;

namespace MySpace.Controllers
{
    public class MyJournalController : Controller
    {
        public IActionResult Index(int? year)
        {
            if (!year.HasValue)
            {
                year = DateTime.UtcNow.Year;
            }
            MyJournalViewModel model = new MyJournalViewModel();
            model.Year = year.Value;
            return View(model);
        }
    }
}
