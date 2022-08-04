using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bank_backend.Models
{
    public class ModelContext : DbContext
    {
        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {

        }

        // public DbSet<<Model_Name>> <Table_name> { get; set; }
        public DbSet<User> UserDetails { get; set; }
        public DbSet<LoginUser> LoginDetails { get; set; }
        public DbSet<Admin> Employee { get; set; }
        public DbSet<Account> AccountDetails { get; set; }
        public DbSet<Payee> Payee { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<FundTransfer> FundTransfer { get; set; }



    }
}
