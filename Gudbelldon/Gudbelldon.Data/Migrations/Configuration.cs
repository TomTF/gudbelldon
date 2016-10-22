namespace Gudbelldon.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Gudbelldon.Data.GudbelldonContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Gudbelldon.Data.GudbelldonContext context)
        {
            //  This method will be called after migrating to the latest version.

            //context.OpeningHours.AddOrUpdate(
            //    new OpeningHour
            //    {
            //        Monday = true,
            //        Tuesday = true,
            //        Thursday = true,
            //        Friday = true,
            //        Saturday = true,
            //        From = TimeSpan.FromMinutes(8 * 60 + 30),
            //        To = TimeSpan.FromMinutes(11 * 60 + 30),
            //        ValidFrom = DateTime.Now
            //    }, new OpeningHour
            //    {
            //        Friday = true,
            //        From = TimeSpan.FromMinutes(15 * 60),
            //        To = TimeSpan.FromMinutes(18 * 60),
            //        ValidFrom = DateTime.Now
            //    });
        }
    }
}
