using ImgBoard.Models.Main;
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
        IDbSet<Category> Categories { get; set; }
        IDbSet<Comment> Comments { get; set; }
        IDbSet<Image> Images { get; set; }
        IDbSet<Tag> Tags { get; set; }
        IDbSet<User> Users { get; set; }
    }
}
