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
        public DashboardForm()
        {
            InitializeComponent();
            
        }
        private Form activeForm = null;

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
            // កូដដំណើរការពេល Form បើកឡើងដំបូង (បើមានអាចដាក់ទីនេះបាន)
            openChildForm(new DashboardHomeForm());
            btnDashboard.Checked = true;    
        }
        private void btnDasboad_Click(object sender, EventArgs e)
        {
            lblCurrentPage.Text = "Dashboard";
            openChildForm(new DashboardHomeForm());
        }

        private void btnSale_Click(object sender, EventArgs e)
        {
            lblCurrentPage.Text = "Sale / POS";
            openChildForm(new Sale_POSForm());
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            lblCurrentPage.Text = "Supplier Management";
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            lblCurrentPage.Text = "Reports";
            //openChildForm(new )
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
            lblCurrentPage.Text = "Supplier Manegenent";
            openChildForm(new SupplierForm());
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            lblCurrentPage.Text = "Customer Management";
            openChildForm(new CustomerForm());
        }

        private void btnReport_Click_1(object sender, EventArgs e)
        {

        }
    }
}
