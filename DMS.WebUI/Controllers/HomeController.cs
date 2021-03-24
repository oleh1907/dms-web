using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DMS.Models;
using DMS.Data;
using DMS.Service;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Security.Principal;
using Microsoft.AspNetCore.Http;
using DMS.Data.ViewModels;
using Microsoft.AspNetCore.Hosting;

namespace DMS.Controllers
{
    /*
     * HOME CONTROLLER MAIN CLASS
     */
    [Authorize]
    public class HomeController : Controller
    {
        private CategoryService _categoryService;
        private readonly ReportsService _reportsService;

        public HomeController(DMSContext context, IHostingEnvironment hostingEnvironment)
        {
            _categoryService = new CategoryService(context);
            _reportsService = new ReportsService(context, hostingEnvironment);
        }

        /*
         * HOMEPAGE
         */
        public IActionResult Index()
        {
            ViewBag.categories = _categoryService.GetAll();
            return View();
        }

        public IEnumerable<UserReport> GetCategoryUsersInfo(int categoryId)
        {
            return _reportsService.GetCategoryUsersInfo(categoryId);
        }

        /*
         * ERROR
         */
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
