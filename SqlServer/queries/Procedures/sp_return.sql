create procedure GetCount
as
begin
declare @count int
select @count=COUNT(*) from Employees
return @count
end
declare @result int
exec @result=GetCount
print @result
--return can only return number type