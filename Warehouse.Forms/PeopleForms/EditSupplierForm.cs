using System.Text.RegularExpressions;
using WarehouseManagementSystem.Data.Context;
using WarehouseManagementSystem.Data.Repositories;
using WarehouseManagementSystem.Domain.Models;

namespace WarehouseManagmentSystem.WinForms.PeopleForms
{
    public partial class EditSupplierForm : Form
    {
        #region Fields
        private Supplier SelectedSupplier;
        #endregion

        #region Constructors
        public EditSupplierForm()
        {
            SelectedSupplier = new Supplier();
            InitializeComponent();
            UnenableControlsTillSelecting();
        }
        #endregion

        #region Load and Reset Data
        private async void LoadSuppliersToGridView()
        {
            using var context = new WarehouseDbContext();
            var repo = new PersonRepository(context);
            var suppliers = await repo.GetSuppliersAsync();
            SupplierDataGridView.DataSource = suppliers;
            HideColumns();
        }
        private async void LoadSelectedSupplier(int supplierId)
        {
            using var context = new WarehouseDbContext();
            var repo = new PersonRepository(context);
            SelectedSupplier = await repo.GetSupplierByPKAsync(supplierId);

            if (SelectedSupplier != null)
            {
                UserNameTextBox.Text = SelectedSupplier.Name;
                UserMobileTextBox.Text = SelectedSupplier.Mobile;
                UserFaxTextBox.Text = SelectedSupplier.Fax;
                UserEmailTextBox.Text = SelectedSupplier.Email;
                UserWebsiteTextBox.Text = SelectedSupplier.Website;
                UserLandlineTextBox.Text = SelectedSupplier.Landline;

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
        private void EditSupplierForm_Load(object sender, EventArgs e)
        {
            LoadSuppliersToGridView();
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
            if (SupplierDataGridView.Columns.Contains("Id"))
                SupplierDataGridView.Columns["Id"].Visible = false;

            if (SupplierDataGridView.Columns.Contains("ReceiptVouchers"))
                SupplierDataGridView.Columns["ReceiptVouchers"].Visible = false;
        }
        #endregion

        private async void UpdateSupplierButton_Click(object sender, EventArgs e)
        {
            if (SelectedSupplier == null)
            {
                MessageBox.Show("Please select a supplier to edit first.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (IsValidForm())
            {
                // Construct confirmation message
                string message = $"Confirm changes:\n\n" +
                                 $"Name: {SelectedSupplier.Name} → {UserNameTextBox.Text}\n" +
                                 $"Mobile: {SelectedSupplier.Mobile ?? "None"} → {UserMobileTextBox.Text}\n" +
                                 $"Landline: {SelectedSupplier.Landline ?? "None"} → {UserLandlineTextBox.Text}\n" +
                                 $"Fax: {SelectedSupplier.Fax ?? "None"} → {UserFaxTextBox.Text}\n" +
                                 $"Email: {SelectedSupplier.Email ?? "None"} → {UserEmailTextBox.Text}\n" +
                                 $"Website: {SelectedSupplier.Website ?? "None"} → {UserWebsiteTextBox.Text}";

                var result = MessageBox.Show(message, "Confirm Changes",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // Apply updates
                        SelectedSupplier.Name = UserNameTextBox.Text;
                        SelectedSupplier.Mobile = UserMobileTextBox.Text;
                        SelectedSupplier.Landline = UserLandlineTextBox.Text;
                        SelectedSupplier.Fax = UserFaxTextBox.Text;
                        SelectedSupplier.Email = UserEmailTextBox.Text;
                        SelectedSupplier.Website = UserWebsiteTextBox.Text;

                        using var context = new WarehouseDbContext();
                        var repo = new PersonRepository(context);
                        await repo.UpdateAsync(SelectedSupplier);

                        MessageBox.Show("Supplier updated successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        ResetFormEnteredData();
                        LoadSuppliersToGridView();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error updating supplier: {ex.Message}", "Error",
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
                MessageBox.Show("Supplier name is required", "Validation Error",
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

        #region Supplier grid view event handler
        private void SupplierDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = SupplierDataGridView.Rows[e.RowIndex];
                int supplierId = Convert.ToInt32(row.Cells["Id"].Value);
                LoadSelectedSupplier(supplierId);
            }
        }
        #endregion



    }
}
