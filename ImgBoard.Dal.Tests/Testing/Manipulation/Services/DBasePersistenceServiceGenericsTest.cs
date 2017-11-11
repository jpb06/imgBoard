using ImgBoard.Dal.Context.Contracts;
using ImgBoard.Dal.Context.EndObjects;
using ImgBoard.Dal.Exceptions;
using ImgBoard.Dal.Exceptions.CustomTypes;
using ImgBoard.Dal.Exceptions.CustomTypes.Specific;
using ImgBoard.Dal.Manipulation.Repositories.Contracts;
using ImgBoard.Dal.Manipulation.Repositories.Implementation.Base;
using ImgBoard.Dal.Manipulation.Repositories.Implementation.Specific;
using ImgBoard.Dal.Manipulation.Services.Main;
using ImgBoard.Dal.Manipulation.Services.Main.Configuration;
using ImgBoard.Dal.Manipulation.Services.Main.Contracts;
using ImgBoard.Models.Main;
using ImgBoard.Shared.Tests.Data.Database;
using ImgBoard.Shared.Tests.Data.Database.DataSets;
using ImgBoard.Shared.Tests.Data.Database.Primitives.Main;
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
    public class DBasePersistenceServiceGenericsTest
    {
        private UnityContainer container;
        private PersistentMainDataSet dataSet;
        private SqlConnection connection;
        private CategoriesSqlHelper categoriesSqlHelper;
        private Category category;

        public DBasePersistenceServiceGenericsTest()
        {
            this.container = new UnityContainer();

            this.container.RegisterType<IImgBoardContext, ImgBoardTestContext>(new HierarchicalLifetimeManager());
            this.container.RegisterType<ICategoryRepository, CategoryRepository>();
            this.container.RegisterType<ICommentRepository, CommentRepository>();
            this.container.RegisterType<IImageRepository, ImageRepository>();
            this.container.RegisterType<ITagRepository, TagRepository>();
            this.container.RegisterType<ICategoryRepository, CategoryRepository>();
            this.container.RegisterType<IUserRepository, UserRepository>();
            this.container.RegisterType<IBaseMainService, PersistenceService>();

            this.dataSet = new PersistentMainDataSet();

            this.connection = new SqlConnection(DatabaseConfiguration.MainConnectionString);
            this.categoriesSqlHelper = new CategoriesSqlHelper(this.connection);

            this.category = new Category
            {
                Title = "Category Title"
            };
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
        public async Task Db_SalesService_Concurrency_NoPolicy()
        {
            using (IUnityContainer childContainer = this.container.CreateChildContainer())
            {
                IBaseMainService service = childContainer.Resolve<IBaseMainService>();
                service.SetPolicy(DataConflictPolicy.NoPolicy);

                var category = await service.GetByIdAsync<Category>(this.dataSet.CategoriesIds.First());
                category.Title = "User 1 Category Title";

                this.categoriesSqlHelper.ModifyTitle(category.Id, "User 2 Category Title");

                DalException ex = Assert.ThrowsAsync<DalException>(async () =>
                {
                    await service.ModifyAsync(category);
                });
                Assert.That(ex.errorType, Is.EqualTo(DalErrorType.BaseServiceDataConflictWithNoPolicy));
            }
        }

        [Test]
        public async Task Db_SalesService_Concurrency_ClientWins()
        {
            using (IUnityContainer childContainer = this.container.CreateChildContainer())
            {
                IBaseMainService service = childContainer.Resolve<IBaseMainService>();
                service.SetPolicy(DataConflictPolicy.ClientWins);

                var category = await service.GetByIdAsync<Category>(this.dataSet.CategoriesIds.ElementAt(1));
                category.Title = "User 1 Category Title 2";

                this.categoriesSqlHelper.ModifyTitle(category.Id, "User 2 Category Title");

                Assert.That(async () =>
                {
                    await service.ModifyAsync(category);
                }, Throws.Nothing);

                var updatedCategory = await service.GetByIdAsync<Category>(this.dataSet.CategoriesIds.ElementAt(1));

                Assert.AreEqual("User 1 Category Title 2", updatedCategory.Title);
            }
        }

        [Test]
        public async Task Db_SalesService_Concurrency_DatabaseWins()
        {
            using (IUnityContainer childContainer = this.container.CreateChildContainer())
            {
                IBaseMainService service = childContainer.Resolve<IBaseMainService>();
                service.SetPolicy(DataConflictPolicy.DatabaseWins);

                var category = await service.GetByIdAsync<Category>(this.dataSet.CategoriesIds.ElementAt(2));
                category.Title = "User 1 Category Title 3";

                this.categoriesSqlHelper.ModifyTitle(category.Id, "User 2 Category Title 3");

                Assert.That(async () =>
                {
                    await service.ModifyAsync(category);
                }, Throws.Nothing);

                var updatedArticle = await service.GetByIdAsync<Category>(this.dataSet.CategoriesIds.ElementAt(2));

                Assert.AreEqual("User 2 Category Title 3", updatedArticle.Title);
            }
        }

        [Test]
        public async Task Db_SalesService_Concurrency_AskClient()
        {
            using (IUnityContainer childContainer = this.container.CreateChildContainer())
            {
                IBaseMainService service = childContainer.Resolve<IBaseMainService>();
                service.SetPolicy(DataConflictPolicy.AskClient);

                var category = await service.GetByIdAsync<Category>(this.dataSet.CategoriesIds.ElementAt(2));
                category.Title = "User 1 Category Title 4";

                this.categoriesSqlHelper.ModifyTitle(category.Id, "User 2 Category Title 4");

                DataConflictException dce = Assert.ThrowsAsync<DataConflictException>(async () =>
                {
                    await service.ModifyAsync(category);
                });
                Assert.AreEqual(DalErrorType.BaseServiceDataConflictWithAskClientPolicy, dce.errorType);

                Assert.IsInstanceOf(typeof(Category), dce.CurrentValues);
                Assert.IsInstanceOf(typeof(Category), dce.DatabaseValues);

                Category currentValues = (Category)dce.CurrentValues;
                Category databaseValues = (Category)dce.DatabaseValues;

                Assert.AreEqual(category.Id, databaseValues.Id);
                Assert.AreEqual("User 2 Category Title 4", databaseValues.Title);

                Assert.AreEqual(category.Id, currentValues.Id);
                Assert.AreEqual("User 1 Category Title 4", currentValues.Title);
            }
        }

        #region async
        [Test, Order(5)]
        public async Task Db_SalesService_CreateArticleAsync()
        {
            using (IUnityContainer childContainer = this.container.CreateChildContainer())
            {
                IBaseMainService service = childContainer.Resolve<IBaseMainService>();

                this.category.Id = 0;
                int result = await service.CreateAsync(this.category);

                Assert.Greater(this.category.Id, 0);
            }
        }

        [Test, Order(6)]
        public void Db_SalesService_UpdateArticleAsync()
        {
            string newTitle = "New Title";
            this.category.Title = newTitle;

            using (IUnityContainer childContainer = this.container.CreateChildContainer())
            {
                IBaseMainService service = childContainer.Resolve<IBaseMainService>();

                Assert.That(async () =>
                {
                    await service.ModifyAsync(this.category);
                }, Throws.Nothing);
            }
        }

        [Test, Order(7)]
        public void Db_SalesService_DeleteArticleAsync()
        {
            using (IUnityContainer childContainer = this.container.CreateChildContainer())
            {
                IBaseMainService service = childContainer.Resolve<IBaseMainService>();

                Assert.That(async () =>
                {
                    await service.DeleteAsync(this.category);
                }, Throws.Nothing);
            }
        }
        #endregion
    }
}
