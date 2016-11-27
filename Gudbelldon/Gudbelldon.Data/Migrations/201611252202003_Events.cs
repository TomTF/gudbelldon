namespace Gudbelldon.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Events : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventId = c.Int(nullable: false, identity: true),
                        ImageUrl = c.String(),
                        Title = c.String(),
                        Subtitle = c.String(),
                        Date = c.DateTime(nullable: false),
                        Description = c.String(),
                        Start = c.Time(nullable: false, precision: 7),
                        End = c.Time(precision: 7),
                    })
                .PrimaryKey(t => t.EventId);
            
            CreateTable(
                "dbo.KnittingNights",
                c => new
                    {
                        KnittingNightId = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.KnittingNightId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.KnittingNights");
            DropTable("dbo.Events");
        }
    }
}
