using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradeClientTestTemplate.Data;
using TradeClientTestTemplate.Models;
using QuickFix.Fields.Converters;
using Abp.Extensions;

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
            ViewBag.Accounts = _db.accounts;
            ViewBag.Traders = _db.traders;
            return View();
        }

        //POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Order obj)
        {
            IEnumerable<EquitiesSymbols> symblList = _db.EquitiesSymbols;
            if (!ModelState.IsValid)
            {
                obj.ClOrdId = Guid.NewGuid().ToString();
                obj.timeCreated = DateTime.Now;
                foreach (var sym in symblList)
                {
                    if (sym.Symbol == obj.Symbol)
                    {
                        obj.EquityFullName = sym.FullName;
                        break;
                    }
                }
                if (!string.IsNullOrEmpty(obj.stopPrice))
                {
                    DecimalConverter.Convert(obj.stopPrice);
                }
                if (!string.IsNullOrEmpty(obj.limitPrice))
                {
                    DecimalConverter.Convert(obj.limitPrice);
                }
                
                obj.status = '0';
                obj.ordered = obj.Quantity;
                obj.placed = 0;
                obj.filled =0;
                obj.uncommited = (obj.ordered - obj.placed);
                obj.leaves = (obj.ordered - obj.filled);
                _db.Order.Add(obj);
                _db.SaveChanges();
            }
            return RedirectToAction("Index", "Home", new { area = "" });
        }

        //GET - PLACE
        public IActionResult Place(int? id)
        {
            var obj = _db.Order.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        //POST - PLACE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Place(Order obj)
        {
            if (ModelState.IsValid)
            {
                obj.TransactTime = DateTime.Now;
                obj.status = 'P';
                obj.placed += obj.Quantity;
                obj.uncommited = (obj.ordered - obj.placed);
                _db.Order.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(obj);

        }
    }
}
