create view vw_Accounts
as
select AccountId,AccountNumber,CustomerId from Accounts
GO
select * from Accounts
select * from vw_Accounts
update vw_Accounts set AccountNumber='ACC1006' where AccountId=10006
select * from vw_Accounts where CustomerId=1
