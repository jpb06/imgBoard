using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImgBoard.Shared.Tests.Data.Database
{
    public static class DatabaseConfiguration
    {
        public static string MainConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["ImgBoardTestContext"].ConnectionString; }
        }
        public static string ErrorsReportingConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["ErrorsReportingContext"].ConnectionString; }
        }
    }
}
