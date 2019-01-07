using System;
using Microsoft.EntityFrameworkCore;
using Treasury.Data.Models;

namespace Treasury.Data
{
    public class TreasuryContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=Treasury;user=root;password=password");
        }

        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Income> Income { get; set; }
        public DbSet<Coffer> Coffers { get; set; }
        public DbSet<Budget> Budgets { get; set; }
    }


}
