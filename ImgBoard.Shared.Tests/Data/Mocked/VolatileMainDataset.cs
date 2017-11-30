using ImgBoard.Dal.Models.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImgBoard.Shared.Tests.Data.Mocked
{
    public class VolatileMainDataset
    {
        public List<DbCategory> Categories { get; set; }
        public List<DbComment> Comments { get; set; }
        public List<DbImage> Images { get; set; }
        public List<DbTag> Tags { get; set; }
        public List<DbUser> Users { get; set; }

        public VolatileMainDataset()
        {
            this.Categories = new List<DbCategory>();
            this.Comments = new List<DbComment>();
            this.Images = new List<DbImage>();
            this.Tags = new List<DbTag>();
            this.Users = new List<DbUser>();

            this.Populate();
        }

        public void Populate()
        {
            #region Articles
            var categories = new List<DbCategory>()
            {
                new DbCategory
                {
                    RowVersion = new byte[] {0, 0, 0, 0, 0, 0, 0, 0},
                    Id = 1, 
                    Title = "Category 1"
                },
                new DbCategory
                {
                    RowVersion = new byte[] {0, 0, 0, 0, 0, 0, 0, 0},
                    Id = 2,
                    Title = "Category 2"
                },
                new DbCategory
                {
                    RowVersion = new byte[] {0, 0, 0, 0, 0, 0, 0, 0},
                    Id = 3,
                    Title = "Category 3"
                },
                new DbCategory
                {
                    RowVersion = new byte[] {0, 0, 0, 0, 0, 0, 0, 0},
                    Id = 4,
                    Title = "Category 4"
                },
                new DbCategory
                {
                    RowVersion = new byte[] {0, 0, 0, 0, 0, 0, 0, 0},
                    Id = 5,
                    Title = "Category 5"
                },
            };

            this.Categories.AddRange(categories);
            #endregion

            #region Users
            this.Users.AddRange(new List<DbUser>()
            {
                new DbUser
                {
                    RowVersion = new byte[] {0, 0, 0, 0, 0, 0, 0, 0},
                    Id = 1,
                    Login = "a",
                    Password = "a",
                    UserName = "User A"
                },
                new DbUser
                {
                    RowVersion = new byte[] {0, 0, 0, 0, 0, 0, 0, 0},
                    Id = 2,
                    Login = "b",
                    Password = "b",
                    UserName = "User B"
                }
            });
            #endregion

            #region Images
            this.Images.AddRange(new List<DbImage>()
            {
                new DbImage
                {
                    RowVersion = new byte[] {0, 0, 0, 0, 0, 0, 0, 0},
                    Id = 1,
                    IdUploader = 1,
                    IdCategory = 1,
                    Name = "Image 1 name",
                    Description = "Image 1 description",
                    FileId = Guid.NewGuid(),

                    Category = categories.ElementAt(0)
                },
                new DbImage
                {
                    RowVersion = new byte[] {0, 0, 0, 0, 0, 0, 0, 0},
                    Id = 2,
                    IdUploader = 1,
                    IdCategory = 1,
                    Name = "Image 2 name",
                    Description = "Image 2 description",
                    FileId = Guid.NewGuid(),

                    Category = categories.ElementAt(0)
                },
                new DbImage
                {
                    RowVersion = new byte[] {0, 0, 0, 0, 0, 0, 0, 0},
                    Id = 3,
                    IdUploader = 1,
                    IdCategory = 1,
                    Name = "Image 3 name",
                    Description = null,
                    FileId = Guid.NewGuid(),

                    Category = categories.ElementAt(0)
                },
                new DbImage
                {
                    RowVersion = new byte[] {0, 0, 0, 0, 0, 0, 0, 0},
                    Id = 4,
                    IdUploader = 1,
                    IdCategory = 1,
                    Name = null,
                    Description = null,
                    FileId = Guid.NewGuid(),

                    Category = categories.ElementAt(0)
                },
                new DbImage
                {
                    RowVersion = new byte[] {0, 0, 0, 0, 0, 0, 0, 0},
                    Id = 5,
                    IdUploader = 2,
                    IdCategory = 1,
                    Name = "Image 5 name",
                    Description = "Image 5 description",
                    FileId = Guid.NewGuid(),

                    Category = categories.ElementAt(0)
                },
                new DbImage
                {
                    RowVersion = new byte[] {0, 0, 0, 0, 0, 0, 0, 0},
                    Id = 6,
                    IdUploader = 2,
                    IdCategory = 1,
                    Name = "Image 5 name",
                    Description = null,
                    FileId = Guid.NewGuid(),

                    Category = categories.ElementAt(0)
                },
                new DbImage
                {
                    RowVersion = new byte[] {0, 0, 0, 0, 0, 0, 0, 0},
                    Id = 7,
                    IdUploader = 2,
                    IdCategory = 2,
                    Name = "Image 7 name",
                    Description = "Image 7 description",
                    FileId = Guid.NewGuid(),

                    Category = categories.ElementAt(1)
                },
                new DbImage
                {
                    RowVersion = new byte[] {0, 0, 0, 0, 0, 0, 0, 0},
                    Id = 8,
                    IdUploader = 2,
                    IdCategory = 3,
                    Name = "Image 8 name",
                    Description = "Image 8 description",
                    FileId = Guid.NewGuid(),

                    Category = categories.ElementAt(2)
                },
                new DbImage
                {
                    RowVersion = new byte[] {0, 0, 0, 0, 0, 0, 0, 0},
                    Id = 9,
                    IdUploader = 2,
                    IdCategory = 3,
                    Name = "Image 9 name",
                    Description = "Image 9 description",
                    FileId = Guid.NewGuid(),

                    Category = categories.ElementAt(2)
                },
                new DbImage
                {
                    RowVersion = new byte[] {0, 0, 0, 0, 0, 0, 0, 0},
                    Id = 10,
                    IdUploader = 2,
                    IdCategory = 3,
                    Name = "Image 8 name",
                    Description = null,
                    FileId = Guid.NewGuid(),

                    Category = categories.ElementAt(2)
                },
                new DbImage
                {
                    RowVersion = new byte[] {0, 0, 0, 0, 0, 0, 0, 0},
                    Id = 11,
                    IdUploader = 2,
                    IdCategory = 3,
                    Name = null,
                    Description = null,
                    FileId = Guid.NewGuid(),

                    Category = categories.ElementAt(2)
                }
            });

            this.Tags.AddRange(new List<DbTag>()
            {
                new DbTag
                {
                    RowVersion = new byte[] {0, 0, 0, 0, 0, 0, 0, 0},
                    Id = 1,
                    Name = "Super",
                    Images = this.Images.Where(el => el.Id % 2 == 0).ToList()
                },
                new DbTag
                {
                    RowVersion = new byte[] {0, 0, 0, 0, 0, 0, 0, 0},
                    Id = 2,
                    Name = "Meh",
                    Images = this.Images.Where(el => el.Id % 2 == 1).ToList()
                },
                new DbTag
                {
                    RowVersion = new byte[] {0, 0, 0, 0, 0, 0, 0, 0},
                    Id = 3,
                    Name = "Blah",
                    Images = this.Images.Where(el => el.Id > 10).ToList()
                },
            });
            #endregion
        }
    }
}
