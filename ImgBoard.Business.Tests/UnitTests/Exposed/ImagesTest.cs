using ImgBoard.Business.Exposed;
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
        public async Task GetAsync()
        {
            List<Image> images = await Images.GetAsync();

            Assert.AreEqual(7, images.Count);
        }

        [Test]
        public async Task GetAsync_ByCategory()
        {
            List<Image> images = await Images.GetAsync(categoryId:this.dataSet.CategoriesIds.First());

            Assert.AreEqual(2, images.Count);
        }

        [Test]
        public async Task GetAsync_ByTag()
        {
            List<Image> images = await Images.GetAsync(tagsIds:new int[] { this.dataSet.TagsIds.ElementAt(0) });

            Assert.AreEqual(4, images.Count);
        }

        [Test]
        public async Task GetAsync_ByTags()
        {
            List<Image> images = await Images.GetAsync(tagsIds: new int[] 
            {
                this.dataSet.TagsIds.ElementAt(0),
                this.dataSet.TagsIds.ElementAt(1)
            });

            Assert.AreEqual(7, images.Count);
        }

        [Test]
        public async Task GetAsync_ByTagsAndCategory()
        {
            List<Image> images = await Images.GetAsync(tagsIds: new int[]
            {
                this.dataSet.TagsIds.ElementAt(0),
                this.dataSet.TagsIds.ElementAt(1)
            }, categoryId:this.dataSet.CategoriesIds.ElementAt(0));

            Assert.AreEqual(2, images.Count);
        }

        [Test]
        public async Task GetMatchAsync_Cat2()
        {
            List<Image> images = await Images.GetMatchAsync("2");

            Assert.AreEqual(2, images.Count);
        }

        [Test]
        public async Task GetMatchAsync_AllCats()
        {
            List<Image> images = await Images.GetMatchAsync("Test Category");

            Assert.AreEqual(5, images.Count);
        }
    }
}
