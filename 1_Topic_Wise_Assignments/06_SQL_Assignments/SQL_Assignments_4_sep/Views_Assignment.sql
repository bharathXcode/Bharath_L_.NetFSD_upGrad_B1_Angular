USE EducationDB;
GO

--Assignment_1
CREATE VIEW vw_StudentDepartment AS
SELECT
s.StudentID,
s.FirstName + ' ' + s.LastName AS StudentName,
d.DepartmentName,
s.AdmissionDate
FROM Students s JOIN Departments d ON s.DepartmentID = d.DepartmentID;

SELECT * FROM vw_StudentDepartment;

SELECT * FROM vw_StudentDepartment WHERE DepartmentName = 'Computer Science';

DROP VIEW vw_StudentDepartment;

--Assignment_2
CREATE VIEW vw_StudentCourses AS
SELECT
s.StudentID,
s.FirstName + ' ' + s.LastName AS StudentName,
c.CourseName,
e.EnrollmentDate
FROM Students s JOIN Enrollments e ON s.StudentID = e.StudentID
JOIN Courses c ON e.CourseID = c.CourseID;

SELECT * FROM vw_StudentCourses WHERE StudentID = 5;

SELECT StudentName, COUNT(CourseName) AS TotalCourses
FROM vw_StudentCourses GROUP BY StudentName;

SELECT * FROM vw_StudentCourses WHERE EnrollmentDate > '2024-01-01';

--Assignemnt_3
CREATE VIEW vw_ExamResults AS
SELECT
s.FirstName + ' ' + s.LastName AS StudentName,
c.CourseName,
e.ExamType,
m.MarksObtained
FROM Students s JOIN Marks m ON s.StudentID = m.StudentID
JOIN Exams e ON m.ExamID = e.ExamID
JOIN Courses c ON e.CourseID = c.CourseID;

SELECT * FROM vw_ExamResults WHERE MarksObtained > 80;

SELECT * FROM vw_ExamResults WHERE MarksObtained =
(
SELECT MAX(MarksObtained)
FROM vw_ExamResults
);

SELECT * FROM vw_ExamResults WHERE MarksObtained < 40;

--Assignment_4
CREATE VIEW vw_DepartmentStudentCount AS
SELECT d.DepartmentName, COUNT(s.StudentID) AS TotalStudents
FROM Departments d
LEFT JOIN Students s ON d.DepartmentID = s.DepartmentID
GROUP BY d.DepartmentName;

SELECT * FROM vw_DepartmentStudentCount WHERE TotalStudents > 10;

SELECT * FROM vw_DepartmentStudentCount ORDER BY TotalStudents DESC;