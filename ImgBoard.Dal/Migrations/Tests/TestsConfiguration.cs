namespace ImgBoard.Dal.Migrations.Tests
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class TestsConfiguration : DbMigrationsConfiguration<ImgBoard.Dal.Context.EndObjects.ImgBoardTestContext>
    {
        public TestsConfiguration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\Tests";
        }

        protected override void Seed(ImgBoard.Dal.Context.EndObjects.ImgBoardTestContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
