using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ImgBoard.Business.Tests.AssemblyInformation
{
    public static class AssemblyHelper
    {
        public static AssemblyName AssemblyName
        {
            get { return Assembly.GetExecutingAssembly().GetName(); }
        }
    }
}
