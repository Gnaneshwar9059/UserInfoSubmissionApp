namespace UserInfoSubmissionApp.Validators;

public sealed class SubmissionValidationException : Exception
{
    public SubmissionValidationException(string message)
        : base(message) { }
}