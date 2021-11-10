namespace Store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletedGenresFromMovieModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "Genres_Id", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "Genres_Id" });
            DropColumn("dbo.Movies", "Genres_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "Genres_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Movies", "Genres_Id");
            AddForeignKey("dbo.Movies", "Genres_Id", "dbo.Genres", "Id", cascadeDelete: true);
        }
    }
}
