namespace MovieShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatePurchase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Purchase",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        PurchaseNumber = c.Guid(nullable: false),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PurchaseDateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        MovieId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Movie", t => t.MovieId, cascadeDelete: true)
                .Index(t => t.MovieId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Purchase", "MovieId", "dbo.Movie");
            DropIndex("dbo.Purchase", new[] { "MovieId" });
            DropTable("dbo.Purchase");
        }
    }
}
