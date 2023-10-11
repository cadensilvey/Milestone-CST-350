using Microsoft.Data.SqlClient;
using Milestone_CST_350.Models;

namespace Milestone_CST_350.Services
{
    public class RegisterDAO
    {

        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Milestone;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        public bool AddUserToDatabase(RegistrationModel user)
        {
            bool success = false;

            // Use a parameterized SQL statement for security and to prevent SQL injection
            string sqlStatement = "INSERT INTO dbo.users (firstName, lastName, sex, age, state, emailAddress, username, password) " +
                                  "VALUES (@FIRSTNAME, @LASTNAME, @SEX, @AGE, @STATE, @EMAILADDRESS, @USERNAME, @PASSWORD)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                command.Parameters.Add("@FIRSTNAME", System.Data.SqlDbType.VarChar, 50).Value = user.FirstName;
                command.Parameters.Add("@LASTNAME", System.Data.SqlDbType.VarChar, 50).Value = user.LastName;
                command.Parameters.Add("@SEX", System.Data.SqlDbType.VarChar, 50).Value = user.Sex;
                command.Parameters.Add("@AGE", System.Data.SqlDbType.Int).Value = user.Age; 
                command.Parameters.Add("@STATE", System.Data.SqlDbType.VarChar, 50).Value = user.State;
                command.Parameters.Add("@EMAILADDRESS", System.Data.SqlDbType.VarChar, 50).Value = user.Email;
                command.Parameters.Add("@USERNAME", System.Data.SqlDbType.VarChar, 50).Value = user.Username;
                command.Parameters.Add("@PASSWORD", System.Data.SqlDbType.VarChar, 50).Value = user.Password;

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery(); // Use ExecuteNonQuery to execute an INSERT statement

                    if (rowsAffected > 0)
                        success = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return success;
        }
    }
}
