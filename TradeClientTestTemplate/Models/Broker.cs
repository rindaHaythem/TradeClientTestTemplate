using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TradeClientTestTemplate.Models
{
    public class Broker
    {
        [Key]
        public int BrokerID { get; set; }
        public string BrokerName { get; set; }
        public string BrokerSymbol { get; set; }
    }
}
