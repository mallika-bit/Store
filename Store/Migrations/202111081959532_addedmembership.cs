namespace Store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedmembership : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "MembershipTypeID", c => c.Byte(nullable: true));
            CreateIndex("dbo.Customers", "MembershipTypeID");
            AddForeignKey("dbo.Customers", "MembershipTypeID", "dbo.MembershipTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "MembershipTypeID", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "MembershipTypeID" });
            DropColumn("dbo.Customers", "MembershipTypeID");
        }
    }
}
