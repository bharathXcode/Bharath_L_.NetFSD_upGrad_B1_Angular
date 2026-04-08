/* ============================================================
SQL SERVER ASSIGNMENT – EDUCATION DOMAIN
Database Name : AssignmentDB3  (6/3/26)
This file contains solutions for Assignment 1 – 10
All questions are written in comments before queries
============================================================ */


/* ============================================================
STEP 1 : CREATE DATABASE
============================================================ */

CREATE DATABASE AssignmentDB3;
GO

USE AssignmentDB3;
GO


/* ============================================================
ASSIGNMENT 1 – CREATE TABLES (DDL)
============================================================ */


/* Question: Create Departments Table */

CREATE TABLE Departments(
    DepartmentID INT PRIMARY KEY,
    DepartmentName VARCHAR(100) UNIQUE,
    Location VARCHAR(100)
);


/* Question: Create Teachers Table */

CREATE TABLE Teachers(
    TeacherID INT PRIMARY KEY,
    TeacherName VARCHAR(100),
    Email VARCHAR(150) UNIQUE,
    DepartmentID INT,
    HireDate DATE,

    FOREIGN KEY (DepartmentID) REFERENCES Departments(DepartmentID)
);


/* Question: Create Students Table */

CREATE TABLE Students(
    StudentID INT PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    DateOfBirth DATE,
    Gender CHAR(1),
    DepartmentID INT,
    AdmissionDate DATE,

    FOREIGN KEY (DepartmentID) REFERENCES Departments(DepartmentID)
);


/* Question: Create Courses Table */

CREATE TABLE Courses(
    CourseID INT PRIMARY KEY,
    CourseName VARCHAR(100),
    Credits INT,
    DepartmentID INT,
    TeacherID INT,

    FOREIGN KEY (DepartmentID) REFERENCES Departments(DepartmentID),
    FOREIGN KEY (TeacherID) REFERENCES Teachers(TeacherID)
);


/* Question: Create Enrollments Table */

CREATE TABLE Enrollments(
    EnrollmentID INT PRIMARY KEY,
    StudentID INT,
    CourseID INT,
    EnrollmentDate DATE DEFAULT GETDATE(),

    FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
    FOREIGN KEY (CourseID) REFERENCES Courses(CourseID)
);


/* Question: Create Exams Table */

CREATE TABLE Exams(
    ExamID INT PRIMARY KEY,
    CourseID INT,
    ExamDate DATE,
    ExamType VARCHAR(50),

    FOREIGN KEY (CourseID) REFERENCES Courses(CourseID)
);


/* Question: Create Marks Table */

CREATE TABLE Marks(
    MarkID INT PRIMARY KEY,
    StudentID INT,
    ExamID INT,
    MarksObtained INT,

    FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
    FOREIGN KEY (ExamID) REFERENCES Exams(ExamID)
);



/* ============================================================
ASSIGNMENT 2 – CONSTRAINTS
============================================================ */


/* Question: Student gender should only allow 'M' or 'F' */

ALTER TABLE Students
ADD CONSTRAINT CHK_Gender CHECK (Gender IN ('M','F'));


/* Question: Course credits must be between 1 and 5 */

ALTER TABLE Courses
ADD CONSTRAINT CHK_Credits CHECK (Credits BETWEEN 1 AND 5);


/* Question: MarksObtained must be between 0 and 100 */

ALTER TABLE Marks
ADD CONSTRAINT CHK_Marks CHECK (MarksObtained BETWEEN 0 AND 100);



/* ============================================================
ASSIGNMENT 3 – ALTER TABLE
============================================================ */


/* Question 1: Add column PhoneNumber to Students */

ALTER TABLE Students
ADD PhoneNumber VARCHAR(15);


/* Question 2: Add Salary column to Teachers */

ALTER TABLE Teachers
ADD Salary INT;


/* Question 3: Modify Salary datatype */

ALTER TABLE Teachers
ALTER COLUMN Salary DECIMAL(10,2);


/* Question 4: Add CHECK constraint to Salary */

ALTER TABLE Teachers
ADD CONSTRAINT CHK_Salary CHECK (Salary > 20000);


/* Question 5: Drop PhoneNumber column */

ALTER TABLE Students
DROP COLUMN PhoneNumber;


/* Question 6: Rename column TeacherName to FullName */

EXEC sp_rename 'Teachers.TeacherName','FullName','COLUMN';




/* ============================================================
ASSIGNMENT 4 – INSERT SAMPLE DATA
============================================================ */


/* Insert Departments (5) */

INSERT INTO Departments VALUES
(1,'Computer Science','Block A'),
(2,'Mechanical','Block B'),
(3,'Electronics','Block C'),
(4,'Civil','Block D'),
(5,'Mathematics','Block E');


/* Insert Teachers (10) */

INSERT INTO Teachers VALUES
(1,'John Smith','john@school.com',1,'2021-05-10',50000),
(2,'Robert Brown','robert@school.com',1,'2023-01-12',55000),
(3,'David Lee','david@school.com',2,'2020-03-15',60000),
(4,'Michael Scott','michael@school.com',3,'2019-07-20',52000),
(5,'Sarah Johnson','sarah@school.com',4,'2022-06-11',48000),
(6,'Emma Wilson','emma@school.com',5,'2023-02-14',47000),
(7,'Chris Evans','chris@school.com',1,'2022-09-10',62000),
(8,'Sophia Clark','sophia@school.com',2,'2021-11-01',45000),
(9,'Daniel White','daniel@school.com',3,'2020-08-21',53000),
(10,'Olivia Green','olivia@school.com',4,'2024-01-05',42000);



/* Insert Students (20) */

INSERT INTO Students VALUES
(1,'Arjun','Reddy','2006-02-12','M',1,'2023-06-01'),
(2,'Aisha','Khan','2007-01-10','F',1,'2023-06-01'),
(3,'Rahul','Sharma','2005-09-20','M',2,'2022-06-01'),
(4,'Sneha','Patel','2006-03-15','F',3,'2023-06-01'),
(5,'Kiran','Das','2007-07-22','M',4,'2023-06-01'),
(6,'Ananya','Roy','2008-01-11','F',5,'2024-06-01'),
(7,'Vikram','Singh','2006-11-19','M',1,'2023-06-01'),
(8,'Pooja','Gupta','2005-05-12','F',2,'2022-06-01'),
(9,'Rohit','Mehta','2007-09-30','M',3,'2023-06-01'),
(10,'Neha','Joshi','2006-10-25','F',4,'2023-06-01'),
(11,'Aditya','Nair','2005-04-02','M',5,'2022-06-01'),
(12,'Priya','Iyer','2006-06-16','F',1,'2023-06-01'),
(13,'Arav','Kapoor','2007-08-18','M',2,'2023-06-01'),
(14,'Divya','Menon','2005-12-21','F',3,'2022-06-01'),
(15,'Riya','Shah','2006-03-28','F',4,'2023-06-01'),
(16,'Kabir','Bose','2007-05-10','M',5,'2023-06-01'),
(17,'Aman','Verma','2008-02-02','M',1,'2024-06-01'),
(18,'Ishita','Agarwal','2006-04-19','F',2,'2023-06-01'),
(19,'Yash','Malhotra','2007-07-07','M',3,'2023-06-01'),
(20,'Tanvi','Kulkarni','2006-01-01','F',4,'2023-06-01');



/* Insert Courses (10) */

INSERT INTO Courses VALUES
(1,'Database Systems',4,1,1),
(2,'Operating Systems',5,1,2),
(3,'Thermodynamics',3,2,3),
(4,'Digital Electronics',4,3,4),
(5,'Structural Engineering',3,4,5),
(6,'Calculus',4,5,6),
(7,'Java Programming',5,1,7),
(8,'Machine Design',3,2,8),
(9,'Microprocessors',4,3,9),
(10,'Engineering Math',5,5,6);



/* ============================================================
ASSIGNMENT 5 – FILTERING DATA (WHERE)
============================================================ */


/* Q1 Find students from Computer Science department */

SELECT * FROM Students
WHERE DepartmentID = (
    SELECT DepartmentID
    FROM Departments
    WHERE DepartmentName='Computer Science'
);


/* Q2 Find teachers hired after 2022 */

SELECT * FROM Teachers
WHERE HireDate > '2022-01-01';


/* Q3 Find students whose name starts with 'A' */

SELECT * FROM Students
WHERE FirstName LIKE 'A%';


/* Q4 Find courses having credits greater than 3 */

SELECT * FROM Courses
WHERE Credits > 3;


/* Q5 Find students born between 2005 and 2008 */

SELECT * FROM Students
WHERE DateOfBirth BETWEEN '2005-01-01' AND '2008-12-31';


/* Q6 Find students not belonging to Mechanical department */

SELECT * FROM Students
WHERE DepartmentID != (
    SELECT DepartmentID FROM Departments
    WHERE DepartmentName='Mechanical'
);


/* Q7 Find teachers whose salary between 40000 and 70000 */

SELECT * FROM Teachers
WHERE Salary BETWEEN 40000 AND 70000;


/* Q8 Find courses not taught by TeacherID = 3 */

SELECT * FROM Courses
WHERE TeacherID <> 3;



/* ============================================================
ASSIGNMENT 6 – GROUP BY
============================================================ */


/* Q1 Count students in each department */

SELECT DepartmentID, COUNT(*) AS StudentCount
FROM Students
GROUP BY DepartmentID;


/* Q2 Find average marks per exam */

SELECT ExamID, AVG(MarksObtained) AS AvgMarks
FROM Marks
GROUP BY ExamID;


/* Q3 Find total students enrolled per course */

SELECT CourseID, COUNT(StudentID) AS TotalStudents
FROM Enrollments
GROUP BY CourseID;


/* Q4 Find maximum marks scored in each exam */

SELECT ExamID, MAX(MarksObtained)
FROM Marks
GROUP BY ExamID;


/* Q5 Find minimum marks per course */

SELECT CourseID, MIN(MarksObtained)
FROM Marks M
JOIN Exams E ON M.ExamID = E.ExamID
GROUP BY CourseID;


/* Q6 Find departments having more than 5 students */

SELECT DepartmentID, COUNT(*) AS TotalStudents
FROM Students
GROUP BY DepartmentID
HAVING COUNT(*) > 5;



/* ============================================================
ASSIGNMENT 7 – JOINS
============================================================ */


/* Q1 Show students with department names */

SELECT S.FirstName, D.DepartmentName
FROM Students S
JOIN Departments D
ON S.DepartmentID = D.DepartmentID;


/* Q2 Show courses with teacher names */

SELECT C.CourseName, T.FullName
FROM Courses C
JOIN Teachers T
ON C.TeacherID = T.TeacherID;


/* Q3 Show student name and enrolled courses */

SELECT S.FirstName, C.CourseName
FROM Students S
JOIN Enrollments E ON S.StudentID = E.StudentID
JOIN Courses C ON C.CourseID = E.CourseID;


/* Q4 Show students with exam marks */

SELECT S.FirstName, M.MarksObtained
FROM Students S
JOIN Marks M ON S.StudentID = M.StudentID;


/* Q5 Show all courses and teachers (LEFT JOIN) */

SELECT C.CourseName, T.FullName
FROM Courses C
LEFT JOIN Teachers T
ON C.TeacherID = T.TeacherID;


/* Q6 Show teachers not assigned to any course */

SELECT T.FullName
FROM Teachers T
LEFT JOIN Courses C
ON T.TeacherID = C.TeacherID
WHERE C.TeacherID IS NULL;



/* ============================================================
ASSIGNMENT 8 – SUBQUERIES
============================================================ */


/* Q1 Find students whose marks greater than average */

SELECT *
FROM Marks
WHERE MarksObtained >
(
SELECT AVG(MarksObtained)
FROM Marks
);


/* Q2 Find courses with maximum credits */

SELECT *
FROM Courses
WHERE Credits =
(
SELECT MAX(Credits)
FROM Courses
);


/* Q3 Find students enrolled in more than 2 courses */

SELECT StudentID
FROM Enrollments
GROUP BY StudentID
HAVING COUNT(CourseID) > 2;



/* ============================================================
ASSIGNMENT 9 – VIEWS
============================================================ */


/* View 1 : Student basic information */

CREATE VIEW StudentInfoView AS
SELECT S.StudentID,
S.FirstName + ' ' + S.LastName AS StudentName,
D.DepartmentName
FROM Students S
JOIN Departments D
ON S.DepartmentID = D.DepartmentID;



/* View 2 : Student course enrollment */

CREATE VIEW EnrollmentView AS
SELECT S.FirstName,
C.CourseName,
E.EnrollmentDate
FROM Students S
JOIN Enrollments E ON S.StudentID = E.StudentID
JOIN Courses C ON C.CourseID = E.CourseID;



/* View 3 : Exam Result View */

CREATE VIEW ExamResultView AS
SELECT S.FirstName,
C.CourseName,
E.ExamType,
M.MarksObtained
FROM Marks M
JOIN Students S ON M.StudentID = S.StudentID
JOIN Exams E ON M.ExamID = E.ExamID
JOIN Courses C ON E.CourseID = C.CourseID;



/* Query View */

SELECT * FROM StudentInfoView;


/* Drop View */

DROP VIEW ExamResultView;



/* ============================================================
ASSIGNMENT 10 – INDEXES
============================================================ */


/* Q1 Create index on Student LastName */

CREATE INDEX idx_student_lastname
ON Students(LastName);


/* Q2 Create index on Teacher Email */

CREATE INDEX idx_teacher_email
ON Teachers(Email);


/* Q3 Composite index on Enrollments */

CREATE INDEX idx_enrollment_student_course
ON Enrollments(StudentID, CourseID);


/* Q4 Unique index on DepartmentName */

CREATE UNIQUE INDEX idx_dept_name
ON Departments(DepartmentName);


/* Q5 Drop an index */

DROP INDEX idx_student_lastname
ON Students;