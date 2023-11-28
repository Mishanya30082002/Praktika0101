using MySqlConnector;
namespace PraktikaVanyushkin;

public class DBHelper
{
    public MySqlConnectionStringBuilder _connectionString { get; }

    public DBHelper()
    {
        _connectionString = new MySqlConnectionStringBuilder
        {
            Server = "localhost",
            Database = "medical",
            UserID = "root",
            Password = "123456"

        };
    }
}