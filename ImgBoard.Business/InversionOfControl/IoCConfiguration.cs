using ImgBoard.Business.Internal;
using ImgBoard.Business.Internal.Contracts;
using ImgBoard.Dal.Context.Contracts;
using ImgBoard.Dal.Context.EndObjects;
using ImgBoard.Dal.Manipulation.Repositories.Contracts;
using ImgBoard.Dal.Manipulation.Repositories.Implementation.Base;
using ImgBoard.Dal.Manipulation.Repositories.Implementation.Specific;
using ImgBoard.Dal.Manipulation.Services.ErrorsReporting;
using ImgBoard.Dal.Manipulation.Services.ErrorsReporting.Contracts;
using ImgBoard.Dal.Manipulation.Services.Main;
using ImgBoard.Dal.Manipulation.Services.Main.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Injection;
using Unity.Lifetime;

namespace ImgBoard.Business.InversionOfControl
{
    internal static class IoCConfiguration
    {
        public static readonly UnityContainer container;

        static IoCConfiguration()
        {
            container = new UnityContainer();

            #region Errors reporting
            container.RegisterType<IErrorsReportingContext, ErrorsReportingContext>(
                new HierarchicalLifetimeManager()
            );
            container.RegisterType(
                typeof(IGenericRepository<>), typeof(GenericRepository<>), 
                new InjectionConstructor(typeof(IErrorsReportingContext)));
            container.RegisterType<IErrorsReportingService, ErrorsReportingService>();

            container.RegisterType<IErrorsReportingManager, ErrorsReportingManager>();
            #endregion

            #region Main
            container.RegisterType<IImgBoardContext, ImgBoardTestContext>(new HierarchicalLifetimeManager());

            container.RegisterType<ICategoryRepository, CategoryRepository>();
            container.RegisterType<ICommentRepository, CommentRepository>();
            container.RegisterType<IImageRepository, ImageRepository>();
            container.RegisterType<ITagRepository, TagRepository>();
            container.RegisterType<ICategoryRepository, CategoryRepository>();
            container.RegisterType<IUserRepository, UserRepository>();

            container.RegisterType<IPersistenceService, PersistenceService>();

            container.RegisterType<IErrorsReportingManager, ErrorsReportingManager>();
            #endregion
        }
    }
}
