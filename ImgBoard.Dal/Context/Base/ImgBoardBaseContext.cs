using ImgBoard.Dal.Context.Contracts;
using ImgBoard.Models.Main;
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

        public virtual IDbSet<Category> Categories { get; set; }
        public virtual IDbSet<Comment> Comments { get; set; }
        public virtual IDbSet<Image> Images { get; set; }
        public virtual IDbSet<Tag> Tags { get; set; }
        public virtual IDbSet<User> Users { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var categoriesModel = modelBuilder.Entity<Category>();
            categoriesModel.HasKey(t => t.Id);
            categoriesModel.Property(t => t.RowVersion).IsFixedLength();

            var commentsModel = modelBuilder.Entity<Comment>();
            commentsModel.HasKey(t => t.Id);
            commentsModel.Property(t => t.RowVersion).IsFixedLength();
            commentsModel.HasRequired(t => t.Image).WithMany(t => t.Comments).WillCascadeOnDelete(false);
            commentsModel.HasRequired(t => t.Creator).WithMany(t => t.Comments).WillCascadeOnDelete(false);

            var imagesModel = modelBuilder.Entity<Image>();
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


            var tagsModel = modelBuilder.Entity<Tag>();
            tagsModel.HasKey(t => t.Id);
            tagsModel.Property(t => t.RowVersion).IsFixedLength();

            var usersModel = modelBuilder.Entity<User>();
            usersModel.HasKey(t => t.Id);
            usersModel.Property(t => t.RowVersion).IsFixedLength();
        }
    }
}
