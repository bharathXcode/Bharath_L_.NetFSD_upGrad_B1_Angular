--Aggregate functions with Group by
--Count,Sum,Avg,Min,Max
select COUNT(*) as TotalCustomers from Customers
select * from Accounts
select CustomerId,COUNT(AccountId) as TotalAccounts from Accounts
group by CustomerId
--Sum
select Sum(Balance) as TotalBankBalance from Accounts
select sum(Amount) as TotalDeposits from Transactions where TransactionType='Credit'
select AccountId,Sum(Amount) as TotalWithDrawals from Transactions
where TransactionType='Debit'
group by AccountId
select BranchId,Sum(Balance) as TotalBalance from Accounts Group by BranchId
--Avg
select Avg(Balance) as Avgbalance from Accounts
select AccountId,Avg(Amount) as AvgTransaction from Transactions group by AccountId
--Min & Max
select Min(Balance) as MinimumBalance, Max(Balance) as MaxBalance from Accounts
--Branches with TotalBalance>20000
select BranchId,Sum(Balance) as TotalBalance from Accounts Group by BranchId
having sum(balance)>20000
--Customers with more than 1 account
select CustomerId,COUNT(*) as TotalAccounts from Accounts
group by CustomerId
select CustomerId,COUNT(*) as TotalAccounts from Accounts
group by CustomerId having Count(*)>1

select BranchId,Sum(Balance) as TotalBalance from Accounts where BranchId<>1001 Group by BranchId
having sum(balance)>20000
select * from Branches

