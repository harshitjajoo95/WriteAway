using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MySpace.Entities.ViewModel;
using MySpace.Models;

namespace MySpace.Controllers
{
    public class WriteAwayController : Controller
    {
        //private readonly IMyDayService _myDayService;
        private readonly IMyDayRepository _myDayRepository;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public WriteAwayController(IMyDayRepository myDayRepository, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this._myDayRepository = myDayRepository;
            this._userManager = userManager;
            this._signInManager = signInManager;
        }
        public IActionResult Index()
        {
            MyDayViewModel model = new MyDayViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(MyDayViewModel model)
        {
            try
            {
                if(_signInManager.IsSignedIn(User))
                {
                    if (ModelState.IsValid)
                    {
                        model.userId = (await _userManager.GetUserAsync(User)).Id;
                        model.UtcDateTime = DateTime.UtcNow;

                        if (model.id > 0)
                        {
                            _myDayRepository.UpdateDayDataById(model);
                        }
                        else
                        {
                            model.LocalDateTime = DateTime.UtcNow.AddMinutes(-model.TimeDifferenceInMinutes);
                            _myDayRepository.AddDayData(model);
                        }
                    }
                    return View(model);

                }
                else
                {
                    return RedirectToAction("Login", "Account");
                }


            }
            catch (Exception exe)
            {
                throw;
            }
        }

        [HttpGet]
        public JsonResult GetCurrentDayData(int timeDifference)
        {
            var data = _myDayRepository.GetCurrentDayData(timeDifference);
            return Json(data);
        }
    }
}
