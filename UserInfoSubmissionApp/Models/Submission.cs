namespace UserInfoSubmissionApp.Models;

public sealed class Submission
{
    public int Id { get; set; }

    public string CreatedByKey { get; set; } = string.Empty;

    public string FirstName { get; set; } = string.Empty;

    public string? MiddleName { get; set; }

    public string LastName { get; set; } = string.Empty;

    public string Gender { get; set; } = string.Empty;

    public DateTime DateOfBirth { get; set; }

    public int Age { get; set; }

    public string MobileNumber { get; set; } = string.Empty;

    public string Country { get; set; } = string.Empty;

    public string State { get; set; } = string.Empty;

    public DateTime SubmittedAt { get; set; }
}