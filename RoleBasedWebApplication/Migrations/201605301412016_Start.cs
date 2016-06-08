namespace RoleBasedWebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Start : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ArtifactClasses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Artifacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        OrderWorth = c.Int(nullable: false),
                        SaleWorth = c.Int(nullable: false),
                        ArtifactImageId = c.Int(nullable: false),
                        ArtifactIconId = c.Int(nullable: false),
                        ArtifactClassId = c.Int(),
                        ArtifactTypeId = c.Int(),
                        Properties = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ArtifactClasses", t => t.ArtifactClassId)
                .ForeignKey("dbo.ArtifactIcons", t => t.ArtifactIconId, cascadeDelete: true)
                .ForeignKey("dbo.ArtifactImages", t => t.ArtifactImageId, cascadeDelete: true)
                .ForeignKey("dbo.ArtifactTypes", t => t.ArtifactTypeId)
                .Index(t => t.ArtifactImageId)
                .Index(t => t.ArtifactIconId)
                .Index(t => t.ArtifactClassId)
                .Index(t => t.ArtifactTypeId);
            
            CreateTable(
                "dbo.ArtifactIcons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Src = c.String(),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ArtifactImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Src = c.String(),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ArtifactTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Buyings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ArtifactId = c.Int(nullable: false),
                        CharacterId = c.Int(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CharacterAvatars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Avatar = c.String(),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Characters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        GoldDime = c.Int(nullable: false),
                        CharacterTypeId = c.Int(nullable: false),
                        CharacterRaseId = c.Int(nullable: false),
                        CharacterAvatarId = c.Int(nullable: false),
                        UserId = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CharacterAvatars", t => t.CharacterAvatarId, cascadeDelete: true)
                .ForeignKey("dbo.CharacterRases", t => t.CharacterRaseId, cascadeDelete: true)
                .ForeignKey("dbo.CharacterTypes", t => t.CharacterTypeId, cascadeDelete: true)
                .Index(t => t.CharacterTypeId)
                .Index(t => t.CharacterRaseId)
                .Index(t => t.CharacterAvatarId);
            
            CreateTable(
                "dbo.CharacterRases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CharacterTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sellings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        CharacterId = c.Int(nullable: false),
                        ArtifactId = c.Int(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Characters", "CharacterTypeId", "dbo.CharacterTypes");
            DropForeignKey("dbo.Characters", "CharacterRaseId", "dbo.CharacterRases");
            DropForeignKey("dbo.Characters", "CharacterAvatarId", "dbo.CharacterAvatars");
            DropForeignKey("dbo.Artifacts", "ArtifactTypeId", "dbo.ArtifactTypes");
            DropForeignKey("dbo.Artifacts", "ArtifactImageId", "dbo.ArtifactImages");
            DropForeignKey("dbo.Artifacts", "ArtifactIconId", "dbo.ArtifactIcons");
            DropForeignKey("dbo.Artifacts", "ArtifactClassId", "dbo.ArtifactClasses");
            DropIndex("dbo.Characters", new[] { "CharacterAvatarId" });
            DropIndex("dbo.Characters", new[] { "CharacterRaseId" });
            DropIndex("dbo.Characters", new[] { "CharacterTypeId" });
            DropIndex("dbo.Artifacts", new[] { "ArtifactTypeId" });
            DropIndex("dbo.Artifacts", new[] { "ArtifactClassId" });
            DropIndex("dbo.Artifacts", new[] { "ArtifactIconId" });
            DropIndex("dbo.Artifacts", new[] { "ArtifactImageId" });
            DropTable("dbo.Sellings");
            DropTable("dbo.CharacterTypes");
            DropTable("dbo.CharacterRases");
            DropTable("dbo.Characters");
            DropTable("dbo.CharacterAvatars");
            DropTable("dbo.Buyings");
            DropTable("dbo.ArtifactTypes");
            DropTable("dbo.ArtifactImages");
            DropTable("dbo.ArtifactIcons");
            DropTable("dbo.Artifacts");
            DropTable("dbo.ArtifactClasses");
        }
    }
}
