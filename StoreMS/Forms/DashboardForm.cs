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
            btnClose.BringToFront();
            btnClose.BackColor = Color.White;
            btnClose.ForeColor = Color.Red;
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            // កូដដំណើរការពេល Form បើកឡើងដំបូង (បើមានអាចដាក់ទីនេះបាន)
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit(); // បិទកម្មវិធីទាំងមូលពេលចុចសញ្ញាខ្វែង (x)
        }

        private void btnDasboad_Click(object sender, EventArgs e)
        {
            lblCurrentPage.Text = "Dashboard";
            // ទីនេះអ្នកអាចសរសេរកូដ Load UserControl ចូលទៅក្នុង mainPanel បាន
        }

        private void btnSale_Click(object sender, EventArgs e)
        {
            lblCurrentPage.Text = "Sale / POS";
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            lblCurrentPage.Text = "Supplier Management";
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            lblCurrentPage.Text = "Stock Management";
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            lblCurrentPage.Text = "Reports";
        }

        private void guna2Button1_Click(object sender, EventArgs e) // នេះជា Event សម្រាប់ btnCustomer
        {
            lblCurrentPage.Text = "Customer Management";
        }

        private void btnCategores_Click(object sender, EventArgs e) // នេះជា Event សម្រាប់ btnCategories
        {
            lblCurrentPage.Text = "Categories Management";
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            lblCurrentPage.Text = "Product Management";
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void profile_Click(object sender, EventArgs e)
        {

        }

        private void adminProfilePic_Click(object sender, EventArgs e)
        {

        }
    }
}