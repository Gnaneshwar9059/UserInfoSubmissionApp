namespace UserInfoSubmissionApp.Forms;

partial class MainForm
{
    private System.ComponentModel.IContainer? components = null;

    private TabControl tabControl;
    private TabPage tabSubmit;
    private TabPage tabHistory;

    private Label lblWelcome;
    private Button btnLogout;

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
        tabControl = new TabControl();
        tabSubmit = new TabPage();
        tabHistory = new TabPage();
        lblWelcome = new Label();
        btnLogout = new Button();

        tabControl.SuspendLayout();
        SuspendLayout();

        //
        // lblWelcome
        //
        lblWelcome.AutoSize = true;
        lblWelcome.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblWelcome.Location = new Point(20, 20);
        lblWelcome.Name = "lblWelcome";
        lblWelcome.Size = new Size(117, 23);
        lblWelcome.TabIndex = 0;
        lblWelcome.Text = "Logged in as:";
        lblWelcome.Anchor = AnchorStyles.Top | AnchorStyles.Left;

        //
        // btnLogout
        //
        btnLogout.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnLogout.Location = new Point(1080, 15);
        btnLogout.Name = "btnLogout";
        btnLogout.Size = new Size(100, 35);
        btnLogout.TabIndex = 1;
        btnLogout.Text = "Logout";
        btnLogout.UseVisualStyleBackColor = true;
        btnLogout.Click += btnLogout_Click;

        //
        // tabControl
        //
        tabControl.Anchor =
            AnchorStyles.Top |
            AnchorStyles.Bottom |
            AnchorStyles.Left |
            AnchorStyles.Right;

        tabControl.Controls.Add(tabSubmit);
        tabControl.Controls.Add(tabHistory);
        tabControl.Location = new Point(20, 70);
        tabControl.Name = "tabControl";
        tabControl.SelectedIndex = 0;
        tabControl.Size = new Size(1160, 610);
        tabControl.TabIndex = 2;

        //
        // tabSubmit
        //
        tabSubmit.Location = new Point(4, 29);
        tabSubmit.Name = "tabSubmit";
        tabSubmit.Padding = new Padding(15);
        tabSubmit.Size = new Size(1152, 577);
        tabSubmit.TabIndex = 0;
        tabSubmit.Text = "Submit Information";
        tabSubmit.UseVisualStyleBackColor = true;

        //
        // tabHistory
        //
        tabHistory.Location = new Point(4, 29);
        tabHistory.Name = "tabHistory";
        tabHistory.Padding = new Padding(15);
        tabHistory.Size = new Size(1152, 577);
        tabHistory.TabIndex = 1;
        tabHistory.Text = "My Submissions";
        tabHistory.UseVisualStyleBackColor = true;

        //
        // MainForm
        //
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;

        ClientSize = new Size(1200, 720);
        MinimumSize = new Size(1200, 720);

        StartPosition = FormStartPosition.CenterScreen;

        MaximizeBox = true;

        Controls.Add(lblWelcome);
        Controls.Add(btnLogout);
        Controls.Add(tabControl);

        Name = "MainForm";
        Text = "User Information Submission";

        tabControl.ResumeLayout(false);
        ResumeLayout(false);
        PerformLayout();
    }
}