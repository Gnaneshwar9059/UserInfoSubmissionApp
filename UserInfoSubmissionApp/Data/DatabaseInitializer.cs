using Dapper;
using Microsoft.Data.Sqlite;

namespace UserInfoSubmissionApp.Data;

/// <summary>
/// Creates the SQLite database schema on first run.
/// Safe to call on every startup — uses CREATE TABLE IF NOT EXISTS.
/// </summary>
public sealed class DatabaseInitializer
{
    private readonly ISqliteConnectionFactory _connectionFactory;

    public DatabaseInitializer(ISqliteConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public void Initialize()
    {
        using var connection = _connectionFactory.CreateConnection();
        connection.Open();

        connection.Execute(
            """
            CREATE TABLE IF NOT EXISTS Submissions
            (
                Id           INTEGER PRIMARY KEY AUTOINCREMENT,
                CreatedByKey TEXT    NOT NULL,
                FirstName    TEXT    NOT NULL,
                MiddleName   TEXT,
                LastName     TEXT    NOT NULL,
                Gender       TEXT    NOT NULL,
                DateOfBirth  TEXT    NOT NULL,
                Age          INTEGER NOT NULL,
                MobileNumber TEXT    NOT NULL,
                Country      TEXT    NOT NULL,
                State        TEXT    NOT NULL,
                SubmittedAt  TEXT    NOT NULL
            );
            CREATE INDEX IF NOT EXISTS IX_Submissions_CreatedByKey
                ON Submissions(CreatedByKey);

            """);
    }
}