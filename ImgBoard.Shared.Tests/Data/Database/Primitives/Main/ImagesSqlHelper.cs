using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImgBoard.Shared.Tests.Data.Database.Primitives.Main
{
    public class ImagesSqlHelper
    {
        private SqlConnection connection;

        public ImagesSqlHelper(SqlConnection connection)
        {
            this.connection = connection;
        }

        public int Create(int? idCategory, int idUser, string name, string description, Guid fileId)
        {
            SqlCommand command = new SqlCommand("INSERT INTO [dbo].[Images] ([IdCategory], [IdUploader], [Name], [Description], [FileId]) " +
                                                "output inserted.Id VALUES (@idCategory, @idUser, @name, @description, @fileId);", connection);
            command.Parameters.AddWithValue("@idCategory", idCategory ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@idUser", idUser);
            command.Parameters.AddWithValue("@name", name ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@description", description ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@fileId", fileId);
            return (int)command.ExecuteScalar();
        }

        public void Modify(int id, int? idCategory, int idUser, string name, string description, Guid fileId)
        {
            SqlCommand command = new SqlCommand("UPDATE [dbo].[Images] "+
                                                "SET [IdCategory] = @idCategory, [IdUploader] = @idUser, [Name] = @name, [Description] = @description, [FileId] = @fileId " +
                                                "WHERE [Id] = @id;", connection);
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@idCategory", idCategory ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@idUser", idUser);
            command.Parameters.AddWithValue("@name", name ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@description", description ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@fileId", fileId);
            command.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            SqlCommand command = new SqlCommand("DELETE FROM [dbo].[Images] WHERE [Id] = @id;", connection);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
        }
    }
}
