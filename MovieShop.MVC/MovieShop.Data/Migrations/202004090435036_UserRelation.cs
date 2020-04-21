namespace MovieShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserRelation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.User", "Role_Id", "dbo.Role");
            DropIndex("dbo.User", new[] { "Role_Id" });
            CreateTable(
                "dbo.UserRole",
                c => new
                    {
                        RoleId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.Role", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.UserId);
            
            AlterColumn("dbo.Movie", "Price", c => c.Decimal(precision: 5, scale: 2));
            AlterColumn("dbo.Review", "Rating", c => c.Decimal(nullable: false, precision: 3, scale: 2));
            DropColumn("dbo.User", "Role_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.User", "Role_Id", c => c.Int());
            DropForeignKey("dbo.UserRole", "UserId", "dbo.User");
            DropForeignKey("dbo.UserRole", "RoleId", "dbo.Role");
            DropIndex("dbo.UserRole", new[] { "UserId" });
            DropIndex("dbo.UserRole", new[] { "RoleId" });
            AlterColumn("dbo.Review", "Rating", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Movie", "Price", c => c.Decimal(precision: 18, scale: 2));
            DropTable("dbo.UserRole");
            CreateIndex("dbo.User", "Role_Id");
            AddForeignKey("dbo.User", "Role_Id", "dbo.Role", "Id");
        }
    }
}
