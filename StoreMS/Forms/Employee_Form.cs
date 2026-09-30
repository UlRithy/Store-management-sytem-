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

    
        private void ApplyRolePermissions()
        {
            if (User.CurrentUser != null && User.CurrentUser.Role != "Admin")
            {
                // លាក់ ឬបិទប៊ូតុង (Disable) មិនឱ្យ Cashier Add, Edit, Delete បាន
                btnAdd.Visible = false;     // ឬប្រើ btnAdd.Enabled = false;
                btnEdit.Visible = false;    // ឬប្រើ btnEdit.Enabled = false;
                btnDelete.Visible = false;  // ឬប្រើ btnDelete.Enabled = false;
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
                MessageBox.Show("មានបញ្ហាក្នុងการទាញយកទិន្នន័យ: " + ex.Message, "កំហុស", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            catch (Exception ex)
            {
                // Handle exception if needed
            }
        }

        // ៣. មុខងារស្វែងរក (Search by Name or Phone)
        //private void txtSearch_TextChanged(object sender, EventArgs e)
        //{
        //    FilterEmployees();
        //}

        //// ៤. មុខងារ Filter តាម Position
        //private void cmbPosition_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    FilterEmployees();
        //}

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

        private void btnAdd_Click_1(object sender, EventArgs e)
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

        private void btnEdit_Click_1(object sender, EventArgs e)
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

        private void pnlCard_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnDelete_Click_1(object sender, EventArgs e)
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

   

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Employee_Form_Load_1(object sender, EventArgs e)
        {
            LoadEmployeeData();
            LoadPositionFilter();
            ApplyRolePermissions(); 
            CustomizeDataGridView();
            FormatDataGridViewColumns();
        }
        private void CustomizeDataGridView()
        {
            // បិទ Visual Styles របស់ Header ដើម្បីឱ្យវាស្ដាប់តាមការកំណត់ពណ៌របស់យើង
            dataGridView1.EnableHeadersVisualStyles = false;

            // កំណត់ពណ៌ក្បាលតារាង (Header Background & Font Color)
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(240, 242, 245); // ពណ៌ប្រផេះស្អាត
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(50, 50, 50);
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            // កំណត់ពណ៌ពេលយកម៉ៅចុចជ្រើសរើសជួរដេក (Selection Style)
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 224, 230);
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;
        }
        private void FormatDataGridViewColumns()
        {
            // ធានាថា DataGridView ប្រើប្រាស់ទំហំដែលយើងកំណត់
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            // កំណត់ទំហំ Column នីមួយៗតាមឈ្មោះ (Column Name) របស់អ្នក
            // (សូមប្ដូរឈ្មោះ "colId", "colName"... ទៅតាមឈ្មោះពិតនៃ Column ក្នុង Project របស់អ្នក)
            if (dataGridView1.Columns["colId"] != null)
                dataGridView1.Columns["colId"].Width = 40;

            if (dataGridView1.Columns["colName"] != null)
                dataGridView1.Columns["colName"].Width = 140;

            if (dataGridView1.Columns["colPhone"] != null)
                dataGridView1.Columns["colPhone"].Width = 120;

            if (dataGridView1.Columns["colEmail"] != null)
                dataGridView1.Columns["colEmail"].Width = 180;

            if (dataGridView1.Columns["colPosition"] != null)
                dataGridView1.Columns["colPosition"].Width = 120;
            if (dataGridView1.Columns["colsalary"] != null)
                dataGridView1.Columns["colsalary"].Width=120;

            if (dataGridView1.Columns["colHireDate"] != null)
                dataGridView1.Columns["colHireDate"].Width = 120;
        }

        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
            FilterEmployees();
        }

        private void cmbPosition_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            FilterEmployees();
        }
    }
}