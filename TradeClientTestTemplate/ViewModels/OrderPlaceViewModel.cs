using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradeClientTestTemplate.Models;

namespace TradeClientTestTemplate.ViewModels
{
    public class OrderPlaceViewModel
    {
        public int OrderID { get; set; }
        public Placement Placement { get; set; }

    }
}
