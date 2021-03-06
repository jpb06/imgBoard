﻿using ImgBoard.Dal.Context.Contracts;
using ImgBoard.Dal.Context.EndObjects;
using ImgBoard.Dal.Manipulation.Repositories.Implementation.Base;
using ImgBoard.Dal.Models.Main;
using ImgBoard.Models.Main;
using ImgBoard.Shared.Tests.Data.Database.DataSets;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImgBoard.Dal.Tests.Testing.Manipulation.Repositories
{
    [TestFixture]
    public class DBaseGenericRepositoryTest
    {
        private IImgBoardContext context;
        private GenericRepository<DbCategory> repository;
        private PersistentMainDataSet dataSet;
        private DbCategory addCategory;

        public DBaseGenericRepositoryTest()
        {
            this.dataSet = new PersistentMainDataSet();
        }

        [OneTimeSetUp]
        public void Init()
        {
            this.context = new ImgBoardTestContext();
            this.repository = new GenericRepository<DbCategory>(this.context);
            this.dataSet.Initialize();
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            this.dataSet.Destroy();
            this.dataSet.Dispose();
            this.context.Dispose();
        }

        [Test, Order(1)]
        public void Db_Repository_Insert()
        {
            this.addCategory = new DbCategory
            {
                Title = "Category 4"
            };

            repository.Insert(this.addCategory);
            int result = this.context.SaveChanges();

            Assert.AreEqual(1, result);
        }

        [Test, Order(2)]
        public void Db_Repository_Update()
        {
            this.addCategory.Title = "Category 4 updated";

            this.repository.Update(this.addCategory);
            int result = this.context.SaveChanges();

            Assert.AreEqual(1, result);

        }

        [Test, Order(3)]
        public void Db_Repository_GetById()
        {
            DbCategory category = this.repository.GetById(this.addCategory.Id);

            Assert.IsNotNull(category);
            Assert.AreEqual(this.addCategory.Title, category.Title);
        }

        [Test]
        public void Db_Repository_GetById_DoesntExist()
        {
            DbCategory category = this.repository.GetById(0);

            Assert.AreEqual(null, category);
        }

        [Test, Order(5)]
        public void Db_Repository_Delete()
        {
            this.repository.Delete(this.addCategory);
            int result = this.context.SaveChanges();

            Assert.AreEqual(1, result);
        }

        [Test]
        public void Db_Repository_DeleteById()
        {
            DbCategory category = new DbCategory
            {
                Title = "Category to delete"
            };

            this.repository.Insert(category);
            this.context.SaveChanges();

            this.repository.Delete(category.Id);
            this.context.SaveChanges();

            DbCategory deletedCategory = this.repository.GetById(category.Id);

            Assert.IsNull(deletedCategory);
        }

        [Test]
        public void Db_Repository_Get_Filtered()
        {
            var categories = this.repository.Get(cat => cat.Title.Contains("2") || cat.Title.Contains("3"));

            Assert.AreEqual(2, categories.Count());
        }

        [Test]
        public void Db_Repository_Get_Ordered()
        {
            var categories = this.repository.Get(orderBy: q => q.OrderByDescending(c => c.Id));

            Assert.AreEqual(3, categories.Count());
            Assert.AreEqual("Test Category 3", categories.First().Title);
            Assert.AreEqual("Test Category 1", categories.ElementAt(2).Title);

        }

        [Test]
        public void Db_Repository_Get_FilteredAndOrdered()
        {
            var categories = this.repository.Get(filter: cat => cat.Title.Contains("2") || cat.Title.Contains("3"),
                                                 orderBy: q => q.OrderByDescending(c => c.Id));

            Assert.AreEqual(2, categories.Count());
            Assert.AreEqual("Test Category 3", categories.First().Title);
            Assert.AreEqual("Test Category 2", categories.Last().Title);
        }

        [Test]
        public void Db_Repository_GetWithRawSql()
        {
            var param = new SqlParameter("title", "Test Category 3");
            var categories = this.repository.GetWithRawSql("SELECT * FROM [dbo].[Categories] WHERE [Categories].[Title] = @title;", param);

            Assert.AreEqual(1, categories.Count());
        }

        #region Async
        [Test, Order(4)]
        public async Task Db_Repository_GetByIdAsync()
        {
            DbCategory category = await this.repository.GetByIdAsync(this.addCategory.Id);

            Assert.IsNotNull(category);
            Assert.AreEqual(this.addCategory.Title, category.Title);
            Assert.AreEqual(this.addCategory.RowVersion, category.RowVersion);
        }

        [Test]
        public async Task Db_Repository_GetByIdAsync_DoesntExist()
        {
            DbCategory category = await this.repository.GetByIdAsync(0);

            Assert.AreEqual(null, category);
        }

        [Test]
        public async Task Db_Repository_GetAsync_Filtered()
        {
            var article = await this.repository.GetAsync(cat => cat.Title.Contains("2") || cat.Title.Contains("3"));

            Assert.AreEqual(2, article.Count());
        }

        [Test]
        public async Task Db_Repository_GetAsync_Ordered()
        {
            var categories = await this.repository.GetAsync(orderBy: q => q.OrderByDescending(c => c.Id));

            Assert.AreEqual(3, categories.Count());
            Assert.AreEqual("Test Category 3", categories.First().Title);
            Assert.AreEqual("Test Category 1", categories.ElementAt(2).Title);

        }

        [Test]
        public async Task Db_Repository_GetAsync_FilteredAndOrdered()
        {
            var article = await this.repository.GetAsync(
                filter: cat => cat.Title.Contains("2") || cat.Title.Contains("3"),
                orderBy: q => q.OrderByDescending(c => c.Id));

            Assert.AreEqual(2, article.Count());
            Assert.AreEqual("Test Category 3", article.First().Title);
            Assert.AreEqual("Test Category 2", article.Last().Title);
        }
        #endregion
    }
}
