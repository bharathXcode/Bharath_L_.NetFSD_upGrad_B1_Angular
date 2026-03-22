select * from Customers
alter view vw_HydCustomers
with encryption
as
select FirstName,LastName,DateOfBirth,Gender,
Phone,Email,City from Customers where city='Hyderabad'
with check option
Go
insert into vw_HydCustomers 
values('Rohith','Sharma','1995.2.23','M'
,'9098987790',
'rohith@gmail.com','Hyderabad')
select * from vw_HydCustomers
sp_helptext vw_HydCustomers