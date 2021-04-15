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
        public int Side { get; set; }
        
        [Required]
        public string Symbol { get; set; }

        public int Quantity { get; set; }

        [DisplayName("Limit Price")]
        public string limitPrice { get; set; }


        [DisplayName("Stop Price")]
        public string stopPrice { get; set; }

        [Required]
        [DisplayName("Order Type")]
        public char OrderType { get; set; }

        [DisplayName("Time In Force")]
        public string TimeInForce { get; set; }

        [DataType(DataType.Text)]
        public string Note { get; set; }

        public char status { get; set; }

        public int ordered { get; set; }
        public int uncommited { get; set; }
        public int placed { get; set; }
        public int filled { get; set; }
        public int leaves { get; set; }

        public string account { get; set; }
        public string trader { get; set; }

        public string EquityFullName { get; set; }

        [Display(Name = "Transact Time")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime  TransactTime { get; set; }

        public DateTime dateGTD { get; set; }


    }
}
