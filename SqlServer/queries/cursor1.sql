select * from Employees
--cursor demo
declare @empId int
declare @salary int
declare @dept varchar(10)
declare emp_cursor cursor
for
select EmployeeId,Salary,Department 
from Employees
open emp_cursor
fetch next from emp_cursor 
into @empId,@salary,@dept
while @@FETCH_STATUS=0
begin
if @dept='Hr'
begin
update Employees
set Salary=@salary+@salary*0.1 where EmployeeId=@empId
end
else if @dept='Admin'
begin
update Employees set Salary=@salary+@salary*0.08 where EmployeeId=@empId
end
else if @dept='Loans'
begin
update Employees
set Salary=@salary+@salary*0.12
where EmployeeId=@empId
end
fetch next from emp_cursor into @empId,@salary,@dept
end
close emp_cursor
deallocate emp_cursor
