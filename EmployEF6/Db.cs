using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployEF6
{
    class Db : DbContext
    {
        public Db() : base ("Admins")
        { }

        public DbSet<Adminn> Admins { get; set; }
        public DbSet<Employy> Employes { get; set; }
    }
}
