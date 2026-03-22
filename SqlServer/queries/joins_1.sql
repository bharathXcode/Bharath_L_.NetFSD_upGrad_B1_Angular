use NewPracticeDb
CREATE TABLE Customers (
CustomerID INT PRIMARY KEY,
CustomerName VARCHAR(50),
City VARCHAR(50)
);
CREATE TABLE Orders (
OrderID INT PRIMARY KEY,
CustomerID INT,
OrderAmount DECIMAL(10,2),
FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
);
insert into Customers(CustomerID,CustomerName,City) 
values(1,'Ravi','Hyderabad'),
(2,'Priya','Mumbai'),
(3,'Amit','Delhi')
insert into Orders(OrderID,CustomerID,OrderAmount)
values(101,1,5000),
(102,1,7000),
(103,2,3000),
(104,3,9000)
--inner join
select c.customerName,o.orderAmount from Customers c inner join
Orders o on c.CustomerID=o.CustomerID
select c.customerName,o.orderAmount from Customers c inner join
Orders o on c.CustomerID=o.CustomerID where o.OrderAmount>5000
select c.customerName,o.orderAmount from Customers c inner join
Orders o on c.CustomerID=o.CustomerID 
where o.OrderAmount>5000 
order by c.CustomerName
insert into Customers(CustomerID,CustomerName,City) 
values(4,'Uday','Hyderabad')
--left join
select c.customerName,o.orderAmount from customers c 
left join Orders o
on c.CustomerID=o.CustomerID
insert into Orders(OrderID,CustomerID,OrderAmount)
values(105,null,5000)
--right join
select c.customerName,o.orderAmount from customers c 
right join Orders o
on c.CustomerID=o.CustomerID
--full join
select c.customerName,o.orderAmount from customers c 
full join Orders o
on c.CustomerID=o.CustomerID

CREATE TABLE Employees (
EmployeeID INT PRIMARY KEY,
EmployeeName VARCHAR(50),
ManagerID INT
);
insert into Employees(EmployeeId,EmployeeName,ManagerID)
values(1,'Raj',null),
(2,'Neha',1),
(3,'Arjen',1),
(4,'Meena',2)
select * from Employees
--self join
--show employees with thire manager names
select e.EmployeeName as Employee,m.employeeName as Manager
from Employees e join Employees m
on e.ManagerID=m.employeeId