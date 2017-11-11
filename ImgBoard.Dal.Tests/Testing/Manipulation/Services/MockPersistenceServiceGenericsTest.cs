using ImgBoard.Dal.Context.Contracts;
using ImgBoard.Dal.Manipulation.Repositories.Contracts;
using ImgBoard.Dal.Manipulation.Services.Main;
using ImgBoard.Dal.Manipulation.Services.Main.Contracts;
using ImgBoard.Models.Main;
using ImgBoard.Shared.Tests.Data.Mocked;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImgBoard.Dal.Tests.Testing.Manipulation.Services
{
    [TestFixture]
    public class MockPersistenceServiceGenericsTest
    {
        private IBaseMainService service;
        private Category categoryToAdd;

        public MockPersistenceServiceGenericsTest()
        {
            this.categoryToAdd = new Category
            {
                Title = "Added title"
            };

            Mock<IImgBoardContext> context = new Mock<IImgBoardContext>();
            Mock<ICategoryRepository> categoryRepo = new Mock<ICategoryRepository>();
            Mock<ICommentRepository> commentRepo = new Mock<ICommentRepository>();
            Mock<IImageRepository> imageRepo = new Mock<IImageRepository>();
            Mock<ITagRepository> tagRepo = new Mock<ITagRepository>();
            Mock<IUserRepository> userRepo = new Mock<IUserRepository>();
            this.service = new PersistenceService(context.Object, 
                categoryRepo.Object, commentRepo.Object, imageRepo.Object, tagRepo.Object, userRepo.Object);
        }

        #region async
        [Test]
        public async Task AddCategoryAsync()
        {
            VolatileMainDataset store = new VolatileMainDataset();
            Mock<IBaseMainService> mockService = new Mock<IBaseMainService>();

            mockService.Setup(s => s.CreateAsync(It.Is<Category>(a => a.Title == "Added title")))
                            .ReturnsAsync(8);
            this.service = mockService.Object;

            int id = await this.service.CreateAsync(this.categoryToAdd);

            Assert.AreEqual(8, id);
        }

        [Test]
        public async Task UpdateCategoryAsync()
        {
            VolatileMainDataset store = new VolatileMainDataset();
            Mock<IBaseMainService> mockService = new Mock<IBaseMainService>();

            mockService.Setup(r => r.ModifyAsync(It.IsAny<Category>()))
                            .Returns(Task.FromResult<object>(null))
                            .Callback((Category a) =>
                            {
                                var index = store.Categories.FindIndex(el => el.Id == a.Id);
                                store.Categories[index] = a;
                            }).Verifiable();
            this.service = mockService.Object;

            Category category = store.Categories.ElementAt(4);
            string newTitle = category.Title = "a5";

            await this.service.ModifyAsync(category);

            mockService.Verify(r => r.ModifyAsync(It.IsAny<Category>()), Times.Once());
            Assert.AreEqual(newTitle, store.Categories.ElementAt(4).Title);

        }

        [Test]
        public async Task DeleteCategoryAsync()
        {
            VolatileMainDataset store = new VolatileMainDataset();
            Mock<IBaseMainService> mockService = new Mock<IBaseMainService>();

            mockService.Setup(r => r.DeleteAsync(It.IsAny<Category>()))
                            .Returns(Task.FromResult<object>(null))
                            .Callback((Category c) =>
                            {
                                store.Categories.Remove(c);
                            }).Verifiable();
            this.service = mockService.Object;

            Category article = store.Categories.ElementAt(4);

            await this.service.DeleteAsync(article);

            mockService.Verify(r => r.DeleteAsync(It.IsAny<Category>()), Times.Once());
            Assert.AreEqual(4, store.Categories.Count);
        }
        #endregion
    }
}
