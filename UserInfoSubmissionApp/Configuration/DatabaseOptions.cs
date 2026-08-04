namespace UserInfoSubmissionApp.Configuration;

public sealed class DatabaseOptions
{
    public const string SectionName = "Database";

    public string FileName { get; init; } = string.Empty;
}