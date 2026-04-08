/* ============================================================
DATABASE CREATION
============================================================ */

/* Create Database */
CREATE DATABASE EducationDB;
GO

/* Use Database */
USE EducationDB;
GO


/* ============================================================
TABLE CREATION
============================================================ */

/* Departments Table */
CREATE TABLE Departments
(
    DepartmentID INT PRIMARY KEY IDENTITY(1,1),
    DepartmentName VARCHAR(100)
);


/* Students Table */
CREATE TABLE Students
(
    StudentID INT PRIMARY KEY IDENTITY(1,1),
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    Gender VARCHAR(10),
    DepartmentID INT,
    DateOfBirth DATE,
    AdmissionDate DATE,
    FOREIGN KEY (DepartmentID) REFERENCES Departments(DepartmentID)
);


/* Teachers Table */
CREATE TABLE Teachers
(
    TeacherID INT PRIMARY KEY IDENTITY(1,1),
    TeacherName VARCHAR(100),
    DepartmentID INT,
    FOREIGN KEY (DepartmentID) REFERENCES Departments(DepartmentID)
);


/* Courses Table */
CREATE TABLE Courses
(
    CourseID INT PRIMARY KEY IDENTITY(1,1),
    CourseName VARCHAR(100),
    DepartmentID INT,
    FOREIGN KEY (DepartmentID) REFERENCES Departments(DepartmentID)
);


/* Enrollments Table */
CREATE TABLE Enrollments
(
    EnrollmentID INT PRIMARY KEY IDENTITY(1,1),
    StudentID INT,
    CourseID INT,
    EnrollmentDate DATE,
    FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
    FOREIGN KEY (CourseID) REFERENCES Courses(CourseID)
);


/* Exams Table */
CREATE TABLE Exams
(
    ExamID INT PRIMARY KEY IDENTITY(1,1),
    CourseID INT,
    ExamType VARCHAR(50),
    ExamDate DATE,
    FOREIGN KEY (CourseID) REFERENCES Courses(CourseID)
);


/* Marks Table */
CREATE TABLE Marks
(
    MarkID INT PRIMARY KEY IDENTITY(1,1),
    StudentID INT,
    ExamID INT,
    MarksObtained INT,
    FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
    FOREIGN KEY (ExamID) REFERENCES Exams(ExamID)
);



/* ============================================================
INSERT SAMPLE DATA
============================================================ */

INSERT INTO Departments VALUES
('Computer Science'),
('Electronics'),
('Mechanical'),
('Civil');


INSERT INTO Students VALUES
('Rahul','Sharma','Male',1,'2002-05-10','2024-07-01'),
('Sneha','Patil','Female',2,'2003-02-14','2024-07-02'),
('Arjun','Reddy','Male',1,'2002-11-20','2024-07-03'),
('Pooja','Nair','Female',3,'2001-09-15','2024-07-04'),
('Kiran','Das','Male',2,'2002-01-01','2024-07-05');


INSERT INTO Teachers VALUES
('Dr Kumar',1),
('Dr Mehta',2),
('Dr Rao',3);


INSERT INTO Courses VALUES
('Database Systems',1),
('Data Structures',1),
('Digital Electronics',2),
('Thermodynamics',3);


INSERT INTO Enrollments VALUES
(1,1,'2024-08-01'),
(2,3,'2024-08-02'),
(3,1,'2024-08-03'),
(4,4,'2024-08-04'),
(5,2,'2024-08-05');


INSERT INTO Exams VALUES
(1,'Midterm','2024-10-01'),
(1,'Final','2024-12-01'),
(2,'Midterm','2024-10-02'),
(3,'Midterm','2024-10-03');


INSERT INTO Marks VALUES
(1,1,85),
(2,1,78),
(3,2,92),
(4,3,55),
(5,4,65);



/* ============================================================
VIEWS ASSIGNMENT
============================================================ */


/* ============================================================
Assignment 1 – Student Department View
Create view vw_StudentDepartment
============================================================ */

CREATE VIEW vw_StudentDepartment
AS
SELECT
S.StudentID,
S.FirstName + ' ' + S.LastName AS StudentName,
D.DepartmentName,
S.AdmissionDate
FROM Students S
JOIN Departments D
ON S.DepartmentID = D.DepartmentID;
GO


/* Task 2: Retrieve all records */

SELECT * FROM vw_StudentDepartment;


/* Task 3: Filter Computer Science students */

SELECT *
FROM vw_StudentDepartment
WHERE DepartmentName = 'Computer Science';


/* Task 4: Drop the view */

-- DROP VIEW vw_StudentDepartment;




/* ============================================================
Assignment 2 – Student Course Enrollment View
============================================================ */

CREATE VIEW vw_StudentCourses
AS
SELECT
S.StudentID,
S.FirstName + ' ' + S.LastName AS StudentName,
C.CourseName,
E.EnrollmentDate
FROM Students S
JOIN Enrollments E
ON S.StudentID = E.StudentID
JOIN Courses C
ON E.CourseID = C.CourseID;
GO


/* Task 1: Courses taken by StudentID = 5 */

SELECT *
FROM vw_StudentCourses
WHERE StudentID = 5;


/* Task 2: Count courses taken by each student */

SELECT
StudentName,
COUNT(CourseName) AS TotalCourses
FROM vw_StudentCourses
GROUP BY StudentName;


/* Task 3: Students enrolled after 2024 */

SELECT *
FROM vw_StudentCourses
WHERE EnrollmentDate > '2024-01-01';




/* ============================================================
Assignment 3 – Exam Result View
============================================================ */

CREATE VIEW vw_ExamResults
AS
SELECT
S.FirstName + ' ' + S.LastName AS StudentName,
C.CourseName,
E.ExamType,
M.MarksObtained
FROM Students S
JOIN Marks M
ON S.StudentID = M.StudentID
JOIN Exams E
ON M.ExamID = E.ExamID
JOIN Courses C
ON E.CourseID = C.CourseID;
GO


/* Students scoring more than 80 */

SELECT *
FROM vw_ExamResults
WHERE MarksObtained > 80;


/* Top scorers */

SELECT TOP 1 *
FROM vw_ExamResults
ORDER BY MarksObtained DESC;


/* Failed students */

SELECT *
FROM vw_ExamResults
WHERE MarksObtained < 60;




/* ============================================================
Assignment 4 – Aggregate View
============================================================ */

CREATE VIEW vw_DepartmentStudentCount
AS
SELECT
D.DepartmentName,
COUNT(S.StudentID) AS TotalStudents
FROM Departments D
LEFT JOIN Students S
ON D.DepartmentID = S.DepartmentID
GROUP BY D.DepartmentName;
GO


/* Departments with more than 10 students */

SELECT *
FROM vw_DepartmentStudentCount
WHERE TotalStudents > 10;


/* Sort departments by student count */

SELECT *
FROM vw_DepartmentStudentCount
ORDER BY TotalStudents DESC;




/* ============================================================
STORED PROCEDURES
============================================================ */


/* Assignment 1 – Insert Student */

CREATE PROCEDURE sp_InsertStudent
@FirstName VARCHAR(50),
@LastName VARCHAR(50),
@Gender VARCHAR(10),
@DepartmentID INT,
@AdmissionDate DATE
AS
BEGIN

INSERT INTO Students
(FirstName,LastName,Gender,DepartmentID,AdmissionDate)

VALUES
(@FirstName,@LastName,@Gender,@DepartmentID,@AdmissionDate);

END
GO


/* Execute Procedure */

EXEC sp_InsertStudent
'Ravi',
'Kumar',
'Male',
1,
'2024-07-10';



/* ============================================================
Assignment 2 – Get Students By Department
============================================================ */

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

END
GO


EXEC sp_GetStudentsByDepartment 2;
EXEC sp_GetStudentsByDepartment 3;




/* ============================================================
Assignment 3 – Enroll Student
============================================================ */

CREATE PROCEDURE sp_EnrollStudent
@StudentID INT,
@CourseID INT
AS
BEGIN

INSERT INTO Enrollments
(StudentID,CourseID,EnrollmentDate)

VALUES
(@StudentID,@CourseID,GETDATE());

END
GO


EXEC sp_EnrollStudent 1,2;




/* ============================================================
Assignment 4 – Get Student Marks
============================================================ */

CREATE PROCEDURE sp_GetStudentMarks
@StudentID INT
AS
BEGIN

SELECT
S.FirstName + ' ' + S.LastName AS StudentName,
C.CourseName,
E.ExamType,
M.MarksObtained
FROM Students S
JOIN Marks M ON S.StudentID=M.StudentID
JOIN Exams E ON M.ExamID=E.ExamID
JOIN Courses C ON E.CourseID=C.CourseID
WHERE S.StudentID=@StudentID;

END
GO


EXEC sp_GetStudentMarks 1;




/* ============================================================
Assignment 5 – Update Marks
============================================================ */

CREATE PROCEDURE sp_UpdateMarks
@MarkID INT,
@NewMarks INT
AS
BEGIN

UPDATE Marks
SET MarksObtained=@NewMarks
WHERE MarkID=@MarkID;

SELECT * FROM Marks WHERE MarkID=@MarkID;

END
GO


EXEC sp_UpdateMarks 1,95;




/* ============================================================
Assignment 6 – Delete Enrollment
============================================================ */

CREATE PROCEDURE sp_DeleteEnrollment
@EnrollmentID INT
AS
BEGIN

DELETE FROM Enrollments
WHERE EnrollmentID=@EnrollmentID;

END
GO


EXEC sp_DeleteEnrollment 3;




/* ============================================================
USER DEFINED FUNCTIONS
============================================================ */


/* Assignment 1 – Grade Function */

CREATE FUNCTION fn_GetGrade
(
@Marks INT
)

RETURNS VARCHAR(10)

AS
BEGIN

DECLARE @Grade VARCHAR(10)

IF @Marks >= 90
SET @Grade='A'

ELSE IF @Marks >= 75
SET @Grade='B'

ELSE IF @Marks >= 60
SET @Grade='C'

ELSE
SET @Grade='Fail'

RETURN @Grade

END
GO


/* Using Grade Function */

SELECT
StudentID,
MarksObtained,
dbo.fn_GetGrade(MarksObtained) AS Grade
FROM Marks;




/* ============================================================
Assignment 2 – Student Age Function
============================================================ */

CREATE FUNCTION fn_GetStudentAge
(
@DOB DATE
)

RETURNS INT

AS
BEGIN

RETURN DATEDIFF(YEAR,@DOB,GETDATE())

END
GO


SELECT
FirstName,
dbo.fn_GetStudentAge(DateOfBirth) AS Age
FROM Students;




/* ============================================================
Assignment 3 – Total Marks Function
============================================================ */

CREATE FUNCTION fn_GetTotalMarks
(
@StudentID INT
)

RETURNS INT

AS
BEGIN

DECLARE @Total INT

SELECT @Total = SUM(MarksObtained)
FROM Marks
WHERE StudentID=@StudentID

RETURN @Total

END
GO


SELECT
StudentID,
dbo.fn_GetTotalMarks(StudentID) AS TotalMarks
FROM Students;




/* ============================================================
Assignment 4 – Student Courses Table Function
============================================================ */

CREATE FUNCTION fn_GetStudentCourses
(
@StudentID INT
)

RETURNS TABLE

AS

RETURN
(
SELECT
C.CourseName,
E.EnrollmentDate
FROM Enrollments E
JOIN Courses C
ON E.CourseID=C.CourseID
WHERE E.StudentID=@StudentID
)
GO


SELECT *
FROM dbo.fn_GetStudentCourses(1);




/* ============================================================
Assignment 5 – Department Students Function
============================================================ */

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
FROM Students
WHERE DepartmentID=@DepartmentID
)
GO


SELECT *
FROM dbo.fn_GetDepartmentStudents(1);
