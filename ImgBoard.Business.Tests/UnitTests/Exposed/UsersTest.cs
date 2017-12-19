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
    public class UsersTest
    {
        private PersistentMainDataSet dataSet;

        public UsersTest()
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
        public async Task GetMatchAsync_Two()
        {
            List<User> users = await Users.GetMatchAsync("a");

            Assert.AreEqual(2, users.Count);
        }

        [Test]
        public async Task GetMatchAsync_One()
        {
            List<User> users = await Users.GetMatchAsync("aa");

            Assert.AreEqual(1, users.Count);
        }
    }
}
