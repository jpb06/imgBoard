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
            this.Categories.AddRange(new List<DbCategory>()
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
            });
            #endregion
        }
    }
}
