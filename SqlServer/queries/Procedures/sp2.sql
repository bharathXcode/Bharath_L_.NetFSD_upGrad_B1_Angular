create procedure sp_getcustomresbycity
(@city varchar(20))
as
begin
select * from Customers where city=@city
end
exec sp_getcustomresbycity 'Delhi'
exec sp_getcustomresbycity 'Chennai'