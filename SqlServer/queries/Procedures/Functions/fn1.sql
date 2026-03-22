create function GetAge(@birthDate Date)
returns int
as
begin
declare @age int
set @age=DATEDIFF
(year,cast(@birthDate as date),getdate())
return @age
end
select dbo.GetAge('2.23.2000') as Age
select * from Accounts
select dbo.GetAge(openDate) as 
Years from Accounts