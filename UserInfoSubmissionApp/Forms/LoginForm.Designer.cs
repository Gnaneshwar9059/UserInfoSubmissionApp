namespace UserInfoSubmissionApp.Forms;

partial class LoginForm
{
    private System.ComponentModel.IContainer? components = null;

    private Label lblTitle;
    private Label lblLogin;

    private Label lblFirstName;
    private Label lblLastName;

    private TextBox txtFirstName;
    private TextBox txtLastName;

    private Button btnContinue;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        lblTitle = new Label();
        lblLogin = new Label();

        lblFirstName = new Label();
        lblLastName = new Label();

        txtFirstName = new TextBox();
        txtLastName = new TextBox();

        btnContinue = new Button();

        SuspendLayout();

        ClientSize = new Size(520, 350);
        StartPosition = FormStartPosition.CenterScreen;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        Text = "User Information Submission";

        lblTitle.AutoSize = true;
        lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        lblTitle.Location = new Point(100, 30);
        lblTitle.Text = "User Information Submission";

        lblLogin.AutoSize = true;
        lblLogin.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
        lblLogin.Location = new Point(225, 80);
        lblLogin.Text = "Login";

        lblFirstName.AutoSize = true;
        lblFirstName.Location = new Point(80, 130);
        lblFirstName.Text = "First Name";

        txtFirstName.Location = new Point(80, 155);
        txtFirstName.Size = new Size(360, 23);

        lblLastName.AutoSize = true;
        lblLastName.Location = new Point(80, 195);
        lblLastName.Text = "Last Name";

        txtLastName.Location = new Point(80, 220);
        txtLastName.Size = new Size(360, 23);

        btnContinue.Location = new Point(190, 275);
        btnContinue.Size = new Size(140, 35);
        btnContinue.Text = "Login";
        btnContinue.Click += btnContinue_Click;

        Controls.Add(lblTitle);
        Controls.Add(lblLogin);

        Controls.Add(lblFirstName);
        Controls.Add(txtFirstName);

        Controls.Add(lblLastName);
        Controls.Add(txtLastName);

        Controls.Add(btnContinue);

        AcceptButton = btnContinue;

        ResumeLayout(false);
        PerformLayout();
    }
}