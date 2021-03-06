﻿using ImgBoard.Framework.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImgBoard.Business.Exceptions.CustomTypes
{
    public class BusinessException : BaseException
    {
        public BusinessException(string errorType, string message = null) : base(errorType, message)
        {
        }
    }
}
