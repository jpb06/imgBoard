using ImgBoard.Dal.Models.Main;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImgBoard.Dal.Context.Contracts
{
    public interface IImgBoardContext : IDbContext
    {
        IDbSet<DbCategory> Categories { get; set; }
        IDbSet<DbComment> Comments { get; set; }
        IDbSet<DbImage> Images { get; set; }
        IDbSet<DbTag> Tags { get; set; }
        IDbSet<DbUser> Users { get; set; }
    }
}
