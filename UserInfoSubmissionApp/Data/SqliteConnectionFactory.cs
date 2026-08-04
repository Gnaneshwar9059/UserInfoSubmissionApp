using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Options;
using UserInfoSubmissionApp.Configuration;

namespace UserInfoSubmissionApp.Data;

public interface ISqliteConnectionFactory
{
    SqliteConnection CreateConnection();
}
public sealed class SqliteConnectionFactory : ISqliteConnectionFactory
{
    private readonly string _connectionString;

    public SqliteConnectionFactory(IOptions<DatabaseOptions> options)
    {
        var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        var applicationFolder = Path.Combine(appDataPath, "UserInfoSubmissionApp");

        Directory.CreateDirectory(applicationFolder);

        var databasePath = Path.Combine(applicationFolder, options.Value.FileName);

        _connectionString = $"Data Source={databasePath}";
    }

    public SqliteConnection CreateConnection()
    {
        return new SqliteConnection(_connectionString);
    }
}