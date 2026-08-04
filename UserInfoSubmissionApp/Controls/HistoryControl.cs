using UserInfoSubmissionApp.Models;
using UserInfoSubmissionApp.Services;

namespace UserInfoSubmissionApp.Controls;

public partial class HistoryControl : UserControl
{
    private readonly LoggedInUser _loggedInUser;
    private readonly ISubmissionService _submissionService;

    public HistoryControl(
        LoggedInUser loggedInUser,
        ISubmissionService submissionService)
    {
        _loggedInUser = loggedInUser;
        _submissionService = submissionService;

        InitializeComponent();

        Load += HistoryControl_Load;
        btnDelete.Click += BtnDelete_ClickAsync;
    }

    private async void HistoryControl_Load(object? sender, EventArgs e)
    {
        await LoadSubmissionsAsync();
    }

    public async Task LoadSubmissionsAsync()
    {
        var submissions = await _submissionService
            .GetByUserKeyAsync(_loggedInUser.UserKey);

        dgvSubmissions.DataSource = submissions;

        ConfigureGrid();
    }

    private async void BtnDelete_ClickAsync(object? sender, EventArgs e)
    {
        if (dgvSubmissions.CurrentRow?.DataBoundItem is not Submission submission)
        {
            MessageBox.Show(
                "Please select a user.",
                "Delete",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            return;
        }

        var result = MessageBox.Show(
            $"Delete '{submission.FirstName} {submission.LastName}'?",
            "Confirm Delete",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (result != DialogResult.Yes)
        {
            return;
        }

        await _submissionService.DeleteAsync(submission.Id);

        await LoadSubmissionsAsync();
    }

    private void ConfigureGrid()
    {
        if (dgvSubmissions.Columns.Count == 0)
        {
            return;
        }

        dgvSubmissions.Columns["Id"]!.Visible = false;
        dgvSubmissions.Columns["CreatedByKey"]!.Visible = false;

        dgvSubmissions.Columns["FirstName"]!.HeaderText = "First Name";
        dgvSubmissions.Columns["MiddleName"]!.HeaderText = "Middle Name";
        dgvSubmissions.Columns["LastName"]!.HeaderText = "Last Name";
        dgvSubmissions.Columns["MobileNumber"]!.HeaderText = "Mobile Number";
        dgvSubmissions.Columns["DateOfBirth"]!.HeaderText = "Date Of Birth";
        dgvSubmissions.Columns["SubmittedAt"]!.HeaderText = "Submitted Date";

        dgvSubmissions.Columns["DateOfBirth"]!
            .DefaultCellStyle.Format = "dd-MMM-yyyy";

        dgvSubmissions.Columns["SubmittedAt"]!
            .DefaultCellStyle.Format = "dd-MMM-yyyy HH:mm";

        dgvSubmissions.AutoSizeColumnsMode =
            DataGridViewAutoSizeColumnsMode.Fill;
    }
}