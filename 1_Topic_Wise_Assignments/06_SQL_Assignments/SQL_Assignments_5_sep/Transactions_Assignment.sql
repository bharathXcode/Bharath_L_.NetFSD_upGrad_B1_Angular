--Assignment_1
CREATE PROCEDURE sp_EnrollStudentTransaction
@StudentID INT,
@CourseID INT
AS
BEGIN
BEGIN TRY
BEGIN TRANSACTION
INSERT INTO Enrollments
(
StudentID,
CourseID,
EnrollmentDate
)
VALUES
(
@StudentID,
@CourseID,
GETDATE()
)
COMMIT TRANSACTION
PRINT 'Enrollment successful'
END TRY
BEGIN CATCH
ROLLBACK TRANSACTION
PRINT 'Enrollment failed'
PRINT ERROR_MESSAGE()
END CATCH
END;

EXEC sp_EnrollStudentTransaction
@StudentID = 2,
@CourseID = 1;

EXEC sp_EnrollStudentTransaction
@StudentID = 2,
@CourseID = 99;

SELECT * FROM Enrollments;

--Assignment_2
CREATE PROCEDURE sp_RecordExamMarks
@StudentID INT,
@ExamID INT,
@MarksObtained INT
AS
BEGIN
BEGIN TRY
BEGIN TRANSACTION
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
)
UPDATE Exams
SET ExamDate = GETDATE()
WHERE ExamID = @ExamID
COMMIT TRANSACTION
PRINT 'Exam marks recorded successfully'
END TRY
BEGIN CATCH
ROLLBACK TRANSACTION
PRINT 'Transaction failed'
PRINT ERROR_MESSAGE()
END CATCH
END;

EXEC sp_RecordExamMarks
@StudentID = 2,
@ExamID = 1,
@MarksObtained = 88;

EXEC sp_RecordExamMarks
@StudentID = 2,
@ExamID = 99,
@MarksObtained = 85;

SELECT * FROM Marks;
SELECT * FROM Exams;

--Assignment_3
CREATE PROCEDURE sp_TransferStudentDepartment
@StudentID INT,
@NewDepartmentID INT
AS
BEGIN
BEGIN TRY
BEGIN TRANSACTION
IF NOT EXISTS (
SELECT 1
FROM Departments
WHERE DepartmentID = @NewDepartmentID
)
BEGIN
RAISERROR('Department does not exist',16,1)
END
UPDATE Students
SET DepartmentID = @NewDepartmentID
WHERE StudentID = @StudentID
COMMIT TRANSACTION
PRINT 'Department transfer successful'
END TRY
BEGIN CATCH
ROLLBACK TRANSACTION
PRINT 'Department transfer failed'
PRINT ERROR_MESSAGE()
END CATCH
END;

EXEC sp_TransferStudentDepartment
@StudentID = 2,
@NewDepartmentID = 3;

EXEC sp_TransferStudentDepartment
@StudentID = 2,
@NewDepartmentID = 99;

SELECT StudentID, DepartmentID FROM Students;