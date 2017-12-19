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
    internal class UsersManager : IUsersManager
    {
        private IPersistenceService persistenceService;

        public UsersManager(IPersistenceService persistenceService)
        {
            this.persistenceService = persistenceService;
        }

        public async Task<List<User>> FetchUsersWithMatchingLogin(string term)
        {
            var data = await this.persistenceService.GetAsync<DbUser>(filter: el => el.Login.Contains(term));

            return data
                .Select(el => el.ToExposed())
                .ToList(); ;
        }
    }
}
