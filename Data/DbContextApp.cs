using Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DbContextApp : DbContext
    {
        public DbContextApp(string nameOrConnectionString = "DbName")
            : base(nameOrConnectionString)
        {
        }

        public DbSet<RootModel> Roots { get; set; }
        public DbSet<ChildModel> Children { get; set; }
    }
}
