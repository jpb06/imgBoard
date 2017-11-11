namespace ImgBoard.Dal.Migrations.Tests
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 256),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdCategory = c.Int(),
                        IdUploader = c.Int(nullable: false),
                        Name = c.String(maxLength: 128),
                        Description = c.String(maxLength: 512),
                        FileId = c.Guid(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.IdUploader, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.IdCategory)
                .Index(t => t.IdCategory)
                .Index(t => t.IdUploader);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdCreator = c.Int(nullable: false),
                        IdImage = c.Int(nullable: false),
                        Message = c.String(nullable: false, maxLength: 1024),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.IdCreator)
                .ForeignKey("dbo.Images", t => t.IdImage)
                .Index(t => t.IdCreator)
                .Index(t => t.IdImage);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(nullable: false, maxLength: 128),
                        Password = c.String(nullable: false, maxLength: 128),
                        UserName = c.String(nullable: false, maxLength: 128),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 128),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ImagesTags",
                c => new
                    {
                        idImage = c.Int(nullable: false),
                        idTag = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.idImage, t.idTag })
                .ForeignKey("dbo.Images", t => t.idImage, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.idTag, cascadeDelete: true)
                .Index(t => t.idImage)
                .Index(t => t.idTag);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Images", "IdCategory", "dbo.Categories");
            DropForeignKey("dbo.ImagesTags", "idTag", "dbo.Tags");
            DropForeignKey("dbo.ImagesTags", "idImage", "dbo.Images");
            DropForeignKey("dbo.Comments", "IdImage", "dbo.Images");
            DropForeignKey("dbo.Comments", "IdCreator", "dbo.Users");
            DropForeignKey("dbo.Images", "IdUploader", "dbo.Users");
            DropIndex("dbo.ImagesTags", new[] { "idTag" });
            DropIndex("dbo.ImagesTags", new[] { "idImage" });
            DropIndex("dbo.Comments", new[] { "IdImage" });
            DropIndex("dbo.Comments", new[] { "IdCreator" });
            DropIndex("dbo.Images", new[] { "IdUploader" });
            DropIndex("dbo.Images", new[] { "IdCategory" });
            DropTable("dbo.ImagesTags");
            DropTable("dbo.Tags");
            DropTable("dbo.Users");
            DropTable("dbo.Comments");
            DropTable("dbo.Images");
            DropTable("dbo.Categories");
        }
    }
}
