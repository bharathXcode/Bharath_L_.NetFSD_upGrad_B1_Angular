CREATE VIEW CustomerTotalBalance
AS
SELECT
c.FirstName,
SUM(a.Balance) AS TotalBalance
FROM Customers c
JOIN Accounts a
ON c.CustomerID = a.CustomerID
GROUP BY c.FirstName;
select * from CustomerTotalBalance
select * from CustomerTotalBalance order by TotalBalance desc