using ImgBoard.Dal.Manipulation.Services.Main.Base;
using ImgBoard.Dal.Manipulation.Services.Main.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using ImgBoard.Dal.Context.Contracts;
using ImgBoard.Dal.Manipulation.Services.Main.Configuration;
using ImgBoard.Dal.Manipulation.Repositories.Contracts;
using ImgBoard.Models.Main;

namespace ImgBoard.Dal.Manipulation.Services.Main
{
    public class PersistenceService : BaseMainService, IPersistenceService
    {
        public PersistenceService(IImgBoardContext context,
                                  ICategoryRepository categoryRepository,
                                  ICommentRepository commentRepository,
                                  IImageRepository imageRepository,
                                  ITagRepository tagRepository,
                                  IUserRepository userRepository)
            : base(context) 
        {
            base.repositoriesSet.Register<Category, ICategoryRepository>(categoryRepository);
            base.repositoriesSet.Register<Comment, ICommentRepository>(commentRepository);
            base.repositoriesSet.Register<Image, IImageRepository>(imageRepository);
            base.repositoriesSet.Register<Tag, ITagRepository>(tagRepository);
            base.repositoriesSet.Register<User, IUserRepository>(userRepository);
        }
    }
}
