﻿using ImgBoard.Business.Exposed;
using ImgBoard.Business.Tests.Configuration;
using ImgBoard.Business.Tests.Exceptions;
using ImgBoard.Dal.Models.ErrorsReporting;
using ImgBoard.Shared.Tests.Data.Database;
using ImgBoard.Shared.Tests.Data.Database.Primitives.ErrorsReporting;
using NUnit.Framework;
using System;
using System.Data.SqlClient;
using System.Reflection;
using System.Threading.Tasks;

namespace ImgBoard.Business.Tests.UnitTests.Exposed
{
    [TestFixture]
    public class ErrorsLoggingTest
    {
        private SqlConnection connection;
        private ExceptionsSqlHelper exceptionsSqlHelper;

        public ErrorsLoggingTest()
        {
            Configuration.InversionOfControl.Initialize(); // dirty trick

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
                await ErrorsLogging.SaveAsync(exception, assemblyName, TestErrorType.DivideByZero);

                ErrorReportException savedException = this.exceptionsSqlHelper.GetBy(assemblyName.Name, assemblyName.Version.ToString());

                Assert.IsNotNull(savedException);

                this.exceptionsSqlHelper.Delete(savedException.Id);
            }
        }
    }
}
