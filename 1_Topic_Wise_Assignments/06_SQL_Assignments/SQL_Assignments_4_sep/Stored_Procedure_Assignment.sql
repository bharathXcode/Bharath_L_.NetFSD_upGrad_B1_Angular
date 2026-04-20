--Assignment_1
CREATE PROCEDURE sp_InsertStudent
@FirstName VARCHAR(50),
@LastName VARCHAR(50),
@Gender VARCHAR(10),
@DepartmentID INT,
@AdmissionDate DATE 
AS 
BEGIN
INSERT INTO Students
(
FirstName,
LastName,
Gender,
DepartmentID,
AdmissionDate
)
VALUES
(
@FirstName,
@LastName,
@Gender,
@DepartmentID,
@AdmissionDate
);
END;

EXEC sp_InsertStudent
@FirstName = 'Ravi',
@LastName = 'Kumar',
@Gender = 'Male',
@DepartmentID = 1,
@AdmissionDate = '2024-07-10';

SELECT * FROM Students;

--Assignment_2
CREATE PROCEDURE sp_GetStudentsByDepartment
@DepartmentID INT
AS
BEGIN
SELECT
StudentID,
FirstName + ' ' + LastName AS StudentName,
AdmissionDate
FROM Students
WHERE DepartmentID = @DepartmentID;
END;

EXEC sp_GetStudentsByDepartment
@DepartmentID = 2;

EXEC sp_GetStudentsByDepartment
@DepartmentID = 3;

--Assignment_3
CREATE PROCEDURE sp_EnrollStudent
@StudentID INT,
@CourseID INT
AS
BEGIN
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
);
END;

EXEC sp_EnrollStudent
@StudentID = 3,
@CourseID = 2;

SELECT * FROM Enrollments;

--Assignment_4
CREATE PROCEDURE sp_GetStudentMarks
@StudentID INT
AS
BEGIN
SELECT
s.FirstName + ' ' + s.LastName AS StudentName,
c.CourseName,
e.ExamType,
m.MarksObtained
FROM Students s
JOIN Marks m ON s.StudentID = m.StudentID
JOIN Exams e ON m.ExamID = e.ExamID
JOIN Courses c ON e.CourseID = c.CourseID
WHERE s.StudentID = @StudentID;
END;

EXEC sp_GetStudentMarks
@StudentID = 1;

SELECT * FROM Marks;

--Assignment_5
CREATE PROCEDURE sp_UpdateMarks
@MarkID INT,
@NewMarks INT
AS
BEGIN
UPDATE Marks
SET MarksObtained = @NewMarks
WHERE MarkID = @MarkID;

SELECT * FROM Marks WHERE MarkID = @MarkID;
END;

EXEC sp_UpdateMarks
@MarkID = 1,
@NewMarks = 92;

SELECT * FROM Marks;

--Assignment_6
CREATE PROCEDURE sp_DeleteEnrollment
@EnrollmentID INT
AS
BEGIN
DELETE FROM Enrollments
WHERE EnrollmentID = @EnrollmentID;
END;

EXEC sp_DeleteEnrollment
@EnrollmentID = 2;

SELECT * FROM Enrollments;