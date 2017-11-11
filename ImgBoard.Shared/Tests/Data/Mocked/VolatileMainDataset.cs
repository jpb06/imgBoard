using ImgBoard.Models.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImgBoard.Shared.Tests.Data.Mocked
{
    public class VolatileMainDataset
    {
        public List<Category> Categories { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Image> Images { get; set; }
        public List<Tag> Tags { get; set; }
        public List<User> Users { get; set; }

        public VolatileMainDataset()
        {
            this.Categories = new List<Category>();
            this.Comments = new List<Comment>();
            this.Images = new List<Image>();
            this.Tags = new List<Tag>();
            this.Users = new List<User>();

            this.Populate();
        }

        public void Populate()
        {
            #region Articles
            this.Categories.AddRange(new List<Category>()
            {
                new Category
                {
                    RowVersion = new byte[] {0, 0, 0, 0, 0, 0, 0, 0},
                    Id = 1, 
                    Title = "Category 1"
                },
                new Category
                {
                    RowVersion = new byte[] {0, 0, 0, 0, 0, 0, 0, 0},
                    Id = 2,
                    Title = "Category 2"
                },
                new Category
                {
                    RowVersion = new byte[] {0, 0, 0, 0, 0, 0, 0, 0},
                    Id = 3,
                    Title = "Category 3"
                },
                new Category
                {
                    RowVersion = new byte[] {0, 0, 0, 0, 0, 0, 0, 0},
                    Id = 4,
                    Title = "Category 4"
                },
                new Category
                {
                    RowVersion = new byte[] {0, 0, 0, 0, 0, 0, 0, 0},
                    Id = 5,
                    Title = "Category 5"
                },
            });
            #endregion
        }
    }
}
