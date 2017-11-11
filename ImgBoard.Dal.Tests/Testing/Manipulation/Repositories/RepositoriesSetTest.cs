using ImgBoard.Dal.Context.Contracts;
using ImgBoard.Dal.Context.EndObjects;
using ImgBoard.Dal.Exceptions;
using ImgBoard.Dal.Exceptions.CustomTypes;
using ImgBoard.Dal.Manipulation.Repositories;
using ImgBoard.Dal.Manipulation.Repositories.Contracts;
using ImgBoard.Dal.Manipulation.Repositories.Implementation.Base;
using ImgBoard.Dal.Manipulation.Repositories.Implementation.Specific;
using ImgBoard.Models.Main;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImgBoard.Dal.Tests.Testing.Manipulation.Repositories
{
    [TestFixture]
    public class RepositoriesSetTest
    {
        [Test]
        public void GetGeneric_ForCategory()
        {
            RepositoriesSet repositoriesSet = new RepositoriesSet();

            repositoriesSet.Register<Category, ICategoryRepository>(new CategoryRepository(new Mock<IImgBoardContext>().Object));

            var repository = repositoriesSet.GetGeneric<Category>();

            Assert.IsInstanceOf<GenericRepository<Category>>(repository);
        }

        [Test]
        public void GetGeneric_ForCategory_NotRegistered()
        {
            RepositoriesSet repositoriesSet = new RepositoriesSet();

            DalException ex = Assert.Throws<DalException>(() =>
            {
                repositoriesSet.GetGeneric<Category>();
            });
            Assert.That(ex.errorType, Is.EqualTo(DalErrorType.RepositoriesSetMissingMapping));
            Assert.That(ex.Message, Is.EqualTo("Instance is missing for ImgBoard.Models.Main.Category"));
        }

        [Test]
        public void GetSpecific_ForCategory()
        {
            RepositoriesSet repositoriesSet = new RepositoriesSet();

            repositoriesSet.Register<Category, ICategoryRepository>(new CategoryRepository(new Mock<IImgBoardContext>().Object));

            var repository = repositoriesSet.GetSpecific<Category, ICategoryRepository>();

            Assert.IsInstanceOf<ICategoryRepository>(repository);
        }

        [Test]
        public void GetSpecific_ForCategory_NotRegistered()
        {
            RepositoriesSet repositoriesSet = new RepositoriesSet();

            DalException ex = Assert.Throws<DalException>(() =>
            {
                repositoriesSet.GetGeneric<Category>();
            });
            Assert.That(ex.errorType, Is.EqualTo(DalErrorType.RepositoriesSetMissingMapping));
            Assert.That(ex.Message, Is.EqualTo("Instance is missing for ImgBoard.Models.Main.Category"));
        }
    }
}
