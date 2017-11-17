using ImgBoard.Business.Internal.Persistence.Contracts;
using ImgBoard.Business.InversionOfControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace ImgBoard.Business.Exposed
{
    public static class ErrorsLogging
    {
        public static async Task SaveAsync(Exception exception, AssemblyName assemblyName, string errorCode)
        {
            using (IUnityContainer unit = IoCConfiguration.container.CreateChildContainer())
            {
                IErrorsReportingManager manager = unit.Resolve<IErrorsReportingManager>();
                await manager.LogErrorAsync(exception, assemblyName, errorCode);
            }
        }
    }
}
