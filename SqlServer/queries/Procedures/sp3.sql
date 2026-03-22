Create table Employees(
EmployeeId int primary key identity(100,1),
Name varchar(30),
Department varchar(20),
Salray int
)
insert into Employees
(Name,Department,Salray) 
values('Karan','HR',45000),
('Suren','Admin',60000)