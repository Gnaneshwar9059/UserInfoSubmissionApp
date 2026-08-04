namespace UserInfoSubmissionApp.Controls;

partial class SubmissionControl
{
    private System.ComponentModel.IContainer? components = null;

    private Label lblFirstName;
    private Label lblMiddleName;
    private Label lblLastName;
    private Label lblGender;
    private Label lblDateOfBirth;
    private Label lblAge;
    private Label lblMobileNumber;
    private Label lblCountry;
    private Label lblState;

    private TextBox txtFirstName;
    private TextBox txtMiddleName;
    private TextBox txtLastName;
    private TextBox txtAge;
    private TextBox txtMobileNumber;

    private ComboBox cmbGender;
    private ComboBox cmbCountry;   // ✅ ComboBox — not TextBox
    private ComboBox cmbState;     // ✅ ComboBox — not TextBox, filters by country

    private DateTimePicker dtpDateOfBirth;
    private Button btnSave;
    private ErrorProvider errorProvider;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        errorProvider = new ErrorProvider(components) { BlinkStyle = ErrorBlinkStyle.NeverBlink };

        lblFirstName = MakeLabel("First Name *");
        lblMiddleName = MakeLabel("Middle Name (optional)");
        lblLastName = MakeLabel("Last Name *");
        lblGender = MakeLabel("Gender *");
        lblDateOfBirth = MakeLabel("Date of Birth *");
        lblAge = MakeLabel("Age");
        lblMobileNumber = MakeLabel("Mobile Number *");
        lblCountry = MakeLabel("Country *");
        lblState = MakeLabel("State / Province *");

        txtFirstName = MakeTextBox();
        txtMiddleName = MakeTextBox();
        txtLastName = MakeTextBox();
        txtMobileNumber = MakeTextBox();
        txtAge = MakeTextBox();
        txtAge.ReadOnly = true;
        txtAge.BackColor = SystemColors.Control;

        cmbGender = MakeCombo();
        cmbCountry = MakeCombo();
        cmbState = MakeCombo();

        dtpDateOfBirth = new DateTimePicker
        {
            Format = DateTimePickerFormat.Short,
            MaxDate = DateTime.Today.AddDays(-1),
            Value = DateTime.Today.AddYears(-18)
        };


        btnSave = new Button
        {
            Text = "Save Submission",
            Size = new Size(180, 40),
            BackColor = Color.FromArgb(0, 120, 215),
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Segoe UI", 10f, FontStyle.Bold),
            Cursor = Cursors.Hand
        };
        btnSave.FlatAppearance.BorderSize = 0;

        // ── Layout — two-column grid ─────────────────────────────────────
        const int col1 = 30;
        const int col2 = 370;
        const int w = 280;

        int row = 30;
        PlaceLabel(lblFirstName, col1, row); PlaceCntrl(txtFirstName, col1, row + 22, w);
        PlaceLabel(lblGender, col2, row); PlaceCntrl(cmbGender, col2, row + 22, w);

        row = 100;
        PlaceLabel(lblMiddleName, col1, row); PlaceCntrl(txtMiddleName, col1, row + 22, w);
        PlaceLabel(lblDateOfBirth, col2, row); PlaceCntrl(dtpDateOfBirth, col2, row + 22, w);

        row = 170;
        PlaceLabel(lblLastName, col1, row); PlaceCntrl(txtLastName, col1, row + 22, w);
        PlaceLabel(lblAge, col2, row); PlaceCntrl(txtAge, col2, row + 22, w);

        row = 240;
        PlaceLabel(lblMobileNumber, col1, row); PlaceCntrl(txtMobileNumber, col1, row + 22, w);
        PlaceLabel(lblCountry, col2, row); PlaceCntrl(cmbCountry, col2, row + 22, w);

        row = 310;
        PlaceLabel(lblState, col2, row); PlaceCntrl(cmbState, col2, row + 22, w);

        btnSave.Location = new Point(col1, 380);

        SuspendLayout();
        Size = new Size(700, 460);

        Controls.AddRange([
            lblFirstName, txtFirstName,
            lblMiddleName, txtMiddleName,
            lblLastName, txtLastName,
            lblGender, cmbGender,
            lblDateOfBirth, dtpDateOfBirth,
            lblAge, txtAge,
            lblMobileNumber, txtMobileNumber,
            lblCountry, cmbCountry,
            lblState, cmbState,
            btnSave
        ]);

        errorProvider.ContainerControl = this;
        ResumeLayout(false);
    }

    // ── Helpers ─────────────────────────────────────────────────────────────

    private static Label MakeLabel(string text) => new()
    {
        Text = text,
        AutoSize = true,
        Font = new Font("Segoe UI", 9f, FontStyle.Bold),
        ForeColor = Color.FromArgb(50, 50, 50)
    };

    private static TextBox MakeTextBox() => new()
    {
        Font = new Font("Segoe UI", 10f),
        BorderStyle = BorderStyle.FixedSingle
    };

    private static ComboBox MakeCombo() => new()
    {
        DropDownStyle = ComboBoxStyle.DropDownList,
        Font = new Font("Segoe UI", 10f)
    };

    private static void PlaceLabel(Control c, int x, int y) => c.Location = new Point(x, y);

    private static void PlaceCntrl(Control c, int x, int y, int w)
    {
        c.Location = new Point(x, y);
        c.Width = w;
    }
}