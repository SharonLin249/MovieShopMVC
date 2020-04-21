namespace MovieShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovieGenreRelation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Trailers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 2084),
                        TrailerUrl = c.String(maxLength: 2084),
                        MovieId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Movie", t => t.MovieId, cascadeDelete: true)
                .Index(t => t.MovieId);
            
            CreateTable(
                "dbo.MovieGenre",
                c => new
                    {
                        GenreId = c.Int(nullable: false),
                        MovieId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.GenreId, t.MovieId })
                .ForeignKey("dbo.Genre", t => t.GenreId, cascadeDelete: true)
                .ForeignKey("dbo.Movie", t => t.MovieId, cascadeDelete: true)
                .Index(t => t.GenreId)
                .Index(t => t.MovieId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MovieGenre", "MovieId", "dbo.Movie");
            DropForeignKey("dbo.MovieGenre", "GenreId", "dbo.Genre");
            DropForeignKey("dbo.Trailers", "MovieId", "dbo.Movie");
            DropIndex("dbo.MovieGenre", new[] { "MovieId" });
            DropIndex("dbo.MovieGenre", new[] { "GenreId" });
            DropIndex("dbo.Trailers", new[] { "MovieId" });
            DropTable("dbo.MovieGenre");
            DropTable("dbo.Trailers");
        }
    }
}
