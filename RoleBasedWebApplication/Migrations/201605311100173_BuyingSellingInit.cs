namespace RoleBasedWebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BuyingSellingInit : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Buyings", "ArtifactId", c => c.Int());
            AlterColumn("dbo.Buyings", "CharacterId", c => c.Int());
            AlterColumn("dbo.Sellings", "CharacterId", c => c.Int());
            AlterColumn("dbo.Sellings", "ArtifactId", c => c.Int());
            CreateIndex("dbo.Buyings", "ArtifactId");
            CreateIndex("dbo.Buyings", "CharacterId");
            CreateIndex("dbo.Sellings", "ArtifactId");
            CreateIndex("dbo.Sellings", "CharacterId");
            AddForeignKey("dbo.Buyings", "ArtifactId", "dbo.Artifacts", "Id");
            AddForeignKey("dbo.Buyings", "CharacterId", "dbo.Characters", "Id");
            AddForeignKey("dbo.Sellings", "ArtifactId", "dbo.Artifacts", "Id");
            AddForeignKey("dbo.Sellings", "CharacterId", "dbo.Characters", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sellings", "CharacterId", "dbo.Characters");
            DropForeignKey("dbo.Sellings", "ArtifactId", "dbo.Artifacts");
            DropForeignKey("dbo.Buyings", "CharacterId", "dbo.Characters");
            DropForeignKey("dbo.Buyings", "ArtifactId", "dbo.Artifacts");
            DropIndex("dbo.Sellings", new[] { "CharacterId" });
            DropIndex("dbo.Sellings", new[] { "ArtifactId" });
            DropIndex("dbo.Buyings", new[] { "CharacterId" });
            DropIndex("dbo.Buyings", new[] { "ArtifactId" });
            AlterColumn("dbo.Sellings", "ArtifactId", c => c.Int(nullable: false));
            AlterColumn("dbo.Sellings", "CharacterId", c => c.Int(nullable: false));
            AlterColumn("dbo.Buyings", "CharacterId", c => c.Int(nullable: false));
            AlterColumn("dbo.Buyings", "ArtifactId", c => c.Int(nullable: false));
        }
    }
}
