namespace Store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenres : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT Genres ON");
            Sql("INSERT INTO Genres(Id, Name) VALUES(1, 'Kids')");
            Sql("INSERT INTO Genres(Id, Name) VALUES(2, 'Comedy')");
            Sql("INSERT INTO Genres(Id, Name) VALUES(3, 'Action')");
        }
        
        public override void Down()
        {
        }
    }
}
