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
     
    }
}
