namespace MovieShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateFavorite : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Favorite",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MovieId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Movie", t => t.MovieId, cascadeDelete: true)
                .Index(t => t.MovieId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Favorite", "MovieId", "dbo.Movie");
            DropIndex("dbo.Favorite", new[] { "MovieId" });
            DropTable("dbo.Favorite");
        }
    }
}
