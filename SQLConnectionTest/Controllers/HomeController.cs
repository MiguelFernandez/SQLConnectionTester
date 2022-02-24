using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SQLConnectionTest.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SQLConnectionTest.Controllers
{
    public class HomeController : Controller
    {        
        private readonly ISQLService _sqlService;

        public HomeController(ISQLService sQLService)
        {
            
            _sqlService = sQLService;
        }

        public IActionResult Index()
        {
            var sqlTest = new SQLTest();

            return View(sqlTest);
        }

        [HttpPost]
        public ActionResult Index(SQLTest sqlConnectionTest)
        {
            if (sqlConnectionTest == null)
                throw new ArgumentNullException(nameof(sqlConnectionTest));

            _sqlService.Connect(sqlConnectionTest);

            return View(sqlConnectionTest);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

       
    }
}
