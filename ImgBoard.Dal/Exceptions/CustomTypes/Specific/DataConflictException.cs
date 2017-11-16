using ImgBoard.Dal.Manipulation.Services.Main.Configuration;
using ImgBoard.Dal.Models.Base;
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
            BaseDbModel dbValues = (BaseDbModel)info.DatabaseValues.ToObject();
            BaseDbModel cValues = (BaseDbModel)info.CurrentValues.ToObject();

            this.DatabaseValues = dbValues;
            this.CurrentValues = cValues;
        }

        public BaseDbModel DatabaseValues { get; set; }
        public BaseDbModel CurrentValues { get; set; }
    }
}
