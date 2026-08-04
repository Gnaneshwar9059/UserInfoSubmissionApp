using UserInfoSubmissionApp.Extensions;
using UserInfoSubmissionApp.Models;
using UserInfoSubmissionApp.Repositories;

namespace UserInfoSubmissionApp.Services;

public interface ISubmissionService
{
    Task SaveAsync(Submission submission);

    Task<bool> UserExistsAsync(
        string createdBy,
        string firstName,
        string lastName);

    Task UpdateAsync(Submission submission);

    Task DeleteAsync(int id);

    Task<IReadOnlyList<Submission>> GetByUserKeyAsync(string createdBy);
}

public sealed class SubmissionService : ISubmissionService
{
    private readonly ISubmissionRepository _repository;

    public SubmissionService(ISubmissionRepository repository)
    {
        _repository = repository;
    }

    public async Task SaveAsync(Submission submission)
    {
        submission.Age = submission.DateOfBirth.CalculateAge();
        submission.SubmittedAt = DateTime.UtcNow;

        await _repository.AddAsync(submission);
    }

    public Task<bool> UserExistsAsync(
        string createdBy,
        string firstName,
        string lastName)
    {
        return _repository.ExistsAsync(
            createdBy,
            firstName,
            lastName);
    }

    public async Task UpdateAsync(Submission submission)
    {
        submission.Age = submission.DateOfBirth.CalculateAge();
        submission.SubmittedAt = DateTime.UtcNow;

        await _repository.UpdateAsync(submission);
    }

    public Task DeleteAsync(int id)
    {
        return _repository.DeleteAsync(id);
    }

    public Task<IReadOnlyList<Submission>> GetByUserKeyAsync(string createdBy)
    {
        return _repository.GetByCreatedByAsync(createdBy);
    }
}