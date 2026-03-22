--sub queries
select FirstName from Customers
where CustomerId in(select CustomerId from Accounts)
SELECT AccountID, Balance
FROM Accounts
WHERE Balance >=
(SELECT AVG(Balance) FROM Accounts);
Select c.FirstName,a.accountId,a.Balance from Customers c join Accounts a
on c.CustomerId=a.CustomerId where a.Balance>=(SELECT AVG(Balance) FROM Accounts);
select Max(balance) from Accounts
select * from Customers where CustomerId=
(select CustomerId from Accounts where balance=(select Max(balance) from Accounts))
select * from Accounts where Balance=(select max(balance) from Accounts)
--customers who is having loans
select * from Customers where CustomerId in (select customerId from loans)
--find the accounts with balance grater than any loan account
select * from Accounts where balance>Any(select LoanAmount from Loans)
--find the accounts with balance grater than all loan account
select * from Accounts where balance>All(select LoanAmount from Loans)
select * from Accounts where Balance>(select Max(loanAmount) from Loans)
--customers having atlease one account
select * from Customers c where 
exists(select 1 from Accounts a where a.CustomerId=c.CustomerId)
--customers not having account
select * from Customers c where 
not exists(select 1 from Accounts a where a.CustomerId=c.CustomerId)

--show customer balance
select c.customerId,c.firstname,a.Balance from Customers c join Accounts a
on c.CustomerId=a.CustomerId
--show customer with total balance
select c.customerId,c.firstname,(select sum(a.balance) from Accounts a
where a.CustomerId=c.CustomerId) as Totalbalance from Customers c
--show total balance of customers at least having 1 account
select c.firstname,sum(a.balance) as TotalBalance
from Customers c join Accounts a
on c.CustomerId=a.CustomerId
group by c.firstname
select c.customerId,c.firstname,(select sum(a.balance) from Accounts a
where a.CustomerId=c.CustomerId) as Totalbalance from Customers c where
exists(select 1 from Accounts a where a.CustomerId=c.CustomerId)
