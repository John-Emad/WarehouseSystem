using System.Text.RegularExpressions;
using WarehouseManagementSystem.Data.Context;
using WarehouseManagementSystem.Data.Repositories;
using WarehouseManagementSystem.Domain.Models;

namespace WarehouseManagmentSystem.WinForms.PeopleForms
{
    public partial class AddSupplierForm : Form
    {
        #region Fields
        #endregion

        #region Constructors
        public AddSupplierForm()
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
            SuplierDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        }
        #endregion

        #region Load and Reset Data
        private async void LoadPeopleToGridView()
        {
            using var context = new WarehouseDbContext();
            var peopleRepository = new PersonRepository(context);
            var suppliers = await peopleRepository.GetSuppliersAsync();
            SuplierDataGridView.DataSource = suppliers;
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
        private void AddSupplierForm_Load(object sender, EventArgs e)
        {
            LoadPeopleToGridView();
        }
        #endregion

        #region Add Supplier Button Even handler
        private async void AddUserButton_ClickAsync(object sender, EventArgs e)
        {
            if (IsValidForm())
            {
                try
                {
                    using var context = new WarehouseDbContext();
                    var personRepository = new PersonRepository(context);
                    Supplier supplier = new Supplier
                    {
                        Name = UserNameTextBox.Text,
                        Landline = UserLandlineTextBox.Text,
                        Fax = UserFaxTextBox.Text,
                        Mobile = UserMobileTextBox.Text,
                        Email = UserEmailTextBox.Text,
                        Website = UserWebsiteTextBox.Text,
                    };
                    await personRepository.AddAsync(supplier);
                    ResetFormEnteredData();
                    LoadPeopleToGridView();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error adding Person: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Supplier name is required", "Validation Error",
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
            if (SuplierDataGridView.Columns.Contains("Id"))
                SuplierDataGridView.Columns["Id"].Visible = false;

            if (SuplierDataGridView.Columns.Contains("ReceiptVouchers"))
                SuplierDataGridView.Columns["ReceiptVouchers"].Visible = false;
        }
        #endregion

        #endregion


    }
}
