using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradeClientTestTemplate.Models;

namespace TradeClientTestTemplate.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Order> Order { get; set; }
        public DbSet<EquitiesSymbols> EquitiesSymbols { get; set; }
        public DbSet<Account> accounts { get; set; }
        public DbSet<Trader> traders { get; set; }
    }
}
