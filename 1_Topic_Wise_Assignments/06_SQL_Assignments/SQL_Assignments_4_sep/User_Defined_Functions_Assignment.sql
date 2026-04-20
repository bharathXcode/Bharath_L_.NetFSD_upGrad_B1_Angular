--Assignment_1
CREATE FUNCTION fn_GetGrade
(
@MarksObtained INT
)
RETURNS VARCHAR(10)
AS
BEGIN
DECLARE @Grade VARCHAR(10)

IF @MarksObtained >= 90
SET @Grade = 'A'
ELSE IF @MarksObtained >= 75
SET @Grade = 'B'
ELSE IF @MarksObtained >= 60
SET @Grade = 'C'
ELSE
SET @Grade = 'Fail'

RETURN @Grade
END;

SELECT
s.FirstName + ' ' + s.LastName AS StudentName,
m.MarksObtained,
dbo.fn_GetGrade(m.MarksObtained) AS Grade
FROM Students s
JOIN Marks m ON s.StudentID = m.StudentID;

--Assignment_2
CREATE FUNCTION fn_GetStudentAge
(
@DateOfBirth DATE
)
RETURNS INT
AS
BEGIN
DECLARE @Age INT

SET @Age = DATEDIFF(YEAR, @DateOfBirth, GETDATE())

RETURN @Age
END;

SELECT
FirstName + ' ' + LastName AS StudentName,
DateOfBirth,
dbo.fn_GetStudentAge(DateOfBirth) AS Age
FROM Students;

--Assignment_3
CREATE FUNCTION fn_GetTotalMarks
(
@StudentID INT
)
RETURNS INT
AS
BEGIN
DECLARE @TotalMarks INT

SELECT @TotalMarks = SUM(MarksObtained)
FROM Marks
WHERE StudentID = @StudentID

RETURN @TotalMarks
END;

SELECT StudentID,
dbo.fn_GetTotalMarks(StudentID) AS TotalMarks FROM Students;

--Assignment_4
CREATE FUNCTION fn_GetStudentCourses
(
@StudentID INT
)
RETURNS TABLE
AS
RETURN
(
SELECT
c.CourseName,
e.EnrollmentDate
FROM Enrollments e
JOIN Courses c
ON e.CourseID = c.CourseID
WHERE e.StudentID = @StudentID
);

SELECT * FROM dbo.fn_GetStudentCourses(1);

--Assignment_5
CREATE FUNCTION fn_GetDepartmentStudents
(
@DepartmentID INT
)
RETURNS TABLE
AS
RETURN
(
SELECT
StudentID,
FirstName + ' ' + LastName AS StudentName,
AdmissionDate
FROM Students WHERE DepartmentID = @DepartmentID
);

SELECT * FROM dbo.fn_GetDepartmentStudents(1);