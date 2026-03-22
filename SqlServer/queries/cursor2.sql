-- Add fine for accounts with balance <10000
DECLARE @AccountID INT
DECLARE @Balance MONEY
DECLARE account_cursor CURSOR
FOR
SELECT AccountID, Balance FROM Accounts
OPEN account_cursor
FETCH NEXT FROM account_cursor INTO @AccountID, @Balance
WHILE @@FETCH_STATUS = 0
BEGIN
IF @Balance < 20000
BEGIN
UPDATE Accounts
SET Balance = Balance - 500
WHERE AccountID = @AccountID
END
FETCH NEXT FROM account_cursor INTO @AccountID, @Balance
END
CLOSE account_cursor
DEALLOCATE account_cursor
select * from Accounts