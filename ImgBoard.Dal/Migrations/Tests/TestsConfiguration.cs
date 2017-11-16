namespace ImgBoard.Dal.Migrations.Tests
{
    using ImgBoard.Dal.Models.Main;
    using System;
    using System.Collections.Generic;
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

        }
    }
}
