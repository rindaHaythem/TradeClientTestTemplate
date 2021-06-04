using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TradeClientTestTemplate.Models
{
    public class Placement
    {
        [Key]
        public int portfolioManagerId { get; set; }

        public string PlacementID { get; set; }
        public string DestinationID { get; set; }
        public string Broker { get; set; }

        [Required]
        public string ClOrdId { get; set; }

        public char status { get; set; }

        [Required]
        [DisplayName("Order Type")]
        public char OrderType { get; set; }

        [DisplayName("Limit Price")]
        public decimal limitPrice { get; set; }

        [DisplayName("Stop Price")]
        public decimal stopPrice { get; set; }

        [DisplayName("Average Price")]
        public decimal AvgPrice { get; set; }

        [DisplayName("Time In Force")]
        public char TimeInForce { get; set; }

        public DateTime dateGTD { get; set; }

        public int Placed { get; set; }
        public int Filled { get; set; }
        public int Working { get; set; }

        public DateTime SendingTime { get; set; }

        [DataType(DataType.Text)]
        public string Note { get; set; }




    }
}
