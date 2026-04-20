--Assignment_1
CREATE TABLE StudentAudit
(
AuditID INT PRIMARY KEY IDENTITY(1,1),
StudentID INT,
ActionType VARCHAR(20),
ActionDate DATETIME
);

CREATE TRIGGER trg_StudentInsertAudit ON Students
AFTER INSERT
AS
BEGIN
INSERT INTO StudentAudit
(
StudentID,
ActionType,
ActionDate
)
SELECT
StudentID,
'INSERT',
GETDATE()
FROM inserted;
END;

INSERT INTO Students
(FirstName, LastName, Gender, DepartmentID, AdmissionDate)
VALUES
('Karthik', 'Rao', 'Male', 1, '2024-07-15');

SELECT * FROM StudentAudit;

INSERT INTO Students
(FirstName, LastName, Gender, DepartmentID, AdmissionDate)
VALUES
('Divya','Sharma','Female',2,'2024-07-16'),
('Rohit','Mehta','Male',3,'2024-07-17');

SELECT * FROM StudentAudit;

--Assignment_2
CREATE TRIGGER trg_PreventStudentDelete ON Students
INSTEAD OF DELETE
AS
BEGIN
IF EXISTS (
SELECT 1
FROM Enrollments e
JOIN deleted d
ON e.StudentID = d.StudentID
)
BEGIN
RAISERROR('Student has course enrollments and cannot be deleted',16,1)
ROLLBACK TRANSACTION
END
ELSE
BEGIN
DELETE FROM Students WHERE StudentID IN (SELECT StudentID FROM deleted)
END
END;

DELETE FROM Students WHERE StudentID = 1;

DELETE FROM Students WHERE StudentID = 6;

SELECT * FROM Students;

--Assignment_3
CREATE TABLE MarksAudit
(
AuditID INT PRIMARY KEY IDENTITY(1,1),
StudentID INT,
ExamID INT,
OldMarks INT,
NewMarks INT,
UpdatedDate DATETIME
);

CREATE TRIGGER trg_UpdateMarksAudit
ON Marks
AFTER UPDATE
AS
BEGIN
INSERT INTO MarksAudit
(
StudentID,
ExamID,
OldMarks,
NewMarks,
UpdatedDate
)
SELECT
d.StudentID,
d.ExamID,
d.MarksObtained,
i.MarksObtained,
GETDATE()
FROM deleted d
JOIN inserted i
ON d.MarkID = i.MarkID;
END;

UPDATE Marks SET MarksObtained = 95 WHERE MarkID = 1;

SELECT * FROM MarksAudit;