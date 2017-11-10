namespace ImgBoard.Dal.Migrations.ErrorsReporting
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Applications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        Version = c.String(nullable: false, maxLength: 128),
                        FirstRunDate = c.DateTime(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.Name, t.Version }, unique: true, name: "IX_NameAndVersion");
            
            CreateTable(
                "dbo.Exceptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdInnerException = c.Int(),
                        IdApplication = c.Int(nullable: false),
                        Type = c.String(nullable: false, maxLength: 512),
                        Message = c.String(nullable: false),
                        Source = c.String(nullable: false, maxLength: 512),
                        SiteModule = c.String(nullable: false, maxLength: 512),
                        SiteName = c.String(nullable: false, maxLength: 512),
                        StackTrace = c.String(nullable: false),
                        CustomErrorType = c.String(maxLength: 512),
                        HelpLink = c.String(maxLength: 512),
                        Date = c.DateTime(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Applications", t => t.IdApplication, cascadeDelete: true)
                .ForeignKey("dbo.Exceptions", t => t.IdInnerException)
                .Index(t => t.IdInnerException)
                .Index(t => t.IdApplication);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Exceptions", "IdInnerException", "dbo.Exceptions");
            DropForeignKey("dbo.Exceptions", "IdApplication", "dbo.Applications");
            DropIndex("dbo.Exceptions", new[] { "IdApplication" });
            DropIndex("dbo.Exceptions", new[] { "IdInnerException" });
            DropIndex("dbo.Applications", "IX_NameAndVersion");
            DropTable("dbo.Exceptions");
            DropTable("dbo.Applications");
        }
    }
}
