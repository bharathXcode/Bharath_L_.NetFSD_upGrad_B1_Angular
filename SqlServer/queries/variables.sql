declare @a int
declare @b int
declare @sum int
set @a=10
set @b=20
set @sum=@a+@b
select @a=34,@b=35 --assign multiple variable values
select @sum as Sum
declare @city varchar(20)
set @city='Hyderabad'
select * from Customers where city=@city
declare @totalCustomers int
select @totalCustomers=count(*) from Customers
select @totalCustomers