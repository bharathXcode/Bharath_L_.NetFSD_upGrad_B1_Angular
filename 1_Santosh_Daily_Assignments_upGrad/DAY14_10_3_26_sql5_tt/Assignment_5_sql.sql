/* ============================================================
   CREATE DATABASE
   ============================================================ */

CREATE DATABASE EducationDB;
GO

USE EducationDB;
GO


/* ============================================================
   CREATE TABLES
   ============================================================ */

CREATE TABLE Departments(
    DepartmentID INT PRIMARY KEY,
    DepartmentName VARCHAR(100)
);

CREATE TABLE Students(
    StudentID INT PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    DepartmentID INT,
    Gender VARCHAR(10),
    AdmissionDate DATE,
    FOREIGN KEY (DepartmentID) REFERENCES Departments(DepartmentID)
);

CREATE TABLE Teachers(
    TeacherID INT PRIMARY KEY,
    TeacherName VARCHAR(100),
    DepartmentID INT,
    FOREIGN KEY (DepartmentID) REFERENCES Departments(DepartmentID)
);

CREATE TABLE Courses(
    CourseID INT PRIMARY KEY,
    CourseName VARCHAR(100),
    Credits INT,
    DepartmentID INT,
    FOREIGN KEY (DepartmentID) REFERENCES Departments(DepartmentID)
);

CREATE TABLE Enrollments(
    EnrollmentID INT PRIMARY KEY,
    StudentID INT,
    CourseID INT,
    FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
    FOREIGN KEY (CourseID) REFERENCES Courses(CourseID)
);

CREATE TABLE Exams(
    ExamID INT PRIMARY KEY,
    CourseID INT,
    ExamDate DATE,
    FOREIGN KEY (CourseID) REFERENCES Courses(CourseID)
);

CREATE TABLE Marks(
    MarkID INT PRIMARY KEY,
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
(1,'Computer Science'),
(2,'Electronics'),
(3,'Mechanical');

INSERT INTO Students VALUES
(101,'Rahul','Sharma',1,'Male','2024-06-01'),
(102,'Anita','Rao',2,'Female','2024-06-02');

INSERT INTO Courses VALUES
(201,'Java Programming',3,1),
(202,'Digital Electronics',2,2);

INSERT INTO Enrollments VALUES
(1,101,201);

INSERT INTO Exams VALUES
(301,201,'2025-01-10');

INSERT INTO Marks VALUES
(1,101,301,85);



/* ============================================================
   TRIGGERS ASSIGNMENTS
   ============================================================ */


/* ============================================================
   Assignment 1 – Audit Trigger for Students
   ============================================================ */

CREATE TABLE StudentAudit(
    AuditID INT IDENTITY(1,1) PRIMARY KEY,
    StudentID INT,
    ActionType VARCHAR(50),
    ActionDate DATETIME
);

GO

CREATE TRIGGER trg_StudentInsertAudit
ON Students
AFTER INSERT
AS
BEGIN

    INSERT INTO StudentAudit(StudentID,ActionType,ActionDate)
    SELECT StudentID,'INSERT',GETDATE()
    FROM inserted;

END;
GO


/* Test */

INSERT INTO Students VALUES
(103,'Kiran','Patil',1,'Male','2024-07-01');

SELECT * FROM StudentAudit;



/* ============================================================
   Assignment 2 – Prevent Deleting Students
   ============================================================ */

GO
CREATE TRIGGER trg_PreventStudentDelete
ON Students
INSTEAD OF DELETE
AS
BEGIN

    IF EXISTS(
        SELECT 1
        FROM Enrollments e
        JOIN deleted d
        ON e.StudentID=d.StudentID
    )
    BEGIN

        RAISERROR('Student has course enrollments and cannot be deleted',16,1);
        ROLLBACK TRANSACTION;

    END

    ELSE
    BEGIN

        DELETE FROM Students
        WHERE StudentID IN (SELECT StudentID FROM deleted);

    END

END;
GO



/* ============================================================
   Assignment 3 – Update Marks Trigger
   ============================================================ */

CREATE TABLE MarksAudit(
    AuditID INT IDENTITY(1,1) PRIMARY KEY,
    StudentID INT,
    ExamID INT,
    OldMarks INT,
    NewMarks INT,
    UpdatedDate DATETIME
);

GO

CREATE TRIGGER trg_UpdateMarksAudit
ON Marks
AFTER UPDATE
AS
BEGIN

    INSERT INTO MarksAudit(StudentID,ExamID,OldMarks,NewMarks,UpdatedDate)
    SELECT
        d.StudentID,
        d.ExamID,
        d.MarksObtained,
        i.MarksObtained,
        GETDATE()
    FROM deleted d
    JOIN inserted i
    ON d.MarkID=i.MarkID;

END;
GO


/* Test */

UPDATE Marks
SET MarksObtained = 90
WHERE MarkID = 1;

SELECT * FROM MarksAudit;




/* ============================================================
   EXCEPTION HANDLING ASSIGNMENTS
   ============================================================ */


/* ============================================================
   Assignment 1 – Insert Student Procedure with Exception Handling
   ============================================================ */

GO
CREATE PROCEDURE sp_AddStudent
@StudentID INT,
@FirstName VARCHAR(50),
@LastName VARCHAR(50),
@DepartmentID INT,
@Gender VARCHAR(10),
@AdmissionDate DATE
AS
BEGIN

    BEGIN TRY

        INSERT INTO Students
        VALUES(@StudentID,@FirstName,@LastName,@DepartmentID,@Gender,@AdmissionDate);

        PRINT 'Student inserted successfully';

    END TRY

    BEGIN CATCH

        PRINT ERROR_MESSAGE();

    END CATCH

END;
GO



/* ============================================================
   Assignment 2 – Marks Validation Procedure
   ============================================================ */

GO
CREATE PROCEDURE sp_InsertMarks
@MarkID INT,
@StudentID INT,
@ExamID INT,
@MarksObtained INT
AS
BEGIN

    BEGIN TRY

        IF @MarksObtained < 0 OR @MarksObtained > 100
        BEGIN
            RAISERROR('Invalid Marks',16,1);
            RETURN;
        END

        INSERT INTO Marks
        VALUES(@MarkID,@StudentID,@ExamID,@MarksObtained);

        PRINT 'Marks inserted successfully';

    END TRY

    BEGIN CATCH

        PRINT ERROR_MESSAGE();

    END CATCH

END;
GO



/* ============================================================
   Assignment 3 – Safe Delete Procedure
   ============================================================ */

GO
CREATE PROCEDURE sp_DeleteStudent
@StudentID INT
AS
BEGIN

    BEGIN TRY

        DELETE FROM Students
        WHERE StudentID=@StudentID;

        PRINT 'Student deleted successfully';

    END TRY

    BEGIN CATCH

        PRINT ERROR_MESSAGE();

    END CATCH

END;
GO




/* ============================================================
   CURSOR ASSIGNMENTS
   ============================================================ */


/* ============================================================
   Assignment 1 – Display Student Names using Cursor
   ============================================================ */

GO
CREATE PROCEDURE sp_DisplayStudentsCursor
AS
BEGIN

    DECLARE @StudentID INT
    DECLARE @StudentName VARCHAR(100)

    DECLARE student_cursor CURSOR FOR
    SELECT StudentID, FirstName + ' ' + LastName
    FROM Students;

    OPEN student_cursor

    FETCH NEXT FROM student_cursor INTO @StudentID,@StudentName

    WHILE @@FETCH_STATUS = 0
    BEGIN

        PRINT 'Student ID: ' + CAST(@StudentID AS VARCHAR)
        PRINT 'Student Name: ' + @StudentName

        FETCH NEXT FROM student_cursor INTO @StudentID,@StudentName

    END

    CLOSE student_cursor
    DEALLOCATE student_cursor

END;
GO



/* ============================================================
   Assignment 2 – Calculate Total Marks Per Student
   ============================================================ */

GO
CREATE PROCEDURE sp_CalculateStudentTotalMarks
AS
BEGIN

    DECLARE @StudentID INT
    DECLARE @Name VARCHAR(100)
    DECLARE @TotalMarks INT

    DECLARE student_cursor CURSOR FOR
    SELECT StudentID, FirstName+' '+LastName
    FROM Students;

    OPEN student_cursor

    FETCH NEXT FROM student_cursor INTO @StudentID,@Name

    WHILE @@FETCH_STATUS = 0
    BEGIN

        SELECT @TotalMarks = SUM(MarksObtained)
        FROM Marks
        WHERE StudentID=@StudentID;

        PRINT 'Student: ' + @Name
        PRINT 'Total Marks: ' + CAST(ISNULL(@TotalMarks,0) AS VARCHAR)

        FETCH NEXT FROM student_cursor INTO @StudentID,@Name

    END

    CLOSE student_cursor
    DEALLOCATE student_cursor

END;
GO



/* ============================================================
   Assignment 3 – Update Course Credits using Cursor
   ============================================================ */

GO
CREATE PROCEDURE sp_UpdateCourseCredits
AS
BEGIN

    DECLARE @CourseID INT
    DECLARE @Credits INT

    DECLARE course_cursor CURSOR FOR
    SELECT CourseID,Credits
    FROM Courses
    WHERE Credits < 3;

    OPEN course_cursor

    FETCH NEXT FROM course_cursor INTO @CourseID,@Credits

    WHILE @@FETCH_STATUS = 0
    BEGIN

        UPDATE Courses
        SET Credits = Credits + 1
        WHERE CourseID=@CourseID;

        FETCH NEXT FROM course_cursor INTO @CourseID,@Credits

    END

    CLOSE course_cursor
    DEALLOCATE course_cursor

END;
GO




/* ============================================================
   TRANSACTION ASSIGNMENTS
   ============================================================ */


/* ============================================================
   Assignment 1 – Student Enrollment Transaction
   ============================================================ */

GO
CREATE PROCEDURE sp_EnrollStudentTransaction
@EnrollmentID INT,
@StudentID INT,
@CourseID INT
AS
BEGIN

    BEGIN TRY

        BEGIN TRANSACTION

        INSERT INTO Enrollments
        VALUES(@EnrollmentID,@StudentID,@CourseID);

        COMMIT

        PRINT 'Enrollment successful';

    END TRY

    BEGIN CATCH

        ROLLBACK

        PRINT ERROR_MESSAGE();

    END CATCH

END;
GO



/* ============================================================
   Assignment 2 – Exam Marks Transaction
   ============================================================ */

GO
CREATE PROCEDURE sp_RecordExamMarks
@MarkID INT,
@StudentID INT,
@ExamID INT,
@Marks INT
AS
BEGIN

    BEGIN TRY

        BEGIN TRANSACTION

        INSERT INTO Marks
        VALUES(@MarkID,@StudentID,@ExamID,@Marks);

        UPDATE Exams
        SET ExamDate = GETDATE()
        WHERE ExamID=@ExamID;

        COMMIT

        PRINT 'Marks recorded successfully';

    END TRY

    BEGIN CATCH

        ROLLBACK

        PRINT ERROR_MESSAGE();

    END CATCH

END;
GO



/* ============================================================
   Assignment 3 – Department Transfer Transaction
   ============================================================ */

GO
CREATE PROCEDURE sp_TransferStudentDepartment
@StudentID INT,
@NewDepartmentID INT
AS
BEGIN

    BEGIN TRY

        BEGIN TRANSACTION

        IF NOT EXISTS(
            SELECT * FROM Departments
            WHERE DepartmentID=@NewDepartmentID
        )
        BEGIN

            RAISERROR('Department does not exist',16,1);

        END

        UPDATE Students
        SET DepartmentID=@NewDepartmentID
        WHERE StudentID=@StudentID;

        COMMIT

        PRINT 'Department transferred successfully';

    END TRY

    BEGIN CATCH

        ROLLBACK

        PRINT ERROR_MESSAGE();

    END CATCH

END;
GO