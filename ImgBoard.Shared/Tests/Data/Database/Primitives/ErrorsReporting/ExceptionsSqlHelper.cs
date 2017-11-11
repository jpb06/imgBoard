using ImgBoard.Models.ErrorsReporting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImgBoard.Shared.Tests.Data.Database.Primitives.ErrorsReporting
{
    public class ExceptionsSqlHelper
    {
        private SqlConnection connection;

        public ExceptionsSqlHelper(SqlConnection connection)
        {
            this.connection = connection;
        }

        public void Delete(int id)
        {
            SqlCommand command = new SqlCommand("DELETE FROM [dbo].[Exceptions] WHERE [Id] = @id;", connection);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
        }

        public ErrorReportException GetBy(int id)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM [dbo].[Exceptions] WHERE [Id] = @id;", connection);
            command.Parameters.AddWithValue("@id", id);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                reader.Read();
                return new ErrorReportException
                {
                    Id = reader.GetInt32(0),
                    IdInnerException = reader.IsDBNull(1) ? (int?)null : reader.GetInt32(1),
                    IdApplication = reader.GetInt32(2),
                    Type = reader.GetString(3),
                    Message = reader.GetString(4),
                    Source = reader.GetString(5),
                    SiteModule = reader.GetString(6),
                    SiteName = reader.GetString(7),
                    StackTrace = reader.GetString(8),
                    CustomErrorType = reader.IsDBNull(9) ? null : reader.GetString(8),
                    HelpLink = reader.IsDBNull(10) ? null : reader.GetString(9),
                    Date = reader.GetDateTime(11),
                    RowVersion = reader.GetValue(12) as byte[]
                };
            }
        }

        public ErrorReportException GetBy(string application, string version)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM [dbo].[Exceptions] " +
                                                "JOIN [dbo].[Applications] on [dbo].[Exceptions].[IdApplication] = [dbo].[Applications].[Id] " +
                                                "WHERE [dbo].[Applications].[Name] = @name AND [dbo].[Applications].[Version] = @version " +
                                                "ORDER BY [dbo].[Exceptions].[Date] desc;", connection);
            command.Parameters.AddWithValue("@name", application);
            command.Parameters.AddWithValue("@version", version);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                reader.Read();
                return new ErrorReportException
                {
                    Id = reader.GetInt32(0),
                    IdInnerException = reader.IsDBNull(1) ? (int?)null : reader.GetInt32(1),
                    IdApplication = reader.GetInt32(2),
                    Type = reader.GetString(3),
                    Message = reader.GetString(4),
                    Source = reader.GetString(5),
                    SiteModule = reader.GetString(6),
                    SiteName = reader.GetString(7),
                    StackTrace = reader.GetString(8),
                    CustomErrorType = reader.IsDBNull(9) ? null : reader.GetString(8),
                    HelpLink = reader.IsDBNull(10) ? null : reader.GetString(9),
                    Date = reader.GetDateTime(11),
                    RowVersion = reader.GetValue(12) as byte[]
                };
            }
        }
    }
}
