using ImgBoard.Business.Internal.Contracts;
using ImgBoard.Dal.Manipulation.Services.Main.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImgBoard.Business.Internal
{
    internal class PersistenceManager : IPersistenceManager
    {
        private IPersistenceService persistenceService;

        public PersistenceManager(IPersistenceService persistenceService)
        {
            this.persistenceService = persistenceService;
        }

        
    }
}
