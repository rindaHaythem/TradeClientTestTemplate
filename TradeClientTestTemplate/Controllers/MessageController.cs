using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuickFix.FIX42;
using QuickFix.Fields.Converters;

namespace TradeClientTestTemplate.Controllers
{
    public class MessageController : Controller
    {
        public IActionResult Index()
        {
            string decimalNumberLikeString = "lolololololololololol";
            decimal price = DecimalConverter.Convert(decimalNumberLikeString);
            return View();
        }
    }
}
