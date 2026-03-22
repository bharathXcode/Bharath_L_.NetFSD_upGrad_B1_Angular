create procedure sp_getcustomres
as
begin
select * from Customers
end
--execute procedure
exec sp_getcustomres
exec sp_getcustomres