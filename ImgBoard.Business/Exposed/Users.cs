using ImgBoard.Business.Internal.Persistence.Contracts;
using ImgBoard.Business.InversionOfControl;
using ImgBoard.Models.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace ImgBoard.Business.Exposed
{
    public static class Users
    {
        public static async Task<List<User>> GetMatchAsync(string term)
        {
            using (IUnityContainer unit = IoCConfiguration.container.CreateChildContainer())
            {
                IUsersManager manager = unit.Resolve<IUsersManager>();

                List<User> users = await manager.FetchUsersWithMatchingLogin(term);

                return users;
            }
        }
    }
}
