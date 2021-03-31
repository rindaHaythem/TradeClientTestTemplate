using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradeClientTestTemplate.Data;
using TradeClientTestTemplate.Models;

namespace TradeClientTestTemplate.Controllers
{
    public class OrderController : Controller
    {

        private readonly ApplicationDbContext _db;
        public OrderController(ApplicationDbContext db)
        {
            _db = db;
        }
                
        public IActionResult Index()
        {
            IEnumerable<Order> objList = _db.Order;
            return View(objList);
        }
        
        //GET - CREATE
        public IActionResult Create()
        {
            ViewBag.Equities = _db.EquitiesSymbols;
            return View();
        }

        //POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Order obj)
        {
            if (!ModelState.IsValid)
            {
                obj.ClOrdId = Guid.NewGuid().ToString();
                obj.timeCreated = DateTime.Now;
                _db.Order.Add(obj);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
