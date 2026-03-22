create procedure 
Money_withdraw(@amt int,@accId int)
as
begin
begin try
begin transaction
update Accounts set 
balance=balance-@amt where AccountID=@accId
declare @balance int
select @balance=balance from 
Accounts where AccountID=@accId
if @balance<5000
rollback
else
commit
end try
begin catch
select 'Error Occured'
end catch
end