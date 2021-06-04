using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TradeClientTestTemplate.Models
{
    public class Order
    {
        [Key]
        public int portfolioManagerId { get; set; }

        [Required]
        public string ClOrdId { get; set; }

        [Required]
        [Display(Name = "Creation Time")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime timeCreated { get; set; }

        [Required] 
        public char Side { get; set; }
        
        [Required]
        public string Symbol { get; set; }

        public int Quantity { get; set; }

        [DisplayName("Limit Price")]
        public decimal limitPrice { get; set; }


        [DisplayName("Stop Price")]
        public decimal stopPrice { get; set; }

        [Required]
        [DisplayName("Order Type")]
        public char OrderType { get; set; }

        [DisplayName("Time In Force")] 
        public char TimeInForce { get; set; }

        public char status { get; set; }

        public int ordered { get; set; }
        public int uncommited { get; set; }
        public int placed { get; set; }
        public int filled { get; set; }
        public int leaves { get; set; }

        public string account { get; set; }
        public string trader { get; set; }

        public string EquityFullName { get; set; }

        public DateTime dateGTD { get; set; }


    }
}
