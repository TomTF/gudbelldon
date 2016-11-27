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
        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<KnittingNight> KnittingNights { get; set; }

        public GudbelldonContext() : base("DatabaseConnection")
        {
        }
    }
}
