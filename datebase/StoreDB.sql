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
    [FullName]   NVARCHAR (255) NOT NULL,
    [Gender]     VARCHAR (50)  NULL,
    [Phone]      VARCHAR (50)  NULL,
    [Position]   NVARCHAR (100) NULL,
    [Salary]     DECIMAL (18, 2) DEFAULT ((0)) NULL,
    [HireDate]   DATE          NULL,
    [Username]   VARCHAR (100) NULL,
    [Address]    NVARCHAR (255) NULL,
    [Email]      VARCHAR (255) NULL,
    CONSTRAINT [PK_tbEmployees] PRIMARY KEY CLUSTERED ([EmployeeID] ASC)
);
GO
CREATE VIEW vwEmployeeDetails AS
SELECT 
    e.EmployeeID AS Id,
    e.FullName,
    e.Gender,
    e.Phone,
    e.Position,
    e.Salary,
    e.HireDate,
    e.Username,
    e.Email,
    e.Address,
    ISNULL(u.Role, 'Staff') AS SystemRole 
FROM tbEmployees e
LEFT JOIN tbUsers u ON e.EmployeeID = u.EmployeeID;
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
-- 7. tbUsers (ភ្ជាប់ជាមួយ tbEmployees)
-- =============================================
CREATE TABLE [dbo].[tbUsers] (
    [UserID] INT IDENTITY (1, 1) NOT NULL,
    [EmployeeID] INT NULL,
    [Username] VARCHAR (40) NOT NULL,
    [Password] VARCHAR (20) NOT NULL,
    [Position] VARCHAR (20) NULL,
    [Role] VARCHAR (50) NULL, 
    [FullName] VARCHAR (100) NULL,
    [IsActive] BIT DEFAULT 1 NOT NULL,
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
       END;
GO

-- View Stock Details
CREATE VIEW vwStockDetails AS
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
INSERT INTO tbCategory (CategoryName, Description) 
VALUES ('Beverages', 'Soft drinks, coffees, teas'),
       ('Snacks', 'Chips, biscuits, and sweets'),
       ('Electronics', 'Electronic devices and accessories');
GO

INSERT INTO tbSuppliers (SupplierName, ContactName, Phone) 
VALUES ('Coca-Cola Supplier', 'Vichea', '012345678');
GO

INSERT INTO tbProducts (ProductName, SupplierID, CategoryID, Unit, Price, CostPrice, StockQty, Barcode, Description) 
VALUES ('Coca Cola Can', 1, 1, 'Can', 0.50, 0.35, 100, '8851011123456', 'Fresh cold soft drink'),
       ('Snack Potato', 1, 2, 'Pack', 1.50, 1.00, 50, '8852022234567', 'Crispy potato snack');
GO

-- បញ្ចូលទិន្នន័យបុគ្គលិក
INSERT INTO tbEmployees (FullName, Gender, Phone, Email, Address, Position, Salary, HireDate, Username) 
VALUES (N'Ul Rithy', 'Male', '0967584633', 'rithy.sok@storems.com', N'រាជធានីភ្នំពេញ', 'Store Manager', 850.00, '2025-01-15', 'rithy'),
       (N'Leang Lina', 'Female', '098765432', 'lina@storems.com', N'ខេត្តសៀមរាប', 'Cashier', 450.00, '2025-03-10', 'lina'),
       (N'Phat soton', 'Female', '011223344', 'soton@storems.com', N'ខេត្តបាត់ដំបង', 'Stock Keeper', 500.00, '2025-06-20', 'soton');
GO

-- បញ្ចូលគណនី Login (tbUsers)
INSERT INTO tbUsers (EmployeeID, Username, Password, Role, FullName, Position, IsActive) 
VALUES (1, 'rithy', '123456', 'Admin', N'Ul Rithy', 'Store Manager', 1),
       (2, 'lina', '123456', 'Cashier', N'Leang Lina', 'Cashier', 1),
       (3, 'soton', '123456', 'Staff', N'Phat soton', 'Stock Keeper', 1);
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

SELECT * FROM tbusers

SELECT *
FROM   tbSuppliers;

SELECT *
FROM   tbStock;

SELECT *
FROM   tbCustomers;

SELECT * FROM tbSaleS;
SELECT * FROM tbSaleDetails;
SELECT * FROM tbEmployees
--DELETE FROM tbSales;
DELETE  FROM tbusers
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
--DROP TABLE IF EXISTS [dbo].[tbEmployees];  
--DROP TABLE IF EXISTS [dbo].[tbCategory];
--DROP TABLE IF EXISTS [dbo].[tbUsers];
--DROP TABLE IF EXISTS [dbo].[tbCustomers];
--GO
--ALTER TABLE tbCustomers
--DROP COLUMN ContactName;
--GO