﻿using ImgBoard.Business.Internal.Persistence.Contracts;
using ImgBoard.Dal.Models.Main;
using ImgBoard.Models.Main;
using ImgBoard.Shared.Tests.Data.Mocked;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImgBoard.Business.Internal.Model;

namespace ImgBoard.Business.Tests.UnitTests.Internal.Persistence
{
    [TestFixture]
    public class MockCategoriesManagerTest
    {
        ICategoriesManager categoriesManager;

        public MockCategoriesManagerTest() { }

        [Test]
        public async Task FetchCategoriesWithMatchingTitle_All()
        {
            VolatileMainDataset dataSet = new VolatileMainDataset();
            Mock<ICategoriesManager> mockService = new Mock<ICategoriesManager>();

            mockService.Setup(s => s.FetchCategoriesWithMatchingTitle(It.IsAny<string>()))
                       .Returns<string>(term => Task.FromResult<List<Category>>(
                           dataSet.Categories
                               .Where(el => el.Title.Contains(term))
                               .Select(el => el.ToExposed())
                               .ToList())
                       );
            this.categoriesManager = mockService.Object;

            List<Category> categories = await this.categoriesManager.FetchCategoriesWithMatchingTitle("Category");

            Assert.AreEqual(5, categories.Count);
        }

        [Test]
        public async Task FetchCategoriesWithMatchingTitle_One()
        {
            VolatileMainDataset dataSet = new VolatileMainDataset();
            Mock<ICategoriesManager> mockService = new Mock<ICategoriesManager>();

            mockService.Setup(s => s.FetchCategoriesWithMatchingTitle(It.IsAny<string>()))
                       .Returns<string>(term => Task.FromResult<List<Category>>(
                           dataSet.Categories
                               .Where(el => el.Title.Contains(term))
                               .Select(el => el.ToExposed())
                               .ToList())
                       );
            this.categoriesManager = mockService.Object;

            List<Category> categories = await this.categoriesManager.FetchCategoriesWithMatchingTitle("1");

            Assert.AreEqual(1, categories.Count);
        }
    }
}
