using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gudbelldon.Data.Model;

namespace Gudbelldon.Data
{
    public class GudbelldonContext : DbContext
    {
        public DbSet<OpeningHour> OpeningHours { get; set; }

        public GudbelldonContext() : base("DatabaseConnection")
        {
        }
    }
}
