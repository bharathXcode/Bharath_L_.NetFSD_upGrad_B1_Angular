-- =============================================
-- ASSIGNMENT - 2 (5/3/26)
-- Database: AssignmentDB
-- =============================================

-- =============================================
-- QUESTION: Create a database named AssignmentDB
-- =============================================

CREATE DATABASE AssignmentDB2;
GO

-- =============================================
-- QUESTION: Use the created database
-- =============================================

USE AssignmentDB2;
GO

-- =============================================
-- QUESTION: Create customers table
-- =============================================

CREATE TABLE customers
(
customer_id INT IDENTITY(1,1) PRIMARY KEY,
first_name VARCHAR(50),
last_name VARCHAR(50),
email VARCHAR(100),
phone VARCHAR(15)
);

-- =============================================
-- QUESTION: Create stores table
-- =============================================

CREATE TABLE stores
(
store_id INT IDENTITY(1,1) PRIMARY KEY,
store_name VARCHAR(100),
city VARCHAR(50)
);

-- =============================================
-- QUESTION: Create brands table
-- =============================================

CREATE TABLE brands
(
brand_id INT IDENTITY(1,1) PRIMARY KEY,
brand_name VARCHAR(100)
);

-- =============================================
-- QUESTION: Create categories table
-- =============================================

CREATE TABLE categories
(
category_id INT IDENTITY(1,1) PRIMARY KEY,
category_name VARCHAR(100)
);

-- =============================================
-- QUESTION: Create products table
-- =============================================

CREATE TABLE products
(
product_id INT IDENTITY(1,1) PRIMARY KEY,
product_name VARCHAR(100),
brand_id INT,
category_id INT,
model_year INT,
list_price DECIMAL(10,2),

FOREIGN KEY (brand_id) REFERENCES brands(brand_id),
FOREIGN KEY (category_id) REFERENCES categories(category_id)
);

-- =============================================
-- QUESTION: Create orders table
-- =============================================

CREATE TABLE orders
(
order_id INT IDENTITY(1,1) PRIMARY KEY,
customer_id INT,
order_status INT,
order_date DATE,
store_id INT,

FOREIGN KEY (customer_id) REFERENCES customers(customer_id),
FOREIGN KEY (store_id) REFERENCES stores(store_id)
);

-- =============================================
-- QUESTION: Create order_items table
-- =============================================

CREATE TABLE order_items
(
item_id INT IDENTITY(1,1) PRIMARY KEY,
order_id INT,
product_id INT,
quantity INT,
list_price DECIMAL(10,2),
discount DECIMAL(4,2),

FOREIGN KEY (order_id) REFERENCES orders(order_id),
FOREIGN KEY (product_id) REFERENCES products(product_id)
);

-- =============================================
-- QUESTION: Create stocks table
-- =============================================

CREATE TABLE stocks
(
store_id INT,
product_id INT,
quantity INT,

PRIMARY KEY(store_id, product_id),

FOREIGN KEY (store_id) REFERENCES stores(store_id),
FOREIGN KEY (product_id) REFERENCES products(product_id)
);

-- =============================================
-- QUESTION: Insert sample data into customers
-- =============================================

INSERT INTO customers(first_name,last_name,email,phone)
VALUES
('Rahul','Sharma','[rahul@gmail.com](mailto:rahul@gmail.com)','9876543210'),
('Sneha','Reddy','[sneha@gmail.com](mailto:sneha@gmail.com)','9876543211'),
('Arjun','Kumar','[arjun@gmail.com](mailto:arjun@gmail.com)','9876543212');

-- =============================================
-- QUESTION: Insert sample stores
-- =============================================

INSERT INTO stores(store_name,city)
VALUES
('Bangalore Store','Bangalore'),
('Hyderabad Store','Hyderabad'),
('Chennai Store','Chennai');

-- =============================================
-- QUESTION: Insert sample brands
-- =============================================

INSERT INTO brands(brand_name)
VALUES
('Apple'),
('Samsung'),
('Sony'),
('Dell');

-- =============================================
-- QUESTION: Insert sample categories
-- =============================================

INSERT INTO categories(category_name)
VALUES
('Smartphones'),
('Laptops'),
('Accessories');

-- =============================================
-- QUESTION: Insert sample products
-- =============================================

INSERT INTO products(product_name,brand_id,category_id,model_year,list_price)
VALUES
('iPhone 14',1,1,2023,900),
('Galaxy S23',2,1,2023,800),
('Sony Headphones',3,3,2022,300),
('Dell XPS Laptop',4,2,2023,1200);

-- =============================================
-- QUESTION: Insert sample orders
-- =============================================

INSERT INTO orders(customer_id,order_status,order_date,store_id)
VALUES
(1,1,'2026-03-01',1),
(2,4,'2026-03-02',2),
(3,4,'2026-03-03',1);

-- =============================================
-- QUESTION: Insert sample order items
-- =============================================

INSERT INTO order_items(order_id,product_id,quantity,list_price,discount)
VALUES
(1,1,2,900,0.10),
(2,2,1,800,0.05),
(3,4,1,1200,0.15);

-- =============================================
-- QUESTION: Insert sample stocks
-- =============================================

INSERT INTO stocks(store_id,product_id,quantity)
VALUES
(1,1,50),
(1,2,40),
(2,3,30),
(3,4,20);

-- ============================================================
-- LEVEL 1 - PROBLEM 1
-- Retrieve customer first name, last name, order_id,
-- order_date and order_status
-- Show only Pending(1) and Completed(4) orders
-- Sort by order_date descending
-- ============================================================

SELECT
c.first_name,
c.last_name,
o.order_id,
o.order_date,
o.order_status
FROM customers c
INNER JOIN orders o
ON c.customer_id = o.customer_id
WHERE o.order_status = 1
OR o.order_status = 4
ORDER BY o.order_date DESC;

-- ============================================================
-- LEVEL 1 - PROBLEM 2
-- Display product_name, brand_name, category_name,
-- model_year and list_price
-- Filter products with list_price > 500
-- Sort results by list_price ascending
-- ============================================================

SELECT
p.product_name,
b.brand_name,
c.category_name,
p.model_year,
p.list_price
FROM products p
INNER JOIN brands b
ON p.brand_id = b.brand_id
INNER JOIN categories c
ON p.category_id = c.category_id
WHERE p.list_price > 500
ORDER BY p.list_price ASC;

-- ============================================================
-- LEVEL 2 - PROBLEM 1
-- Store wise total sales summary
-- Calculate total sales using
-- quantity * list_price * (1 - discount)
-- Include only completed orders
-- ============================================================

SELECT
s.store_name,
SUM(oi.quantity * oi.list_price * (1 - oi.discount)) AS total_sales
FROM stores s
INNER JOIN orders o
ON s.store_id = o.store_id
INNER JOIN order_items oi
ON o.order_id = oi.order_id
WHERE o.order_status = 4
GROUP BY s.store_name
ORDER BY total_sales DESC;

-- ============================================================
-- LEVEL 2 - PROBLEM 2
-- Display product_name, store_name,
-- available stock and total quantity sold
-- Include products even if not sold
-- ============================================================

SELECT
p.product_name,
s.store_name,
st.quantity AS available_stock,
SUM(ISNULL(oi.quantity,0)) AS total_quantity_sold
FROM stocks st
INNER JOIN products p
ON st.product_id = p.product_id
INNER JOIN stores s
ON st.store_id = s.store_id
LEFT JOIN order_items oi
ON st.product_id = oi.product_id
GROUP BY p.product_name, s.store_name, st.quantity
ORDER BY p.product_name;
