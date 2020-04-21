namespace MovieShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateMovieCrew1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MovieCrew",
                c => new
                    {
                        MovieId = c.Int(nullable: false),
                        CrewId = c.Int(nullable: false),
                        Department = c.String(nullable: false, maxLength: 128),
                        Job = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.MovieId, t.CrewId, t.Department, t.Job })
                .ForeignKey("dbo.Crew", t => t.CrewId, cascadeDelete: true)
                .ForeignKey("dbo.Movie", t => t.MovieId, cascadeDelete: true)
                .Index(t => t.MovieId)
                .Index(t => t.CrewId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MovieCrew", "MovieId", "dbo.Movie");
            DropForeignKey("dbo.MovieCrew", "CrewId", "dbo.Crew");
            DropIndex("dbo.MovieCrew", new[] { "CrewId" });
            DropIndex("dbo.MovieCrew", new[] { "MovieId" });
            DropTable("dbo.MovieCrew");
        }
    }
}
