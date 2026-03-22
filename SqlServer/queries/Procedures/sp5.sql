CREATE PROCEDURE GetCustomerBalance
@CustomerID INT
AS
BEGIN
SELECT SUM(Balance) AS TotalBalance
FROM Accounts
WHERE CustomerID = @CustomerID
END
exec GetCustomerBalance 3