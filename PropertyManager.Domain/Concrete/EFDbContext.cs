using PropertyManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManager.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public EFDbContext() : base("EFDbContext")
        {
            Database.SetInitializer<EFDbContext>(null);
        }

        public DbSet<User> Users { get; set; }
    }
}
