namespace Store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypeUpdateRowsName : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET Name='Pay as you go' WHERE DiscountRate=0 ");
            Sql("UPDATE MembershipTypes SET Name='Monthly' WHERE DiscountRate=2 ");
            Sql("UPDATE MembershipTypes SET Name='Anually' WHERE DiscountRate=15 ");
            Sql("UPDATE MembershipTypes SET Name='Weekly' WHERE DiscountRate=10 ");
        }
        
        public override void Down()
        {
        }
    }
}
