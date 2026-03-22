create procedure GetEmployeeCount
@TotalEmployees int output
as
begin
select @TotalEmployees=COUNT(*) from Employees
end

declare @result int
exec GetEmployeeCount @result output
select @result as Total_Count