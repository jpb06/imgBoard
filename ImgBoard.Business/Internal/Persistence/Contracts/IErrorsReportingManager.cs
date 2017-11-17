using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ImgBoard.Business.Internal.Persistence.Contracts
{
    internal interface IErrorsReportingManager
    {
        Task LogErrorAsync(Exception exception, AssemblyName assemblyName, string errorCode);
    }
}
