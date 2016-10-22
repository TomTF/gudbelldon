namespace Gudbelldon.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OpeningHours",
                c => new
                    {
                        OpeningHourId = c.Int(nullable: false, identity: true),
                        Monday = c.Boolean(nullable: false),
                        Tuesday = c.Boolean(nullable: false),
                        Wednesday = c.Boolean(nullable: false),
                        Thursday = c.Boolean(nullable: false),
                        Friday = c.Boolean(nullable: false),
                        Saturday = c.Boolean(nullable: false),
                        Sunday = c.Boolean(nullable: false),
                        From = c.Time(nullable: false, precision: 7),
                        To = c.Time(nullable: false, precision: 7),
                        ValidFrom = c.DateTime(nullable: false),
                        ValidTo = c.DateTime(),
                    })
                .PrimaryKey(t => t.OpeningHourId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.OpeningHours");
        }
    }
}
