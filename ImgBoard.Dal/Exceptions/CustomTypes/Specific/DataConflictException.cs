using ImgBoard.Dal.Manipulation.Services.Main.Configuration;
using ImgBoard.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImgBoard.Dal.Exceptions.CustomTypes.Specific
{
    public class DataConflictException : DalException
    {
        public DataConflictException(string errorType, DataConflictInfo info)
            : base(errorType, "Data conflict (Optimistic concurrency)")
        {
            BaseModel dbValues = (BaseModel)info.DatabaseValues.ToObject();
            BaseModel cValues = (BaseModel)info.CurrentValues.ToObject();

            this.DatabaseValues = dbValues;
            this.CurrentValues = cValues;
        }

        public BaseModel DatabaseValues { get; set; }
        public BaseModel CurrentValues { get; set; }
    }
}
