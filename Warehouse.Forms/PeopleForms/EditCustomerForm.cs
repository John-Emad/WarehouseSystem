using System.Text.RegularExpressions;
using WarehouseManagementSystem.Data.Context;
using WarehouseManagementSystem.Data.Repositories;
using WarehouseManagementSystem.Domain.Models;

namespace WarehouseManagmentSystem.WinForms.PeopleForms
{
    public partial class EditCustomerForm : Form
    {
        #region Fields
        private Customer SelectedCustomer;
        #endregion

        #region Constructors
        public EditCustomerForm()
        {
            SelectedCustomer = new Customer();
            InitializeComponent();
            LoadCustomersToGridView();
            UnenableControlsTillSelecting();
        }
        #endregion

        #region Load and Reset Data
        private async void LoadCustomersToGridView()
        {
            using var context = new WarehouseDbContext();
            var repo = new PersonRepository(context);
            var customers = await repo.GetCustomersAsync();
            CustomerDataGridView.DataSource = customers;
            HideColumns();
        }
        private async void LoadSelectedSupplier(int customerId)
        {
            using var context = new WarehouseDbContext();
            var repo = new PersonRepository(context);
            SelectedCustomer = await repo.GetCustomerByPKAsync(customerId);

            if (SelectedCustomer != null)
            {
                UserNameTextBox.Text = SelectedCustomer.Name;
                UserMobileTextBox.Text = SelectedCustomer.Mobile;
                UserFaxTextBox.Text = SelectedCustomer.Fax;
                UserEmailTextBox.Text = SelectedCustomer.Email;
                UserWebsiteTextBox.Text = SelectedCustomer.Website;
                UserLandlineTextBox.Text = SelectedCustomer.Landline;

                EnableControls();
            }
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

        #region Enable Unenable Controls
        private void UnenableControlsTillSelecting()
        {
            UserNameTextBox.Enabled = false;
            UserMobileTextBox.Enabled = false;
            UserFaxTextBox.Enabled = false;
            UserEmailTextBox.Enabled = false;
            UserWebsiteTextBox.Enabled = false;
            UserLandlineTextBox.Enabled = false;
        }

        private void EnableControls()
        {
            UserNameTextBox.Enabled = true;
            UserMobileTextBox.Enabled = true;
            UserFaxTextBox.Enabled = true;
            UserEmailTextBox.Enabled = true;
            UserWebsiteTextBox.Enabled = true;
            UserLandlineTextBox.Enabled = true;
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

        private async void UpdateCustomersButton_Click(object sender, EventArgs e)
        {
            if (SelectedCustomer == null)
            {
                MessageBox.Show("Please select a supplier to edit first.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (IsValidForm())
            {
                // Construct confirmation message
                string message = $"Confirm changes:\n\n" +
                                 $"Name: {SelectedCustomer.Name} → {UserNameTextBox.Text}\n" +
                                 $"Mobile: {SelectedCustomer.Mobile ?? "None"} → {UserMobileTextBox.Text}\n" +
                                 $"Landline: {SelectedCustomer.Landline ?? "None"} → {UserLandlineTextBox.Text}\n" +
                                 $"Fax: {SelectedCustomer.Fax ?? "None"} → {UserFaxTextBox.Text}\n" +
                                 $"Email: {SelectedCustomer.Email ?? "None"} → {UserEmailTextBox.Text}\n" +
                                 $"Website: {SelectedCustomer.Website ?? "None"} → {UserWebsiteTextBox.Text}";

                var result = MessageBox.Show(message, "Confirm Changes",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // Apply updates
                        SelectedCustomer.Name = UserNameTextBox.Text;
                        SelectedCustomer.Mobile = UserMobileTextBox.Text;
                        SelectedCustomer.Landline = UserLandlineTextBox.Text;
                        SelectedCustomer.Fax = UserFaxTextBox.Text;
                        SelectedCustomer.Email = UserEmailTextBox.Text;
                        SelectedCustomer.Website = UserWebsiteTextBox.Text;

                        using var context = new WarehouseDbContext();
                        var repo = new PersonRepository(context);
                        await repo.UpdateAsync(SelectedCustomer);

                        MessageBox.Show("Customer updated successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        ResetFormEnteredData();
                        LoadCustomersToGridView();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error updating customer: {ex.Message}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

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

            if (!string.IsNullOrWhiteSpace(UserMobileTextBox.Text) &&
                !Regex.IsMatch(UserMobileTextBox.Text, digitsOnlyPattern))
            {
                MessageBox.Show("Mobile number must contain digits only", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!string.IsNullOrWhiteSpace(UserLandlineTextBox.Text) &&
                !Regex.IsMatch(UserLandlineTextBox.Text, digitsOnlyPattern))
            {
                MessageBox.Show("Landline number must contain digits only", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!string.IsNullOrWhiteSpace(UserFaxTextBox.Text) &&
                !Regex.IsMatch(UserFaxTextBox.Text, digitsOnlyPattern))
            {
                MessageBox.Show("Fax number must contain digits only", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!string.IsNullOrWhiteSpace(UserEmailTextBox.Text) &&
                !Regex.IsMatch(UserEmailTextBox.Text, emailPattern))
            {
                MessageBox.Show("Invalid email format", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

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

        #region Customer grid view event handler
        private void CustomerDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = CustomerDataGridView.Rows[e.RowIndex];
                int customerId = Convert.ToInt32(row.Cells["Id"].Value);
                LoadSelectedSupplier(customerId);
            }
        }
        #endregion
    }
}
