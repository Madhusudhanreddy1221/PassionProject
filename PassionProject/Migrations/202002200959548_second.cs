namespace PassionProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Models", "Year", c => c.String());
            AddColumn("dbo.Models", "EngineType", c => c.String());
            AddColumn("dbo.Models", "Power", c => c.String());
            AddColumn("dbo.Models", "TopSpeed", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Models", "TopSpeed");
            DropColumn("dbo.Models", "Power");
            DropColumn("dbo.Models", "EngineType");
            DropColumn("dbo.Models", "Year");
        }
    }
}
