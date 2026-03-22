--create view
create view vw_CustomerWithBalance
as
select c.FirstName,a.Balance from Customers c join Accounts a
on c.CustomerId=a.CustomerId 
Go
select * from vw_CustomerWithBalance
select * from vw_CustomerWithBalance 
order by FirstName
select * from vw_CustomerWithBalance 
where Balance>30000