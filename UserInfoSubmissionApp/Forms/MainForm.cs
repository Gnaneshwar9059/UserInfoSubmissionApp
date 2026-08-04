using UserInfoSubmissionApp.Controls;
using UserInfoSubmissionApp.Models;
using UserInfoSubmissionApp.Services;

namespace UserInfoSubmissionApp.Forms;

public partial class MainForm : Form
{
    private readonly LoggedInUser _loggedInUser;
    private readonly ISubmissionService _submissionService;

    private HistoryControl _historyControl = null!;

    public bool LogoutRequested { get; private set; }

    public MainForm(
        LoggedInUser loggedInUser,
        ISubmissionService submissionService)
    {
        _loggedInUser = loggedInUser;
        _submissionService = submissionService;

        InitializeComponent();

        LoadControls();

        ApplyUserInformation();
    }

    private void LoadControls()
    {
        var _submissionControl = new SubmissionControl(
            _loggedInUser,
            _submissionService);

        _historyControl = new HistoryControl(
            _loggedInUser,
            _submissionService);

        _submissionControl.SubmissionSaved += async (_, _) =>
        {
            await _historyControl.LoadSubmissionsAsync();
        };

        _submissionControl.Dock = DockStyle.Fill;
        _historyControl.Dock = DockStyle.Fill;

        tabSubmit.Controls.Add(_submissionControl);
        tabHistory.Controls.Add(_historyControl);
    }

    private void ApplyUserInformation()
    {
        lblWelcome.Text =
            $"Logged in as: {_loggedInUser.DisplayName}";
    }

    private void btnLogout_Click(object? sender, EventArgs e)
    {
        var result = MessageBox.Show(
            "Are you sure you want to logout?",
            "Logout",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (result != DialogResult.Yes)
        {
            return;
        }

        LogoutRequested = true;

        Close();
    }
}