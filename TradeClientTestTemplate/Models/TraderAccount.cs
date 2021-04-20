using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradeClientTestTemplate.Models
{
    public class TraderAccount
    {
        public string TraderID { get; set; }
        public Trader Trader { get; set; }

        public string AccountID { get; set; }
        public Account Account { get; set; }
    }
}
