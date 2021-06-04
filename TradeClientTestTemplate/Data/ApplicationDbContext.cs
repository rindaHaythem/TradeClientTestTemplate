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

        public DbSet<Order> Order { get; set; }
        public DbSet<Placement> Placement { get; set; }
        public DbSet<Destination> destinations { get; set; }
        public DbSet<Broker> brokers { get; set; }
        public DbSet<EquitiesSymbols> EquitiesSymbols { get; set; }
        public DbSet<Account> accounts { get; set; }
        public DbSet<Trader> traders { get; set; }
        public DbSet<TraderAccount> TradersAccounts { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
         protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<TraderAccount>().HasKey(c => new { c.AccountID, c.TraderID });
        } 
        
    }
}
