using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TradeClientTestTemplate.Models
{
    public class Account
    {
        [Key]
        [Display(Name = "Account ID")]
        public string accountId { get; set; }

        public string accountSymbol { get; set; }

        public string accountFullName { get; set; }

        public virtual ICollection<Trader> listOfTraders { get; set; }
    }
}
