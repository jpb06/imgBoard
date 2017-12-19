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
    public class TagsTest
    {
        private PersistentMainDataSet dataSet;

        public TagsTest()
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
        public async Task GetMatchAsync_All()
        {
            List<Tag> tags = await Tags.GetMatchAsync("Tag");

            Assert.AreEqual(3, tags.Count);
        }

        [Test]
        public async Task GetMatchAsync_One()
        {
            List<Tag> tags = await Tags.GetMatchAsync("Bad");

            Assert.AreEqual(1, tags.Count);
        }
    }
}
