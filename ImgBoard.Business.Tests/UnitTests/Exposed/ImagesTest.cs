using ImgBoard.Business.Exposed;
using ImgBoard.Dal.Models.Main;
using ImgBoard.Models.Main;
using ImgBoard.Shared.Tests.Data.Database.DataSets;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImgBoard.Business.Tests.UnitTests.Exposed
{
    [TestFixture]
    public class ImagesTest
    {
        private PersistentMainDataSet dataSet;

        public ImagesTest()
        {
            Configuration.InversionOfControl.Initialize(); // dirty trick

            this.dataSet = new PersistentMainDataSet();
        }

        [OneTimeSetUp]
        public void Init()
        {
            this.dataSet.Initialize();
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            this.dataSet.Destroy();
            this.dataSet.Dispose();
        }

        [Test]
        public async Task FetchImagesAsync_ByOneCat()
        {
            List<Image> images = await Images.GetAsync(
                categoriesIds: new int[] { this.dataSet.CategoriesIds.ElementAt(0) }
            );

            Assert.AreEqual(3, images.Count);
        }

        [Test]
        public async Task FetchImagesAsync_ByTwoCats()
        {
            List<Image> images = await Images.GetAsync(
                categoriesIds: new int[] 
                {
                    this.dataSet.CategoriesIds.ElementAt(0),
                    this.dataSet.CategoriesIds.ElementAt(1)
                }
            );

            Assert.AreEqual(5, images.Count);
        }

        [Test]
        public async Task FetchImagesAsync_ByOneTag()
        {
            List<Image> images = await Images.GetAsync(
                tagsIds: new int[] { this.dataSet.TagsIds.ElementAt(0) }
            );

            Assert.AreEqual(5, images.Count);
        }

        [Test]
        public async Task FetchImagesAsync_ByTwoTags()
        {
            List<Image> images = await Images.GetAsync(
                tagsIds: new int[] 
                { 
                    this.dataSet.TagsIds.ElementAt(0),
                    this.dataSet.TagsIds.ElementAt(1)
                });

            Assert.AreEqual(8, images.Count);
        }

        [Test]
        public async Task FetchImagesAsync_ByName()
        {
            List<Image> images = await Images.GetAsync(name: "image");

            Assert.AreEqual(7, images.Count);
        }

        [Test]
        public async Task FetchImagesAsync_ByDescription()
        {
            List<Image> images = await Images.GetAsync(description: "Description");

            Assert.AreEqual(5, images.Count);
        }

        [Test]
        public async Task FetchImagesAsync_ByUploader()
        {
            List<Image> images = await Images.GetAsync(uploader: "a");

            Assert.AreEqual(5, images.Count);
        }

        [Test]
        public async Task FetchImagesAsync_ByExtension()
        {
            List<Image> images = await Images.GetAsync(extension: "jpg");

            Assert.AreEqual(3, images.Count);
        }

        [Test]
        public async Task FetchImagesAsync_All()
        {
            List<Image> images = await Images.GetAsync(
                tagsIds: new int[] { this.dataSet.TagsIds.ElementAt(0) },
                categoriesIds: new int[] { this.dataSet.CategoriesIds.ElementAt(0) },
                name: "image",
                description: "image",
                uploader: "a",
                extension: "jpg"
            );

            Assert.AreEqual(1, images.Count);
        }

        [Test]
        public async Task FetchImagesAsync_Half()
        {
            List<Image> images = await Images.GetAsync(
                categoriesIds: new int[] 
                {
                    this.dataSet.CategoriesIds.ElementAt(0),
                    this.dataSet.CategoriesIds.ElementAt(1)
                },
                description: "image",
                extension: "jpg"
            );

            Assert.AreEqual(1, images.Count);
        }
    }
}
