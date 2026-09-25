-- ១. បង្កើត និងប្រើប្រាស់ Database
CREATE DATABASE StoreManagement;


GO
USE StoreManagement;


GO
-- =============================================
-- 2. tbCategory
-- =============================================
CREATE TABLE [dbo].[tbCategory] (
    [CategoryID] INT IDENTITY (1, 1) NOT NULL,
    [CategoryName] VARCHAR (255) NULL,
    [Description] VARCHAR (255) NULL,
    CONSTRAINT [PK_tbCategory] PRIMARY KEY ([CategoryID])
) ON [PRIMARY];


GO
-- =============================================
-- 3. tbCustomers
-- =============================================
CREATE TABLE [dbo].[tbCustomers] (
    [CustomerID] INT IDENTITY (1, 1) NOT NULL,
    [CustomerName] VARCHAR (255) NULL,
    [ContactName] VARCHAR (255) NULL,
    [Phone] VARCHAR (50) NULL,
    [Email] VARCHAR (255) NULL,
    [Address] VARCHAR (255) NULL,
    [City] VARCHAR (255) NULL,
    [PostalCode] VARCHAR (255) NULL,
    [Country] VARCHAR (255) NULL,
    CONSTRAINT [PK_tbCustomers] PRIMARY KEY CLUSTERED ([CustomerID] ASC)
) ON [PRIMARY];


GO
-- =============================================
-- 4. tbEmployees
-- =============================================
CREATE TABLE [dbo].[tbEmployees] (
    [EmployeeID] INT IDENTITY (1, 1) NOT NULL,
    [LastName] VARCHAR (255) NULL,
    [FirstName] VARCHAR (255) NULL,
    [BirthDate] DATE NULL,
    [Photo] VARCHAR (255) NULL,
    [Notes] TEXT NULL,
    CONSTRAINT [PK_tbEmployees] PRIMARY KEY ([EmployeeID])
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY];


GO
-- =============================================
-- 5. tbShippers
-- =============================================
CREATE TABLE [dbo].[tbShippers] (
    [ShipperID] INT IDENTITY (1, 1) NOT NULL,
    [ShipperName] VARCHAR (255) NULL,
    [Phone] VARCHAR (255) NULL,
    CONSTRAINT [PK_tbShippers] PRIMARY KEY ([ShipperID])
) ON [PRIMARY];


GO
-- =============================================
-- 6. tbSuppliers
-- =============================================
CREATE TABLE [dbo].[tbSuppliers] (
    [SupplierID] INT IDENTITY (1, 1) NOT NULL,
    [SupplierName] VARCHAR (255) NULL,
    [ContactName] VARCHAR (255) NULL,
    [Address] VARCHAR (255) NULL,
    [City] VARCHAR (255) NULL,
    [PostalCode] VARCHAR (255) NULL,
    [Country] VARCHAR (255) NULL,
    [Phone] VARCHAR (255) NULL,
    CONSTRAINT [PK_tbSuppliers] PRIMARY KEY ([SupplierID])
) ON [PRIMARY];


GO
-- =============================================
-- 7. tbUsers (បានបន្ថែម Column Role និង FullName ស្របតាមកូដ C# របស់អ្នក)
-- =============================================
CREATE TABLE [dbo].[tbUsers] (
    [UserID] INT IDENTITY (1, 1) NOT NULL,
    [EmployeeID] INT NULL,
    [FirstName] VARCHAR (20) NULL,
    [LastName] VARCHAR (20) NULL,
    [Username] VARCHAR (40) NOT NULL,
    [Password] VARCHAR (20) NOT NULL,
    [Position] VARCHAR (20) NULL,
    [Role] VARCHAR (50) NULL, -- បន្ថែមသຳหรับ Admin/User
    [FullName] VARCHAR (100) NULL, -- បន្ថែមសម្រាប់បង្ហាញឈ្មោះពេញ
    CONSTRAINT [PK_tbUsers] PRIMARY KEY ([UserID]),
    CONSTRAINT [FK_tbUsers_tbEmployees] FOREIGN KEY ([EmployeeID]) REFERENCES [dbo].[tbEmployees] ([EmployeeID])
) ON [PRIMARY];


GO
-- =============================================
-- 8. tbProducts
-- =============================================
CREATE TABLE [dbo].[tbProducts] (
    [ProductID] INT IDENTITY (1, 1) NOT NULL,
    [ProductName] VARCHAR (255) NULL,
    [SupplierID] INT NULL,
    [CategoryID] INT NULL,
    [Unit] VARCHAR (50) NULL,
    [Price] DECIMAL (18, 2) NULL,
    [CostPrice] DECIMAL (18, 2) DEFAULT 0.00 NOT NULL,
    [StockQty] INT DEFAULT 0 NOT NULL,
    [Barcode] VARCHAR (50) NULL UNIQUE,
    [Description] VARCHAR (255) NULL,
    [Image] VARCHAR (255) NULL,
    [ImagePath] VARCHAR (500) NULL,
    CONSTRAINT [PK_tbProducts] PRIMARY KEY ([ProductID]),
    CONSTRAINT [FK_tbProducts_tbSuppliers] FOREIGN KEY ([SupplierID]) REFERENCES [dbo].[tbSuppliers] ([SupplierID]),
    CONSTRAINT [FK_tbProducts_tbCategory] FOREIGN KEY ([CategoryID]) REFERENCES [dbo].[tbCategory] ([CategoryID])
) ON [PRIMARY];


GO
-- =============================================
-- 9. tbStock
-- =============================================
CREATE TABLE tbStock (
    StockId INT IDENTITY (1, 1) PRIMARY KEY,
    ProductId INT FOREIGN KEY REFERENCES tbProducts (ProductId) ON DELETE CASCADE,
    Quantity INT DEFAULT 0 NOT NULL,
    MinStockLevel INT DEFAULT 5 NOT NULL,
    Status NVARCHAR (50) DEFAULT 'In Stock',
    LastUpdated DATETIME DEFAULT GETDATE()
);


GO
-- Trigger សម្រាប់ Update Stock
CREATE TRIGGER trg_UpdateProductStock
    ON tbStock
    AFTER INSERT
    AS BEGIN
           UPDATE p
           SET    p.StockQty = p.StockQty + i.Quantity
           FROM   tbProducts AS p
                  INNER JOIN
                  inserted AS i
                  ON p.ProductID = i.ProductId;
       END


GO
-- View Stock Details
CREATE VIEW vwStockDetails
AS
SELECT s.StockId,
       p.ProductId,
       p.ProductName,
       ISNULL(c.CategoryName, N'N/A') AS CategoryName,
       s.Quantity,
       s.MinStockLevel,
       s.Status,
       s.LastUpdated
FROM   tbStock AS s
       INNER JOIN
       tbProducts AS p
       ON s.ProductId = p.ProductId
       LEFT OUTER JOIN
       tbCategory AS c
       ON p.CategoryId = c.CategoryId;


GO
-- =============================================
-- 10. tbOrders & tbOrderDetails
-- =============================================
CREATE TABLE [dbo].[tbOrders] (
    [OrderID] INT IDENTITY (1, 1) NOT NULL,
    [CustomerID] INT NULL,
    [EmployeeID] INT NULL,
    [OrderDate] DATE NULL,
    [ShipperID] INT NULL,
    CONSTRAINT [PK_tbOrders] PRIMARY KEY ([OrderID]),
    CONSTRAINT [FK_tbOrders_tbCustomers] FOREIGN KEY ([CustomerID]) REFERENCES [dbo].[tbCustomers] ([CustomerID]),
    CONSTRAINT [FK_tbOrders_tbEmployees] FOREIGN KEY ([EmployeeID]) REFERENCES [dbo].[tbEmployees] ([EmployeeID]),
    CONSTRAINT [FK_tbOrders_tbShippers] FOREIGN KEY ([ShipperID]) REFERENCES [dbo].[tbShippers] ([ShipperID])
) ON [PRIMARY];


GO
CREATE TABLE [dbo].[tbOrderDetails] (
    [OrderDetailID] INT IDENTITY (1, 1) NOT NULL,
    [OrderID] INT NULL,
    [ProductID] INT NULL,
    [Quantity] INT NULL,
    CONSTRAINT [PK_tbOrderDetails] PRIMARY KEY ([OrderDetailID]),
    CONSTRAINT [FK_tbOrderDetails_tbOrders] FOREIGN KEY ([OrderID]) REFERENCES [dbo].[tbOrders] ([OrderID]),
    CONSTRAINT [FK_tbOrderDetails_tbProducts] FOREIGN KEY ([ProductID]) REFERENCES [dbo].[tbProducts] ([ProductID])
) ON [PRIMARY];


GO
-- =============================================
-- 11. tbSales & tbSaleDetails
-- =============================================
CREATE TABLE [dbo].[tbSales] (
    [SaleID] INT IDENTITY (1, 1) NOT NULL,
    [InvoiceNo] VARCHAR (50) NULL,
    [SaleDate] DATETIME NULL,
    [CustomerID] INT NULL,
    [UserID] INT NULL,
    [TotalAmount] DECIMAL (18, 2) NULL,
    [PaymentMethod] VARCHAR (50) NULL,
    CONSTRAINT [PK_tbSales] PRIMARY KEY ([SaleID])
) ON [PRIMARY];


GO
CREATE TABLE [dbo].[tbSaleDetails] (
    [SaleDetailID] INT IDENTITY (1, 1) NOT NULL,
    [SaleID] INT NULL,
    [ProductID] INT NULL,
    [Quantity] INT NULL,
    [Price] DECIMAL (18, 2) NULL,
    CONSTRAINT [PK_tbSaleDetails] PRIMARY KEY ([SaleDetailID]),
    CONSTRAINT [FK_tbSaleDetails_tbSales] FOREIGN KEY ([SaleID]) REFERENCES [dbo].[tbSales] ([SaleID]) ON DELETE CASCADE,
    CONSTRAINT [FK_tbSaleDetails_tbProducts] FOREIGN KEY ([ProductID]) REFERENCES [dbo].[tbProducts] ([ProductID])
) ON [PRIMARY];


GO
-- =============================================
-- 12. បញ្ចូលទិន្នន័យគំរូដំបូង (Sample Data)
-- =============================================
INSERT  INTO tbCategory (CategoryName, Description)
VALUES                 ('Beverages', 'Soft drinks, coffees, teas'),
('Snacks', 'Chips, biscuits, and sweets'),
('Electronics', 'Electronic devices and accessories');


GO
INSERT  INTO tbSuppliers (SupplierName, ContactName, Phone)
VALUES                  ('Coca-Cola Supplier', 'Vichea', '012345678');


GO
INSERT  INTO tbProducts (ProductName, SupplierID, CategoryID, Unit, Price, CostPrice, StockQty, Barcode, Description)
VALUES                 ('Coca Cola Can', 1, 1, 'Can', 0.50, 0.35, 100, '8851011123456', 'Fresh cold soft drink'),
('Snack Potato', 1, 2, 'Pack', 1.50, 1.00, 50, '8852022234567', 'Crispy potato snack');


GO
-- បញ្ចូលគណនី Admin សម្រាប់ Login
INSERT  INTO tbUsers (Username, Password, Role, FullName, Position)
VALUES              ('admin', '123456', 'Admin', 'System Administrator', 'Manager');


GO
--INSERT INTO tbSales (InvoiceNo, TotalAmount, PaymentMethod, SaleDate, UserID) 
--VALUES (@InvoiceNo, @TotalAmount, @PaymentMethod, GETDATE(), @UserID)
-- លុបចោលទិន្នន័យស្ទួន (បើមាន)
--WITH CTE AS (
-- SELECT SupplierID,
--          ROW_NUMBER() OVER (PARTITION BY SupplierName ORDER BY SupplierID) as row_num
--   FROM tbSuppliers
--)DELETE FROM CTE WHERE row_num > 1;
--GO
SELECT *
FROM   tbProducts;

SELECT *
FROM   tbCategory;

SELECT *
FROM   tbOrders;

SELECT *
FROM   tbSuppliers;

SELECT *
FROM   tbStock;

SELECT *
FROM   tbCustomers;

SELECT * FROM tbSaleS;
SELECT * FROM tbSaleDetails;


-- បិទ និងលុប Database ចាស់ចោល
--USE master;
--GO
--ALTER DATABASE StoreManagement SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
--DROP DATABASE StoreManagement;
--GO
--DROP TABLE IF EXISTS [dbo].[tbOrderDetails];
--DROP TABLE IF EXISTS [dbo].[tbOrders];       -- តារាងនេះហើយដែលទាក់ទងនឹង tbEmployees និង tbCustomers
--DROP TABLE IF EXISTS [dbo].[tbProducts];
--DROP TABLE IF EXISTS [dbo].[tbSuppliers];
--DROP TABLE IF EXISTS [dbo].[tbShippers];
--DROP TABLE IF EXISTS [dbo].[tbEmployees];   -- ឥឡូវអាចលុបបានដោយសុវត្ថិភាព
--DROP TABLE IF EXISTS [dbo].[tbCategory];
--DROP TABLE IF EXISTS [dbo].[tbUsers];
--DROP TABLE IF EXISTS [dbo].[tbCustomers];
--GO
--ALTER TABLE tbCustomers
--DROP COLUMN ContactName;
--GO