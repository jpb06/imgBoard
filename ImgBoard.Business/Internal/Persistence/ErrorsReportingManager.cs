using ImgBoard.Business.Internal.Persistence.Contracts;
using ImgBoard.Dal.Manipulation.Services.ErrorsReporting.Contracts;
using ImgBoard.Dal.Models.ErrorsReporting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ImgBoard.Business.Internal.Persistence
{
    internal class ErrorsReportingManager : IErrorsReportingManager
    {
        private IErrorsReportingService reportingService;

        public ErrorsReportingManager(IErrorsReportingService reportingService)
        {
            this.reportingService = reportingService;
        }

        public async Task LogErrorAsync(Exception exception, AssemblyName assemblyName, string errorCode)
        {
            string applicationName = assemblyName.Name;
            string applicationVersion = assemblyName.Version.ToString();

            ErrorReportApplication application = await this.reportingService.GetApplicationAsync(applicationName, applicationVersion);
            if (application == null)
                application = await this.reportingService.CreateApplicationAsync(applicationName, applicationVersion);

            await this.reportingService.LogExceptionAsync(application.Id, exception, errorCode);
        }
    }
}
