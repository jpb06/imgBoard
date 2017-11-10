using ImgBoard.Dal.Manipulation.Services.Main.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImgBoard.Dal.Manipulation.Services.Base
{
    public class SaveResult
    {
        public int AlteredObjectsCount { get; set; }
        public int[] AlteredIds { get; set; }
        public DataConflictInfo DataConflictInfo { get; set; }

        public SaveResult()
        {
            this.AlteredObjectsCount = 0;
            this.AlteredIds = new int[] { };
            this.DataConflictInfo = null;
        }

        public void Validate(int expectedObjectsCount, DataConflictPolicy dataConflictPolicy)
        {
            if (dataConflictPolicy == DataConflictPolicy.DatabaseWins &&
                (this.AlteredObjectsCount != 0 || this.AlteredIds.Count() != expectedObjectsCount))
            {

                // TODO : apply proper exceptions segregation & logging
                throw new Exception("SaveResultPersistenceValidationFailure");
            }


            if (dataConflictPolicy == DataConflictPolicy.ClientWins &&
                (this.AlteredObjectsCount != expectedObjectsCount || this.AlteredIds.Count() != expectedObjectsCount))
            {
                // TODO : apply proper exceptions segregation & logging
                throw new Exception("SaveResultPersistenceValidationFailure");
            }


        }
    }
}
