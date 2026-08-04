using UserInfoSubmissionApp.Models;

namespace UserInfoSubmissionApp.Forms;

public partial class LoginForm : Form
{
    public LoggedInUser? LoggedInUser { get; private set; }

    public LoginForm()
    {
        InitializeComponent();
    }

    private void btnContinue_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtFirstName.Text))
        {
            MessageBox.Show(
                "First Name is required.",
                "Validation",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            txtFirstName.Focus();
            return;
        }

        if (string.IsNullOrWhiteSpace(txtLastName.Text))
        {
            MessageBox.Show(
                "Last Name is required.",
                "Validation",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            txtLastName.Focus();
            return;
        }

        LoggedInUser = new LoggedInUser
        {
            FirstName = txtFirstName.Text.Trim(),
            LastName = txtLastName.Text.Trim()
        };

        DialogResult = DialogResult.OK;
        Close();
    }
}