create procedure sp_div_error(@a int,@b int)
as
begin
BEGIN TRY
SELECT @a/@b
END TRY
BEGIN CATCH
SELECT
ERROR_NUMBER() AS ErrorNumber,
ERROR_MESSAGE() AS ErrorMessage,
ERROR_LINE() AS ErrorLine,
ERROR_PROCEDURE() as 'Procedure',
ERROR_STATE() as ErrorState,
ERROR_SEVERITY() as ErrorSeverity
END CATCH
end
exec sp_div_error 12,0