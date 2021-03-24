using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TradeClientTestTemplate.Models
{
    public class EquitiesSymbols
    {
        [Key]
        public int SymbolId { get; set; }
        public string Symbol { get; set; }
        public string FullName { get; set; }
            
    }
}
