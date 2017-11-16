using ImgBoard.Dal.Manipulation.Services.Main.Base;
using ImgBoard.Dal.Manipulation.Services.Main.Contracts;
using ImgBoard.Dal.Context.Contracts;
using ImgBoard.Dal.Manipulation.Repositories.Contracts;
using ImgBoard.Dal.Models.Main;

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
            base.repositoriesSet.Register<DbCategory, ICategoryRepository>(categoryRepository);
            base.repositoriesSet.Register<DbComment, ICommentRepository>(commentRepository);
            base.repositoriesSet.Register<DbImage, IImageRepository>(imageRepository);
            base.repositoriesSet.Register<DbTag, ITagRepository>(tagRepository);
            base.repositoriesSet.Register<DbUser, IUserRepository>(userRepository);
        }
    }
}
