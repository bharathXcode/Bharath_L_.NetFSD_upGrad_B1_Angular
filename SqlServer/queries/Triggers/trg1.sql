create trigger trg_AfterInsertEmployee
on Employees
after insert
as
begin
print 'New Employee Added'
end
--adding new row
insert into Employees 
values('Varun','Hr',50000)
insert into Employees 
values('Jeevan','Admin',40000)