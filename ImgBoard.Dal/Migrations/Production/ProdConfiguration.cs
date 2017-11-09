namespace ImgBoard.Dal.Migrations.Production
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class ProdConfiguration : DbMigrationsConfiguration<ImgBoard.Dal.Context.EndObjects.ImgBoardContext>
    {
        public ProdConfiguration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\Production";
        }

        protected override void Seed(ImgBoard.Dal.Context.EndObjects.ImgBoardContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
