namespace SaveOrg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MoveIsPrimary : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Addresses", "IsPrimary", c => c.Boolean(nullable: false));
            DropColumn("dbo.StudentAddresses", "IsPrimary");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StudentAddresses", "IsPrimary", c => c.Boolean(nullable: false));
            DropColumn("dbo.Addresses", "IsPrimary");
        }
    }
}
