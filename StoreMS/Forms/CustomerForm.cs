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
    public partial class CustomerForm : Form
    {
        public CustomerForm()
        {
            InitializeComponent();
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            // កូដសម្រាប់ទាញយកទិន្នន័យអតិថិជនមកបង្ហាញក្នុង DataGridView (ប្រសិនបើមាន Database)
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Open Add Customer Form/Dialog", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Edit selected customer", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Delete selected customer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            // កូដសម្រាប់ស្វែងរកអតិថិជន (Search filter)
        }

        private void panelCards_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}