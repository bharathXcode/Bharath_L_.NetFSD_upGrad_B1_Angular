INSERT INTO Customers 
(FirstName, LastName, DateOfBirth, Gender, Phone, Email, City)
VALUES
('Ravi', 'Kumar', '1990-05-10', 'M', '9876543210', 'ravi@gmail.com', 'Nellore'),
('Sneha', 'Reddy', '1995-08-21', 'F', '9876543211', 'sneha@gmail.com', 'Hyderabad'),
('Arjun', 'Sharma', '1988-02-15', 'M', '9876543212', 'arjun@gmail.com', 'Chennai'),
('Priya', 'Verma', '1992-11-30', 'F', '9876543213', 'priya@gmail.com', 'Bangalore');
select * from Customers
INSERT INTO Branches (BranchName, IFSCCode, City, State)
VALUES 
('Nellore Main Branch', 'SBIN0001001', 'Nellore', 'Andhra Pradesh'),
('Hyderabad Central', 'SBIN0002002', 'Hyderabad', 'Telangana'),
('Chennai City Branch', 'SBIN0003003', 'Chennai', 'Tamil Nadu'),
('Bangalore MG Road', 'SBIN0004004', 'Bangalore', 'Karnataka');

select * from Branches
INSERT INTO Accounts
(AccountNumber, CustomerID, BranchID, AccountType, Balance)
VALUES
('ACC10001', 1, 1001, 'Savings', 5000),
('ACC10002', 2, 1002, 'Current', 15000),
('ACC10003', 3, 1003, 'Savings', 8000),
('ACC10004', 4, 1000, 'Savings', 12000),
('ACC10005', 1, 1002, 'Current', 25000);
select * from Accounts

INSERT INTO Loans
(CustomerID, BranchID, LoanAmount, LoanType, StartDate, Status)
VALUES
(1, 1001, 200000, 'Home Loan', '2023-01-01', 'Active'),
(2, 1002, 50000,  'Personal Loan', '2023-06-15', 'Active'),
(3, 1003, 300000,  'Car Loan', '2022-09-10', 'Closed');

INSERT INTO Transactions
(AccountID, TransactionType, Amount, Description)
VALUES
(10002, 'Credit', 2000, 'Salary Deposit'),
(10003, 'Debit', 1000, 'ATM Withdrawal'),
(10002, 'Credit', 5000, 'Business Income'),
(10003, 'Debit', 2000, 'Online Shopping'),
(10004, 'Credit', 3000, 'Cash Deposit'),
(10005, 'Debit', 5000, 'Bill Payment');

INSERT INTO Customers
(FirstName, LastName, DateOfBirth, Gender, Phone, Email, City)
VALUES
('Kiran', 'Rao', '1993-03-15', 'M', '9876543214', 'kiran@gmail.com', 'Hyderabad');

INSERT INTO Branches
VALUES ('Mumbai Central', 'SBIN0005005', 'Mumbai', 'Maharashtra');
