namespace Store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedGenresToMovieModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "GenresID", c => c.Byte(nullable: false));
            AddColumn("dbo.Movies", "Genres_Id", c => c.Int());
            CreateIndex("dbo.Movies", "Genres_Id");
            AddForeignKey("dbo.Movies", "Genres_Id", "dbo.Genres", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "Genres_Id", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "Genres_Id" });
            DropColumn("dbo.Movies", "Genres_Id");
            DropColumn("dbo.Movies", "GenresID");
        }
    }
}
