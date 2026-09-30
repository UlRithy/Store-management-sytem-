using StoreMS.Data;
using StoreMS.Forms;
using StoreMS.Models;
using StoreMS.Repositories;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace StoreManagementSystem.Forms
{
    public partial class LoignForm : Form
    {
        // ហៅប្រើប្រាស់ Repository សម្រាប់ទាក់ទងជាមួយ Database
        private UserRepository userRepo = new UserRepository();

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

        // មុខងារចម្បងពេលចុចប៊ូតុង Login
        private void button1_Click_1(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();

            // ឆែកមើលក្រែងលោអ្នកប្រើប្រាស់មិនបានបញ្ចូលទិន្នន័យ
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("សូមបញ្ចូល Username និង Password ជាមុនសិន!", "ការជូនដំណឹង", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // ប្រើប្រាស់ UserRepository សម្រាប់ផ្ទៀងផ្ទាត់គណនី (ពិនិត្យ IsActive = 1 ស្រាប់ក្នុង Repository)
                User loggedUser = userRepo.Authenticate(username, password);

                if (loggedUser != null)
                {
                    //  រក្សាទុកទិន្នន័យទៅក្នុង User.CurrentUser សម្រាប់ប្រើប្រាស់ទូទាំងប្រព័ន្ធ (ជំនួស UserSession)
                    User.CurrentUser = loggedUser;

                    // បង្ហាញសារស្វាគមន៍
                    MessageBox.Show("សូមស្វាគមន៍ការចូលកាន់ប្រព័ន្ធ, " + User.CurrentUser.FullName + " (" + User.CurrentUser.Role + ")!", "ជោគជ័យ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // បើក DashboardForm ថ្មី
                    DashboardForm main = new DashboardForm();
                    main.Show();

                    // លាក់ទម្រង់ Login ចោល
                    this.Hide();
                }
                else
                {
                    // បើ Login មិនជោគជ័យ
                    MessageBox.Show("ឈ្មោះអ្នកប្រើប្រាស់ (Username) ឬ លេខសម្ងាត់ (Password) មិនត្រឹមត្រូវ ឬគណនីត្រូវបានបិទ!", "បរាជ័យ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox2.Clear();
                    textBox2.Focus();
                }
            }
            catch (Exception ex)
            {
                // ចាប់យកកំហុស (Error) ប្រសិនបើមានបញ្ហាទាក់ទងនឹង Database
                MessageBox.Show("មានបញ្ហាក្នុងការភ្ជាប់ Database: " + ex.Message, "កំហុសឆ្គង", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}