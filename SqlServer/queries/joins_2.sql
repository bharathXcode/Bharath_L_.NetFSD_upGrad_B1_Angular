use bankDb
--Get Customers with their Accounts
select c.FirstName,a.AccountNumber,a.Balance
from Customers c inner join
Accounts a on c.CustomerId=a.CustomerId
select * from Customers
--show transaction details with account number
select a.AccountNumber,t.TransactionType,t.amount
from Accounts a join Transactions t
on a.AccountId=t.AccountId
--group with innter join
--Get transaction count of an account
select a.accountNumber,count(t.transactionId) as TransactionCount
from Accounts a join Transactions t
on a.AccountId=t.AccountId
group by a.accountNumber
--show customers with and without having records
--left join
select c.FirstName,a.AccountNumber,a.Balance
from Customers c left join
Accounts a on c.CustomerId=a.CustomerId
select * from Customers
select c.*
from Customers c
left join
Accounts a
on c.CustomerId=a.CustomerId
where a.AccountId is null
--right
select c.FirstName,a.AccountNumber,a.Balance
from Customers c right join
Accounts a on c.CustomerId=a.CustomerId
select * from Customers
--full join
select c.FirstName,l.loanAmount
from Customers c full join Loans l
on c.CustomerId=l.CustomerId
--cross join
--custromre use possible branches
select c.firstName,b.branchName
from Customers c 
cross join Branches b
select * from Customers
--self join
-- Customres in same city
select c1.firstname as customer1,c2.firstname as customer2, c1.city
from Customers c1 join Customers c2
on c1.city=c2.city
and c1.CustomerId<>c2.CustomerId
--Compare accounts with same branch
select a1.accountNumber as account1,
a2.accountNumber as account2, a1.branchId
from Accounts a1 join Accounts a2
on a1.BranchId=a2.BranchId
and a1.AccountId<>a2.AccountId
--get customer account and branch details
--join 3 tables
select
c.firstName,
a.accountNumber,
b.branchName
from Customers c join Accounts a
on c.CustomerId=a.CustomerId
join Branches b
on a.BranchId=b.BranchId
--join 4 tables
select
c.firstName,
a.accountNumber,
b.branchName,
t.TransactionType,
t.amount
from Customers c join Accounts a
on c.CustomerId=a.CustomerId
join Branches b
on a.BranchId=b.BranchId
join Transactions t
on a.AccountId=t.AccountId