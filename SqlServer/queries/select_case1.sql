--select case 
declare @week_day int=2
SELECT
@week_day as [WeekDay],
CASE @week_day
WHEN 1 THEN 'Monday'
WHEN 2 THEN 'Tuesday'
WHEN 5 THEN 'Friday'
ELSE 'Invalid Day'
END AS 'Weekday'