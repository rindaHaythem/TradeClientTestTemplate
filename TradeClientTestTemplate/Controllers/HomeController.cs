using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using TradeClientTestTemplate.Data;
using TradeClientTestTemplate.Models;

namespace TradeClientTestTemplate.Controllers
{
    public class HomeController : Controller
    {
        /*private readonly ILogger<HomeController> _logger;*/
        private readonly ApplicationDbContext _db;
        public HomeController(/*ILogger<HomeController> logger */ApplicationDbContext db )
        {
            _db = db;
            /*_logger = logger;*/
        }
       

        public IActionResult Index()
        {
            IEnumerable<Order> objList = _db.Order;
            ViewBag.Traders = _db.traders;
            return View(objList);
        }

        public IActionResult Placement()
        {
            IEnumerable<Placement> placementList = _db.Placement;
            ViewBag.Destination = _db.destinations;
            return View(placementList);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
