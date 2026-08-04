using UserInfoSubmissionApp.Data;
using UserInfoSubmissionApp.Extensions;
using UserInfoSubmissionApp.Models;
using UserInfoSubmissionApp.Services;
using UserInfoSubmissionApp.Validators;

namespace UserInfoSubmissionApp.Controls;

public partial class SubmissionControl : UserControl
{
    private readonly LoggedInUser _loggedInUser;
    private readonly ISubmissionService _submissionService;

    public event EventHandler? SubmissionSaved;
    private bool _dobSelected;

    public SubmissionControl(LoggedInUser loggedInUser, ISubmissionService submissionService)
    {
        _loggedInUser = loggedInUser;
        _submissionService = submissionService;

        InitializeComponent();
        PopulateStaticDropdowns();


        _dobSelected = false;

        dtpDateOfBirth.Format = DateTimePickerFormat.Custom;
        dtpDateOfBirth.CustomFormat = " ";
        txtAge.Text = string.IsNullOrEmpty(dtpDateOfBirth.Text) ? "" : dtpDateOfBirth.Value.CalculateAge().ToString();

        dtpDateOfBirth.ValueChanged += DtpDateOfBirth_ValueChanged;
        cmbCountry.SelectedIndexChanged += CmbCountry_SelectedIndexChanged;
        btnSave.Click += BtnSave_ClickAsync;


    }

    private void DtpDateOfBirth_ValueChanged(object? sender, EventArgs e)
    {
        _dobSelected = true;

        dtpDateOfBirth.CustomFormat = "dd-MM-yyyy";

        txtAge.Text = dtpDateOfBirth.Value.CalculateAge().ToString();
    }
    private void CmbCountry_SelectedIndexChanged(object? sender, EventArgs e)
    {
        cmbState.Items.Clear();

        var states = LocationData.GetStates(cmbCountry.Text);
        cmbState.Items.AddRange([.. states]);

        if (cmbState.Items.Count > 0)
        {
            cmbState.SelectedIndex = 0;
        }
    }

    private async void BtnSave_ClickAsync(object? sender, EventArgs e)
    {
        errorProvider.Clear();

        if (!ValidateInputs())
        {
            return;
        }

        btnSave.Enabled = false;

        try
        {
            var submission = BuildSubmission();

            var exists = await _submissionService.UserExistsAsync(
                submission.CreatedByKey,
                submission.FirstName,
                submission.LastName);

            if (exists)
            {
                var result = MessageBox.Show(
                    "User already exists. Do you want to overwrite the details?",
                    "Duplicate User",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    return;
                }

                await _submissionService.UpdateAsync(submission);
            }
            else
            {
                await _submissionService.SaveAsync(submission);
            }

            MessageBox.Show(
                "Submission saved successfully.",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            SubmissionSaved?.Invoke(this, EventArgs.Empty);

            ClearForm();
        }
        catch (SubmissionValidationException ex)
        {
            MessageBox.Show(
                ex.Message,
                "Validation",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                ex.Message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
        finally
        {
            btnSave.Enabled = true;
        }
    }

    private void PopulateStaticDropdowns()
    {
        cmbGender.Items.AddRange(["Male", "Female", "Other", "Prefer not to say"]);

        var countries = LocationData.GetCountries();
        cmbCountry.Items.AddRange([.. countries]);
    }

    private bool ValidateInputs()
    {
        var valid = true;

        if (string.IsNullOrWhiteSpace(txtFirstName.Text))
        {
            errorProvider.SetError(txtFirstName, "Required");
            valid = false;
        }

        if (string.IsNullOrWhiteSpace(txtLastName.Text))
        {
            errorProvider.SetError(txtLastName, "Required");
            valid = false;
        }

        if (cmbGender.SelectedIndex < 0)
        {
            errorProvider.SetError(cmbGender, "Please select a gender");
            valid = false;
        }

        if (!_dobSelected)
        {
            errorProvider.SetError(
                dtpDateOfBirth,
                "Date of Birth is required");

            valid = false;
        }

        if (string.IsNullOrWhiteSpace(txtMobileNumber.Text))
        {
            errorProvider.SetError(txtMobileNumber, "Required");
            valid = false;
        }

        if (cmbCountry.SelectedIndex < 0)
        {
            errorProvider.SetError(cmbCountry, "Please select a country");
            valid = false;
        }

        if (cmbState.SelectedIndex < 0)
        {
            errorProvider.SetError(cmbState, "Please select a state");
            valid = false;
        }

        return valid;
    }

    private Submission BuildSubmission() => new()
    {
        CreatedByKey = _loggedInUser.UserKey,
        FirstName = txtFirstName.Text.Trim(),
        MiddleName = string.IsNullOrWhiteSpace(txtMiddleName.Text)
            ? null
            : txtMiddleName.Text.Trim(),
        LastName = txtLastName.Text.Trim(),
        Gender = cmbGender.Text,
        DateOfBirth = dtpDateOfBirth.Value.Date,
        MobileNumber = txtMobileNumber.Text.Trim(),
        Country = cmbCountry.Text,
        State = cmbState.Text
    };

    private void ClearForm()
    {
        txtFirstName.Clear();
        txtMiddleName.Clear();
        txtLastName.Clear();
        txtMobileNumber.Clear();
        txtAge.Clear();

        cmbGender.SelectedIndex = -1;
        cmbCountry.SelectedIndex = -1;
        cmbState.Items.Clear();

        _dobSelected = false;

        //dtpDateOfBirth.Value = DateTime.Today;

        dtpDateOfBirth.Format = DateTimePickerFormat.Custom;
        dtpDateOfBirth.CustomFormat = " ";

        txtAge.Clear();

        errorProvider.Clear();
    }
}