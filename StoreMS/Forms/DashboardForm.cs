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
        // Properties សម្រាប់រក្សាទុកទិន្នន័យ User
        public int CurrentUserId { get; set; }
        public string CurrentFullName { get; set; }
        public string CurrentRole { get; set; }

        private Form activeForm = null;

        // 1. Default Constructor (គ្មាន Argument)
        public DashboardForm()
        {
            InitializeComponent();
        }

        // 2. Overloaded Constructor (ទទួលយក 3 តម្លៃពី LoginForm) - ទុកតែមួយនេះបានហើយ
        public DashboardForm(int userId, string fullName, string role) : this()
        {
            CurrentUserId = userId;
            CurrentFullName = fullName;
            CurrentRole = role;
        }

        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();

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
            // បញ្ជូនទិន្នន័យ User ទៅកាន់ DashboardHomeForm ពេលបើកឡើងដំបូង
            DashboardHomeForm homeForm = new DashboardHomeForm(CurrentUserId, CurrentFullName, CurrentRole);
            openChildForm(homeForm);
            btnDashboard.Checked = true;
        }

        private void btnDasboad_Click(object sender, EventArgs e)
        {
            lblCurrentPage.Text = "Dashboard";
            // បញ្ជូនទិន្នន័យ User ទៅជាមួយពេលចុចប៊ូតុង Dashboard
            DashboardHomeForm homeForm = new DashboardHomeForm(CurrentUserId, CurrentFullName, CurrentRole);
            openChildForm(homeForm);
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
            lblCurrentPage.Text = "Reports";
        }
    }
}