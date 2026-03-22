create trigger trg_AfterUpdateEmployee
on employees
after update
as
begin
declare @salary int
select @salary=salary from inserted
if @salary<=0
rollback
print 'transaction aborted'
print 'reason: salary is -ve'
end
update Employees set salary=-1000 
where EmployeeId=101
select * from Employees
select * from inserted