namespace Gudbelldon.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExtendKnittingNight : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.KnittingNights", "Icon", c => c.String());
            AddColumn("dbo.KnittingNights", "Color", c => c.String());
            AddColumn("dbo.KnittingNights", "Location", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.KnittingNights", "Location");
            DropColumn("dbo.KnittingNights", "Color");
            DropColumn("dbo.KnittingNights", "Icon");
        }
    }
}
