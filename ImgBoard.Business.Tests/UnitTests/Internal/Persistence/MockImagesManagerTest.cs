using ImgBoard.Business.Internal.Persistence.Contracts;
using ImgBoard.Dal.Models.Main;
using ImgBoard.Shared.Tests.Data.Mocked;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImgBoard.Business.Tests.UnitTests.Internal.Persistence
{
    [TestFixture]
    public class MockImagesManagerTest
    {
        IImagesManager imagesManager;

        public MockImagesManagerTest() { }

        [Test]
        public async Task FetchImagesAsync()
        {
            VolatileMainDataset dataSet = new VolatileMainDataset();
            Mock<IImagesManager> mockService = new Mock<IImagesManager>();

            mockService.Setup(s => s.FetchImagesAsync())
                       .ReturnsAsync(dataSet.Images);
            this.imagesManager = mockService.Object;

            List<DbImage> images = await this.imagesManager.FetchImagesAsync();

            Assert.AreEqual(11, images.Count);
        }
        
        [Test]
        public async Task FetchImagesByCategoryAsync()
        {
            VolatileMainDataset dataSet = new VolatileMainDataset();
            Mock<IImagesManager> mockService = new Mock<IImagesManager>();

            mockService.Setup(s => s.FetchImagesByCategoryAsync(It.IsAny<int>()))
                       .Returns<int>(categoryId => Task.FromResult<List<DbImage>>(dataSet.Images.Where(el => el.IdCategory == categoryId).ToList()));
            this.imagesManager = mockService.Object;

            List<DbImage> images = await this.imagesManager.FetchImagesByCategoryAsync(1);

            Assert.AreEqual(6, images.Count);
        }

        [Test]
        public async Task FetchTaggedImagesAsync()
        {
            VolatileMainDataset dataSet = new VolatileMainDataset();
            Mock<IImagesManager> mockService = new Mock<IImagesManager>();

            mockService.Setup(s => s.FetchTaggedImagesAsync(It.IsAny<int[]>()))
                       .Returns<int[]>(tagsIds => Task.FromResult<List<DbImage>>(dataSet.Tags.Where(el => tagsIds.Contains(el.Id))
                                                                                             .SelectMany(el => el.Images).ToList()));
            this.imagesManager = mockService.Object;

            List<DbImage> images = await this.imagesManager.FetchTaggedImagesAsync(new int[] { 1 });

            Assert.AreEqual(5, images.Count);
        }

        [Test]
        public async Task FetchTaggedImagesAsync_SeveralTags()
        {
            VolatileMainDataset dataSet = new VolatileMainDataset();
            Mock<IImagesManager> mockService = new Mock<IImagesManager>();

            mockService.Setup(s => s.FetchTaggedImagesAsync(It.IsAny<int[]>()))
                       .Returns<int[]>(tagsIds => Task.FromResult<List<DbImage>>(dataSet.Tags.Where(el => tagsIds.Contains(el.Id))
                                                                                             .SelectMany(el => el.Images).ToList()));
            this.imagesManager = mockService.Object;

            List<DbImage> images = await this.imagesManager.FetchTaggedImagesAsync(new int[] { 1, 3 });

            Assert.AreEqual(6, images.Count);
        }
    }
}
