using ImgBoard.Business.Internal.Persistence.Contracts;
using ImgBoard.Dal.Manipulation.Services.Main.Contracts;
using ImgBoard.Dal.Models.Main;
using ImgBoard.Models.Main;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImgBoard.Business.Internal.Model;

namespace ImgBoard.Business.Internal.Persistence
{
    internal class TagsManager : ITagsManager
    {
        private IPersistenceService persistenceService;

        public TagsManager(IPersistenceService persistenceService)
        {
            this.persistenceService = persistenceService;
        }

        public async Task<List<Tag>> FetchTagsWithMatchingName(string term)
        {
            var data = await this.persistenceService.GetAsync<DbTag>(filter: el => el.Name.Contains(term));

            return data
                .Select(el => el.ToExposed())
                .ToList(); ;
        }
    }
}
