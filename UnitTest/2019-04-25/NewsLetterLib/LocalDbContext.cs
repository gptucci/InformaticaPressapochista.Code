using BizMathLib.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizMathLib
{
    public partial class LocalDbContext : DbContext
    {
        public LocalDbContext()
            : base()
        {

            
        }
        



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            Database.SetInitializer<LocalDbContext>(null);

            
            base.OnModelCreating(modelBuilder);

        }
    }
}
