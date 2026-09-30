using StoreMS.Models;
using StoreMS.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreMS.Layout
{
    public partial class Emplo_AddEdit_Form : Form
    {
        private readonly EmployeeRepository _employeeRepository;
        private readonly Employee _employee;
        private readonly bool _isEditMode;

        // Constructor សម្រាប់ករណី Add (បន្ថែមថ្មី)
        public Emplo_AddEdit_Form()
        {
            InitializeComponent();
            _employeeRepository = new EmployeeRepository(); // ប្រើប្រាស់ Database class កណ្តាល
            _employee = new Employee();
            _isEditMode = false;
            lblTitle.Text = "Add New Employee";
        }

        // Constructor សម្រាប់ករណី Edit (កែប្រែទិន្នន័យចាស់)
        public Emplo_AddEdit_Form(Employee employeeToEdit)
        {
            InitializeComponent();
            _employeeRepository = new EmployeeRepository(); // ប្រើប្រាស់ Database class កណ្តាល
            _employee = employeeToEdit;
            _isEditMode = true;
            lblTitle.Text = "Edit Employee";

            // យកទិន្នន័យចាស់មកដាក់បង្ហាញលើ Controls
            PopulateFormFields();
        }

        private void PopulateFormFields()
        {
            txtFullName.Text = _employee.FullName;
            cmbGender.SelectedItem = _employee.Gender;
            txtPhone.Text = _employee.Phone;
            txtEmail.Text = _employee.Email; // <--- បន្ថែមការបង្ហាញ Email ចាស់
            txtPosition.Text = _employee.Position;
            txtSalary.Text = _employee.Salary.ToString();

            if (_employee.HireDate.HasValue)
            {
                dtpHireDate.Value = _employee.HireDate.Value;
            }

            txtUsername.Text = _employee.Username;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // ធ្វើการ Validate ទិន្នន័យចាំបាច់
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("សូមបញ្ចូលឈ្មោះបុគ្គលិក!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFullName.Focus();
                return;
            }

            // ផ្ដល់តម្លៃទៅឱ្យ Object _employee
            _employee.FullName = txtFullName.Text.Trim();
            _employee.Gender = cmbGender.SelectedItem?.ToString() ?? "";
            _employee.Phone = txtPhone.Text.Trim();
            _employee.Email = txtEmail.Text.Trim(); // <--- បន្ថែមការផ្ដល់តម្លៃ Email
            _employee.Position = txtPosition.Text.Trim();

            decimal salary = 0;
            decimal.TryParse(txtSalary.Text, out salary);
            _employee.Salary = salary;

            _employee.HireDate = dtpHireDate.Value;
            _employee.Username = txtUsername.Text.Trim();

            bool success = false;

            if (_isEditMode)
            {
                // ហៅមុខងារ Update
                success = _employeeRepository.Update(_employee);
                if (success)
                {
                    MessageBox.Show("កែប្រែទិន្នន័យបុគ្គលិកបានជោគជ័យ!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                // ហៅមុខងារ Add
                success = _employeeRepository.Add(_employee);
                if (success)
                {
                    MessageBox.Show("បន្ថែមបុគ្គលិកថ្មីបានជោគជ័យ!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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