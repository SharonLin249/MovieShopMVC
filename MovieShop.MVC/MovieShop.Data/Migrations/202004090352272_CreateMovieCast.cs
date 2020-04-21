namespace MovieShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateMovieCast : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MovieCast",
                c => new
                    {
                        MovieId = c.Int(nullable: false),
                        CastId = c.Int(nullable: false),
                        Character = c.String(nullable: false, maxLength: 450),
                    })
                .PrimaryKey(t => new { t.MovieId, t.CastId, t.Character })
                .ForeignKey("dbo.Cast", t => t.CastId, cascadeDelete: true)
                .ForeignKey("dbo.Movie", t => t.MovieId, cascadeDelete: true)
                .Index(t => t.MovieId)
                .Index(t => t.CastId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MovieCast", "MovieId", "dbo.Movie");
            DropForeignKey("dbo.MovieCast", "CastId", "dbo.Cast");
            DropIndex("dbo.MovieCast", new[] { "CastId" });
            DropIndex("dbo.MovieCast", new[] { "MovieId" });
            DropTable("dbo.MovieCast");
        }
    }
}
