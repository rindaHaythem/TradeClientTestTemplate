﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TradeClientTestTemplate.Models
{
    public class Trader
    {
        [Key]
        public string traderId { get; set; }

        public string traderSymbol { get; set; }

        public string traderFullName { get; set; }


        public IList<TraderAccount> TraderAccounts { get; set; } = new List<TraderAccount>();
    }
}
