-- =========================================================
-- DATABASE CREATION
-- =========================================================
-- Create main database used for all assignments
CREATE DATABASE AdoDB;
GO

-- Switch to the created database
USE AdoDB;

------------------------------------------------------------------------------------------------
-- =========================================================
-- ASSIGNMENT 1: STUDENT MANAGEMENT SYSTEM (BASIC CRUD)
-- =========================================================

-- Create Students table
CREATE TABLE Students (
 Id INT PRIMARY KEY IDENTITY,        -- Auto-increment student ID
 Name NVARCHAR(100),                 -- Student Name
 Age INT,                            -- Student Age
 Grade NVARCHAR(10)                  -- Student Grade
);

-- View all student records
SELECT * FROM Students;

------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------
-- =========================================================
-- ASSIGNMENT 2: EMPLOYEE MANAGEMENT (STORED PROCEDURES)
-- =========================================================

-- Create Employees table
CREATE TABLE Employees (
    EmpId INT IDENTITY(1,1) PRIMARY KEY,  -- Auto-increment employee ID
    Name NVARCHAR(100),                   -- Employee Name
    Salary DECIMAL(10,2),                 -- Employee Salary
    Department NVARCHAR(50)               -- Department Name
);
GO

-- ---------------------------------------------------------
-- STORED PROCEDURE: INSERT EMPLOYEE
-- ---------------------------------------------------------
CREATE OR ALTER PROCEDURE InsertEmployee
    @Name NVARCHAR(100),
    @Salary DECIMAL(10,2),
    @Department NVARCHAR(50)
AS
BEGIN
    INSERT INTO dbo.Employees (Name, Salary, Department)
    VALUES (@Name, @Salary, @Department)
END;
GO

-- ---------------------------------------------------------
-- STORED PROCEDURE: FETCH EMPLOYEES BY DEPARTMENT
-- ---------------------------------------------------------
CREATE OR ALTER PROCEDURE GetEmployeesByDepartment
    @Department NVARCHAR(50)
AS
BEGIN
    SELECT * FROM dbo.Employees WHERE Department = @Department
END;
GO

-- ---------------------------------------------------------
-- STORED PROCEDURE: UPDATE EMPLOYEE SALARY
-- ---------------------------------------------------------
CREATE OR ALTER PROCEDURE UpdateSalary
    @EmpId INT,
    @Salary DECIMAL(10,2)
AS
BEGIN
    UPDATE dbo.Employees 
    SET Salary = @Salary 
    WHERE EmpId = @EmpId
END;
GO

-- View all employee records
SELECT * FROM Employees;

-------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------
-- =========================================================
-- ASSIGNMENT 3: PRODUCT INVENTORY SYSTEM (DISCONNECTED MODEL)
-- =========================================================

-- Create Products table
CREATE TABLE Products (
    ProductId INT PRIMARY KEY IDENTITY,   -- Auto-increment product ID
    ProductName NVARCHAR(100),            -- Product Name
    Price DECIMAL(10,2),                  -- Product Price
    Stock INT                             -- Available Stock
);
GO

-- Insert sample data for testing
INSERT INTO Products (ProductName, Price, Stock) VALUES
('Pen', 20, 100),
('Notebook', 50, 200),
('Mouse', 500, 50);
GO

-- View all products
SELECT * FROM Products;

---------------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------
-- =========================================================
-- ASSIGNMENT 4: ORDER MANAGEMENT SYSTEM (TRANSACTIONS)
-- =========================================================

-- Create Orders table
CREATE TABLE Orders (
    OrderId INT PRIMARY KEY IDENTITY,     -- Auto-increment Order ID
    CustomerName NVARCHAR(100),           -- Customer Name
    TotalAmount DECIMAL(10,2)             -- Total Order Amount
);
GO

-- Create OrderItems table (Child table)
CREATE TABLE OrderItems (
    ItemId INT PRIMARY KEY IDENTITY,      -- Auto-increment Item ID
    OrderId INT,                          -- Foreign Key (linked to Orders)
    ProductName NVARCHAR(100),            -- Product Name
    Quantity INT,                         -- Quantity ordered
    FOREIGN KEY (OrderId) REFERENCES Orders(OrderId)  -- FK Constraint
);
GO

-- View order data
SELECT * FROM Orders;
SELECT * FROM OrderItems;

--------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------
-- =========================================================
-- ASSIGNMENT 5: LIBRARY MANAGEMENT SYSTEM (MINI PROJECT)
-- =========================================================

-- Create Books table
CREATE TABLE Books (
    BookId INT PRIMARY KEY IDENTITY,      -- Auto-increment Book ID
    Title NVARCHAR(200),                  -- Book Title
    Author NVARCHAR(100),                 -- Author Name
    Price DECIMAL(10,2)                   -- Book Price
);
GO

-- Insert sample books
INSERT INTO Books (Title, Author, Price) VALUES
('Java Basics', 'James', 500),
('C# Fundamentals', 'Microsoft', 600),
('Spring Boot Guide', 'Pivotal', 700);
GO

-- View all books
SELECT * FROM Books;