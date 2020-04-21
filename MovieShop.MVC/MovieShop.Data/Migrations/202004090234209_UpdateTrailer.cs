namespace MovieShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTrailer : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Trailers", newName: "Trailer");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Trailer", newName: "Trailers");
        }
    }
}
