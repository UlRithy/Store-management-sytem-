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

        private readonly SaleRepository saleRepo =
            new SaleRepository();

        private readonly BindingList<SaleDetail> cartList =
            new BindingList<SaleDetail>();

        private readonly PrintDocument printDocument1 =
            new PrintDocument();

        // User ដែល Login ចូល
        // បច្ចុប្បន្នប្រើ 1 ជា Default
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

        private void Sale_POSForm_Load(
            object sender,
            EventArgs e)
        {
            try
            {
                // -----------------------------
                // Cart DataGridView
                // -----------------------------

                dgvCart.AutoGenerateColumns = false;

                dgvCart.DataSource = cartList;

                dgvCart.RowTemplate.Height = 50;

                // -----------------------------
                // Print
                // -----------------------------

                printDocument1.PrintPage +=
                    new PrintPageEventHandler(
                        printDocument1_PrintPage
                    );

                // -----------------------------
                // Load Customer
                // -----------------------------

                LoadCustomers();

                // -----------------------------
                // Load Category
                // -----------------------------

                LoadCategories();

                // -----------------------------
                // Load Products
                // -----------------------------

                LoadProducts("");

                // -----------------------------
                // Total
                // -----------------------------

                CalculateTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error loading POS:\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }


        // =========================================================
        // PANEL PAINT
        // =========================================================

        private void pnlTop_Paint(
            object sender,
            PaintEventArgs e)
        {
            // មិនចាំបាច់មាន code
        }


        // =========================================================
        // LOAD CUSTOMERS
        // =========================================================

        private void LoadCustomers()
        {
            try
            {
                string query = @"
                    SELECT
                        CustomerID,
                        CustomerName
                    FROM tbCustomers
                    ORDER BY CustomerName ASC";

                DataTable dt =
                    Database.ExecuteQuery(query);

                cmbCustomer.DataSource = dt;

                cmbCustomer.DisplayMember =
                    "CustomerName";

                cmbCustomer.ValueMember =
                    "CustomerID";

                if (dt.Rows.Count > 0)
                {
                    cmbCustomer.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error loading customers:\n\n" +
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
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

                DataTable dt =
                    Database.ExecuteQuery(query);

                // Add All Categories
                DataRow allRow =
                    dt.NewRow();

                allRow["CategoryID"] = 0;

                allRow["CategoryName"] =
                    "All Categories";

                dt.Rows.InsertAt(
                    allRow,
                    0
                );

                cmbCategory.DataSource = dt;

                cmbCategory.DisplayMember =
                    "CategoryName";

                cmbCategory.ValueMember =
                    "CategoryID";

                cmbCategory.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error loading categories:\n\n" +
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }


        // =========================================================
        // LOAD PRODUCT IMAGE
        // =========================================================

        private Image LoadProductImage(
            string imagePath)
        {
            try
            {
                // -----------------------------------------
                // Empty ImagePath
                // -----------------------------------------

                if (string.IsNullOrWhiteSpace(imagePath))
                {
                    return CreateNoImage();
                }

                imagePath =
                    imagePath.Trim();


                // -----------------------------------------
                // Possible paths
                // -----------------------------------------

                List<string> possiblePaths =
                    new List<string>();


                // -----------------------------------------
                // 1. Absolute Path
                // -----------------------------------------

                if (Path.IsPathRooted(imagePath))
                {
                    possiblePaths.Add(
                        imagePath
                    );
                }


                // -----------------------------------------
                // 2. Application Startup Path
                // -----------------------------------------

                possiblePaths.Add(
                    Path.Combine(
                        Application.StartupPath,
                        imagePath
                    )
                );


                // -----------------------------------------
                // 3. Base Directory
                // -----------------------------------------

                possiblePaths.Add(
                    Path.Combine(
                        AppDomain.CurrentDomain.BaseDirectory,
                        imagePath
                    )
                );


                // -----------------------------------------
                // 4. Project Folder
                // -----------------------------------------

                DirectoryInfo directory =
                    Directory.GetParent(
                        Application.StartupPath
                    );

                if (directory != null)
                {
                    directory =
                        directory.Parent;
                }

                if (directory != null)
                {
                    string projectPath =
                        directory.FullName;

                    possiblePaths.Add(
                        Path.Combine(
                            projectPath,
                            imagePath
                        )
                    );
                }


                // -----------------------------------------
                // Find Image
                // -----------------------------------------

                foreach (string path
                    in possiblePaths.Distinct())
                {
                    if (File.Exists(path))
                    {
                        // Clone image so file won't be locked
                        using (
                            Image temp =
                            Image.FromFile(path)
                        )
                        {
                            return new Bitmap(temp);
                        }
                    }
                }


                // -----------------------------------------
                // Image not found
                // -----------------------------------------

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
            Bitmap bmp =
                new Bitmap(
                    120,
                    100
                );

            using (
                Graphics g =
                Graphics.FromImage(bmp)
            )
            {
                g.Clear(
                    Color.WhiteSmoke
                );

                using (
                    Font font =
                    new Font(
                        "Segoe UI",
                        10F,
                        FontStyle.Italic
                    )
                )
                {
                    using (
                        Brush brush =
                        new SolidBrush(
                            Color.Gray
                        )
                    )
                    {
                        StringFormat sf =
                            new StringFormat();

                        sf.Alignment =
                            StringAlignment.Center;

                        sf.LineAlignment =
                            StringAlignment.Center;

                        g.DrawString(
                            "No Image",
                            font,
                            brush,
                            new Rectangle(
                                0,
                                0,
                                120,
                                100
                            ),
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

        private void LoadProducts(
            string searchName,
            int categoryId = 0)
        {
            // Clear old cards
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

                List<SqlParameter> parameters =
                    new List<SqlParameter>();


                // -----------------------------------------
                // Search Product Name
                // -----------------------------------------

                if (!string.IsNullOrWhiteSpace(searchName))
                {
                    query += @"
                        AND ProductName LIKE @SearchName";

                    parameters.Add(
                        new SqlParameter(
                            "@SearchName",
                            "%" +
                            searchName +
                            "%"
                        )
                    );
                }


                // -----------------------------------------
                // Category
                // -----------------------------------------

                if (categoryId > 0)
                {
                    query += @"
                        AND CategoryID = @CategoryID";

                    parameters.Add(
                        new SqlParameter(
                            "@CategoryID",
                            categoryId
                        )
                    );
                }


                // -----------------------------------------
                // Order
                // -----------------------------------------

                query += @"
                    ORDER BY ProductName ASC";


                // -----------------------------------------
                // Execute
                // -----------------------------------------

                DataTable dt =
                    Database.ExecuteQuery(
                        query,
                        parameters.ToArray()
                    );


                // -----------------------------------------
                // Create Product Cards
                // -----------------------------------------

                foreach (
                    DataRow row
                    in dt.Rows
                )
                {
                    int productId =
                        Convert.ToInt32(
                            row["ProductID"]
                        );


                    string productName =
                        row["ProductName"]
                        == DBNull.Value
                        ? ""
                        : row["ProductName"]
                            .ToString();


                    decimal price =
                        row["Price"]
                        == DBNull.Value
                        ? 0m
                        : Convert.ToDecimal(
                            row["Price"]
                        );


                    int stock =
                        row["StockQty"]
                        == DBNull.Value
                        ? 0
                        : Convert.ToInt32(
                            row["StockQty"]
                        );


                    string imagePath =
                        row["ImagePath"]
                        == DBNull.Value
                        ? ""
                        : row["ImagePath"]
                            .ToString();


                    // -----------------------------------------
                    // Load Image
                    // -----------------------------------------

                    Image productImage =
                        LoadProductImage(
                            imagePath
                        );


                    // -----------------------------------------
                    // Product Card
                    // -----------------------------------------

                    Panel card =
                        new Panel
                        {
                            Width = 150,

                            Height = 190,

                            BackColor =
                                Color.White,

                            Margin =
                                new Padding(8),

                            Cursor =
                                Cursors.Hand,

                            BorderStyle =
                                BorderStyle.FixedSingle
                        };


                    // -----------------------------------------
                    // PictureBox
                    // -----------------------------------------

                    PictureBox pb =
                        new PictureBox
                        {
                            Width = 140,

                            Height = 100,

                            Dock =
                                DockStyle.Top,

                            SizeMode =
                                PictureBoxSizeMode.Zoom,

                            BackColor =
                                Color.WhiteSmoke,

                            Cursor =
                                Cursors.Hand
                        };


                    if (productImage != null)
                    {
                        pb.Image =
                            productImage;
                    }


                    // -----------------------------------------
                    // Product Name
                    // -----------------------------------------

                    Label lblName =
                        new Label
                        {
                            Text =
                                productName,

                            Dock =
                                DockStyle.Top,

                            Height = 35,

                            Font =
                                new Font(
                                    "Segoe UI",
                                    9F,
                                    FontStyle.Bold
                                ),

                            TextAlign =
                                ContentAlignment.MiddleCenter,

                            Cursor =
                                Cursors.Hand
                        };


                    // -----------------------------------------
                    // Price
                    // -----------------------------------------

                    Label lblPrice =
                        new Label
                        {
                            Text =
                                "$" +
                                price.ToString("N2"),

                            Dock =
                                DockStyle.Bottom,

                            Height = 25,

                            Font =
                                new Font(
                                    "Segoe UI",
                                    9.5F,
                                    FontStyle.Bold
                                ),

                            ForeColor =
                                Color.FromArgb(
                                    40,
                                    167,
                                    69
                                ),

                            TextAlign =
                                ContentAlignment.MiddleCenter,

                            Cursor =
                                Cursors.Hand
                        };


                    // -----------------------------------------
                    // Stock
                    // -----------------------------------------

                    Label lblStock =
                        new Label
                        {
                            Text =
                                "Stock: " +
                                stock,

                            Dock =
                                DockStyle.Bottom,

                            Height = 25,

                            Font =
                                new Font(
                                    "Segoe UI",
                                    8.5F,
                                    FontStyle.Regular
                                ),

                            ForeColor =
                                stock > 0
                                ? Color.DarkGreen
                                : Color.Red,

                            TextAlign =
                                ContentAlignment.MiddleCenter
                        };


                    // -----------------------------------------
                    // Add controls
                    // -----------------------------------------

                    card.Controls.Add(
                        lblStock
                    );

                    card.Controls.Add(
                        lblPrice
                    );

                    card.Controls.Add(
                        lblName
                    );

                    card.Controls.Add(
                        pb
                    );


                    // -----------------------------------------
                    // Click Card
                    // -----------------------------------------

                    card.Click +=
                        (s, e) =>
                        {
                            AddToCart(
                                productId,
                                productName,
                                price,
                                1,
                                stock,
                                productImage
                            );
                        };


                    // -----------------------------------------
                    // Click Image
                    // -----------------------------------------

                    pb.Click +=
                        (s, e) =>
                        {
                            AddToCart(
                                productId,
                                productName,
                                price,
                                1,
                                stock,
                                productImage
                            );
                        };


                    // -----------------------------------------
                    // Click Name
                    // -----------------------------------------

                    lblName.Click +=
                        (s, e) =>
                        {
                            AddToCart(
                                productId,
                                productName,
                                price,
                                1,
                                stock,
                                productImage
                            );
                        };


                    // -----------------------------------------
                    // Click Price
                    // -----------------------------------------

                    lblPrice.Click +=
                        (s, e) =>
                        {
                            AddToCart(
                                productId,
                                productName,
                                price,
                                1,
                                stock,
                                productImage
                            );
                        };


                    // -----------------------------------------
                    // Add Card
                    // -----------------------------------------

                    flpProducts.Controls.Add(
                        card
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error loading products:\n\n" +
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }


        // =========================================================
        // ADD TO CART
        // =========================================================

        private void AddToCart(
            int productId,
            string productName,
            decimal price,
            int qty,
            int stockQty,
            Image productImage = null)
        {
            // -----------------------------------------
            // Check Stock
            // -----------------------------------------

            if (stockQty <= 0)
            {
                MessageBox.Show(
                    "ទំនិញនេះអស់ពីស្តុក!",
                    "Out of Stock",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }


            // -----------------------------------------
            // Existing Item
            // -----------------------------------------

            SaleDetail existingItem =
                cartList.FirstOrDefault(
                    x =>
                    x.ProductId ==
                    productId
                );


            if (existingItem != null)
            {
                // Check quantity
                if (
                    existingItem.Quantity +
                    qty >
                    stockQty
                )
                {
                    MessageBox.Show(
                        "ស្តុកក្នុងឃ្លាំងមិនគ្រប់គ្រាន់ទេ!",
                        "Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }


                existingItem.Quantity += qty;


                // Image
                if (
                    existingItem.ProductImage ==
                    null
                    &&
                    productImage != null
                )
                {
                    existingItem.ProductImage =
                        productImage;
                }


                dgvCart.Refresh();
            }
            else
            {
                // -----------------------------------------
                // New Item
                // -----------------------------------------

                if (qty > stockQty)
                {
                    MessageBox.Show(
                        "ស្តុកក្នុងឃ្លាំងមិនគ្រប់គ្រាន់ទេ!",
                        "Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }


                cartList.Add(
                    new SaleDetail
                    {
                        ProductId =
                            productId,

                        ProductName =
                            productName,

                        Price =
                            price,

                        Quantity =
                            qty,

                        ProductImage =
                            productImage
                    }
                );
            }


            // -----------------------------------------
            // Calculate
            // -----------------------------------------

            CalculateTotal();
        }


        // =========================================================
        // CALCULATE TOTAL
        // =========================================================

        private void CalculateTotal()
        {
            decimal grandTotal =
                0m;


            foreach (
                SaleDetail item
                in cartList
            )
            {
                grandTotal +=
                    item.SubTotal;
            }


            lblTotalAmount.Text =
                "$" +
                grandTotal.ToString(
                    "N2"
                );
        }


        // =========================================================
        // BARCODE SCAN
        // =========================================================

        private void txtBarcodeScan_KeyDown(
            object sender,
            KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;


            string barcode =
                txtBarcodeScan.Text.Trim();


            if (
                string.IsNullOrWhiteSpace(
                    barcode
                )
            )
            {
                return;
            }


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


                SqlParameter[] parameters =
                {
                    new SqlParameter(
                        "@Barcode",
                        barcode
                    )
                };


                DataTable dt =
                    Database.ExecuteQuery(
                        query,
                        parameters
                    );


                // -----------------------------------------
                // Not Found
                // -----------------------------------------

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show(
                        "រកមិនឃើញទំនិញដែលមាន Barcode នេះទេ!",
                        "Not Found",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    txtBarcodeScan.SelectAll();

                    return;
                }


                // -----------------------------------------
                // Product
                // -----------------------------------------

                DataRow row =
                    dt.Rows[0];


                int productId =
                    Convert.ToInt32(
                        row["ProductID"]
                    );


                string productName =
                    row["ProductName"]
                    == DBNull.Value
                    ? ""
                    : row["ProductName"]
                        .ToString();


                decimal price =
                    row["Price"]
                    == DBNull.Value
                    ? 0m
                    : Convert.ToDecimal(
                        row["Price"]
                    );


                int stock =
                    row["StockQty"]
                    == DBNull.Value
                    ? 0
                    : Convert.ToInt32(
                        row["StockQty"]
                    );


                string imagePath =
                    row["ImagePath"]
                    == DBNull.Value
                    ? ""
                    : row["ImagePath"]
                        .ToString();


                Image productImage =
                    LoadProductImage(
                        imagePath
                    );


                // -----------------------------------------
                // Add Cart
                // -----------------------------------------

                AddToCart(
                    productId,
                    productName,
                    price,
                    1,
                    stock,
                    productImage
                );


                txtBarcodeScan.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Barcode Error:\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }


            e.Handled = true;

            e.SuppressKeyPress = true;
        }


        // =========================================================
        // DOUBLE CLICK CART - CHANGE QUANTITY
        // =========================================================

        private void dgvCart_CellDoubleClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;


            SaleDetail selectedItem =
                dgvCart.Rows[
                    e.RowIndex
                ].DataBoundItem
                as SaleDetail;


            if (selectedItem == null)
                return;


            using (
                Form prompt =
                new Form()
            )
            {
                prompt.Width = 380;

                prompt.Height = 190;

                prompt.FormBorderStyle =
                    FormBorderStyle.FixedDialog;

                prompt.Text =
                    "កែប្រែចំនួន";

                prompt.StartPosition =
                    FormStartPosition.CenterParent;

                prompt.MaximizeBox =
                    false;

                prompt.MinimizeBox =
                    false;


                Label textLabel =
                    new Label
                    {
                        Left = 20,

                        Top = 20,

                        Width = 320,

                        Text =
                            "បញ្ចូលចំនួនថ្មីសម្រាប់ " +
                            selectedItem.ProductName
                    };


                TextBox inputBox =
                    new TextBox
                    {
                        Left = 20,

                        Top = 55,

                        Width = 320,

                        Text =
                            selectedItem.Quantity
                            .ToString()
                    };


                Button confirmation =
                    new Button
                    {
                        Text = "OK",

                        Left = 240,

                        Top = 95,

                        Width = 100,

                        DialogResult =
                            DialogResult.OK
                    };


                prompt.Controls.Add(
                    textLabel
                );

                prompt.Controls.Add(
                    inputBox
                );

                prompt.Controls.Add(
                    confirmation
                );


                prompt.AcceptButton =
                    confirmation;


                if (
                    prompt.ShowDialog()
                    ==
                    DialogResult.OK
                )
                {
                    int newQty;


                    if (
                        !int.TryParse(
                            inputBox.Text,
                            out newQty
                        )
                        ||
                        newQty <= 0
                    )
                    {
                        MessageBox.Show(
                            "ចំនួនមិនត្រឹមត្រូវទេ!",
                            "Warning",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );

                        return;
                    }


                    int stockQty =
                        GetProductStock(
                            selectedItem.ProductId
                        );


                    if (
                        newQty >
                        stockQty
                    )
                    {
                        MessageBox.Show(
                            "ចំនួនលើសពីស្តុកដែលមាន!\n\n" +
                            "Stock: " +
                            stockQty,
                            "Warning",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );

                        return;
                    }


                    selectedItem.Quantity =
                        newQty;


                    dgvCart.Refresh();

                    CalculateTotal();
                }
            }
        }


        // =========================================================
        // GET PRODUCT STOCK
        // =========================================================

        private int GetProductStock(
            int productId)
        {
            try
            {
                string query = @"
                    SELECT StockQty
                    FROM tbProducts
                    WHERE ProductID = @ProductID";


                SqlParameter[] parameters =
                {
                    new SqlParameter(
                        "@ProductID",
                        productId
                    )
                };


                DataTable dt =
                    Database.ExecuteQuery(
                        query,
                        parameters
                    );


                if (
                    dt.Rows.Count ==
                    0
                )
                {
                    return 0;
                }


                return Convert.ToInt32(
                    dt.Rows[0][
                        "StockQty"
                    ]
                );
            }
            catch
            {
                return 0;
            }
        }


        // =========================================================
        // CHECKOUT
        // =========================================================

        private void btnCheckout_Click(
            object sender,
            EventArgs e)
        {
            // -----------------------------------------
            // Cart Empty
            // -----------------------------------------

            if (cartList.Count == 0)
            {
                MessageBox.Show(
                    "សូមបញ្ចូលទំនិញក្នុងកន្ត្រកជាមុនសិន!",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }


            // -----------------------------------------
            // Total
            // -----------------------------------------

            decimal totalAmount =
                cartList.Sum(
                    x => x.SubTotal
                );


            // -----------------------------------------
            // Payment Form
            // -----------------------------------------

            using (
                PaymentForm paymentForm =
                new PaymentForm(
                    totalAmount
                )
            )
            {
                paymentForm.ShowDialog();


                if (
                    !paymentForm.IsConfirmed
                )
                {
                    return;
                }


                try
                {
                    int customerId =
                        0;


                    if (
                        cmbCustomer.SelectedValue
                        != null
                    )
                    {
                        int.TryParse(
                            cmbCustomer
                                .SelectedValue
                                .ToString(),
                            out customerId
                        );
                    }


                    // -----------------------------------------
                    // Sale Object
                    // -----------------------------------------

                    Sale sale =
                        new Sale
                        {
                            InvoiceNo =
                                GenerateInvoiceNo(),

                            SaleDate =
                                DateTime.Now,

                            CustomerId =
                                customerId,

                            UserId =
                                currentUserId,

                            TotalAmount =
                                totalAmount,

                            PaymentMethod =
                                paymentForm
                                    .PaymentMethod,

                            SaleDetails =
                                new List<SaleDetail>(
                                    cartList
                                )
                        };


                    // -----------------------------------------
                    // Save
                    // -----------------------------------------

                    bool isSuccess =
                        saleRepo.Checkout(
                            sale
                        );


                    if (isSuccess)
                    {
                        MessageBox.Show(
                            "ទូទាត់ប្រាក់បានជោគជ័យ!\n\n" +

                            "Invoice: " +
                            sale.InvoiceNo +

                            "\nTotal: $" +
                            totalAmount.ToString(
                                "N2"
                            ) +

                            "\nChange: $" +
                            paymentForm
                                .ChangeAmount
                                .ToString(
                                    "N2"
                                ),
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );


                        // -----------------------------------------
                        // Print
                        // -----------------------------------------

                        try
                        {
                            printDocument1.Print();
                        }
                        catch
                        {
                            // Printer not available
                        }


                        // -----------------------------------------
                        // Clear Cart
                        // -----------------------------------------

                        cartList.Clear();

                        CalculateTotal();


                        // -----------------------------------------
                        // Reload Products
                        // -----------------------------------------

                        LoadProducts(
                            txtSearchProduct.Text.Trim(),
                            GetSelectedCategoryId()
                        );


                        txtBarcodeScan.Clear();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Checkout failed:\n\n" +
                        ex.Message,
                        "Checkout Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        }


        // =========================================================
        // GENERATE INVOICE NUMBER
        // =========================================================

        private string GenerateInvoiceNo()
        {
            return
                "INV-" +
                DateTime.Now.ToString(
                    "yyyyMMddHHmmssfff"
                );
        }


        // =========================================================
        // PRINT RECEIPT
        // =========================================================

        private void printDocument1_PrintPage(
            object sender,
            PrintPageEventArgs e)
        {
            Graphics g =
                e.Graphics;


            using (
                Font fontTitle =
                new Font(
                    "Segoe UI",
                    14,
                    FontStyle.Bold
                )
            )

            using (
                Font fontHeader =
                new Font(
                    "Segoe UI",
                    9,
                    FontStyle.Bold
                )
            )

            using (
                Font fontBody =
                new Font(
                    "Segoe UI",
                    9,
                    FontStyle.Regular
                )
            )
            {
                float startX =
                    10;

                float startY =
                    10;


                // -----------------------------------------
                // Shop Name
                // -----------------------------------------

                g.DrawString(
                    "MARTKH24H",
                    fontTitle,
                    Brushes.Black,
                    startX + 50,
                    startY
                );


                g.DrawString(
                    "អាសយដ្ឋាន៖ ភ្នំពេញ, កម្ពុជា",
                    fontBody,
                    Brushes.Black,
                    startX + 50,
                    startY + 25
                );


                g.DrawString(
                    "------------------------------------------------",
                    fontBody,
                    Brushes.Black,
                    startX,
                    startY + 45
                );


                // -----------------------------------------
                // Invoice
                // -----------------------------------------

                g.DrawString(
                    "Invoice: " +
                    GenerateInvoiceNo(),
                    fontBody,
                    Brushes.Black,
                    startX,
                    startY + 65
                );


                // -----------------------------------------
                // Date
                // -----------------------------------------

                g.DrawString(
                    "កាលបរិច្ឆេទ៖ " +
                    DateTime.Now.ToString(
                        "dd/MM/yyyy HH:mm"
                    ),
                    fontBody,
                    Brushes.Black,
                    startX,
                    startY + 85
                );


                g.DrawString(
                    "------------------------------------------------",
                    fontBody,
                    Brushes.Black,
                    startX,
                    startY + 105
                );


                // -----------------------------------------
                // Header
                // -----------------------------------------

                float offset =
                    startY + 125;


                g.DrawString(
                    "Item",
                    fontHeader,
                    Brushes.Black,
                    startX,
                    offset
                );


                g.DrawString(
                    "Qty",
                    fontHeader,
                    Brushes.Black,
                    startX + 150,
                    offset
                );


                g.DrawString(
                    "Price",
                    fontHeader,
                    Brushes.Black,
                    startX + 200,
                    offset
                );


                g.DrawString(
                    "Total",
                    fontHeader,
                    Brushes.Black,
                    startX + 250,
                    offset
                );


                offset += 25;


                // -----------------------------------------
                // Items
                // -----------------------------------------

                foreach (
                    SaleDetail item
                    in cartList
                )
                {
                    g.DrawString(
                        item.ProductName,
                        fontBody,
                        Brushes.Black,
                        startX,
                        offset
                    );


                    g.DrawString(
                        item.Quantity.ToString(),
                        fontBody,
                        Brushes.Black,
                        startX + 150,
                        offset
                    );


                    g.DrawString(
                        item.Price.ToString(
                            "N2"
                        ),
                        fontBody,
                        Brushes.Black,
                        startX + 200,
                        offset
                    );


                    g.DrawString(
                        item.SubTotal.ToString(
                            "N2"
                        ),
                        fontBody,
                        Brushes.Black,
                        startX + 250,
                        offset
                    );


                    offset += 20;
                }


                // -----------------------------------------
                // Total
                // -----------------------------------------

                g.DrawString(
                    "------------------------------------------------",
                    fontBody,
                    Brushes.Black,
                    startX,
                    offset
                );


                offset += 25;


                decimal total =
                    cartList.Sum(
                        x => x.SubTotal
                    );


                g.DrawString(
                    "TOTAL: $" +
                    total.ToString(
                        "N2"
                    ),
                    fontTitle,
                    Brushes.Black,
                    startX,
                    offset
                );


                offset += 35;


                g.DrawString(
                    "អរគុណសម្រាប់ការអញ្ជើញមកទិញទំនិញ!",
                    fontBody,
                    Brushes.Black,
                    startX + 20,
                    offset
                );
            }
        }


        // =========================================================
        // REMOVE ITEM
        // =========================================================

        private void btnRemoveItem_Click(
            object sender,
            EventArgs e)
        {
            if (
                dgvCart.SelectedRows.Count ==
                0
            )
            {
                MessageBox.Show(
                    "សូមជ្រើសរើសទំនិញដែលចង់លុប!",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }


            SaleDetail selectedItem =
                dgvCart.SelectedRows[0]
                .DataBoundItem
                as SaleDetail;


            if (selectedItem != null)
            {
                cartList.Remove(
                    selectedItem
                );

                CalculateTotal();
            }
        }


        // =========================================================
        // CLEAR CART
        // =========================================================

        private void btnClearCart_Click(
            object sender,
            EventArgs e)
        {
            if (cartList.Count == 0)
                return;


            DialogResult result =
                MessageBox.Show(
                    "តើអ្នកចង់លុបទំនិញទាំងអស់ចេញពីកន្ត្រកមែនទេ?",
                    "Confirm",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );


            if (
                result ==
                DialogResult.Yes
            )
            {
                cartList.Clear();

                CalculateTotal();
            }
        }


        // =========================================================
        // SEARCH PRODUCT
        // =========================================================

        private void txtSearchProduct_TextChanged(
            object sender,
            EventArgs e)
        {
            int categoryId =
                GetSelectedCategoryId();


            LoadProducts(
                txtSearchProduct.Text.Trim(),
                categoryId
            );
        }


        // =========================================================
        // CATEGORY CHANGED
        // =========================================================

        private void cmbCategory_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            if (
                cmbCategory.SelectedValue ==
                null
            )
            {
                return;
            }


            int categoryId =
                GetSelectedCategoryId();


            LoadProducts(
                txtSearchProduct.Text.Trim(),
                categoryId
            );
        }


        // =========================================================
        // GET CATEGORY ID
        // =========================================================

        private int GetSelectedCategoryId()
        {
            if (
                cmbCategory.SelectedValue ==
                null
            )
            {
                return 0;
            }


            int categoryId;


            if (
                int.TryParse(
                    cmbCategory
                        .SelectedValue
                        .ToString(),
                    out categoryId
                )
            )
            {
                return categoryId;
            }


            return 0;
        }


        // =========================================================
        // SET CURRENT USER ID
        // =========================================================

        public void SetCurrentUserId(
            int userId)
        {
            currentUserId =
                userId;
        }
    }
}