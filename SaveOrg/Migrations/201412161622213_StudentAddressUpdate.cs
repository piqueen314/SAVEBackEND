namespace SaveOrg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StudentAddressUpdate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentAddresses",
                c => new
                    {
                        StudentAddressId = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        AddressId = c.Int(nullable: false),
                        IsPrimary = c.Boolean(nullable: false),
                        ModUser = c.String(nullable: false),
                        ModDate = c.DateTime(nullable: false),
                        SetupUser = c.String(nullable: false),
                        SetupDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.StudentAddressId)
                .ForeignKey("dbo.Addresses", t => t.AddressId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.AddressId);
            
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        AddressId = c.Int(nullable: false, identity: true),
                        Address1 = c.String(nullable: false),
                        Address2 = c.String(),
                        City = c.String(nullable: false),
                        State = c.String(nullable: false),
                        ZipCode = c.Int(nullable: false),
                        ModUser = c.String(nullable: false),
                        ModDate = c.DateTime(nullable: false),
                        SetupUser = c.String(nullable: false),
                        SetupDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AddressId);
            
            CreateTable(
                "dbo.AddressHistories",
                c => new
                    {
                        AddressHistoryId = c.Int(nullable: false, identity: true),
                        AddressId = c.Int(nullable: false),
                        Address1 = c.String(nullable: false),
                        Address2 = c.String(),
                        City = c.String(nullable: false),
                        State = c.String(nullable: false),
                        ZipCode = c.Int(nullable: false),
                        ModUser = c.String(nullable: false),
                        ModDate = c.DateTime(nullable: false),
                        SetupUser = c.String(nullable: false),
                        SetupDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AddressHistoryId)
                .ForeignKey("dbo.Addresses", t => t.AddressId, cascadeDelete: true)
                .Index(t => t.AddressId);
            
            CreateTable(
                "dbo.StudentAddressHistories",
                c => new
                    {
                        StudentAddressHistoryId = c.Int(nullable: false, identity: true),
                        StudentAddressId = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                        AddressId = c.Int(nullable: false),
                        ModUser = c.String(nullable: false),
                        ModDate = c.DateTime(nullable: false),
                        SetupUser = c.String(nullable: false),
                        SetupDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.StudentAddressHistoryId)
                .ForeignKey("dbo.StudentAddresses", t => t.StudentAddressId, cascadeDelete: true)
                .Index(t => t.StudentAddressId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentAddresses", "StudentId", "dbo.Students");
            DropForeignKey("dbo.StudentAddressHistories", "StudentAddressId", "dbo.StudentAddresses");
            DropForeignKey("dbo.StudentAddresses", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.AddressHistories", "AddressId", "dbo.Addresses");
            DropIndex("dbo.StudentAddressHistories", new[] { "StudentAddressId" });
            DropIndex("dbo.AddressHistories", new[] { "AddressId" });
            DropIndex("dbo.StudentAddresses", new[] { "AddressId" });
            DropIndex("dbo.StudentAddresses", new[] { "StudentId" });
            DropTable("dbo.StudentAddressHistories");
            DropTable("dbo.AddressHistories");
            DropTable("dbo.Addresses");
            DropTable("dbo.StudentAddresses");
        }
    }
}
