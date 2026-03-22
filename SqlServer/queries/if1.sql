--condtional statemetns
--simple if
--if else
declare @age int
set @age=9
if @age>=18
begin
select 'Person eligible for voting!!!'
end
else
begin
print 'Sorry!! you are not eligible for voting this time'
end
GO