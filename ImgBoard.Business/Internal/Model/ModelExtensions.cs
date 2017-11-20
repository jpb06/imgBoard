using ImgBoard.Dal.Models.Main;
using ImgBoard.Models.Main;
using System.Linq;

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
                Creator = comment.Creator == null ? null : comment.Creator.ToExposed(),
                Image = comment.Image == null ? null : comment.Image.ToExposed()
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
                Category = image.Category == null ? null : image.Category.ToExposed(),
                Uploader = image.Uploader == null ? null : image.Uploader.ToExposed(),
                Tags = image.Tags == null ? null : image.Tags.Select(t => t.ToExposed()).ToList()
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
