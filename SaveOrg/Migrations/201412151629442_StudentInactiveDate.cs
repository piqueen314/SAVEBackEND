namespace SaveOrg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StudentInactiveDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StudentHistories", "InactiveDate", c => c.DateTime());
            AddColumn("dbo.Students", "InactiveDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "InactiveDate");
            DropColumn("dbo.StudentHistories", "InactiveDate");
        }
    }
}
