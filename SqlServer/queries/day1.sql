--create database
create database NewPracticeDb
--select database
use NewPracticeDb
--create tables
CREATE TABLE Product (
ProductID INT PRIMARY KEY IDENTITY(1,1),
[Name] NVARCHAR(20) NOT NULL,
Price DECIMAL(10,2) NOT NULL,
Stock INT CHECK (Stock >= 0)
);
CREATE TABLE Customer (
CustomerID INT PRIMARY KEY IDENTITY(1,1),
Name NVARCHAR(100),
Email NVARCHAR(100) UNIQUE
);
CREATE TABLE Orders (
OrderID INT PRIMARY KEY IDENTITY(1,1),
CustomerID INT,
OrderDate DATETIME2 DEFAULT SYSDATETIME(),
FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID)
);