using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange_Rate_API
{
    internal class ExchangeHouse: DbContext
    {
        public DbSet<DbExchangeData> ExchangeData { get; set; }

        public ExchangeHouse()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite(@"Data Source=ExchangeHouse.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DbExchangeData>().HasData(
                new DbExchangeData() { Id = 1, key = "PLN", value = 4.0M, timestamp = 1241324 },
                new DbExchangeData() { Id = 2, key = "USD", value = 1.0M, timestamp = 1241324 },
                new DbExchangeData() { Id = 3, key = "EUR", value = 0.9M, timestamp = 1241324 }
                );
        }

    }
}
