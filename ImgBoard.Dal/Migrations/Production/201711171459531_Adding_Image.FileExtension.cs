namespace ImgBoard.Dal.Migrations.Production
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Adding_ImageFileExtension : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Images", "FileExtension", c => c.String(nullable: false, maxLength: 5));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Images", "FileExtension");
        }
    }
}
