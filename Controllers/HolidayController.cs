using EmployeeManagement.Areas.Identity.Data;
using EmployeeManagement.Data;
using EmployeeManagement.Models;
using EmployeeManagement.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers
{
    [Authorize]
    public class HolidayController : Controller
    {
        private readonly IApplicationUserProvider _iApplicationUserProvider;
        private readonly IHolidayProvider _iHolidayProvider;

        public HolidayController(IHolidayProvider iHolidayProvider, IApplicationUserProvider iApplicationUserProvider)
        {
            _iHolidayProvider = iHolidayProvider;
            _iApplicationUserProvider = iApplicationUserProvider;
        }
        [HttpGet]
        public async Task<IActionResult> Index(string id = "")
        {
            ApplicationUserViewModel user = new ApplicationUserViewModel();
            user = await _iApplicationUserProvider.GetById(id);
            return View(user);
        }
        [HttpPost]
        public IActionResult Index(HolidayViewModel model)
        {
            try
            {
                _iHolidayProvider.SaveHoliday(model);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
