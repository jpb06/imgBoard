using ImgBoard.Business.InversionOfControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImgBoard.Business.Tests.Configuration
{
    public static class InversionOfControl
    {
        static InversionOfControl()
        {
            IoCConfiguration.ConfigureForTests();
        }

        public static void Initialize() { }
    }
}
