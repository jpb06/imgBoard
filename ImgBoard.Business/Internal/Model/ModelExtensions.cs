using ImgBoard.Dal.Models.Main;
using ImgBoard.Models.Main;

namespace ImgBoard.Business.Internal.Model
{
    public static class ModelExtensions
    {
        public static Category ToExposed(this DbCategory category)
        {
            return new Category
            {
                Id = category.Id,
                Title = category.Title
            };
        }

        public static Comment ToExposed(this DbComment comment)
        {
            return new Comment
            {
                Id = comment.Id,
                IdCreator = comment.IdCreator,
                IdImage = comment.IdImage,
                Message = comment.Message,
                Creator = comment.Creator == null ? null : new User
                {
                    Id = comment.Creator.Id,
                    Login = comment.Creator.Login,
                    Password = comment.Creator.Password,
                    UserName = comment.Creator.UserName
                },
                Image = comment.Image == null ? null : new Image
                {
                    Id = comment.Image.Id,
                    IdCategory = comment.Image.IdCategory,
                    IdUploader = comment.Image.IdUploader,
                    Name = comment.Image.Name,
                    Description = comment.Image.Description,
                    FileId = comment.Image.FileId.ToString("N"),
                    Category = comment.Image.Category == null ? null : new Category
                    {
                        Id = comment.Image.Category.Id,
                        Title = comment.Image.Category.Title
                    }
                }
            };
        }

        public static Image ToExposed(this DbImage image)
        {
            return new Image
            {
                Id = image.Id,
                IdCategory = image.IdCategory,
                IdUploader = image.IdUploader,
                Name = image.Name,
                Description = image.Description,
                FileId = image.FileId.ToString("N"),
            FileExtension = image.FileExtension,
                Category = image.Category == null ? null : new Category
                {
                    Id = image.Category.Id,
                    Title = image.Category.Title
                },
                Uploader = image.Uploader == null ? null : new User
                {
                    Id = image.Uploader.Id,
                    Login = image.Uploader.Login,
                    Password = image.Uploader.Password,
                    UserName = image.Uploader.UserName
                }
            };
        }

        public static Tag ToExposed(this DbTag tag)
        {
            return new Tag
            {
                Id = tag.Id,
                Name = tag.Name
            };
        }

        public static User ToExposed(this DbUser user)
        {
            return new User
            {
                Id = user.Id,
                Login = user.Login,
                Password = user.Password,
                UserName = user.UserName
            };
        }
    }
}
