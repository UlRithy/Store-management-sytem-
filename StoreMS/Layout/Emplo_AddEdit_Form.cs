using StoreMS.Models;
using StoreMS.Repositories;
using System;
using System.Windows.Forms;

namespace StoreMS.Layout
{
    public partial class Emplo_AddEdit_Form : Form
    {
        private readonly EmployeeRepository _employeeRepository;
        private readonly UserRepository _userRepository;
        private readonly Employee _employee;
        private readonly bool _isEditMode;

        // Constructor សម្រាប់ករណី Add (បន្ថែមថ្មី)
        public Emplo_AddEdit_Form()
        {
            InitializeComponent();
            _employeeRepository = new EmployeeRepository();
            _userRepository = new UserRepository();
            _employee = new Employee();
            _isEditMode = false;
            lblTitle.Text = "Add New Employee";

            // កំណត់យកតម្លៃទី១ ស្វ័យប្រវត្តិប្រសិនបើមាន Item ក្នុង ComboBox
            if (cmbRole.Items.Count > 0)
                cmbRole.SelectedIndex = 0;
        }

        // Constructor សម្រាប់ករណី Edit (កែប្រែទិន្នន័យចាស់)
        public Emplo_AddEdit_Form(Employee employeeToEdit)
        {
            InitializeComponent();
            _employeeRepository = new EmployeeRepository();
            _userRepository = new UserRepository();
            _employee = employeeToEdit;
            _isEditMode = true;
            lblTitle.Text = "Edit Employee";

            PopulateFormFields();
        }

        private void PopulateFormFields()
        {
            txtFullName.Text = _employee.FullName;
            cmbGender.SelectedItem = _employee.Gender;
            txtPhone.Text = _employee.Phone;
            txtEmail.Text = _employee.Email;
            txtAddress.Text = _employee.Address;
            txtPosition.Text = _employee.Position;
            txtSalary.Text = _employee.Salary.ToString();

            if (_employee.HireDate.HasValue)
            {
                dtpHireDate.Value = _employee.HireDate.Value;
            }

            txtUsername.Text = _employee.Username;

            if (!string.IsNullOrEmpty(_employee.Role) && cmbRole.Items.Contains(_employee.Role))
            {
                cmbRole.SelectedItem = _employee.Role;
            }

            // ទុកប្រអប់ Password ឱ្យនៅទទេរពេល Edit ដើម្បីសុវត្ថិភាព
            txtPassword.Text = string.Empty;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // 1. Validate ទិន្នន័យចាំបាច់
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("សូមបញ្ចូលឈ្មោះបុគ្គលិក!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFullName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("សូមបញ្ចូល Username!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }

            // 2. ផ្ដល់តម្លៃទៅឱ្យ Object _employee
            _employee.FullName = txtFullName.Text.Trim();
            _employee.Gender = cmbGender.SelectedItem?.ToString() ?? "";
            _employee.Phone = txtPhone.Text.Trim();
            _employee.Email = txtEmail.Text.Trim();
            _employee.Address = txtAddress.Text.Trim();
            _employee.Position = txtPosition.Text.Trim();

            decimal salary = 0;
            decimal.TryParse(txtSalary.Text, out salary);
            _employee.Salary = salary;

            _employee.HireDate = dtpHireDate.Value;
            _employee.Username = txtUsername.Text.Trim();

            // 3. កែសម្រួលកូដទាញយក Role ឱ្យមានសុវត្ថិភាព (មិនឱ្យទទេ)
            if (cmbRole.SelectedItem != null)
            {
                _employee.Role = cmbRole.SelectedItem.ToString();
            }
            else if (cmbRole.Items.Count > 0)
            {
                cmbRole.SelectedIndex = 0;
                _employee.Role = cmbRole.SelectedItem.ToString();
            }
            else
            {
                _employee.Role = "Staff"; // តម្លៃលំនាំដើមការពារក្រែងលោគ្មាន Item
            }

            bool success = false;

            if (_isEditMode)
            {
                // ក. ធ្វើបច្ចុប្បន្នភាពទិន្នន័យបុគ្គលិក (tbEmployees)
                success = _employeeRepository.Update(_employee);

                if (success)
                {
                    // ខ. ធ្វើបច្ចុប្បន្នភាពគណនី User ក្នុង (tbUsers) ផងដែរ
                    var existingUser = _userRepository.GetByUsername(_employee.Username);

                    if (existingUser != null)
                    {
                        existingUser.FullName = _employee.FullName;
                        existingUser.Position = _employee.Position;
                        existingUser.Role = _employee.Role;

                        // ប្រសិនបើអ្នកប្រើប្រាស់បានវាយបញ្ចូល Password ថ្មី ទើបធ្វើការដូរ Password ថ្មី
                        if (!string.IsNullOrWhiteSpace(txtPassword.Text))
                        {
                            existingUser.Password = txtPassword.Text.Trim();
                        }

                        _userRepository.Update(existingUser);
                    }

                    MessageBox.Show("កែប្រែទិន្នន័យបុគ្គលិកបានជោគជ័យ!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                // ក. បន្ថែមបុគ្គលិកថ្មី (tbEmployees)
                success = _employeeRepository.Add(_employee);

                if (success)
                {
                    // ខ. បន្ថែមគណនី User ថ្មី (tbUsers)
                    var newUser = new User
                    {
                        UserName = txtUsername.Text.Trim(),
                        Password = string.IsNullOrWhiteSpace(txtPassword.Text) ? "123456" : txtPassword.Text.Trim(),
                        FullName = txtFullName.Text.Trim(),
                        Role = _employee.Role, // យកតាម _employee ដែលបានកំណត់រួច
                        Position = txtPosition.Text.Trim(),
                        IsActive = true
                    };

                    _userRepository.Add(newUser);

                    MessageBox.Show("បន្ថែមបុគ្គលិកថ្មី និងគណនី Login បានជោគជ័យ!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            if (success)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("មានបញ្ហាកើតឡើងក្នុងការរក្សាទុកទិន្នន័យ!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}