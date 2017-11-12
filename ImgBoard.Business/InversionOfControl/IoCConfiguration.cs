using ImgBoard.Business.Internal;
using ImgBoard.Business.Internal.Contracts;
using ImgBoard.Dal.Context.Contracts;
using ImgBoard.Dal.Context.EndObjects;
using ImgBoard.Dal.Manipulation.Repositories.Contracts;
using ImgBoard.Dal.Manipulation.Repositories.Implementation.Base;
using ImgBoard.Dal.Manipulation.Services.ErrorsReporting;
using ImgBoard.Dal.Manipulation.Services.ErrorsReporting.Contracts;
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

            container.RegisterType<IErrorsReportingContext, ErrorsReportingContext>(
                new HierarchicalLifetimeManager()
            );
            container.RegisterType(
                typeof(IGenericRepository<>), typeof(GenericRepository<>), 
                new InjectionConstructor(typeof(IErrorsReportingContext)));
            container.RegisterType<IErrorsReportingService, ErrorsReportingService>();

            container.RegisterType<IErrorsReportingManager, ErrorsReportingManager>();
        }
    }
}
