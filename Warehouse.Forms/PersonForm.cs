using WarehouseManagementSystem.Data.Context;
using WarehouseManagementSystem.Data.Repositories;
using WarehouseManagementSystem.Domain.Enums;
using WarehouseManagementSystem.Domain.Models;

namespace WarehouseManagmentSystem.WinForms
{
    public partial class PersonForm : Form
    {
        #region Fields
        public UserType UserType { get; set; }
        #endregion

        #region Constructors
        public PersonForm()
        {
            InitializeComponent();
            LoadPeopleToGridView();
            LoadUserTypeToComboBox();
            PersonUserTypeComboBox.SelectedIndex = -1;
        }
        #endregion

        #region Methods
        private void LoadUserTypeToComboBox()
        {
            PersonUserTypeComboBox.DataSource = Enum.GetValues(typeof(UserType));
        }

        private async void LoadPeopleToGridView()
        {
            using (var context = new WarehouseDbContext())
            {
                var peopleRepository = new PersonRepository(context);
                var people = await peopleRepository.GetAllAsync();
                var peopleDTO = people.Select(p => new
                {
                    p.Name,
                    p.Landline,
                    p.Fax,
                    p.Mobile,
                    p.Email,
                    p.Website,
                    PersonType = p is Customer ? "Customer" :
                                 p is Supplier ? "Supplier" : "Unknown"
                }).ToList();
                personDataGridView.DataSource = peopleDTO; 
            }
        }

        private async void AddUserButton_ClickAsync(object sender, EventArgs e)
        {
            // Check if name is null
            if (string.IsNullOrWhiteSpace(UserNameTextBox.Text))
            {
                MessageBox.Show("Person name is required", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // check if not a user type is selected
            if (PersonUserTypeComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("User type is required", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Console.WriteLine(PersonUserTypeComboBox.SelectedItem);
                return;
            }

            try
            {

                using (var context = new WarehouseDbContext())
                {
                    var personRepository = new PersonRepository(context);
                    switch (UserType)
                    {

                        case UserType.Supplier:
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
                            break;

                        case UserType.Customer:
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
                            break;
                    } 
                }
                ResetFormEnteredData();
                LoadPeopleToGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding Person: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            PersonUserTypeComboBox.SelectedIndex = -1;
        }
        #endregion

        private void PersonUserTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PersonUserTypeComboBox.SelectedItem is UserType selectedType)
            {
                // Store the selected value
                this.UserType = selectedType;
            }
        }
    }
}
