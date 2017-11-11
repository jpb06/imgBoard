using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImgBoard.Shared.Tests.Data.Database.Primitives.Main
{
    public class UsersSqlHelper
    {
        private SqlConnection connection;

        public UsersSqlHelper(SqlConnection connection)
        {
            this.connection = connection;
        }

        public int Create(string login, string password, string username)
        {
            SqlCommand command = new SqlCommand("INSERT INTO [dbo].[Users] ([Login], [Password], [UserName]) output inserted.Id VALUES (@login, @password, @username);", connection);
            command.Parameters.AddWithValue("@login", login);
            command.Parameters.AddWithValue("@password", password);
            command.Parameters.AddWithValue("@username", username);
            return (int)command.ExecuteScalar();
        }

        public void Modify(int id, string login, string password, string username)
        {
            SqlCommand command = new SqlCommand("UPDATE [dbo].[Users] "+
                                                "SET [Login] = @login, [Password] = @password, [UserName] = @username " +
                                                "WHERE [Id] = @id;", connection);
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@login", login);
            command.Parameters.AddWithValue("@password", password);
            command.Parameters.AddWithValue("@username", username);
            command.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            SqlCommand command = new SqlCommand("DELETE FROM [dbo].[Users] WHERE [Id] = @id;", connection);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
        }
    }
}
