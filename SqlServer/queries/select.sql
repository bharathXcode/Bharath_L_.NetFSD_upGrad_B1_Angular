select * from Accounts
select * from Accounts where AccountType='savings'
select accountId,AccountNumber from Accounts
select AccountNumber,Balance from Accounts where Balance>10000
select LoanId,LoanAmount from Loans where status='active'
--logical operators
select * from Accounts where AccountType='Savings' and Balance>5000
select * from Customers where city='Hyderabad' or city= 'Chennai'
select * from Customers where City <> 'Chennai'
--Between
select * from Accounts where Balance between 5000 and 20000
select * from Loans where LoanAmount between 50000 and 200000
--in
select * from Customers where city in('Hyderabad','Chennai')
select * from Accounts where BranchId in(1001,1002)
--like
select * from Customers where FirstName like 'R%' --starts with R
select * from Customers where Email like '%gamil%' --email contains gmail
--compare null
select * from Customers where Email is null
--sorting data
select * from Accounts order by Balance asc
select * from Accounts order by Balance desc
--multiple coluns
select * from Accounts order by BranchId asc, Balance desc