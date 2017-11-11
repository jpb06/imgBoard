using ImgBoard.Dal.Context.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImgBoard.Dal.Context.EndObjects
{
    // https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/powershell
    // Get-Help EntityFramework

    // Enable-Migrations
    // Add-Migration <name>
    // Update-Database

    // -------------------------------------------------

    // Enable-Migrations -MigrationsDirectory "Migrations\Tests" -ContextTypeName ImgBoard.Dal.Context.EndObjects.ImgBoardTestContext

    // Add-Migration -ConfigurationTypeName TestsConfiguration -Name <something>

    // Update-Database -ConfigurationTypeName TestsConfiguration

    public class ImgBoardTestContext : ImgBoardBaseContext
    {
        public ImgBoardTestContext() : base("name=ImgBoardTestContext") { }
    }
}
