namespace UserInfoSubmissionApp.Models;
public sealed class LoggedInUser
{
    public string FirstName { get; init; } = string.Empty;

    public string LastName { get; init; } = string.Empty;
    public string DisplayName => $"{FirstName} {LastName}";
    public string UserKey =>
        $"{FirstName.Trim().ToLowerInvariant()}|{LastName.Trim().ToLowerInvariant()}";
}