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
    public class MockUsersManagerTest
    {
        IUsersManager usersManager;

        public MockUsersManagerTest() { }

        [Test]
        public async Task FetchUsersWithMatchingLogin_Two()
        {
            VolatileMainDataset dataSet = new VolatileMainDataset();
            Mock<IUsersManager> mockService = new Mock<IUsersManager>();

            mockService.Setup(s => s.FetchUsersWithMatchingLogin(It.IsAny<string>()))
                       .Returns<string>(term => Task.FromResult<List<User>>(
                           dataSet.Users
                               .Where(el => el.Login.Contains(term))
                               .Select(el => el.ToExposed())
                               .ToList())
                       );
            this.usersManager = mockService.Object;

            List<User> users = await this.usersManager.FetchUsersWithMatchingLogin("a");

            Assert.AreEqual(2, users.Count);
        }

        [Test]
        public async Task FetchUsersWithMatchingLogin_One()
        {
            VolatileMainDataset dataSet = new VolatileMainDataset();
            Mock<IUsersManager> mockService = new Mock<IUsersManager>();

            mockService.Setup(s => s.FetchUsersWithMatchingLogin(It.IsAny<string>()))
                       .Returns<string>(term => Task.FromResult<List<User>>(
                           dataSet.Users
                               .Where(el => el.Login.Contains(term))
                               .Select(el => el.ToExposed())
                               .ToList())
                       );
            this.usersManager = mockService.Object;

            List<User> users = await this.usersManager.FetchUsersWithMatchingLogin("b");

            Assert.AreEqual(1, users.Count);
        }
    }
}
