using ImgBoard.Dal.Context.Contracts;
using ImgBoard.Dal.Models.Main;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImgBoard.Dal.Context.Base
{
    public class ImgBoardBaseContext : DbContext, IImgBoardContext
    {
        public ImgBoardBaseContext(string connectionString)
            : base(connectionString)
        {
        }

        public virtual IDbSet<DbCategory> Categories { get; set; }
        public virtual IDbSet<DbComment> Comments { get; set; }
        public virtual IDbSet<DbImage> Images { get; set; }
        public virtual IDbSet<DbTag> Tags { get; set; }
        public virtual IDbSet<DbUser> Users { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var categoriesModel = modelBuilder.Entity<DbCategory>();
            categoriesModel.HasKey(t => t.Id);
            categoriesModel.Property(t => t.RowVersion).IsFixedLength();

            var commentsModel = modelBuilder.Entity<DbComment>();
            commentsModel.HasKey(t => t.Id);
            commentsModel.Property(t => t.RowVersion).IsFixedLength();
            commentsModel.HasRequired(t => t.Image).WithMany(t => t.Comments).WillCascadeOnDelete(false);
            commentsModel.HasRequired(t => t.Creator).WithMany(t => t.Comments).WillCascadeOnDelete(false);

            var imagesModel = modelBuilder.Entity<DbImage>();
            imagesModel.HasKey(t => t.Id);
            imagesModel.Property(t => t.RowVersion).IsFixedLength();
            imagesModel.HasMany(t => t.Tags)
                       .WithMany(t => t.Images)
                       .Map(j =>
                       {
                           j.MapLeftKey("idImage");
                           j.MapRightKey("idTag");
                           j.ToTable("ImagesTags");
                       });


            var tagsModel = modelBuilder.Entity<DbTag>();
            tagsModel.HasKey(t => t.Id);
            tagsModel.Property(t => t.RowVersion).IsFixedLength();

            var usersModel = modelBuilder.Entity<DbUser>();
            usersModel.HasKey(t => t.Id);
            usersModel.Property(t => t.RowVersion).IsFixedLength();
        }
    }
}
