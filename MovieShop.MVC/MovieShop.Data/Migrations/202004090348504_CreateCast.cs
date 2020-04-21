namespace MovieShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateCast : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cast",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 128),
                        Gender = c.String(),
                        TmdbUrl = c.String(),
                        ProfilePath = c.String(maxLength: 2084),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Cast");
        }
    }
}
