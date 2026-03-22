DECLARE @Balance INT
SELECT @Balance = Balance
FROM Accounts
WHERE AccountID = 10002
IF @Balance < 5000
PRINT 'Low Balance'
ELSE
PRINT 'Sufficient Balance'