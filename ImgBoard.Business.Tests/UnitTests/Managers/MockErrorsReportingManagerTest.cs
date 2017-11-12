using ImgBoard.Business.Internal.Contracts;
using ImgBoard.Models.ErrorsReporting;
using ImgBoard.Shared.Tests.Data.Mocked;
using ImgBoard.Shared.Tests.Exceptions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ImgBoard.Business.Tests.UnitTests.Managers
{
    [TestFixture]
    public class MockErrorsReportingManagerTest
    {
        IErrorsReportingManager errorsReportingManager;

        public MockErrorsReportingManagerTest() { }

        [Test]
        public void LogErrorAsync()
        {
            VolatileErrorsReportingDataset store = new VolatileErrorsReportingDataset();

            Mock<IErrorsReportingManager> mockManager = new Mock<IErrorsReportingManager>();
            mockManager.Setup(m => m.LogErrorAsync(It.IsAny<Exception>(),
                                                   It.IsAny<AssemblyName>(),
                                                   It.IsAny<string>()))
                       .Returns(Task.FromResult<object>(null))
                       .Callback<Exception, AssemblyName, string>((exception, assemblyName, errorCode) =>
                       {
                           store.Exceptions.Add(new ErrorReportException
                           {
                               Id = 1,
                               IdApplication = store.Applications.First().Id,
                               Type = exception.GetType().ToString(),
                               Message = exception.Message,
                               Source = exception.Source,
                               SiteModule = (exception.TargetSite != null && exception.TargetSite.Module != null) ? exception.TargetSite.Module.Name : null,
                               SiteName = exception.TargetSite.Name,
                               StackTrace = exception.StackTrace,
                               HelpLink = exception.HelpLink,
                               Date = DateTime.Now,
                               CustomErrorType = errorCode
                           });
                       }).Verifiable();
            this.errorsReportingManager = mockManager.Object;

            try
            {
                ExceptionGenerator.ThrowsOne();
            }
            catch (Exception exception)
            {
                Assert.That(async () =>
                {
                    await this.errorsReportingManager.LogErrorAsync(exception,
                                                                    Assembly.GetExecutingAssembly().GetName(),
                                                                    "ErrorType.Specific");
                }, Throws.Nothing);

                mockManager.Verify(m => m.LogErrorAsync(It.IsAny<Exception>(), It.IsAny<AssemblyName>(), It.IsAny<string>()), Times.Once());
                Assert.AreEqual(1, store.Exceptions.Count);
            }
        }
    }
}
