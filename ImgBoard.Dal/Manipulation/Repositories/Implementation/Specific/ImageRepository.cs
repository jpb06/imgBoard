using ImgBoard.Dal.Context.Contracts;
using ImgBoard.Dal.Manipulation.Repositories.Contracts;
using ImgBoard.Dal.Manipulation.Repositories.Implementation.Base;
using ImgBoard.Models.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImgBoard.Dal.Manipulation.Repositories.Implementation.Specific
{
    public class ImageRepository : GenericRepository<Image>, IImageRepository
    {
        public ImageRepository(IImgBoardContext context) : base(context) { }
    }
}
