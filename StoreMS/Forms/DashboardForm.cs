using StoreMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreMS.Forms
{
    public partial class DashboardForm : Form
    {
        private Form activeForm = null;

        public DashboardForm()
        {
            InitializeComponent();
        }

        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }

            activeForm = childForm;

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            mainPanel.Controls.Add(childForm);
            mainPanel.Tag = childForm;

            childForm.BringToFront();
            childForm.Show();
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            // ពិនិត្យមើលថាតើមាន User Login ចូលហើយឬនៅ
            if (User.CurrentUser != null)
            {
                // Title Bar
                this.Text = $"{User.CurrentUser.FullName} ({User.CurrentUser.Role})";

                // User Name Label
                lblAdminName.Text = User.CurrentUser.FullName;
            }

            // Current Page
            lblCurrentPage.Text = "Dashboard";

            //  អនុវត្តការកំណត់សិទ្ធិ (លាក់/បង្ហាញ Menu តាម Role)
            ApplyRolePermissions();

            // Open Dashboard Home (អាចទាញយក UserId, FullName, Role ពី User.CurrentUser ផ្ទាល់)
            OpenDashboardHome();

            btnDashboard.Checked = true;
        }

        // មុខងារសម្រាប់ទប់សិទ្ធិ (Role-Based Access Control)
        private void ApplyRolePermissions()
        {
            // ប្រសិនបើ Role មិនមែនជា "Admin" (ឧ. Cashier ឬ Staff)
            if (User.CurrentUser?.Role != "Admin")
            {
                // លាក់ប៊ូតុងគ្រប់គ្រងបុគ្គលិក ឬមុខងាររសើបផ្សេងទៀត
                btnEmployee.Visible = false;
                // btnReport.Visible = false; // បើចង់លាក់របាយការណ៍សម្រាប់ Staff អាចបើក Code นี้បាន
            }
            else
            {
                // បើជា Admin គឺបង្ហាញធម្មតា
                btnEmployee.Visible = true;
            }
        }

        private void OpenDashboardHome()
        {
            if (User.CurrentUser != null)
            {
                DashboardHomeForm homeForm = new DashboardHomeForm(
                    User.CurrentUser.UserId,
                    User.CurrentUser.FullName,
                    User.CurrentUser.Role
                );
                openChildForm(homeForm);
            }
        }

        private void btnDasboad_Click(object sender, EventArgs e)
        {
            lblCurrentPage.Text = "Dashboard";
            OpenDashboardHome();
        }

        private void btnSale_Click(object sender, EventArgs e)
        {
            lblCurrentPage.Text = "Sale / POS";
            openChildForm(new Sale_POSForm());
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            lblCurrentPage.Text = "Product Management";
            openChildForm(new FormProduct());
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            lblCurrentPage.Text = "Categories Management";
            openChildForm(new FormCategory());
        }

        private void btnStock_Click_1(object sender, EventArgs e)
        {
            NavigateToStock();
        }

        public void NavigateToStock()
        {
            lblCurrentPage.Text = "Stock Management";
            openChildForm(new StockForm());
        }

        private void btnSupplier_Click_1(object sender, EventArgs e)
        {
            lblCurrentPage.Text = "Supplier Management";
            openChildForm(new SupplierForm());
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            lblCurrentPage.Text = "Customer Management";
            openChildForm(new CustomerForm());
        }

        private void btnReport_Click_1(object sender, EventArgs e)
        {
            lblCurrentPage.Text = "Reports Management";
            openChildForm(new ReportForm());
        }

        private void lblAdminName_Click(object sender, EventArgs e)
        {
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            // ការពារបន្ថែម៖ ទោះបីជាប៊ូតុងបង្ហាញ ក៏ត្រូវឆែកសិទ្ធិម្ដងទៀតមុននឹងបើក Form
            if (User.CurrentUser?.Role == "Admin")
            {
                lblCurrentPage.Text = "Employees Management";
                openChildForm(new Employee_Form());
            }
            else
            {
                MessageBox.Show("អ្នកគ្មានសិទ្ធិគ្រប់គ្រងលើទម្រង់បុគ្គលិកនេះទេ!", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}