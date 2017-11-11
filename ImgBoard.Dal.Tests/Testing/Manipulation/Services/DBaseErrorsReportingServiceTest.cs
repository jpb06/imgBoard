using ImgBoard.Dal.Context.Contracts;
using ImgBoard.Dal.Context.EndObjects;
using ImgBoard.Dal.Exceptions;
using ImgBoard.Dal.Exceptions.CustomTypes;
using ImgBoard.Dal.Manipulation.Repositories.Contracts;
using ImgBoard.Dal.Manipulation.Repositories.Implementation.Base;
using ImgBoard.Dal.Manipulation.Services.ErrorsReporting;
using ImgBoard.Dal.Manipulation.Services.ErrorsReporting.Contracts;
using ImgBoard.Models.ErrorsReporting;
using ImgBoard.Shared.Tests.Data.Database;
using ImgBoard.Shared.Tests.Data.Database.DataSets;
using ImgBoard.Shared.Tests.Data.Database.Primitives.ErrorsReporting;
using ImgBoard.Shared.Tests.Exceptions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Lifetime;

namespace ImgBoard.Dal.Tests.Testing.Manipulation.Services
{
    [TestFixture]
    public class DBaseErrorsReportingServiceTest
    {
        private UnityContainer container;
        private PersistentErrorsReportingDataSet dataSet;
        private SqlConnection connection;
        private ExceptionsSqlHelper exceptionsSqlHelper;

        public DBaseErrorsReportingServiceTest()
        {
            this.container = new UnityContainer();

            this.container.RegisterType<IDbContext, ErrorsReportingContext>(new HierarchicalLifetimeManager());
            this.container.RegisterType(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            this.container.RegisterType<IErrorsReportingService, ErrorsReportingService>();

            this.dataSet = new PersistentErrorsReportingDataSet();

            this.connection = new SqlConnection(DatabaseConfiguration.ErrorsReportingConnectionString);
            this.exceptionsSqlHelper = new ExceptionsSqlHelper(this.connection);
        }

        [OneTimeSetUp]
        public void Init()
        {
            this.dataSet.Initialize();
            this.connection.Open();
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            this.connection.Close();
            this.dataSet.Destroy();
            this.dataSet.Dispose();
        }

        [Test]
        public async Task Db_ErrorsReportingService_CreateApplicationAsync()
        {
            using (IUnityContainer childContainer = this.container.CreateChildContainer())
            {
                IErrorsReportingService service = childContainer.Resolve<IErrorsReportingService>();
                ErrorReportApplication result = await service.CreateApplicationAsync("TestApplication", "a.a.a.a");

                Assert.IsNotNull(result);
                Assert.Greater(result.Id, 0);

                this.dataSet.ApplicationsIds.Add(result.Id);
            }
        }

        [Test]
        public void Db_ErrorsReportingService_CreateApplicationAsync_AlreadyExists()
        {
            using (IUnityContainer childContainer = this.container.CreateChildContainer())
            {
                IErrorsReportingService service = childContainer.Resolve<IErrorsReportingService>();

                DalException ex = Assert.ThrowsAsync<DalException>(async () =>
                {
                    await service.CreateApplicationAsync("TestApplicationAlreadyExisting", "a.a.a.a");
                });
                Assert.That(ex.errorType, Is.EqualTo(DalErrorType.SqlUniqueConstraintViolation));
            }
        }

        [Test]
        public async Task Db_ErrorsReportingService_GetApplicationAsync()
        {
            using (IUnityContainer childContainer = this.container.CreateChildContainer())
            {
                IErrorsReportingService service = childContainer.Resolve<IErrorsReportingService>();
                ErrorReportApplication application = await service.GetApplicationAsync("TestApplicationAlreadyExisting", "a.a.a.a");

                Assert.Greater(application.Id, 0);
                Assert.AreEqual(new DateTime(2000, 1, 1), application.FirstRunDate);
            }
        }

        [Test]
        public void Db_ErrorsReportingService_GetApplicationAsync_NotExisting()
        {
            using (IUnityContainer childContainer = this.container.CreateChildContainer())
            {
                IErrorsReportingService service = childContainer.Resolve<IErrorsReportingService>();
                ErrorReportApplication application = null;
                Assert.That(async () =>
                {
                    application = await service.GetApplicationAsync("TestApplicationAlreadyExisting", "z.z.z.z");
                }, Throws.Nothing);

                Assert.IsNull(application);
            }
        }

        [Test]
        public void Db_ErrorsReportingService_LogExceptionAsync()
        {
            using (IUnityContainer childContainer = this.container.CreateChildContainer())
            {
                IErrorsReportingService service = childContainer.Resolve<IErrorsReportingService>();

                try
                {
                    ExceptionGenerator.ThrowsOne();
                }
                catch (Exception exception)
                {
                    int? id = null;
                    Assert.That(async () =>
                    {
                        id = await service.LogExceptionAsync(this.dataSet.ApplicationsIds.ElementAt(0), exception, "ErrorType.Specific");
                    }, Throws.Nothing);

                    Assert.IsNotNull(id);

                    ErrorReportException ex = this.exceptionsSqlHelper.GetBy(id.Value);

                    Assert.AreEqual("One", ex.Message);
                }
            }
        }

        [Test]
        public void Db_ErrorsReportingService_LogExceptionAsync_WithInner()
        {
            using (IUnityContainer childContainer = this.container.CreateChildContainer())
            {
                IErrorsReportingService service = childContainer.Resolve<IErrorsReportingService>();

                try
                {
                    ExceptionGenerator.ThrowsTwo();
                }
                catch (Exception exception)
                {
                    int? id = null;
                    Assert.That(async () =>
                    {
                        id = await service.LogExceptionAsync(this.dataSet.ApplicationsIds.ElementAt(0), exception, "ErrorType.Specific");
                    }, Throws.Nothing);

                    Assert.IsNotNull(id);

                    ErrorReportException ex = this.exceptionsSqlHelper.GetBy(id.Value);
                    ErrorReportException innerEx = this.exceptionsSqlHelper.GetBy(ex.IdInnerException.Value);

                    Assert.AreEqual("Two", ex.Message);
                    Assert.AreEqual("One", innerEx.Message);
                }
            }
        }
    }
}
