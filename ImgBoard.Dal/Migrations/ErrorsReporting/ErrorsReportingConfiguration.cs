namespace ImgBoard.Dal.Migrations.ErrorsReporting
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class ErrorsReportingConfiguration : DbMigrationsConfiguration<ImgBoard.Dal.Context.EndObjects.ErrorsReportingContext>
    {
        public ErrorsReportingConfiguration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\ErrorsReporting";
        }

        protected override void Seed(ImgBoard.Dal.Context.EndObjects.ErrorsReportingContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
