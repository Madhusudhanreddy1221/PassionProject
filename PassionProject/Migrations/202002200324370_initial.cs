namespace PassionProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bikes",
                c => new
                    {
                        BikeID = c.Int(nullable: false, identity: true),
                        MakeID = c.Int(nullable: false),
                        ModelID = c.Int(nullable: false),
                        BikeName = c.String(),
                        Price = c.Double(nullable: false),
                        Color = c.String(),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.BikeID)
                .ForeignKey("dbo.Makes", t => t.MakeID, cascadeDelete: true)
                .ForeignKey("dbo.Models", t => t.ModelID, cascadeDelete: true)
                .Index(t => t.MakeID)
                .Index(t => t.ModelID);
            
            CreateTable(
                "dbo.Makes",
                c => new
                    {
                        MakeID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.MakeID);
            
            CreateTable(
                "dbo.Models",
                c => new
                    {
                        ModelID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ModelID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        CustomerFname = c.String(),
                        CustomerLname = c.String(),
                        CustomerAddress = c.String(),
                        CustomerHomePhone = c.String(),
                    })
                .PrimaryKey(t => t.CustomerID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        BikeID = c.Int(nullable: false),
                        CustomerID = c.Int(nullable: false),
                        Orderdate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.Bikes", t => t.BikeID, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .Index(t => t.BikeID)
                .Index(t => t.CustomerID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.Orders", "BikeID", "dbo.Bikes");
            DropForeignKey("dbo.Bikes", "ModelID", "dbo.Models");
            DropForeignKey("dbo.Bikes", "MakeID", "dbo.Makes");
            DropIndex("dbo.Orders", new[] { "CustomerID" });
            DropIndex("dbo.Orders", new[] { "BikeID" });
            DropIndex("dbo.Bikes", new[] { "ModelID" });
            DropIndex("dbo.Bikes", new[] { "MakeID" });
            DropTable("dbo.Orders");
            DropTable("dbo.Customers");
            DropTable("dbo.Models");
            DropTable("dbo.Makes");
            DropTable("dbo.Bikes");
        }
    }
}
