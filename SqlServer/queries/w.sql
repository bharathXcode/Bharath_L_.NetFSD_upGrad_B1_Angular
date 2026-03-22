DECLARE @Counter INT = 1
WHILE @Counter <= 10
BEGIN
IF @Counter = 6
BREAK -- loop terminates
PRINT @Counter
SET @Counter = @Counter + 1
END
