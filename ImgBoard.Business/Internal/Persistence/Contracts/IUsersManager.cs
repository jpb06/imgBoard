using ImgBoard.Models.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImgBoard.Business.Internal.Persistence.Contracts
{
    internal interface IUsersManager
    {
        Task<List<User>> FetchUsersWithMatchingLogin(string term);
        
    }
}
