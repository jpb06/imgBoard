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

        public List<int> CategoriesIds { get; private set; }
        public List<int> ImagesIds { get; private set; }
        public List<int> UsersIds { get; private set; }

        public PersistentMainDataSet()
        {
            this.CategoriesIds = new List<int>();
            this.ImagesIds = new List<int>();
            this.UsersIds = new List<int>();

            this.connection = new SqlConnection(DatabaseConfiguration.MainConnectionString);
            this.connection.Open();

            this.categories = new CategoriesSqlHelper(this.connection);
            this.images = new ImagesSqlHelper(this.connection);
            this.users = new UsersSqlHelper(this.connection);
        }

        public void Initialize()
        {
            this.UsersIds.Add(this.users.Create("a", "a", "User 1"));
            this.UsersIds.Add(this.users.Create("b", "b", "User 2"));

            this.CategoriesIds.Add(this.categories.Create("Test Category 1"));
            this.CategoriesIds.Add(this.categories.Create("Test Category 2"));
            this.CategoriesIds.Add(this.categories.Create("Test Category 3"));

            this.ImagesIds.Add(this.images.Create(this.CategoriesIds.ElementAt(0), this.UsersIds.ElementAt(0), "image 1", "image 1 Description", Guid.NewGuid()));
            this.ImagesIds.Add(this.images.Create(this.CategoriesIds.ElementAt(1), this.UsersIds.ElementAt(0), "image 2", null, Guid.NewGuid()));
            this.ImagesIds.Add(this.images.Create(this.CategoriesIds.ElementAt(2), this.UsersIds.ElementAt(0), "image 3", "image 3 Description", Guid.NewGuid()));

            this.ImagesIds.Add(this.images.Create(this.CategoriesIds.ElementAt(0), this.UsersIds.ElementAt(1), "image 4", null, Guid.NewGuid()));
            this.ImagesIds.Add(this.images.Create(this.CategoriesIds.ElementAt(1), this.UsersIds.ElementAt(1), "image 5", "image 5 Description", Guid.NewGuid()));
        }

        public void Destroy()
        {
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
