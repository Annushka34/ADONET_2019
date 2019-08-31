using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_CodeFirst
{
    public class EfContext : DbContext
    {
        public EfContext() : base ("myConnection")
        {
                
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }

        public DbSet<Address> Addresses { get; set; }


    }
}
