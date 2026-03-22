--modify the data
--update and delete
select * from Accounts
select * from Loans
update Accounts set Balance=15000 where AccountNumber='Acc10001'
update Accounts set BranchId=1003,AccountType='Savings'where AccountNumber='Acc10005'
update Loans set Status='Closed' where LoanId=3
--Delete rows
delete from Loans where Status='closed' and StartDate between '1.1.2022' and '12.31.2022'