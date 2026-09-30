using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

using StoreMS.Data;
using StoreMS.Models;
using StoreMS.Repositories;

namespace StoreMS.Forms
{
    public partial class Sale_POSForm : Form
    {
        // =========================================================
        // VARIABLES
        // =========================================================

        private readonly SaleRepository saleRepo = new SaleRepository();

        private readonly BindingList<SaleDetail> cartList = new BindingList<SaleDetail>();

        private readonly PrintDocument printDocument1 = new PrintDocument();

        // User ដែល Login ចូល (បច្ចុប្បន្នប្រើ 1 ជា Default)
        private int currentUserId = 1;


        // =========================================================
        // CONSTRUCTOR
        // =========================================================

        public Sale_POSForm()
        {
            InitializeComponent();
        }


        // =========================================================
        // FORM LOAD
        // =========================================================

        private void Sale_POSForm_Load(object sender, EventArgs e)
        {
            try
            {
                // Cart DataGridView
                dgvCart.AutoGenerateColumns = false;
                dgvCart.DataSource = cartList;
                dgvCart.RowTemplate.Height = 50;

                // Print
                printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);

                // Load Category & Products
                LoadCategories();
                LoadProducts("");

                // Total
                CalculateTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error loading POS:\n\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }


        // =========================================================
        // PANEL PAINT
        // =========================================================

        private void pnlTop_Paint(object sender, PaintEventArgs e)
        {
            // មិនចាំបាច់មាន code
        }


        // =========================================================
        // LOAD CATEGORIES
        // =========================================================

        private void LoadCategories()
        {
            try
            {
                string query = @"
                    SELECT 
                        CategoryID, 
                        CategoryName 
                    FROM tbCategory 
                    ORDER BY CategoryName ASC";

                DataTable dt = Database.ExecuteQuery(query);

                DataRow allRow = dt.NewRow();
                allRow["CategoryID"] = 0;
                allRow["CategoryName"] = "All Categories";
                dt.Rows.InsertAt(allRow, 0);

                cmbCategory.DataSource = dt;
                cmbCategory.DisplayMember = "CategoryName";
                cmbCategory.ValueMember = "CategoryID";
                cmbCategory.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error loading categories:\n\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }


        // =========================================================
        // LOAD PRODUCT IMAGE
        // =========================================================

        private Image LoadProductImage(string imagePath)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(imagePath))
                {
                    return CreateNoImage();
                }

                imagePath = imagePath.Trim();
                List<string> possiblePaths = new List<string>();

                if (Path.IsPathRooted(imagePath))
                {
                    possiblePaths.Add(imagePath);
                }

                possiblePaths.Add(Path.Combine(Application.StartupPath, imagePath));
                possiblePaths.Add(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, imagePath));

                DirectoryInfo directory = Directory.GetParent(Application.StartupPath);
                if (directory != null)
                {
                    directory = directory.Parent;
                }

                if (directory != null)
                {
                    string projectPath = directory.FullName;
                    possiblePaths.Add(Path.Combine(projectPath, imagePath));
                }

                foreach (string path in possiblePaths.Distinct())
                {
                    if (File.Exists(path))
                    {
                        using (Image temp = Image.FromFile(path))
                        {
                            return new Bitmap(temp);
                        }
                    }
                }

                return CreateNoImage();
            }
            catch
            {
                return CreateNoImage();
            }
        }


        // =========================================================
        // CREATE NO IMAGE
        // =========================================================

        private Image CreateNoImage()
        {
            Bitmap bmp = new Bitmap(120, 100);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.WhiteSmoke);

                using (Font font = new Font("Segoe UI", 10F, FontStyle.Italic))
                {
                    using (Brush brush = new SolidBrush(Color.Gray))
                    {
                        StringFormat sf = new StringFormat();
                        sf.Alignment = StringAlignment.Center;
                        sf.LineAlignment = StringAlignment.Center;

                        g.DrawString(
                            "No Image",
                            font,
                            brush,
                            new Rectangle(0, 0, 120, 100),
                            sf
                        );
                    }
                }
            }

            return bmp;
        }


        // =========================================================
        // LOAD PRODUCTS
        // =========================================================

        private void LoadProducts(string searchName, int categoryId = 0)
        {
            flpProducts.Controls.Clear();

            try
            {
                string query = @"
                    SELECT 
                        ProductID, 
                        ProductName, 
                        Price, 
                        StockQty, 
                        ImagePath 
                    FROM tbProducts 
                    WHERE 1 = 1";

                List<SqlParameter> parameters = new List<SqlParameter>();

                if (!string.IsNullOrWhiteSpace(searchName))
                {
                    query += " AND ProductName LIKE @SearchName";
                    parameters.Add(new SqlParameter("@SearchName", "%" + searchName + "%"));
                }

                if (categoryId > 0)
                {
                    query += " AND CategoryID = @CategoryID";
                    parameters.Add(new SqlParameter("@CategoryID", categoryId));
                }

                query += " ORDER BY ProductName ASC";

                DataTable dt = Database.ExecuteQuery(query, parameters.ToArray());

                foreach (DataRow row in dt.Rows)
                {
                    int productId = Convert.ToInt32(row["ProductID"]);
                    string productName = row["ProductName"] == DBNull.Value ? "" : row["ProductName"].ToString();
                    decimal price = row["Price"] == DBNull.Value ? 0m : Convert.ToDecimal(row["Price"]);
                    int stock = row["StockQty"] == DBNull.Value ? 0 : Convert.ToInt32(row["StockQty"]);
                    string imagePath = row["ImagePath"] == DBNull.Value ? "" : row["ImagePath"].ToString();

                    Image productImage = LoadProductImage(imagePath);

                    Panel card = new Panel
                    {
                        Width = 150,
                        Height = 190,
                        BackColor = Color.White,
                        Margin = new Padding(8),
                        Cursor = Cursors.Hand,
                        BorderStyle = BorderStyle.FixedSingle
                    };

                    PictureBox pb = new PictureBox
                    {
                        Width = 140,
                        Height = 100,
                        Dock = DockStyle.Top,
                        SizeMode = PictureBoxSizeMode.Zoom,
                        BackColor = Color.WhiteSmoke,
                        Cursor = Cursors.Hand
                    };

                    if (productImage != null)
                    {
                        pb.Image = productImage;
                    }

                    Label lblName = new Label
                    {
                        Text = productName,
                        Dock = DockStyle.Top,
                        Height = 35,
                        Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                        TextAlign = ContentAlignment.MiddleCenter,
                        Cursor = Cursors.Hand
                    };

                    Label lblPrice = new Label
                    {
                        Text = "$" + price.ToString("N2"),
                        Dock = DockStyle.Bottom,
                        Height = 25,
                        Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                        ForeColor = Color.FromArgb(40, 167, 69),
                        TextAlign = ContentAlignment.MiddleCenter,
                        Cursor = Cursors.Hand
                    };

                    Label lblStock = new Label
                    {
                        Text = "Stock: " + stock,
                        Dock = DockStyle.Bottom,
                        Height = 25,
                        Font = new Font("Segoe UI", 8.5F, FontStyle.Regular),
                        ForeColor = stock > 0 ? Color.DarkGreen : Color.Red,
                        TextAlign = ContentAlignment.MiddleCenter
                    };

                    card.Controls.Add(lblStock);
                    card.Controls.Add(lblPrice);
                    card.Controls.Add(lblName);
                    card.Controls.Add(pb);

                    card.Click += (s, e) => AddToCart(productId, productName, price, 1, stock, productImage);
                    pb.Click += (s, e) => AddToCart(productId, productName, price, 1, stock, productImage);
                    lblName.Click += (s, e) => AddToCart(productId, productName, price, 1, stock, productImage);
                    lblPrice.Click += (s, e) => AddToCart(productId, productName, price, 1, stock, productImage);

                    flpProducts.Controls.Add(card);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error loading products:\n\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }


        // =========================================================
        // ADD TO CART
        // =========================================================

        private void AddToCart(int productId, string productName, decimal price, int qty, int stockQty, Image productImage = null)
        {
            if (stockQty <= 0)
            {
                MessageBox.Show("ទំនិញនេះអស់ពីស្តុក!", "Out of Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaleDetail existingItem = cartList.FirstOrDefault(x => x.ProductId == productId);

            if (existingItem != null)
            {
                if (existingItem.Quantity + qty > stockQty)
                {
                    MessageBox.Show("ស្តុកក្នុងឃ្លាំងមិនគ្រប់គ្រាន់ទេ!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                existingItem.Quantity += qty;
                if (existingItem.ProductImage == null && productImage != null)
                {
                    existingItem.ProductImage = productImage;
                }

                dgvCart.Refresh();
            }
            else
            {
                if (qty > stockQty)
                {
                    MessageBox.Show("ស្តុកក្នុងឃ្លាំងមិនគ្រប់គ្រាន់ទេ!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                cartList.Add(new SaleDetail
                {
                    ProductId = productId,
                    ProductName = productName,
                    Price = price,
                    Quantity = qty,
                    ProductImage = productImage
                });
            }

            CalculateTotal();
        }


        // =========================================================
        // CALCULATE TOTAL
        // =========================================================

        private void CalculateTotal()
        {
            decimal grandTotal = 0m;

            foreach (SaleDetail item in cartList)
            {
                grandTotal += item.SubTotal;
            }

            lblTotalAmount.Text = "$" + grandTotal.ToString("N2");
        }


        // =========================================================
        // BARCODE SCAN
        // =========================================================

        private void txtBarcodeScan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;

            string barcode = txtBarcodeScan.Text.Trim();
            if (string.IsNullOrWhiteSpace(barcode))
                return;

            try
            {
                string query = @"
                    SELECT 
                        ProductID, 
                        ProductName, 
                        Price, 
                        StockQty, 
                        ImagePath 
                    FROM tbProducts 
                    WHERE Barcode = @Barcode";

                SqlParameter[] parameters = { new SqlParameter("@Barcode", barcode) };
                DataTable dt = Database.ExecuteQuery(query, parameters);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("រកមិនឃើញទំនិញដែលមាន Barcode នេះទេ!", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBarcodeScan.SelectAll();
                    return;
                }

                DataRow row = dt.Rows[0];
                int productId = Convert.ToInt32(row["ProductID"]);
                string productName = row["ProductName"] == DBNull.Value ? "" : row["ProductName"].ToString();
                decimal price = row["Price"] == DBNull.Value ? 0m : Convert.ToDecimal(row["Price"]);
                int stock = row["StockQty"] == DBNull.Value ? 0 : Convert.ToInt32(row["StockQty"]);
                string imagePath = row["ImagePath"] == DBNull.Value ? "" : row["ImagePath"].ToString();

                Image productImage = LoadProductImage(imagePath);

                AddToCart(productId, productName, price, 1, stock, productImage);
                txtBarcodeScan.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error scanning barcode:\n\n" + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // =========================================================
        // SEARCH BOX & CATEGORY CHANGED
        // =========================================================

        private void txtSearchProduct_TextChanged(object sender, EventArgs e)
        {
            string searchKeyword = txtSearchProduct.Text.Trim();
            int categoryId = 0;

            if (cmbCategory.SelectedValue != null && int.TryParse(cmbCategory.SelectedValue.ToString(), out int parsedId))
            {
                categoryId = parsedId;
            }

            LoadProducts(searchKeyword, categoryId);
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCategory.SelectedValue == null)
                return;

            if (int.TryParse(cmbCategory.SelectedValue.ToString(), out int categoryId))
            {
                string searchKeyword = txtSearchProduct != null ? txtSearchProduct.Text.Trim() : "";
                LoadProducts(searchKeyword, categoryId);
            }
        }


        // =========================================================
        // CART REMOVE BUTTONS
        // =========================================================

        private void dgvCart_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            cartList.RemoveAt(e.RowIndex);
            CalculateTotal();
        }

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            if (dgvCart.SelectedRows.Count > 0)
            {
                int rowIndex = dgvCart.SelectedRows[0].Index;
                cartList.RemoveAt(rowIndex);
                CalculateTotal();
            }
            else
            {
                MessageBox.Show("សូមជ្រើសរើសទំនិញដែលចង់លុបចេញពីកន្ត្រក!", "Select Item", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnClearCart_Click(object sender, EventArgs e)
        {
            if (cartList.Count > 0)
            {
                DialogResult result = MessageBox.Show("តើអ្នកពិតជាចង់លុបទំនិញទាំងអស់ក្នុងកន្ត្រកមែនទេ?", "Confirm Clear", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    cartList.Clear();
                    CalculateTotal();
                }
            }
        }


        // =========================================================
        // CHECKOUT / COMPLETE SALE
        // =========================================================

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            if (cartList.Count == 0)
            {
                MessageBox.Show("មិនមានទំនិញនៅក្នុងកន្ត្រកទិញទេ!", "Empty Cart", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                decimal totalAmount = 0m;
                foreach (var item in cartList)
                {
                    totalAmount += item.SubTotal;
                }

                // បើកផ្ទាំង PaymentForm ឱ្យអ្នកប្រើប្រាស់ជ្រើសរើសវិធីបង់ប្រាក់
                using (PaymentForm paymentForm = new PaymentForm(totalAmount))
                {
                    if (paymentForm.ShowDialog() == DialogResult.OK)
                    {
                        string invoiceNo = "INV-" + DateTime.Now.ToString("yyyyMMdd-HHmmss");

                        Sale sale = new Sale
                        {
                            InvoiceNo = invoiceNo,
                            SaleDate = DateTime.Now,
                            CustomerId = 0,
                            UserId = currentUserId,
                            TotalAmount = totalAmount,
                            PaymentMethod = paymentForm.PaymentMethod,
                            SaleDetails = cartList.ToList()
                        };

                        // រក្សាទុកចូល Database
                        bool success = saleRepo.Checkout(sale);

                        if (success)
                        {
                            MessageBox.Show(
                                $"ការលក់បានជោគជ័យ!\nវិធីទូទាត់៖ {paymentForm.PaymentMethod}\nប្រាក់អាប់៖ ${paymentForm.ChangeAmount:N2}",
                                "Success",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information
                            );

                            // បញ្ជាឱ្យព្រីនវិក្កយបត្រចេញមកក្រៅ
                            printDocument1.Print();

                            // សម្អាតកន្ត្រកត្រៀមលក់បន្ត
                            cartList.Clear();
                            CalculateTotal();
                            LoadProducts("");
                            txtBarcodeScan.Focus();
                        }
                        else
                        {
                            MessageBox.Show("មិនអាចរក្សាទុកការលក់បានទេ សូមព្យាយាមម្ដងទៀត។", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during checkout:\n\n" + ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // =========================================================
        // PRINT DOCUMENT EVENT (RECEIPT PRINTING)
        // =========================================================

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;

            // កំណត់ហ្វុងអក្សរសម្រាប់ផ្នែកផ្សេងៗ
            Font fontTitle = new Font("Segoe UI", 14, FontStyle.Bold);
            Font fontHeader = new Font("Segoe UI", 9, FontStyle.Regular);
            Font fontBold = new Font("Segoe UI", 10, FontStyle.Bold);
            Font fontItem = new Font("Segoe UI", 9, FontStyle.Regular);
            Brush brush = Brushes.Black;

            float startX = 10;
            float startY = 10;

            // កំណត់ទទឹងក្រដាសកម្ដៅ (Thermal Printer 80mm ស្មើនឹងប្រហែល 280-300 pixels)
            float pageWidth = 280;

            StringFormat centerFormat = new StringFormat { Alignment = StringAlignment.Center };
            StringFormat rightFormat = new StringFormat { Alignment = StringAlignment.Far };

            float y = startY;

            // ==========================================
            // ១. ហាង និងព័ត៌មានក្បាលវិក្កយបត្រ (Header)
            // ==========================================
            g.DrawString("MARTKH24H", fontTitle, brush, new RectangleF(startX, y, pageWidth, 25), centerFormat);
            y += 30;

            g.DrawString("អាសយដ្ឋាន៖ ភ្នំពេញ, កម្ពុជា", fontHeader, brush, new RectangleF(startX, y, pageWidth, 15), centerFormat);
            y += 18;
            g.DrawString("ទូរស័ព្ទ៖ 012 345 678", fontHeader, brush, new RectangleF(startX, y, pageWidth, 15), centerFormat);
            y += 22;

            g.DrawString("----------------------------------------------------------------", fontHeader, brush, startX, y);
            y += 15;

            // ព័ត៌មានវិក្កយបត្រ និងកាលបរិច្ឆេទ
            g.DrawString("កាលបរិច្ឆេទ៖ " + DateTime.Now.ToString("dd-MM-yyyy HH:mm"), fontHeader, brush, startX, y);
            y += 18;
            g.DrawString("Cashier: Administrator", fontHeader, brush, startX, y);
            y += 22;

            g.DrawString("----------------------------------------------------------------", fontHeader, brush, startX, y);
            y += 15;

            // ==========================================
            // ២. បញ្ជីទំនិញ (Itemized List Header)
            // ==========================================
            g.DrawString("បរិយាយទំនិញ", fontBold, brush, startX, y);
            g.DrawString("តម្លៃ", fontBold, brush, pageWidth - 40, y, rightFormat);
            y += 18;

            g.DrawString("----------------------------------------------------------------", fontHeader, brush, startX, y);
            y += 15;

            // ==========================================
            // ៣. បង្ហាញទំនិញនីមួយៗក្នុងកន្ត្រក (Cart Items)
            // ==========================================
            foreach (var item in cartList)
            {
                g.DrawString(item.ProductName, fontItem, brush, startX, y);
                y += 16;

                string qtyPrice = $"{item.Quantity} x ${item.Price:N2}";
                g.DrawString(qtyPrice, fontItem, brush, startX + 10, y);

                string subTotalStr = $"${item.SubTotal:N2}";
                g.DrawString(subTotalStr, fontItem, brush, pageWidth, y, rightFormat);

                y += 22;
            }

            g.DrawString("----------------------------------------------------------------", fontHeader, brush, startX, y);
            y += 15;

            // ==========================================
            // ៤. បូកសរុបទឹកប្រាក់ (Totals & Payment)
            // ==========================================
            g.DrawString("សរុបទឹកប្រាក់ (Total):", fontBold, brush, startX, y);
            g.DrawString(lblTotalAmount.Text, fontBold, brush, pageWidth, y, rightFormat);
            y += 25;

            // ==========================================
            // ៥. ផ្នែកបាតវិក្កយបត្រ (Footer)
            // ==========================================
            g.DrawString("អរគុណសម្រាប់ការអញ្ជើញមកទិញទំនិញ!", fontHeader, brush, new RectangleF(startX, y, pageWidth, 15), centerFormat);
            y += 20;
            g.DrawString("Please Come Again!", fontHeader, brush, new RectangleF(startX, y, pageWidth, 15), centerFormat);
        }

        private void dgvCart_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}