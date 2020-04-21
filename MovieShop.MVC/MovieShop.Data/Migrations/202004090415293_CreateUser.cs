namespace MovieShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateUser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 128),
                        LastName = c.String(maxLength: 128),
                        DateOfBirth = c.DateTime(precision: 7, storeType: "datetime2"),
                        Email = c.String(maxLength: 256),
                        HashedPassword = c.String(maxLength: 1024),
                        Salt = c.String(maxLength: 1024),
                        PhoneNumber = c.String(maxLength: 16),
                        TwoFactorEnabled = c.Boolean(),
                        LockoutEndDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        LastLoginDateTime = c.DateTime(precision: 7, storeType: "datetime2"),
                        IsLocked = c.Boolean(),
                        AccessFailedCount = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Favorite", "UserId");
            CreateIndex("dbo.Purchase", "UserId");
            CreateIndex("dbo.Review", "UserId");
            AddForeignKey("dbo.Favorite", "UserId", "dbo.User", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Purchase", "UserId", "dbo.User", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Review", "UserId", "dbo.User", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Review", "UserId", "dbo.User");
            DropForeignKey("dbo.Purchase", "UserId", "dbo.User");
            DropForeignKey("dbo.Favorite", "UserId", "dbo.User");
            DropIndex("dbo.Review", new[] { "UserId" });
            DropIndex("dbo.Purchase", new[] { "UserId" });
            DropIndex("dbo.Favorite", new[] { "UserId" });
            DropTable("dbo.User");
        }
    }
}
