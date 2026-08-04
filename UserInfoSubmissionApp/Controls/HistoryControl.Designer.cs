namespace UserInfoSubmissionApp.Controls;

partial class HistoryControl
{
    private System.ComponentModel.IContainer? components = null;

    private FlowLayoutPanel pnlActions;
    private Button btnDelete;
    private DataGridView dgvSubmissions;

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
        pnlActions = new FlowLayoutPanel();
        btnDelete = new Button();
        dgvSubmissions = new DataGridView();
        pnlActions.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvSubmissions).BeginInit();
        SuspendLayout();
        // 
        // pnlActions
        // 
        pnlActions.Controls.Add(btnDelete);
        pnlActions.Dock = DockStyle.Top;
        pnlActions.Location = new Point(0, 0);
        pnlActions.Name = "pnlActions";
        pnlActions.Padding = new Padding(10, 8, 10, 8);
        pnlActions.Size = new Size(900, 45);
        pnlActions.TabIndex = 1;
        // 
        // btnDelete
        // 
        btnDelete.Location = new Point(10, 11);
        btnDelete.Margin = new Padding(0, 3, 3, 3);
        btnDelete.Name = "btnDelete";
        btnDelete.Size = new Size(130, 30);
        btnDelete.TabIndex = 0;
        btnDelete.Text = "Delete Selected";
        // 
        // dgvSubmissions
        // 
        dgvSubmissions.AllowUserToAddRows = false;
        dgvSubmissions.AllowUserToDeleteRows = false;
        dgvSubmissions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvSubmissions.ColumnHeadersHeight = 29;
        dgvSubmissions.Dock = DockStyle.Fill;
        dgvSubmissions.Location = new Point(0, 45);
        dgvSubmissions.MultiSelect = false;
        dgvSubmissions.Name = "dgvSubmissions";
        dgvSubmissions.ReadOnly = true;
        dgvSubmissions.RowHeadersVisible = false;
        dgvSubmissions.RowHeadersWidth = 51;
        dgvSubmissions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvSubmissions.Size = new Size(900, 455);
        dgvSubmissions.TabIndex = 0;
        // 
        // HistoryControl
        // 
        Controls.Add(dgvSubmissions);
        Controls.Add(pnlActions);
        Name = "HistoryControl";
        Size = new Size(900, 500);
        pnlActions.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvSubmissions).EndInit();
        ResumeLayout(false);
    }
}