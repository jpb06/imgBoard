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
        private IImagesManager imagesManager;

        public MockImagesManagerTest() { }

        [Test]
        public async Task FetchImagesAsync_ByOneCat()
        {
            VolatileMainDataset dataSet = new VolatileMainDataset();
            Mock<IImagesManager> mockService = new Mock<IImagesManager>();

            mockService
                .Setup(s => s.FetchImagesAsync(null, It.IsAny<int[]>(), null, null, null, null))
                .Returns<int[], int[], string, string, string, string> (
                    (tagsIds, categoriesIds, name, description, uploader, extension) => 
                        Task.FromResult<List<DbImage>>(dataSet.Images.Where(i => 
                            (i.IdCategory.HasValue && categoriesIds.Contains(i.IdCategory.Value))
                        ).ToList()));
            this.imagesManager = mockService.Object;

            List<DbImage> images = await this.imagesManager.FetchImagesAsync(categoriesIds:new int[] { 1 });

            Assert.AreEqual(6, images.Count);
        }

        [Test]
        public async Task FetchImagesAsync_ByTwoCats()
        {
            VolatileMainDataset dataSet = new VolatileMainDataset();
            Mock<IImagesManager> mockService = new Mock<IImagesManager>();

            mockService
                .Setup(s => s.FetchImagesAsync(null, It.IsAny<int[]>(), null, null, null, null))
                .Returns<int[], int[], string, string, string, string>(
                    (tagsIds, categoriesIds, name, description, uploader, extension) =>
                        Task.FromResult<List<DbImage>>(dataSet.Images.Where(i => 
                            (i.IdCategory.HasValue && categoriesIds.Contains(i.IdCategory.Value))
                        ).ToList()));
            this.imagesManager = mockService.Object;

            List<DbImage> images = await this.imagesManager.FetchImagesAsync(categoriesIds: new int[] { 1, 2 });

            Assert.AreEqual(7, images.Count);
        }

        [Test]
        public async Task FetchImagesAsync_ByOneTag()
        {
            VolatileMainDataset dataSet = new VolatileMainDataset();
            Mock<IImagesManager> mockService = new Mock<IImagesManager>();

            mockService
                .Setup(s => s.FetchImagesAsync(It.IsAny<int[]>(), null, null, null, null, null))
                .Returns<int[], int[], string, string, string, string>(
                    (tagsIds, categoriesIds, name, description, uploader, extension) =>
                        Task.FromResult<List<DbImage>>(dataSet.Images.Where(i => 
                            i.Tags.Any(t => tagsIds.Contains(t.Id))
                        ).ToList()));
            this.imagesManager = mockService.Object;

            List<DbImage> images = await this.imagesManager.FetchImagesAsync(tagsIds: new int[] { 1 });

            Assert.AreEqual(5, images.Count);
        }

        [Test]
        public async Task FetchImagesAsync_ByTwoTags()
        {
            VolatileMainDataset dataSet = new VolatileMainDataset();
            Mock<IImagesManager> mockService = new Mock<IImagesManager>();

            mockService
                .Setup(s => s.FetchImagesAsync(It.IsAny<int[]>(), null, null, null, null, null))
                .Returns<int[], int[], string, string, string, string>(
                    (tagsIds, categoriesIds, name, description, uploader, extension) =>
                        Task.FromResult<List<DbImage>>(dataSet.Images.Where(i => 
                            i.Tags.Any(t => tagsIds.Contains(t.Id))
                        ).ToList()));
            this.imagesManager = mockService.Object;

            List<DbImage> images = await this.imagesManager.FetchImagesAsync(tagsIds: new int[] { 1, 3 });

            Assert.AreEqual(6, images.Count);
        }

        [Test]
        public async Task FetchImagesAsync_ByName()
        {
            VolatileMainDataset dataSet = new VolatileMainDataset();
            Mock<IImagesManager> mockService = new Mock<IImagesManager>();

            mockService
                .Setup(s => s.FetchImagesAsync(null, null, It.IsAny<string>(), null, null, null))
                .Returns<int[], int[], string, string, string, string>(
                    (tagsIds, categoriesIds, name, description, uploader, extension) =>
                        Task.FromResult<List<DbImage>>(dataSet.Images.Where(i => 
                            (i.Name != null && i.Name.Contains(name))
                        ).ToList()));
            this.imagesManager = mockService.Object;

            List<DbImage> images = await this.imagesManager.FetchImagesAsync(name: "name");

            Assert.AreEqual(9, images.Count);
        }

        [Test]
        public async Task FetchImagesAsync_ByDescription()
        {
            VolatileMainDataset dataSet = new VolatileMainDataset();
            Mock<IImagesManager> mockService = new Mock<IImagesManager>();

            mockService
                .Setup(s => s.FetchImagesAsync(null, null, null, It.IsAny<string>(), null, null))
                .Returns<int[], int[], string, string, string, string>(
                    (tagsIds, categoriesIds, name, description, uploader, extension) =>
                        Task.FromResult<List<DbImage>>(dataSet.Images.Where(i => 
                            (i.Description != null && i.Description.Contains(description))
                        ).ToList()));
            this.imagesManager = mockService.Object;

            List<DbImage> images = await this.imagesManager.FetchImagesAsync(description: "description");

            Assert.AreEqual(6, images.Count);
        }

        [Test]
        public async Task FetchImagesAsync_ByUploader()
        {
            VolatileMainDataset dataSet = new VolatileMainDataset();
            Mock<IImagesManager> mockService = new Mock<IImagesManager>();

            mockService
                .Setup(s => s.FetchImagesAsync(null, null, null, null, It.IsAny<string>(), null))
                .Returns<int[], int[], string, string, string, string>(
                    (tagsIds, categoriesIds, name, description, uploader, extension) =>
                        Task.FromResult<List<DbImage>>(dataSet.Images.Where(i => 
                            i.Uploader.Login.StartsWith(uploader)
                        ).ToList()));
            this.imagesManager = mockService.Object;

            List<DbImage> images = await this.imagesManager.FetchImagesAsync(uploader: "a");

            Assert.AreEqual(4, images.Count);
        }

        [Test]
        public async Task FetchImagesAsync_ByExtension()
        {
            VolatileMainDataset dataSet = new VolatileMainDataset();
            Mock<IImagesManager> mockService = new Mock<IImagesManager>();

            mockService
                .Setup(s => s.FetchImagesAsync(null, null, null, null, null, It.IsAny<string>()))
                .Returns<int[], int[], string, string, string, string>(
                    (tagsIds, categoriesIds, name, description, uploader, extension) =>
                        Task.FromResult<List<DbImage>>(dataSet.Images.Where(i => 
                            i.FileExtension == extension
                        ).ToList()));
            this.imagesManager = mockService.Object;

            List<DbImage> images = await this.imagesManager.FetchImagesAsync(extension: "jpg");

            Assert.AreEqual(4, images.Count);
        }

        [Test]
        public async Task FetchImagesAsync_All()
        {
            VolatileMainDataset dataSet = new VolatileMainDataset();
            Mock<IImagesManager> mockService = new Mock<IImagesManager>();

            mockService
                .Setup(s => s.FetchImagesAsync(
                    It.IsAny<int[]>(), 
                    It.IsAny<int[]>(), 
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(), 
                    It.IsAny<string>()))
                .Returns<int[], int[], string, string, string, string>(
                    (tagsIds, categoriesIds, name, description, uploader, extension) => 
                        Task.FromResult<List<DbImage>>(dataSet.Images.Where(i => 
                            (i.IdCategory.HasValue && categoriesIds.Contains(i.IdCategory.Value)) &&
                            (i.Tags.Any(t => tagsIds.Contains(t.Id))) &&
                            (i.Name != null && i.Name.Contains(name)) &&
                            (i.Description != null && i.Description.Contains(description)) &&
                            i.Uploader.Login.StartsWith(uploader) &&
                            i.FileExtension == extension
                        ).ToList()));
            this.imagesManager = mockService.Object;

            List<DbImage> images = await this.imagesManager.FetchImagesAsync(
                tagsIds: new int[] { 1, 3 },
                categoriesIds: new int[] { 3 },
                name: "Image", 
                description: "Image", 
                uploader: "b",
                extension: "gif"
            );

            Assert.AreEqual(1, images.Count);
        }

        [Test]
        public async Task FetchImagesAsync_Half()
        {
            VolatileMainDataset dataSet = new VolatileMainDataset();
            Mock<IImagesManager> mockService = new Mock<IImagesManager>();

            mockService
                .Setup(s => s.FetchImagesAsync(
                    null,
                    It.IsAny<int[]>(),
                    It.IsAny<string>(),
                    null,
                    null,
                    It.IsAny<string>()))
                .Returns<int[], int[], string, string, string, string>(
                    (tagsIds, categoriesIds, name, description, uploader, extension) =>
                        Task.FromResult<List<DbImage>>(dataSet.Images.Where(i =>
                            (i.IdCategory.HasValue && categoriesIds.Contains(i.IdCategory.Value)) &&
                            (i.Name != null && i.Name.Contains(name)) &&
                            i.FileExtension == extension
                        ).ToList()));
            this.imagesManager = mockService.Object;

            List<DbImage> images = await this.imagesManager.FetchImagesAsync(
                categoriesIds: new int[] { 3 },
                name: "Image",
                extension: "gif"
            );

            Assert.AreEqual(2, images.Count);
        }
    }
}
