namespace BusinessSpecificLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Assets",
                c => new
                    {
                        AssetKey = c.Int(nullable: false, identity: true),
                        AssetName = c.String(nullable: false, maxLength: 70),
                        Description = c.String(unicode: false),
                        sys_active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AssetKey);
            
            CreateTable(
                "dbo.cat_Area",
                c => new
                    {
                        AreaKey = c.Int(nullable: false, identity: true),
                        Area = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.AreaKey);
            
            CreateTable(
                "dbo.cross_Emploee_Asset",
                c => new
                    {
                        EmploeeKey = c.Int(nullable: false),
                        AssetKey = c.Int(nullable: false),
                        DutyLevelKey = c.Int(),
                    })
                .PrimaryKey(t => new { t.EmploeeKey, t.AssetKey })
                .ForeignKey("dbo.cat_DutyLevel", t => t.DutyLevelKey)
                .ForeignKey("dbo.Emploee", t => t.EmploeeKey)
                .ForeignKey("dbo.Assets", t => t.AssetKey)
                .Index(t => t.EmploeeKey)
                .Index(t => t.AssetKey)
                .Index(t => t.DutyLevelKey);
            
            CreateTable(
                "dbo.cat_DutyLevel",
                c => new
                    {
                        DutyLevelKey = c.Int(nullable: false, identity: true),
                        DutyLevel = c.String(maxLength: 70),
                    })
                .PrimaryKey(t => t.DutyLevelKey);
            
            CreateTable(
                "dbo.Emploee",
                c => new
                    {
                        EmploeeKey = c.Int(nullable: false, identity: true),
                        DirectBossKey = c.Int(),
                        DepartmentKey = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 200),
                        Email = c.String(maxLength: 200),
                        EmailTwo = c.String(maxLength: 200),
                        PhoneOne = c.String(maxLength: 50),
                        PhoneTwo = c.String(maxLength: 50),
                        PhoneThree = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.EmploeeKey)
                .ForeignKey("dbo.Department", t => t.DepartmentKey)
                .ForeignKey("dbo.Emploee", t => t.DirectBossKey)
                .Index(t => t.DirectBossKey)
                .Index(t => t.DepartmentKey);
            
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        DepartmentKey = c.Int(nullable: false, identity: true),
                        LocationKey = c.Int(nullable: false),
                        Deparment = c.String(nullable: false, maxLength: 150),
                        Description = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.DepartmentKey)
                .ForeignKey("dbo.cat_Location", t => t.LocationKey)
                .Index(t => t.LocationKey);
            
            CreateTable(
                "dbo.cat_Location",
                c => new
                    {
                        LocationKey = c.Int(nullable: false, identity: true),
                        Location = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.LocationKey);
            
            CreateTable(
                "dbo.Company",
                c => new
                    {
                        CompanyKey = c.Int(nullable: false, identity: true),
                        LocationKey = c.Int(nullable: false),
                        CompanyName = c.String(nullable: false, maxLength: 200),
                        Description = c.String(maxLength: 200),
                        Address = c.String(unicode: false),
                        PhoneOne = c.String(maxLength: 50),
                        PhoneTwo = c.String(maxLength: 50),
                        Email = c.String(maxLength: 100),
                        sys_active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CompanyKey)
                .ForeignKey("dbo.cat_Location", t => t.LocationKey)
                .Index(t => t.LocationKey);
            
            CreateTable(
                "dbo.cross_Area_Asset",
                c => new
                    {
                        AssetKey = c.Int(nullable: false),
                        AreaKey = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AssetKey, t.AreaKey })
                .ForeignKey("dbo.Assets", t => t.AssetKey, cascadeDelete: true)
                .ForeignKey("dbo.cat_Area", t => t.AreaKey, cascadeDelete: true)
                .Index(t => t.AssetKey)
                .Index(t => t.AreaKey);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.cross_Emploee_Asset", "AssetKey", "dbo.Assets");
            DropForeignKey("dbo.Emploee", "DirectBossKey", "dbo.Emploee");
            DropForeignKey("dbo.Emploee", "DepartmentKey", "dbo.Department");
            DropForeignKey("dbo.Department", "LocationKey", "dbo.cat_Location");
            DropForeignKey("dbo.Company", "LocationKey", "dbo.cat_Location");
            DropForeignKey("dbo.cross_Emploee_Asset", "EmploeeKey", "dbo.Emploee");
            DropForeignKey("dbo.cross_Emploee_Asset", "DutyLevelKey", "dbo.cat_DutyLevel");
            DropForeignKey("dbo.cross_Area_Asset", "AreaKey", "dbo.cat_Area");
            DropForeignKey("dbo.cross_Area_Asset", "AssetKey", "dbo.Assets");
            DropIndex("dbo.cross_Area_Asset", new[] { "AreaKey" });
            DropIndex("dbo.cross_Area_Asset", new[] { "AssetKey" });
            DropIndex("dbo.Company", new[] { "LocationKey" });
            DropIndex("dbo.Department", new[] { "LocationKey" });
            DropIndex("dbo.Emploee", new[] { "DepartmentKey" });
            DropIndex("dbo.Emploee", new[] { "DirectBossKey" });
            DropIndex("dbo.cross_Emploee_Asset", new[] { "DutyLevelKey" });
            DropIndex("dbo.cross_Emploee_Asset", new[] { "AssetKey" });
            DropIndex("dbo.cross_Emploee_Asset", new[] { "EmploeeKey" });
            DropTable("dbo.cross_Area_Asset");
            DropTable("dbo.Company");
            DropTable("dbo.cat_Location");
            DropTable("dbo.Department");
            DropTable("dbo.Emploee");
            DropTable("dbo.cat_DutyLevel");
            DropTable("dbo.cross_Emploee_Asset");
            DropTable("dbo.cat_Area");
            DropTable("dbo.Assets");
        }
    }
}
