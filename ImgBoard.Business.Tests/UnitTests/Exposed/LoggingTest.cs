using ImgBoard.Business.Exposed;
using ImgBoard.Business.InversionOfControl;
using ImgBoard.Business.Tests.AssemblyInformation;
using ImgBoard.Business.Tests.Exceptions;
using ImgBoard.Dal.Models.ErrorsReporting;
using ImgBoard.Shared.Tests.Data.Database;
using ImgBoard.Shared.Tests.Data.Database.Primitives.ErrorsReporting;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ImgBoard.Business.Tests.UnitTests.Exposed
{
    [TestFixture]
    public class LoggingTest
    {
        private SqlConnection connection;
        private ExceptionsSqlHelper exceptionsSqlHelper;

        public LoggingTest()
        {
            this.connection = new SqlConnection(DatabaseConfiguration.ErrorsReportingConnectionString);
            this.exceptionsSqlHelper = new ExceptionsSqlHelper(this.connection);
        }

        [OneTimeSetUp]
        public void Init()
        {
            this.connection.Open();
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            this.connection.Close();
        }

        [Test]
        public async Task SaveAsync()
        {
            int a = 2, b = 0;

            try
            {
                int c = a / b;
            }
            catch (Exception exception)
            {
                AssemblyName assemblyName = AssemblyHelper.AssemblyName;
                await Logging.SaveAsync(exception, assemblyName, TestErrorType.DivideByZero);

                ErrorReportException savedException = this.exceptionsSqlHelper.GetBy(assemblyName.Name, assemblyName.Version.ToString());

                Assert.IsNotNull(savedException);

                this.exceptionsSqlHelper.Delete(savedException.Id);
            }
        }
    }
}
