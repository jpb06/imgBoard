using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImgBoard.Shared.Tests.Data.Database.Primitives.Main
{
    public class TagsSqlHelper
    {
        private SqlConnection connection;

        public TagsSqlHelper(SqlConnection connection)
        {
            this.connection = connection;
        }

        public int Create(string name)
        {
            SqlCommand command = new SqlCommand("INSERT INTO [dbo].[Tags] ([Name]) output inserted.Id VALUES (@name);", connection);
            command.Parameters.AddWithValue("@name", name);
            return (int)command.ExecuteScalar();
        }

        public void Modify(int id, string name)
        {
            SqlCommand command = new SqlCommand("UPDATE [dbo].[Tags] SET [Name] = @name WHERE [Id] = @id;", connection);
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@name", name);
            command.ExecuteNonQuery();
        }

        public void ModifyName(int id, string name)
        {
            SqlCommand command = new SqlCommand("UPDATE [dbo].[Tags] SET " +
                                                "[Name] = @name " +
                                                "WHERE [Id] = @id;", connection);
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@name", name);
            command.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            SqlCommand command = new SqlCommand("DELETE FROM [dbo].[Tags] WHERE [Id] = @id;", connection);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
        }
    }
}
