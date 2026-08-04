using Dapper;
using UserInfoSubmissionApp.Data;
using UserInfoSubmissionApp.Models;

namespace UserInfoSubmissionApp.Repositories;

public interface ISubmissionRepository
{
    Task AddAsync(Submission submission);

    Task<bool> ExistsAsync(string createdBy, string firstName, string lastName);

    Task UpdateAsync(Submission submission);

    Task<IReadOnlyList<Submission>> GetByCreatedByAsync(string createdBy);

    Task DeleteAsync(int id);
}

public sealed class SubmissionRepository : ISubmissionRepository
{
    private readonly ISqliteConnectionFactory _connectionFactory;

    public SubmissionRepository(ISqliteConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task AddAsync(Submission submission)
    {
        using var connection = _connectionFactory.CreateConnection();

        const string sql =
            """
            INSERT INTO Submissions
            (
                CreatedByKey,
                FirstName,
                MiddleName,
                LastName,
                Gender,
                DateOfBirth,
                Age,
                MobileNumber,
                State,
                Country,
                SubmittedAt
            )
            VALUES
            (
                @CreatedByKey,
                @FirstName,
                @MiddleName,
                @LastName,
                @Gender,
                @DateOfBirth,
                @Age,
                @MobileNumber,
                @State,
                @Country,
                @SubmittedAt
            );
            """;

        await connection.ExecuteAsync(sql, submission);
    }

    public async Task<bool> ExistsAsync(
        string createdBy,
        string firstName,
        string lastName)
    {
        using var connection = _connectionFactory.CreateConnection();

        const string sql =
            """
            SELECT EXISTS
            (
                SELECT 1
                FROM Submissions
                WHERE CreatedByKey = @CreatedByKey  
                AND FirstName = @FirstName
                AND LastName = @LastName
            );
            """;

        return await connection.ExecuteScalarAsync<bool>(sql, new
        {
            CreatedByKey = createdBy,
            FirstName = firstName,
            LastName = lastName
        });
    }

    public async Task UpdateAsync(Submission submission)
    {
        using var connection = _connectionFactory.CreateConnection();

        const string sql =
            """
            UPDATE Submissions
            SET
                MiddleName = @MiddleName,
                Gender = @Gender,
                DateOfBirth = @DateOfBirth,
                Age = @Age,
                MobileNumber = @MobileNumber,
                State = @State,
                Country = @Country,
                SubmittedAt = @SubmittedAt
            WHERE
                CreatedByKey = @CreatedByKey
            AND FirstName = @FirstName
            AND LastName = @LastName;
            """;

        await connection.ExecuteAsync(sql, submission);
    }

    public async Task<IReadOnlyList<Submission>> GetByCreatedByAsync(string createdBy)
    {
        using var connection = _connectionFactory.CreateConnection();

        const string sql =
            """
            SELECT
                Id,
                CreatedByKey,
                FirstName,
                MiddleName,
                LastName,
                Gender,
                DateOfBirth,
                Age,
                MobileNumber,
                State,
                Country,
                SubmittedAt
            FROM Submissions
            WHERE CreatedByKey = @CreatedByKey
            ORDER BY SubmittedAt DESC;
            """;

        var result = await connection.QueryAsync<Submission>(sql, new
        {
            CreatedByKey = createdBy
        });

        return result.ToList();
    }

    public async Task DeleteAsync(int id)
    {
        using var connection = _connectionFactory.CreateConnection();

        const string sql =
            """
            DELETE FROM Submissions
            WHERE Id = @Id;
            """;

        await connection.ExecuteAsync(sql, new
        {
            Id = id
        });
    }
}