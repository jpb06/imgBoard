using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImgBoard.Shared.Tests.Data.Database.Primitives.Main
{
    public class ImagesTagsSqlHelper
    {
        private SqlConnection connection;

        public ImagesTagsSqlHelper(SqlConnection connection)
        {
            this.connection = connection;
        }

        public Tuple<int, int> Create(int imageId, int tagId)
        {
            SqlCommand command = new SqlCommand("INSERT INTO [dbo].[ImagesTags] ([idImage],[idTag]) VALUES (@imageId, @tagId);", connection);
            command.Parameters.AddWithValue("@imageId", imageId);
            command.Parameters.AddWithValue("@tagId", tagId);
            command.ExecuteScalar();

            return Tuple.Create(imageId, tagId);
        }

        public void Delete(Tuple<int, int> id)
        {
            SqlCommand command = new SqlCommand("DELETE FROM [dbo].[ImagesTags] WHERE [idImage] = @imageId AND [idTag] = @tagId;", connection);
            command.Parameters.AddWithValue("@imageId", id.Item1);
            command.Parameters.AddWithValue("@tagId", id.Item2);
            command.ExecuteNonQuery();
        }
    }
}
