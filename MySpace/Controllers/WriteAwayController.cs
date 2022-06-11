using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.DataProtection;
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
        private /*readonly*/ IDataProtector _protector;
        private readonly IDataProtectionProvider _dataProtectionProvider;

        public WriteAwayController(IMyDayRepository myDayRepository, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager
            , IDataProtectionProvider dataProtectionProvider)
        {
            this._myDayRepository = myDayRepository;
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._dataProtectionProvider = dataProtectionProvider;

            if((User != null) && _signInManager.IsSignedIn(User))
            {
                _protector = dataProtectionProvider.CreateProtector(User.Identity.Name);
            }

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
                        if ((User != null) && _protector == null)
                        {
                            _protector = _dataProtectionProvider.CreateProtector(User.Identity.Name);
                        }
                        if( model != null && model.WrittenData != null)
                        {
                            model.EncryptedWrittenData = _protector.Protect(model.WrittenData);
                            model.WrittenData = model.EncryptedWrittenData;
                        }
                        if (model.id > 0)
                        {
                            _myDayRepository.UpdateDayDataById(model);
                        }
                        else
                        {
                            model.LocalDateTime = DateTime.UtcNow.AddMinutes(-model.TimeDifferenceInMinutes);
                            _myDayRepository.AddDayData(model);
                        }
                        if (model.EncryptedWrittenData != null)
                        {
                            model.WrittenData = _protector.Unprotect(model.EncryptedWrittenData);
                        }
                    }
                    return View(model);

                }
                else
                {
                    return RedirectToAction("Login", "Account");
                }


            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //[HttpGet]
        //public JsonResult GetCurrentDayData(int timeDifference)
        //{
        //    var data = _myDayRepository.GetCurrentDayData(timeDifference);
        //    return Json(data);
        //}
        [HttpGet]
        public JsonResult GetUsersLocalDayData(int timeDifference)
        {
            MyDayViewModel data = new MyDayViewModel();
            if (_signInManager.IsSignedIn(User))
            {
                if((User != null) && _protector == null)
                {
                    _protector = _dataProtectionProvider.CreateProtector(User.Identity.Name);
                }
                data = _myDayRepository.GetUsersLocalDayData(timeDifference);
                if(data != null && data.WrittenData!=null)
                {
                    data.WrittenData = _protector.Unprotect(data.WrittenData);

                }
            }
            return Json(data);
        }
    }
}
