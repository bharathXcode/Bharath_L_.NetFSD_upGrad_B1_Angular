create procedure sp_divison(@a int,@b int)
as
begin
begin try
declare @result int
set @result=@a*@b
return @result
end try
begin catch
raiserror('Error Occured',17,1)
end catch
end