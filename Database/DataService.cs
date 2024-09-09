using System;
using System.Data.SQLite;

namespace Database;

public class DataService
{
    private readonly SQLiteConnection _connection;
    public DataService()
    {
        _connection = new SQLiteConnection("Data Source=AndonMobileAppDb.db");
    }

    public SQLiteConnection GetConnection()
    {
        return _connection;
    }
    public async Task<bool> AuthenticateUserAsync(string email, string password)
    {
        using (var connection = GetConnection())
        {
            await connection.OpenAsync();
            string query = "SELECT COUNT(*) FROM Users WHERE Email=@Email AND Password=@Password";
            using (var command = new SQLiteCommand(query, _connection))
            {
                command.Parameters.AddWithValue("Email", email);
                command.Parameters.AddWithValue("Password", password);
                int count = Convert.ToInt32(await command.ExecuteScalarAsync());
                return count > 0;
            }
        }
    }

}
