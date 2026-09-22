using StoreMS.Data;
using StoreMS.Forms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace StoreManagementSystem.Forms
{
    public partial class LoignForm : Form
    {
        public LoignForm()
        {
            InitializeComponent();
        }

        private void Loign_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

     

        private void label6_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox1.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnClose_MouseEnter(object sender, EventArgs e)
        {
            btnClose.BackColor = Color.FromArgb(239, 68, 68);
            btnClose.ForeColor = Color.White;
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            btnClose.BackColor = Color.Transparent;
            btnClose.ForeColor = Color.FromArgb(148, 163, 184);
        }

        private void panel1_Paint(object sender, PaintEventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void pictureBox1_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void pictureBox2_Click(object sender, EventArgs e) { }
        private void pictureBox3_Click(object sender, EventArgs e) { }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("សូមបញ្ចូល Username និង Password ជាមុនសិន!", "ការជូនដំណឹង", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string query = "SELECT UserID, Username, FullName, Role, Position FROM tbUsers WHERE Username = @Username AND Password = @Password";

                SqlParameter[] parameters = {
                    new SqlParameter("@Username", username),
                    new SqlParameter("@Password", password)
                };

                DataTable dt = Database.ExecuteQuery(query, parameters);

                if (dt.Rows.Count > 0)
                {
                    // Convert ត្រូវជា int ស្របតាមប្រភេទဒေតានៅក្នុង Database
                    int userId = Convert.ToInt32(dt.Rows.Count > 0 ? dt.Rows[0]["UserID"] : 0);
                    string fullName = dt.Rows[0]["FullName"].ToString();
                    string role = dt.Rows[0]["Role"].ToString();

                    MessageBox.Show("សូមស្វាគមន៍ការចូលកាន់ប្រព័ន្ធ, " + fullName + " (" + role + ")!", "ជោគជ័យ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    
                    DashboardForm main = new DashboardForm(userId, fullName, role);
                    main.Show();

                    this.Hide();
                }
                else
                {
                    MessageBox.Show("ឈ្មោះអ្នកប្រើប្រាស់ (Username) ឬ លេខសម្ងាត់ (Password) មិនត្រឹមត្រូវទេ!", "បរាជ័យ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox2.Clear();
                    textBox2.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("មានបញ្ហាក្នុងការភ្ជាប់ Database: " + ex.Message, "កំហុសឆ្គង", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}