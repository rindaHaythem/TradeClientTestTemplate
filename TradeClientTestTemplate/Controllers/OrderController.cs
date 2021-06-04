using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradeClientTestTemplate.Data;
using TradeClientTestTemplate.Models;
using QuickFix.Fields.Converters;
using QuickFix.Fields;
using Grpc.Net.Client;
using AutoMapper;
using GrpcFixMessage;
using Microsoft.AspNetCore.Http;
using TradeClientTestTemplate.ViewModels;

namespace TradeClientTestTemplate.Controllers
{
    public class OrderController : Controller
    {

        private readonly ApplicationDbContext _db;
        private readonly GrpcChannel channel;

        public OrderController(ApplicationDbContext db)
        {
            _db = db;
            channel = GrpcChannel.ForAddress("https://localhost:5001");
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
                obj.ClOrdId = Guid.NewGuid().ToString().Substring(0, 8);
                obj.timeCreated = DateTime.UtcNow;
                foreach (var sym in symblList)
                {
                    if (sym.Symbol == obj.Symbol)
                    {
                        obj.EquityFullName = sym.FullName;
                        break;
                    }
                }
                if (obj.stopPrice != decimal.Zero)
                {
                    DecimalConverter.Convert(obj.stopPrice);
                }
                if (obj.limitPrice != decimal.Zero)
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
        public IActionResult Place(int id)
        {
            //var orderPlaceViewModel = new OrderPlaceViewModel();
            Placement pl = new Placement();
            //orderPlaceViewModel.Placement = pl;
            //orderPlaceViewModel.OrderID = id;

            var obj = _db.Order.Find(id);
            ViewBag.Order = obj;
            ViewBag.Brokers = _db.brokers;
            ViewBag.Destinations = _db.destinations;
            TempData["OrderID"] = id;
            
            if (obj == null)
            {
                return NotFound();
            }
            return View(pl);
        }

        //POST - PLACE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Place(Placement pl)
        {
            
                #region update Order
                var obj = _db.Order.Find(TempData["OrderID"]);
                obj.placed += obj.Quantity;
                obj.uncommited = (obj.ordered - obj.placed);

                if (obj.placed != obj.Quantity)
                {
                    obj.status = 'Z';
                }
                else
                {
                    obj.status = 'Y';
                }
                #endregion
                
                pl.PlacementID = Guid.NewGuid().ToString();
                
                pl.ClOrdId = obj.ClOrdId;
                pl.status = 'P';
                pl.AvgPrice = decimal.Zero;
                pl.Filled = 0;
                pl.Working = pl.Placed - pl.Filled;
                pl.SendingTime = DateTime.UtcNow;

                _db.Order.Update(obj);
                _db.Placement.Update(pl);
                _db.SaveChanges();

                #region Send data though gRPC to Fix Engine

                var client = new Constructer.ConstructerClient(channel);
                NewOrderSingleRequest newOrderSingleRequest = new NewOrderSingleRequest();
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Placement, NewOrderSingleRequest>()
                        .ForMember(newOrderSingleRequest => newOrderSingleRequest.OrderType, act => act.MapFrom(pl => pl.OrderType.ToString()))
                        .ForMember(newOrderSingleRequest => newOrderSingleRequest.LimitPrice, act => act.MapFrom(pl => NullToString(pl.limitPrice)))
                        .ForMember(newOrderSingleRequest => newOrderSingleRequest.StopPrice, act => act.MapFrom(pl => NullToString(pl.stopPrice)))
                        .ForMember(newOrderSingleRequest => newOrderSingleRequest.TransactTime, act => act.MapFrom(pl => pl.SendingTime))
                        .ForMember(newOrderSingleRequest => newOrderSingleRequest.TimeInForce, act => act.MapFrom(pl => pl.TimeInForce))
                        .ForMember(newOrderSingleRequest => newOrderSingleRequest.DateGTD, act => act.MapFrom(pl => NullToString(pl.dateGTD)))
                        .ForMember(newOrderSingleRequest => newOrderSingleRequest.Note, act => act.MapFrom(pl => NullToString(pl.Note)));
                });

                var mapper = new Mapper(config);
                newOrderSingleRequest = mapper.Map<NewOrderSingleRequest>(pl);
                newOrderSingleRequest.Side = obj.Side.ToString();
                newOrderSingleRequest.Symbol = obj.Symbol;
                client.BuildFixMessage(newOrderSingleRequest);
                #endregion

                return RedirectToAction("Placement", "Home");
            
            //return View(orderPlaceViewModel);

        }

        private static string NullToString(object Value)
        {
            return Value == null ? "" : Value.ToString();
        }
    }

}
