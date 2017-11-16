using ImgBoard.Dal.Models.ErrorsReporting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImgBoard.Dal.Manipulation.Services.ErrorsReporting.Contracts
{
    public interface IErrorsReportingService
    {
        Task<ErrorReportApplication> GetApplicationAsync(string name, string version);
        Task<ErrorReportApplication> CreateApplicationAsync(string name, string version);
        Task<int?> LogExceptionAsync(int versionId, Exception exception, string errorCode);
    }
}
