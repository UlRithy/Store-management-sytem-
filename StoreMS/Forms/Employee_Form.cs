using StoreMS.Models;
using StoreMS.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace StoreMS.Forms
{
    public partial class Employee_Form : Form
    {
        private readonly EmployeeRepository _employeeRepository;
        private List<Employee> _employeeList;

        public Employee_Form()
        {
            InitializeComponent();
            _employeeRepository = new EmployeeRepository();
        }

        private void Employee_Form_Load_1(object sender, EventArgs e)
        {
            LoadEmployeeData();
            LoadPositionFilter();
            ApplyRolePermissions();
            CustomizeDataGridView();
            FormatDataGridViewColumns();
        }

        // ការត្រួតពិនិត្យសិទ្ធិអ្នកប្រើប្រាស់ (Role-Based Permissions)
        private void ApplyRolePermissions()
        {
            if (User.CurrentUser != null && User.CurrentUser.Role != "Admin")
            {
                // លាក់ប៊ូតុងមិនឱ្យ Cashier អាច Add, Edit, Delete បាន
                btnAdd.Visible = false;
                btnEdit.Visible = false;
                btnDelete.Visible = false;
            }
        }

        // ១. ទាញយក និងបង្ហាញទិន្នន័យបុគ្គលិកចូល DataGridView
        private void LoadEmployeeData()
        {
            try
            {
                _employeeList = _employeeRepository.GetAll().ToList();
                dataGridView1.DataSource = _employeeList;
                UpdateTotalCount(_employeeList.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show("មានបញ្ហាក្នុងការទាញយកទិន្នន័យ: " + ex.Message, "កំហុស", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ២. បង្ហាញបញ្ជី Position ក្នុង ComboBox សម្រាប់ Filter
        private void LoadPositionFilter()
        {
            try
            {
                if (_employeeList == null) return;

                var positions = _employeeList
                                   .Select(emp => emp.Position)
                                   .Distinct()
                                   .Where(p => !string.IsNullOrEmpty(p))
                                   .ToList();
                positions.Insert(0, "All Positions");
                cmbPosition.DataSource = positions;
                if (cmbPosition.Items.Count > 0)
                    cmbPosition.SelectedIndex = 0;
            }
            catch (Exception)
            {
                // Handle exception if needed
            }
        }

        // ៣. មុខងារ Filter (តាម Name/Phone និង Position)
        private void FilterEmployees()
        {
            if (_employeeList == null) return;

            string keyword = txtSearch.Text.Trim().ToLower();
            string selectedPosition = cmbPosition.SelectedItem?.ToString();

            var filtered = _employeeList.AsEnumerable();

            // ត្រងតាម Keyword (Name ឬ Phone)
            if (!string.IsNullOrEmpty(keyword))
            {
                filtered = filtered.Where(emp =>
                    (emp.FullName != null && emp.FullName.ToLower().Contains(keyword)) ||
                    (emp.Phone != null && emp.Phone.Contains(keyword))
                );
            }

            // ត្រងតាម Position
            if (!string.IsNullOrEmpty(selectedPosition) && selectedPosition != "All Positions")
            {
                filtered = filtered.Where(emp => emp.Position == selectedPosition);
            }

            var resultList = filtered.ToList();
            dataGridView1.DataSource = resultList;
            UpdateTotalCount(resultList.Count);
        }

        private void UpdateTotalCount(int count)
        {
            lblTotal.Text = $"Total employees: {count}";
        }



        //  ការតុបតែង DataGridView (Styling)
        private void CustomizeDataGridView()
        {
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(240, 242, 245);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(50, 50, 50);
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 224, 230);
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;
        }

        private void FormatDataGridViewColumns()
        {
            dataGridView1.AutoGenerateColumns = false; // បិទការបង្កើត Column ស្វ័យប្រវត្តិដើម្បីការពារបញ្ហាជាន់គ្នា

            if (dataGridView1.Columns["colId"] != null)
            {
                dataGridView1.Columns["colId"].DataPropertyName = "EmployeeID";
                dataGridView1.Columns["colId"].Visible = false;
            }

            if (dataGridView1.Columns["colName"] != null)
                dataGridView1.Columns["colName"].DataPropertyName = "FullName";

            if (dataGridView1.Columns["colGender"] != null)
                dataGridView1.Columns["colGender"].DataPropertyName = "Gender";

            if (dataGridView1.Columns["colPhone"] != null)
                dataGridView1.Columns["colPhone"].DataPropertyName = "Phone";

            if (dataGridView1.Columns["colEmail"] != null)
                dataGridView1.Columns["colEmail"].DataPropertyName = "Email";

            if (dataGridView1.Columns["colAddress"] != null)
                dataGridView1.Columns["colAddress"].DataPropertyName = "Address";

            if (dataGridView1.Columns["colPosition"] != null)
                dataGridView1.Columns["colPosition"].DataPropertyName = "Position";

            if (dataGridView1.Columns["colSalary"] != null)
            {
                dataGridView1.Columns["colSalary"].DataPropertyName = "Salary";
                dataGridView1.Columns["colSalary"].DefaultCellStyle.Format = "N2";
            }

            if (dataGridView1.Columns["colHireDate"] != null)
            {
                dataGridView1.Columns["colHireDate"].DataPropertyName = "HireDate";
                dataGridView1.Columns["colHireDate"].DefaultCellStyle.Format = "yyyy-MM-dd";
            }

            if (dataGridView1.Columns["colUsername"] != null)
                dataGridView1.Columns["colUsername"].DataPropertyName = "Username";

            if (dataGridView1.Columns["colRole"] != null)
                dataGridView1.Columns["colRole"].DataPropertyName = "Role";
        }

        // Event Triggers សម្រាប់ Search និង Position Filter
        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
            FilterEmployees();
        }

        private void cmbPosition_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            FilterEmployees();
        }

        private void pnlCard_Paint_1(object sender, PaintEventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var addForm = new StoreMS.Layout.Emplo_AddEdit_Form())
            {
                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    LoadEmployeeData();
                    LoadPositionFilter();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int employeeId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["colId"].Value);
                var employeeToEdit = _employeeList.FirstOrDefault(emp => emp.EmployeeID == employeeId);

                if (employeeToEdit != null)
                {
                    using (var editForm = new StoreMS.Layout.Emplo_AddEdit_Form(employeeToEdit))
                    {
                        if (editForm.ShowDialog() == DialogResult.OK)
                        {
                            LoadEmployeeData();
                            LoadPositionFilter();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("សូមជ្រើសរើសបុគ្គលិកណាមួយដែលចង់កែប្រែ!", "ការជូនដំណឹង", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int employeeId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["colId"].Value);
                string employeeName = dataGridView1.SelectedRows[0].Cells["colName"].Value.ToString();

                var confirmResult = MessageBox.Show($"តើអ្នកពិតជាចង់លុបបុគ្គលិកឈ្មោះ [{employeeName}] នេះមែនទេ?",
                                                    "បញ្ជាក់ការលុប",
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Warning);

                if (confirmResult == DialogResult.Yes)
                {
                    bool success = _employeeRepository.Delete(employeeId);
                    if (success)
                    {
                        MessageBox.Show("លុបទិន្នន័យបានសម្រេច!", "ជោគជ័យ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadEmployeeData();
                        LoadPositionFilter();
                    }
                    else
                    {
                        MessageBox.Show("ការលុបទិន្នន័យមិនបានជោគជ័យឡើយ។", "កំហុស", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("សូមជ្រើសរើសជួរដេក (Row) ក្នុងតារាងដែលចង់លុប!", "ការជូនដំណឹង", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}