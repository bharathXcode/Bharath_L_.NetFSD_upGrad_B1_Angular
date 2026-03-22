--restrict delete the employees
create trigger trg_AfterDeleteEmployee
on Employees
after delete
as
begin
print 'access denied'
rollback --revoke the updates
end
Delete from Employees where EmployeeId=101
select * from Employees