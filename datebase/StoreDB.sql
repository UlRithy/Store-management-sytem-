-- ១. បង្កើត និងប្រើប្រាស់ Database
CREATE DATABASE StoreManagement;
GO

USE StoreManagement;
GO

-- =============================================
-- 2. tbCategory
-- =============================================
CREATE TABLE [dbo].[tbCategory](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [varchar](255) NULL,
	[Description] [varchar](255) NULL,
	 
	CONSTRAINT [PK_tbCategory] PRIMARY KEY ([CategoryID])
) ON [PRIMARY];
GO

-- =============================================
-- 3. tbCustomers
-- =============================================
CREATE TABLE [dbo].[tbCustomers](
    [CustomerID] [int] IDENTITY(1,1) NOT NULL,
    [CustomerName] [varchar](255) NULL,
    [ContactName] [varchar](255) NULL,
    [Phone] [varchar](50) NULL,         
    [Email] [varchar](255) NULL,        
    [Address] [varchar](255) NULL,
    [City] [varchar](255) NULL,
    [PostalCode] [varchar](255) NULL,
    [Country] [varchar](255) NULL,

    CONSTRAINT [PK_tbCustomers] PRIMARY KEY CLUSTERED ([CustomerID] ASC)
) ON [PRIMARY];
GO

-- =============================================
-- 4. tbEmployees
-- =============================================
CREATE TABLE [dbo].[tbEmployees](
	[EmployeeID] [int] IDENTITY(1,1) NOT NULL,
	[LastName] [varchar](255) NULL,
	[FirstName] [varchar](255) NULL,
	[BirthDate] [date] NULL,
	[Photo] [varchar](255) NULL,
	[Notes] [text] NULL,

	CONSTRAINT [PK_tbEmployees] PRIMARY KEY ([EmployeeID])
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY];
GO

-- =============================================
-- 5. tbShippers
-- =============================================
CREATE TABLE [dbo].[tbShippers](
	[ShipperID] [int] IDENTITY(1,1) NOT NULL,
	[ShipperName] [varchar](255) NULL,
	[Phone] [varchar](255) NULL,

	CONSTRAINT [PK_tbShippers] PRIMARY KEY ([ShipperID])
) ON [PRIMARY];
GO

-- =============================================
-- 6. tbSuppliers
-- =============================================
CREATE TABLE [dbo].[tbSuppliers](
	[SupplierID] [int] IDENTITY(1,1) NOT NULL,
	[SupplierName] [varchar](255) NULL,
	[ContactName] [varchar](255) NULL,
	[Address] [varchar](255) NULL,
	[City] [varchar](255) NULL,
	[PostalCode] [varchar](255) NULL,
	[Country] [varchar](255) NULL,
	[Phone] [varchar](255) NULL,

	CONSTRAINT [PK_tbSuppliers] PRIMARY KEY ([SupplierID])
) ON [PRIMARY];
GO

-- =============================================
-- 7. tbUsers (បានបន្ថែម Column Role និង FullName ស្របតាមកូដ C# របស់អ្នក)
-- =============================================
CREATE TABLE [dbo].[tbUsers](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeID] [int] NULL,
	[FirstName] [varchar](20) NULL,
	[LastName] [varchar](20) NULL,
	[Username] [varchar](40) NOT NULL,
	[Password] [varchar](20) NOT NULL,
	[Position] [varchar](20) NULL,
	[Role] [varchar](50) NULL,         -- បន្ថែមသຳหรับ Admin/User
	[FullName] [varchar](100) NULL,     -- បន្ថែមសម្រាប់បង្ហាញឈ្មោះពេញ

	CONSTRAINT [PK_tbUsers] PRIMARY KEY ([UserID]),
	CONSTRAINT [FK_tbUsers_tbEmployees]
		FOREIGN KEY ([EmployeeID])
		REFERENCES [dbo].[tbEmployees] ([EmployeeID])
) ON [PRIMARY];
GO

-- =============================================
-- 8. tbProducts
-- =============================================
CREATE TABLE [dbo].[tbProducts]( 
	[ProductID] [int] IDENTITY(1,1) NOT NULL, 
	[ProductName] [varchar](255) NULL, 
	[SupplierID] [int] NULL, 
	[CategoryID] [int] NULL, 
	[Unit] [varchar](50) NULL, 
	[Price] [decimal](18,2) NULL,
	[CostPrice] [decimal](18,2) NOT NULL DEFAULT 0.00,
	[StockQty] [int] NOT NULL DEFAULT 0,
	[Barcode] [varchar](50) NULL UNIQUE,
	[Description] [varchar](255) NULL,
	[Image] [varchar](255) NULL,
	[ImagePath] [varchar](500) NULL,

	CONSTRAINT [PK_tbProducts] PRIMARY KEY ([ProductID]), 

	CONSTRAINT [FK_tbProducts_tbSuppliers] 
		FOREIGN KEY ([SupplierID]) 
		REFERENCES [dbo].[tbSuppliers] ([SupplierID]), 

	CONSTRAINT [FK_tbProducts_tbCategory] 
		FOREIGN KEY ([CategoryID]) 
		REFERENCES [dbo].[tbCategory] ([CategoryID]) 
) ON [PRIMARY];
GO

-- =============================================
-- 9. tbStock
-- =============================================
CREATE TABLE tbStock (
    StockId INT IDENTITY(1,1) PRIMARY KEY,
    ProductId INT FOREIGN KEY REFERENCES tbProducts(ProductId) ON DELETE CASCADE,
    Quantity INT NOT NULL DEFAULT 0,
    MinStockLevel INT NOT NULL DEFAULT 5,
    Status NVARCHAR(50) DEFAULT 'In Stock', 
    LastUpdated DATETIME DEFAULT GETDATE()
);
GO

-- Trigger សម្រាប់ Update Stock
CREATE TRIGGER trg_UpdateProductStock
ON tbStock
AFTER INSERT
AS
BEGIN
    UPDATE p
    SET p.StockQty = p.StockQty + i.Quantity
    FROM tbProducts p
    INNER JOIN inserted i ON p.ProductID = i.ProductId;
END;
GO

-- View Stock Details
CREATE VIEW vwStockDetails AS
SELECT 
    s.StockId,
    p.ProductId,
    p.ProductName,
    ISNULL(c.CategoryName, N'N/A') AS CategoryName,
    s.Quantity,
    s.MinStockLevel,
    s.Status,
    s.LastUpdated
FROM tbStock s
INNER JOIN tbProducts p ON s.ProductId = p.ProductId
LEFT JOIN tbCategory c ON p.CategoryId = c.CategoryId;
GO

-- =============================================
-- 10. tbOrders & tbOrderDetails
-- =============================================
CREATE TABLE [dbo].[tbOrders](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NULL,
	[EmployeeID] [int] NULL,
	[OrderDate] [date] NULL,
	[ShipperID] [int] NULL,

	CONSTRAINT [PK_tbOrders] PRIMARY KEY ([OrderID]),
	CONSTRAINT [FK_tbOrders_tbCustomers] FOREIGN KEY ([CustomerID]) REFERENCES [dbo].[tbCustomers] ([CustomerID]),
	CONSTRAINT [FK_tbOrders_tbEmployees] FOREIGN KEY ([EmployeeID]) REFERENCES [dbo].[tbEmployees] ([EmployeeID]),
	CONSTRAINT [FK_tbOrders_tbShippers] FOREIGN KEY ([ShipperID]) REFERENCES [dbo].[tbShippers] ([ShipperID])
) ON [PRIMARY];
GO

CREATE TABLE [dbo].[tbOrderDetails](
	[OrderDetailID] [int] IDENTITY(1,1) NOT NULL,
	[OrderID] [int] NULL,
	[ProductID] [int] NULL,
	[Quantity] [int] NULL,

	CONSTRAINT [PK_tbOrderDetails] PRIMARY KEY ([OrderDetailID]),
	CONSTRAINT [FK_tbOrderDetails_tbOrders] FOREIGN KEY ([OrderID]) REFERENCES [dbo].[tbOrders] ([OrderID]),
	CONSTRAINT [FK_tbOrderDetails_tbProducts] FOREIGN KEY ([ProductID]) REFERENCES [dbo].[tbProducts] ([ProductID])
) ON [PRIMARY];
GO

-- =============================================
-- 11. tbSales & tbSaleDetails
-- =============================================
CREATE TABLE [dbo].[tbSales](
	[SaleID] [int] IDENTITY(1,1) NOT NULL,
	[InvoiceNo] [varchar](50) NULL,
	[SaleDate] [datetime] NULL,
	[CustomerID] [int] NULL,
	[UserID] [int] NULL,
	[TotalAmount] [decimal](18,2) NULL,
	[PaymentMethod] [varchar](50) NULL,

	CONSTRAINT [PK_tbSales] PRIMARY KEY ([SaleID])
) ON [PRIMARY];
GO

CREATE TABLE [dbo].[tbSaleDetails](
	[SaleDetailID] [int] IDENTITY(1,1) NOT NULL,
	[SaleID] [int] NULL,
	[ProductID] [int] NULL,
	[Quantity] [int] NULL,
	[Price] [decimal](18,2) NULL,

	CONSTRAINT [PK_tbSaleDetails] PRIMARY KEY ([SaleDetailID]),
	CONSTRAINT [FK_tbSaleDetails_tbSales] FOREIGN KEY ([SaleID]) REFERENCES [dbo].[tbSales] ([SaleID]) ON DELETE CASCADE,
	CONSTRAINT [FK_tbSaleDetails_tbProducts] FOREIGN KEY ([ProductID]) REFERENCES [dbo].[tbProducts] ([ProductID])
) ON [PRIMARY];
GO

-- =============================================
-- 12. បញ្ចូលទិន្នន័យគំរូដំបូង (Sample Data)
-- =============================================
INSERT INTO tbCategory (CategoryName, Description) VALUES 
('Beverages', 'Soft drinks, coffees, teas'),
('Snacks', 'Chips, biscuits, and sweets'),
('Electronics', 'Electronic devices and accessories');
GO

INSERT INTO tbSuppliers (SupplierName, ContactName, Phone) VALUES 
('Coca-Cola Supplier', 'Vichea', '012345678');
GO

INSERT INTO tbProducts (ProductName, SupplierID, CategoryID, Unit, Price, CostPrice, StockQty, Barcode, Description) VALUES 
('Coca Cola Can', 1, 1, 'Can', 0.50, 0.35, 100, '8851011123456', 'Fresh cold soft drink'),
('Snack Potato', 1, 2, 'Pack', 1.50, 1.00, 50, '8852022234567', 'Crispy potato snack');
GO

-- បញ្ចូលគណនី Admin សម្រាប់ Login
INSERT INTO tbUsers (Username, Password, Role, FullName, Position)
VALUES ('admin', '123456', 'Admin', 'System Administrator', 'Manager');
GO
-- លុបចោលទិន្នន័យស្ទួន (បើមាន)
--WITH CTE AS (
   -- SELECT SupplierID,
 --          ROW_NUMBER() OVER (PARTITION BY SupplierName ORDER BY SupplierID) as row_num
 --   FROM tbSuppliers
--)DELETE FROM CTE WHERE row_num > 1;
--GO

SELECT * FROM tbProducts;
SELECT * FROM tbCategory;
SELECT * FROM tbOrders;
SELECT * FROM tbSuppliers;
SELECT * FROM tbStock;
SELECT * FROM tbCustomers

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