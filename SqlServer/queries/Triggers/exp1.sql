create procedure sp_div(@a int,@b int)
as
begin
BEGIN TRY
SELECT @a/@b
END TRY
BEGIN CATCH
SELECT 'An error occurred'
END CATCH
end