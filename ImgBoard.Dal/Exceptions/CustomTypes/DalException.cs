using ImgBoard.Framework.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImgBoard.Dal.Exceptions.CustomTypes
{
    public class DalException : BaseException
    {
        public DalException(string errorType, string message = null) : base(errorType, message)
        {
        }
    }
}
