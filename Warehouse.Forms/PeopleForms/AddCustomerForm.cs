using System.Text.RegularExpressions;
using WarehouseManagementSystem.Data.Context;
using WarehouseManagementSystem.Data.Repositories;
using WarehouseManagementSystem.Domain.Models;

namespace WarehouseManagmentSystem.WinForms
{
    public partial class AddCustomerForm : Form
    {
        #region Fields
        #endregion

        #region Constructors
        public AddCustomerForm()
        {
            InitializeComponent();
            ApplyAnchorsAndDocking();
        }
        #endregion

        #region Methods

        #region UI 
        private void ApplyAnchorsAndDocking()
        {
            // TextBoxes should stretch horizontally
            UserNameTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            UserMobileTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            UserLandlineTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            UserFaxTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            UserEmailTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            UserWebsiteTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            // Label should stretch horizontally
            UserNameLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            UserMobileLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            UserLandlineLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            UserFaxLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            UserEmailLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            UserWebsiteLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            // Button should stay at the bottom right
            AddUserButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            // DataGridView should expand to fill the bottom area
            CustomerDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        }
        #endregion

        #region Load and Reset Data
        private void AddCustomerForm_Load(object sender, EventArgs e)
        {
            LoadPeopleToGridView();
        }
        private async void LoadPeopleToGridView()
        {
            using var context = new WarehouseDbContext();
            var peopleRepository = new PersonRepository(context);
            var customers = await peopleRepository.GetCustomersAsync();
            CustomerDataGridView.DataSource = customers;
            HideColumns();
        }
        private void ResetFormEnteredData()
        {
            UserNameTextBox.Clear();
            UserLandlineTextBox.Clear();
            UserFaxTextBox.Clear();
            UserMobileTextBox.Clear();
            UserEmailTextBox.Clear();
            UserWebsiteTextBox.Clear();
        }
        #endregion

        #region Add Customer Button Even handler
        private async void AddUserButton_ClickAsync(object sender, EventArgs e)
        {

            if (IsValidForm())
            {
                // Create confirmation message
                string message = $"Confirm Adding Customer\n\n" +
                               $"Name:            {UserNameTextBox.Text}\n" +
                               $"Landline number: {UserLandlineTextBox.Text}\n" +
                               $"Fax number:      {UserFaxTextBox.Text}\n" +
                               $"Mobile number:   {UserMobileTextBox.Text}\n" +
                               $"Email number:    {UserEmailTextBox.Text}\n" +
                               $"Website number:  {UserWebsiteTextBox.Text}\n";

                var result = MessageBox.Show(message, "Confirm Adding",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        using var context = new WarehouseDbContext();
                        var personRepository = new PersonRepository(context);
                        Customer customer = new Customer
                        {
                            Name = UserNameTextBox.Text,
                            Landline = UserLandlineTextBox.Text,
                            Fax = UserFaxTextBox.Text,
                            Mobile = UserMobileTextBox.Text,
                            Email = UserEmailTextBox.Text,
                            Website = UserWebsiteTextBox.Text,
                        };
                        await personRepository.AddAsync(customer);
                        ResetFormEnteredData();
                        LoadPeopleToGridView();
                        MessageBox.Show($"Customer added successfully!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error adding Customer: {ex.Message}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }
        #endregion

        #region Validations
        private bool IsValidForm()
        {
            string digitsOnlyPattern = @"^\d+$";
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            if (string.IsNullOrWhiteSpace(UserNameTextBox.Text))
            {
                MessageBox.Show("Customer name is required", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Mobile Number: Optional, but must be digits
            if (!string.IsNullOrWhiteSpace(UserMobileTextBox.Text)
                && !Regex.IsMatch(UserMobileTextBox.Text, digitsOnlyPattern))
            {
                MessageBox.Show("Mobile number must contain digits only", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Landline Number: Optional, but must be digits
            if (!string.IsNullOrWhiteSpace(UserLandlineTextBox.Text)
                && !Regex.IsMatch(UserLandlineTextBox.Text, digitsOnlyPattern))
            {
                MessageBox.Show("Landline number must contain digits only", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Fax Number: Optional, but must be digits
            if (!string.IsNullOrWhiteSpace(UserFaxTextBox.Text)
                && !Regex.IsMatch(UserFaxTextBox.Text, digitsOnlyPattern))
            {
                MessageBox.Show("Fax number must contain digits only", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Email: Optional, but must be valid format
            if (!string.IsNullOrWhiteSpace(UserEmailTextBox.Text) &&
                !Regex.IsMatch(UserEmailTextBox.Text, emailPattern))
            {
                MessageBox.Show("Invalid email format", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Website: Optional, but must be valid URL format
            if (!string.IsNullOrWhiteSpace(UserWebsiteTextBox.Text) &&
                !Uri.IsWellFormedUriString(UserWebsiteTextBox.Text, UriKind.Absolute))
            {
                MessageBox.Show("Invalid website URL", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        #endregion

        #region Hide unnecessary Columns
        private void HideColumns()
        {
            if (CustomerDataGridView.Columns.Contains("Id"))
                CustomerDataGridView.Columns["Id"].Visible = false;

            if (CustomerDataGridView.Columns.Contains("IssueVouchers"))
                CustomerDataGridView.Columns["IssueVouchers"].Visible = false;
        }
        #endregion

        #endregion

    }
}