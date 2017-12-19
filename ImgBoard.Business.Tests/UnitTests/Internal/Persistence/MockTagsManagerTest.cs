using ImgBoard.Business.Internal.Persistence.Contracts;
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
    public class MockTagsManagerTest
    {
        ITagsManager tagsManager;

        public MockTagsManagerTest() { }

        [Test]
        public async Task FetchTagsWithMatchingName_All()
        {
            VolatileMainDataset dataSet = new VolatileMainDataset();
            Mock<ITagsManager> mockService = new Mock<ITagsManager>();

            mockService.Setup(s => s.FetchTagsWithMatchingName(It.IsAny<string>()))
                       .Returns<string>(term => Task.FromResult<List<Tag>>(
                           dataSet.Tags
                               .Where(el => el.Name.Contains(term))
                               .Select(el => el.ToExposed())
                               .ToList())
                       );
            this.tagsManager = mockService.Object;

            List<Tag> tags = await this.tagsManager.FetchTagsWithMatchingName("Tag");

            Assert.AreEqual(3, tags.Count);
        }

        [Test]
        public async Task FetchTagsWithMatchingName_Meh()
        {
            VolatileMainDataset dataSet = new VolatileMainDataset();
            Mock<ITagsManager> mockService = new Mock<ITagsManager>();

            mockService.Setup(s => s.FetchTagsWithMatchingName(It.IsAny<string>()))
                       .Returns<string>(term => Task.FromResult<List<Tag>>(
                           dataSet.Tags
                               .Where(el => el.Name.Contains(term))
                               .Select(el => el.ToExposed())
                               .ToList())
                       );
            this.tagsManager = mockService.Object;

            List<Tag> tags = await this.tagsManager.FetchTagsWithMatchingName("Meh");

            Assert.AreEqual(1, tags.Count);
        }
    }
}
