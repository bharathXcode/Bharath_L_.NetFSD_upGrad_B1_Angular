CREATE TABLE EmployeeAudit
(
EmployeeID INT,
Name VARCHAR(50),
Salary INT,
DeletedDate DATETIME
)
CREATE TRIGGER trg_AuditEmployeeDelete
ON Employees
AFTER DELETE
AS
BEGIN
INSERT INTO EmployeeAudit
SELECT EmployeeID, Name, Salary, GETDATE()
FROM DELETED
END
Delete from Employees where EmployeeId=101
select * from EmployeeAudit
