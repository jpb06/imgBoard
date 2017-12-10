using ImgBoard.Business.Internal.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImgBoard.Dal.Models.Main;
using ImgBoard.Dal.Manipulation.Services.Main.Contracts;

namespace ImgBoard.Business.Internal.Persistence
{
    internal class CategoriesManager : ICategoriesManager
    {
        private IPersistenceService persistenceService;

        public CategoriesManager(IPersistenceService persistenceService)
        {
            this.persistenceService = persistenceService;
        }

        public async Task<List<DbCategory>> FetchCategoriesWithMatchingTitle(string term)
        {
            var data = await this.persistenceService.GetAsync<DbCategory>(filter: el => el.Title.Contains(term));

            return data;
        }
    }
}
