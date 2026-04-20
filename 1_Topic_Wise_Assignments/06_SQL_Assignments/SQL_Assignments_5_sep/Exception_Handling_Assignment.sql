--Assignment_1
CREATE PROCEDURE sp_AddStudent
@FirstName VARCHAR(50),
@LastName VARCHAR(50),
@DepartmentID INT,
@Gender VARCHAR(10),
@AdmissionDate DATE
AS
BEGIN
BEGIN TRY
INSERT INTO Students
(
FirstName,
LastName,
DepartmentID,
Gender,
AdmissionDate
)
VALUES
(
@FirstName,
@LastName,
@DepartmentID,
@Gender,
@AdmissionDate
);
PRINT 'Student inserted successfully';
END TRY
BEGIN CATCH
PRINT ERROR_MESSAGE();
END CATCH
END;

EXEC sp_AddStudent
@FirstName = 'Arun',
@LastName = 'Kumar',
@DepartmentID = 1,
@Gender = 'Male',
@AdmissionDate = '2024-07-20';

EXEC sp_AddStudent
@FirstName = 'Neha',
@LastName = 'Sharma',
@DepartmentID = 99,
@Gender = 'Female',
@AdmissionDate = '2024-07-21';

--Assignment_2
CREATE PROCEDURE sp_InsertMarks
@StudentID INT,
@ExamID INT,
@MarksObtained INT
AS
BEGIN
IF @MarksObtained < 0 OR @MarksObtained > 100
BEGIN
RAISERROR('Invalid Marks',16,1)
END
ELSE
BEGIN
INSERT INTO Marks
(
StudentID,
ExamID,
MarksObtained
)
VALUES
(
@StudentID,
@ExamID,
@MarksObtained
);
END
END;

EXEC sp_InsertMarks
@StudentID = 2,
@ExamID = 1,
@MarksObtained = 85;

EXEC sp_InsertMarks
@StudentID = 2,
@ExamID = 1,
@MarksObtained = 120;

--Assignment_3
CREATE PROCEDURE sp_DeleteStudent
@StudentID INT
AS
BEGIN
BEGIN TRY
DELETE FROM Students WHERE StudentID = @StudentID;

PRINT 'Student deleted successfully';
END TRY

BEGIN CATCH
PRINT ERROR_MESSAGE();
END CATCH
END;

EXEC sp_DeleteStudent 
@StudentID = 1;

SELECT * FROM Students
WHERE StudentID NOT IN
(
SELECT StudentID FROM Enrollments
);

EXEC sp_DeleteStudent 
@StudentID = 9;