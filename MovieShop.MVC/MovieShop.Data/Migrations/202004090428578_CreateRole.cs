namespace MovieShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateRole : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.User", "Role_Id", c => c.Int());
            CreateIndex("dbo.User", "Role_Id");
            AddForeignKey("dbo.User", "Role_Id", "dbo.Role", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User", "Role_Id", "dbo.Role");
            DropIndex("dbo.User", new[] { "Role_Id" });
            DropColumn("dbo.User", "Role_Id");
            DropTable("dbo.Role");
        }
    }
}
