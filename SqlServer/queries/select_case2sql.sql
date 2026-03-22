declare @Marks int=80
SELECT
@Marks as Marks,
CASE 
WHEN @Marks>90 THEN 'Excellent'
WHEN @Marks>75 THEN 'Good'
WHEN @Marks>50 THEN 'Average'
ELSE 'Needs Improvement'
END AS Grade