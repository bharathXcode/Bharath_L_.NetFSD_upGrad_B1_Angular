--Assignment_1
CREATE PROCEDURE sp_DisplayStudentsCursor
AS
BEGIN
DECLARE @StudentID INT
DECLARE @StudentName VARCHAR(100)
DECLARE student_cursor CURSOR FOR
SELECT
StudentID,
FirstName + ' ' + LastName
FROM Students;
OPEN student_cursor
FETCH NEXT FROM student_cursor
INTO @StudentID, @StudentName
WHILE @@FETCH_STATUS = 0
BEGIN
PRINT 'StudentID: ' + CAST(@StudentID AS VARCHAR) + '  StudentName: ' + @StudentName
FETCH NEXT FROM student_cursor
INTO @StudentID, @StudentName
END
CLOSE student_cursor
DEALLOCATE student_cursor
END;

EXEC sp_DisplayStudentsCursor;

--Assignment_2
CREATE PROCEDURE sp_CalculateStudentTotalMarks
AS
BEGIN
DECLARE @StudentID INT
DECLARE @StudentName VARCHAR(100)
DECLARE @TotalMarks INT
DECLARE student_cursor CURSOR FOR
SELECT StudentID, FirstName + ' ' + LastName
FROM Students;
OPEN student_cursor
FETCH NEXT FROM student_cursor
INTO @StudentID, @StudentName
WHILE @@FETCH_STATUS = 0
BEGIN
SELECT @TotalMarks = SUM(MarksObtained) FROM Marks WHERE StudentID = @StudentID
PRINT 'StudentName: ' + @StudentName + '  TotalMarks: ' + ISNULL(CAST(@TotalMarks AS VARCHAR), '0')
FETCH NEXT FROM student_cursor
INTO @StudentID, @StudentName
END
CLOSE student_cursor
DEALLOCATE student_cursor
END;

EXEC sp_CalculateStudentTotalMarks;

--Assignment_3
ALTER TABLE Courses
ADD Credits INT DEFAULT 2;
UPDATE Courses SET Credits = 2 WHERE CourseID = 1;
UPDATE Courses SET Credits = 3 WHERE CourseID = 2;
UPDATE Courses SET Credits = 1 WHERE CourseID = 3;

CREATE PROCEDURE sp_UpdateCourseCredits
AS
BEGIN
DECLARE @CourseID INT
DECLARE @Credits INT
DECLARE course_cursor CURSOR FOR
SELECT CourseID, Credits
FROM Courses
WHERE Credits < 3
OPEN course_cursor
FETCH NEXT FROM course_cursor
INTO @CourseID, @Credits
WHILE @@FETCH_STATUS = 0
BEGIN
UPDATE Courses
SET Credits = Credits + 1
WHERE CourseID = @CourseID
FETCH NEXT FROM course_cursor
INTO @CourseID, @Credits
END
CLOSE course_cursor
DEALLOCATE course_cursor
END;

EXEC sp_UpdateCourseCredits;

SELECT * FROM Courses;