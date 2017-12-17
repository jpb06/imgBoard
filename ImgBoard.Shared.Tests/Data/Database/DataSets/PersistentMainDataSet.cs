using ImgBoard.Shared.Tests.Data.Database.Primitives.Main;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImgBoard.Shared.Tests.Data.Database.DataSets
{
    public class PersistentMainDataSet
    {
        private SqlConnection connection;
        private CategoriesSqlHelper categories;
        private UsersSqlHelper users;
        private ImagesSqlHelper images;
        private TagsSqlHelper tags;
        private ImagesTagsSqlHelper imagesTags;

        public List<int> CategoriesIds { get; private set; }
        public List<int> ImagesIds { get; private set; }
        public List<int> UsersIds { get; private set; }
        public List<int> TagsIds { get; private set; }
        public List<Tuple<int, int>> ImageTagIds { get; private set; }

        public PersistentMainDataSet()
        {
            this.CategoriesIds = new List<int>();
            this.ImagesIds = new List<int>();
            this.UsersIds = new List<int>();
            this.TagsIds = new List<int>();
            this.ImageTagIds = new List<Tuple<int, int>>();

            this.connection = new SqlConnection(DatabaseConfiguration.MainConnectionString);
            this.connection.Open();

            this.categories = new CategoriesSqlHelper(this.connection);
            this.images = new ImagesSqlHelper(this.connection);
            this.users = new UsersSqlHelper(this.connection);
            this.tags = new TagsSqlHelper(this.connection);
            this.imagesTags = new ImagesTagsSqlHelper(this.connection);
        }

        public void Initialize()
        {
            this.UsersIds.Add(this.users.Create("a", "a", "User 1"));
            this.UsersIds.Add(this.users.Create("b", "b", "User 2"));

            this.CategoriesIds.Add(this.categories.Create("Test Category 1"));
            this.CategoriesIds.Add(this.categories.Create("Test Category 2"));
            this.CategoriesIds.Add(this.categories.Create("Test Category 3"));

            this.ImagesIds.Add(this.images.Create(this.CategoriesIds.ElementAt(0), this.UsersIds.ElementAt(0), "image 1", "image 1 Description", Guid.NewGuid(), "jpg"));
            this.ImagesIds.Add(this.images.Create(this.CategoriesIds.ElementAt(1), this.UsersIds.ElementAt(0), "image 2", null, Guid.NewGuid(), "png"));
            this.ImagesIds.Add(this.images.Create(this.CategoriesIds.ElementAt(2), this.UsersIds.ElementAt(0), "image 3", "image 3 Description", Guid.NewGuid(), "gif"));

            this.ImagesIds.Add(this.images.Create(this.CategoriesIds.ElementAt(0), this.UsersIds.ElementAt(1), "image 4", null, Guid.NewGuid(), "jpg"));
            this.ImagesIds.Add(this.images.Create(this.CategoriesIds.ElementAt(1), this.UsersIds.ElementAt(1), "image 5", "image 5 Description", Guid.NewGuid(), "gif"));

            this.ImagesIds.Add(this.images.Create(null, this.UsersIds.ElementAt(0), null, "image 6 Description", Guid.NewGuid(), "png"));
            this.ImagesIds.Add(this.images.Create(null, this.UsersIds.ElementAt(1), "Image 7", null, Guid.NewGuid(), "jpg"));

            this.ImagesIds.Add(this.images.Create(this.CategoriesIds.ElementAt(0), this.UsersIds.ElementAt(0), "image 8", "image 8 Description", Guid.NewGuid(), "png"));

            this.TagsIds.Add(this.tags.Create("Good"));
            this.TagsIds.Add(this.tags.Create("Bad"));
            this.TagsIds.Add(this.tags.Create("Sad"));

            this.ImageTagIds.Add(this.imagesTags.Create(this.ImagesIds.ElementAt(0), this.TagsIds.ElementAt(0)));
            this.ImageTagIds.Add(this.imagesTags.Create(this.ImagesIds.ElementAt(3), this.TagsIds.ElementAt(0)));
            this.ImageTagIds.Add(this.imagesTags.Create(this.ImagesIds.ElementAt(5), this.TagsIds.ElementAt(0)));
            this.ImageTagIds.Add(this.imagesTags.Create(this.ImagesIds.ElementAt(6), this.TagsIds.ElementAt(0)));
            this.ImageTagIds.Add(this.imagesTags.Create(this.ImagesIds.ElementAt(7), this.TagsIds.ElementAt(0)));

            this.ImageTagIds.Add(this.imagesTags.Create(this.ImagesIds.ElementAt(1), this.TagsIds.ElementAt(1)));
            this.ImageTagIds.Add(this.imagesTags.Create(this.ImagesIds.ElementAt(2), this.TagsIds.ElementAt(1)));
            this.ImageTagIds.Add(this.imagesTags.Create(this.ImagesIds.ElementAt(4), this.TagsIds.ElementAt(1)));

            this.ImageTagIds.Add(this.imagesTags.Create(this.ImagesIds.ElementAt(0), this.TagsIds.ElementAt(2)));
            this.ImageTagIds.Add(this.imagesTags.Create(this.ImagesIds.ElementAt(2), this.TagsIds.ElementAt(2)));
            this.ImageTagIds.Add(this.imagesTags.Create(this.ImagesIds.ElementAt(4), this.TagsIds.ElementAt(2)));
            this.ImageTagIds.Add(this.imagesTags.Create(this.ImagesIds.ElementAt(6), this.TagsIds.ElementAt(2)));
        }

        public void Destroy()
        {
            foreach (var id in this.ImageTagIds)
                this.imagesTags.Delete(id);

            foreach (var id in this.TagsIds)
                this.tags.Delete(id);

            foreach (var id in this.ImagesIds)
                this.images.Delete(id);

            foreach (var id in this.UsersIds)
                this.users.Delete(id);

            foreach (var id in this.CategoriesIds)
                this.categories.Delete(id);
        }

        public void Dispose()
        {
            this.connection.Close();
            this.connection.Dispose();
        }
    }
}
