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
            // ទីនេះអ្នកអាចសរសេរកូដ Load UserControl ចូលទៅក្នុង mainPanel បាន
            openChildForm(new DashboardHomeForm());
            
           


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
            openChildForm(new CategoryForm());
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

        private void headerPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
           
            
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}