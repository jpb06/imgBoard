using ImgBoard.Dal.Context.Contracts;
using ImgBoard.Dal.Manipulation.Repositories.Implementation.Specific;
using ImgBoard.Models.Main;
using ImgBoard.Shared.Tests.Data.Mocked;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ImgBoard.Dal.Tests.Testing.Manipulation.Repositories
{
    [TestFixture]
    public class MockGenericRepositoryTest
    {
        private CategoryRepository categoryRepository;

        public MockGenericRepositoryTest() { }

        [Test]
        public void Insert()
        {
            VolatileMainDataset store = new VolatileMainDataset();
            Mock<IImgBoardContext> context = new Mock<IImgBoardContext>();
            Mock<CategoryRepository> mockCategoryRepository = new Mock<CategoryRepository>(context.Object);

            mockCategoryRepository.Setup(r => r.Insert(It.IsAny<Category>()))
                                  .Callback((Category c) =>
                                  {
                                    c.Id = 6;
                                    c.RowVersion = new byte[] { 0, 0, 0, 0, 0, 0, 0, 1 };
                                    store.Categories.Add(c);
                                  }).Verifiable();
            this.categoryRepository = mockCategoryRepository.Object;

            Category category = new Category
            {
                Title = "Category 6"
            };

            this.categoryRepository.Insert(category);

            mockCategoryRepository.Verify(r => r.Insert(It.IsAny<Category>()), Times.Once());
            Assert.AreEqual(6, store.Categories.Count);
            Assert.AreEqual(6, store.Categories.Last().Id);
        }

        [Test]
        public void Update()
        {
            VolatileMainDataset store = new VolatileMainDataset();
            Mock<IImgBoardContext> context = new Mock<IImgBoardContext>();
            Mock<CategoryRepository> mockCategoryRepository = new Mock<CategoryRepository>(context.Object);

            mockCategoryRepository.Setup(r => r.Update(It.IsAny<Category>()))
                                  .Callback((Category c) =>
                                  {
                                    var index = store.Categories.FindIndex(el => el.Id == c.Id);
                                    store.Categories[index] = c;
                                  }).Verifiable();
            this.categoryRepository = mockCategoryRepository.Object;

            Category category = store.Categories.ElementAt(4);
            string newTitle = category.Title = "c5";

            this.categoryRepository.Update(category);

            mockCategoryRepository.Verify(r => r.Update(It.IsAny<Category>()), Times.Once());
            Assert.AreEqual(newTitle, store.Categories.ElementAt(4).Title);
        }

        [Test]
        public void Delete()
        {
            VolatileMainDataset store = new VolatileMainDataset();
            Mock<IImgBoardContext> context = new Mock<IImgBoardContext>();
            Mock<CategoryRepository> mockCategoryRepository = new Mock<CategoryRepository>(context.Object);

            mockCategoryRepository.Setup(r => r.Delete(It.IsAny<Category>()))
                                 .Callback((Category c) =>
                                 {
                                     store.Categories.Remove(c);
                                 }).Verifiable();
            this.categoryRepository = mockCategoryRepository.Object;

            Category category = store.Categories.ElementAt(4);

            this.categoryRepository.Delete(category);

            mockCategoryRepository.Verify(r => r.Delete(It.IsAny<Category>()), Times.Once());
            Assert.AreEqual(4, store.Categories.Count);
        }

        [Test]
        public void DeleteById()
        {
            VolatileMainDataset store = new VolatileMainDataset();
            Mock<IImgBoardContext> context = new Mock<IImgBoardContext>();
            Mock<CategoryRepository> mockCategoryRepository = new Mock<CategoryRepository>(context.Object);

            mockCategoryRepository.Setup(r => r.Delete(It.IsAny<int>()))
                                 .Callback((object a) =>
                                 {
                                     var index = store.Categories.FindIndex(el => el.Id == (int)a);
                                     store.Categories.RemoveAt(index);
                                 }).Verifiable();
            this.categoryRepository = mockCategoryRepository.Object;

            this.categoryRepository.Delete(1);

            mockCategoryRepository.Verify(r => r.Delete(It.IsAny<int>()), Times.Once());
            Assert.AreEqual(4, store.Categories.Count);
        }

        [Test]
        public void GetById()
        {
            VolatileMainDataset store = new VolatileMainDataset();
            Mock<IImgBoardContext> context = new Mock<IImgBoardContext>();
            Mock<CategoryRepository> mockCategoryRepository = new Mock<CategoryRepository>(context.Object);

            mockCategoryRepository.Setup(r => r.GetById(It.IsInRange<int>(1, 6, Range.Inclusive)))
                                 .Returns<int>(id => store.Categories.Find(el => el.Id == id));
            this.categoryRepository = mockCategoryRepository.Object;

            Category category = this.categoryRepository.GetById(1);
            Category storedCategory = store.Categories.Single(el => el.Id == 1);

            Assert.AreEqual(category.Title, storedCategory.Title);
        }

        [Test]
        public void GetById_DoesntExist()
        {
            VolatileMainDataset store = new VolatileMainDataset();
            Mock<IImgBoardContext> context = new Mock<IImgBoardContext>();
            Mock<CategoryRepository> mockCategoryRepository = new Mock<CategoryRepository>(context.Object);

            mockCategoryRepository.Setup(r => r.GetById(It.IsNotIn<int>(1, 2, 3, 4, 5, 6)))
                                 .Returns<Category>(null);
            this.categoryRepository = mockCategoryRepository.Object;

            Category category = this.categoryRepository.GetById(10);

            Assert.AreEqual(null, category);
        }

        [Test]
        public void Get_Filtered()
        {
            VolatileMainDataset store = new VolatileMainDataset();
            Mock<IImgBoardContext> context = new Mock<IImgBoardContext>();
            Mock<CategoryRepository> mockCategoryRepository = new Mock<CategoryRepository>(context.Object);

            mockCategoryRepository.Setup(r => r.Get(It.IsAny<Expression<Func<Category, bool>>>(), null, string.Empty))
                                  .Returns((Expression<Func<Category, bool>> filter,
                                            Func<IQueryable<Category>, IOrderedQueryable<Category>> orderBy,
                                            string includeProperties) => store.Categories.Where(filter.Compile()));
            this.categoryRepository = mockCategoryRepository.Object;

            var result = this.categoryRepository.Get(filter: c => c.Id >= 2);

            Assert.AreEqual(4, result.Count());
        }

        [Test]
        public void Get_Ordered()
        {
            VolatileMainDataset store = new VolatileMainDataset();
            Mock<IImgBoardContext> context = new Mock<IImgBoardContext>();
            Mock<CategoryRepository> mockCategoryRepository = new Mock<CategoryRepository>(context.Object);

            mockCategoryRepository.Setup(r => r.Get(null, It.IsAny<Func<IQueryable<Category>, IOrderedQueryable<Category>>>(), string.Empty))
                                  .Returns((Expression<Func<Category, bool>> filter,
                                            Func<IQueryable<Category>, IOrderedQueryable<Category>> orderBy,
                                            string includeProperties) => orderBy.Invoke(store.Categories.AsQueryable()));
            this.categoryRepository = mockCategoryRepository.Object;

            var result = this.categoryRepository.Get(orderBy: q => q.OrderByDescending(a => a.Id));

            Assert.AreEqual(5, result.Count());
            Assert.AreEqual(1, result.Last().Id);
            Assert.AreEqual(5, result.First().Id);
        }

        [Test]
        public void Get_FilteredAndOrdered()
        {
            VolatileMainDataset store = new VolatileMainDataset();
            Mock<IImgBoardContext> context = new Mock<IImgBoardContext>();
            Mock<CategoryRepository> mockCategoryRepository = new Mock<CategoryRepository>(context.Object);

            mockCategoryRepository.Setup(r => r.Get(It.IsAny<Expression<Func<Category, bool>>>(),
                                                    It.IsAny<Func<IQueryable<Category>, IOrderedQueryable<Category>>>(),
                                                    string.Empty))
                                  .Returns((Expression<Func<Category, bool>> filter,
                                            Func<IQueryable<Category>, IOrderedQueryable<Category>> orderBy,
                                            string includeProperties) => orderBy.Invoke(store.Categories.Where(filter.Compile()).AsQueryable()));
            this.categoryRepository = mockCategoryRepository.Object;

            var result = this.categoryRepository.Get(filter: c => c.Id >= 2,
                                                     orderBy: q => q.OrderByDescending(c => c.Id));

            Assert.AreEqual(4, result.Count());
            Assert.AreEqual(5, result.First().Id);
            Assert.AreEqual(2, result.Last().Id);
        }

        #region async
        [Test]
        public async Task GetByIdAsync()
        {
            VolatileMainDataset store = new VolatileMainDataset();
            Mock<IImgBoardContext> context = new Mock<IImgBoardContext>();
            Mock<CategoryRepository> mockCategoryRepository = new Mock<CategoryRepository>(context.Object);

            mockCategoryRepository.Setup(r => r.GetByIdAsync(It.IsInRange<int>(1, 5, Range.Inclusive)))
                                  .Returns<int>(id => Task.FromResult(store.Categories.Find(el => el.Id == id)));
            this.categoryRepository = mockCategoryRepository.Object;

            Category category = await this.categoryRepository.GetByIdAsync(1);
            Category storedCategory = store.Categories.Single(el => el.Id == 1);

            Assert.AreEqual(category.Title, storedCategory.Title);
        }

        [Test]
        public async Task GetByIdAsync_DoesntExist()
        {
            VolatileMainDataset store = new VolatileMainDataset();
            Mock<IImgBoardContext> context = new Mock<IImgBoardContext>();
            Mock<CategoryRepository> mockCategoryRepository = new Mock<CategoryRepository>(context.Object);

            mockCategoryRepository.Setup(r => r.GetByIdAsync(It.IsNotIn<int>(1, 2, 3, 4, 5, 6)))
                                  .Returns<int>(id => Task.FromResult<Category>(null));
            this.categoryRepository = mockCategoryRepository.Object;

            Category category = await this.categoryRepository.GetByIdAsync(10);

            Assert.AreEqual(null, category);
        }

        [Test]
        public async Task GetAsync_Filtered()
        {
            VolatileMainDataset store = new VolatileMainDataset();
            Mock<IImgBoardContext> context = new Mock<IImgBoardContext>();
            Mock<CategoryRepository> mockCategoryRepository = new Mock<CategoryRepository>(context.Object);

            mockCategoryRepository.Setup(r => r.GetAsync(It.IsAny<Expression<Func<Category, bool>>>(), null, string.Empty))
                                  .Returns((Expression<Func<Category, bool>> filter,
                                            Func<IQueryable<Category>, IOrderedQueryable<Category>> orderBy,
                                            string includeProperties) => Task.FromResult(store.Categories.Where(filter.Compile())));
            this.categoryRepository = mockCategoryRepository.Object;

            var result = await this.categoryRepository.GetAsync(filter: c => c.Id >= 2);

            Assert.AreEqual(4, result.Count());
        }

        [Test]
        public async Task GetAsync_Ordered()
        {
            VolatileMainDataset store = new VolatileMainDataset();
            Mock<IImgBoardContext> context = new Mock<IImgBoardContext>();
            Mock<CategoryRepository> mockCategoryRepository = new Mock<CategoryRepository>(context.Object);

            mockCategoryRepository.Setup(r => r.GetAsync(null, It.IsAny<Func<IQueryable<Category>, IOrderedQueryable<Category>>>(), string.Empty))
                                  .Returns((Expression<Func<Category, bool>> filter,
                                            Func<IQueryable<Category>, IOrderedQueryable<Category>> orderBy,
                                            string includeProperties) =>
                                  {
                                      var ordered = orderBy.Invoke(store.Categories.AsQueryable());
                                      return Task.FromResult(ordered.AsEnumerable());
                                  });
            this.categoryRepository = mockCategoryRepository.Object;

            var result = await this.categoryRepository.GetAsync(orderBy: q => q.OrderByDescending(c => c.Id));

            Assert.AreEqual(5, result.Count());
            Assert.AreEqual(1, result.Last().Id);
            Assert.AreEqual(5, result.First().Id);
        }

        [Test]
        public async Task GetAsync_FilteredAndOrdered()
        {
            VolatileMainDataset store = new VolatileMainDataset();
            Mock<IImgBoardContext> context = new Mock<IImgBoardContext>();
            Mock<CategoryRepository> mockCategoryRepository = new Mock<CategoryRepository>(context.Object);

            mockCategoryRepository.Setup(r => r.GetAsync(It.IsAny<Expression<Func<Category, bool>>>(),
                                                         It.IsAny<Func<IQueryable<Category>, IOrderedQueryable<Category>>>(),
                                                         string.Empty))
                                  .Returns((Expression<Func<Category, bool>> filter,
                                            Func<IQueryable<Category>, IOrderedQueryable<Category>> orderBy,
                                            string includeProperties) =>
                                  {
                                      var filtered = store.Categories.Where(filter.Compile()).AsQueryable();
                                      var ordered = orderBy.Invoke(filtered);
                                      return Task.FromResult(ordered.AsEnumerable());
                                  });
            this.categoryRepository = mockCategoryRepository.Object;

            var result = await this.categoryRepository.GetAsync(filter: c => c.Id >= 2,
                                                                orderBy: q => q.OrderByDescending(c => c.Id));

            Assert.AreEqual(4, result.Count());
            Assert.AreEqual(5, result.First().Id);
            Assert.AreEqual(2, result.Last().Id);
        }
        #endregion
    }
}
