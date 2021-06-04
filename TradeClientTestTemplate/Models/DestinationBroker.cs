using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradeClientTestTemplate.Models
{
    public class DestinationBroker
    {
        public int BrokerID { get; set; }
        public Broker Broker { get; set; }
        public Guid DestinationID { get; set; }
        public Destination Destination { get; set; }


    }
}
