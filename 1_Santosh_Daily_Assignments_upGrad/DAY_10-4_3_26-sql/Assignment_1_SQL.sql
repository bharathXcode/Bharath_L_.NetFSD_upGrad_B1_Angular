-- creating a Database for Assignment (04/03/26)
CREATE DATABASE AssignmentDB;

-- Switch to the AssignmentDB database
USE AssignmentDB;

-----------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------

-- Creating Worker Table
CREATE TABLE Worker (
    WORKER_ID INT PRIMARY KEY IDENTITY(1,1),
    FIRST_NAME VARCHAR(25),
    LAST_NAME VARCHAR(25),
    SALARY INT,
    JOINING_DATE DATETIME,
    DEPARTMENT CHAR(25)
);

-- Creating Bonus Table
CREATE TABLE Bonus (
    WORKER_REF_ID INT,
    BONUS_AMOUNT INT,
    BONUS_DATE DATETIME,
    FOREIGN KEY (WORKER_REF_ID)
    REFERENCES Worker(WORKER_ID)
    ON DELETE CASCADE
);

-- Creating Title Table
CREATE TABLE Title (
    WORKER_REF_ID INT,
    WORKER_TITLE CHAR(25),
    AFFECTED_FROM DATETIME,
    FOREIGN KEY (WORKER_REF_ID)
    REFERENCES Worker(WORKER_ID)
    ON DELETE CASCADE
);

---------------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------

-- Inserting sample data into Worker table
SET IDENTITY_INSERT Worker ON;

INSERT INTO Worker (WORKER_ID,FIRST_NAME,LAST_NAME,SALARY,JOINING_DATE,DEPARTMENT) VALUES
(1,'Monika','Arora',100000,'2014-02-20 09:00:00','HR'),
(2,'Niharika','Verma',80000,'2014-06-11 09:00:00','Admin'),
(3,'Vishal','Singhal',300000,'2014-02-20 09:00:00','HR'),
(4,'Amitabh','Singh',500000,'2014-02-20 09:00:00','Admin'),
(5,'Vivek','Bhati',500000,'2014-06-11 09:00:00','Admin'),
(6,'Vipul','Diwan',200000,'2014-06-11 09:00:00','Account'),
(7,'Satish','Kumar',75000,'2014-01-20 09:00:00','Account'),
(8,'Geetika','Chauhan',90000,'2014-04-11 09:00:00','Admin');

SET IDENTITY_INSERT Worker OFF;

-- Inserting data into Bonus table
INSERT INTO Bonus VALUES
(1,5000,'2016-02-20'),
(2,3000,'2016-06-11'),
(3,4000,'2016-02-20'),
(1,4500,'2016-02-20'),
(2,3500,'2016-06-11');

-- Inserting data into Title table
INSERT INTO Title VALUES
(1,'Manager','2016-02-20'),
(2,'Executive','2016-06-11'),
(8,'Executive','2016-06-11'),
(5,'Manager','2016-06-11'),
(4,'Asst. Manager','2016-06-11'),
(7,'Executive','2016-06-11'),
(6,'Lead','2016-06-11'),
(3,'Lead','2016-06-11');

----------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------

-- 1. Write an SQL query to fetch FIRST_NAME from Worker table using alias WORKER_NAME.
SELECT FIRST_NAME AS WORKER_NAME
FROM Worker;

-- 2. Write an SQL query to fetch FIRST_NAME from Worker table in upper case.
SELECT UPPER(FIRST_NAME) AS fname_Upper
FROM Worker;

-- 3. Write an SQL query to fetch unique values of DEPARTMENT from Worker table.
SELECT DISTINCT DEPARTMENT
FROM Worker;

-- 4. Write an SQL query to print first three characters of FIRST_NAME.
SELECT SUBSTRING(FIRST_NAME,1,3) AS fname_3char
FROM Worker;

-- 5. Write an SQL query to find position of alphabet 'a' in 'Amitabh'.
SELECT CHARINDEX('a','Amitabh') AS POSITION;

-- 6. Write an SQL query to print FIRST_NAME after removing right side spaces. ***
SELECT RTRIM(FIRST_NAME)
FROM Worker;

-- 7. Write an SQL query to print DEPARTMENT after removing left side spaces.  ***
SELECT LTRIM(DEPARTMENT)
FROM Worker;

-- 8. Write an SQL query that fetches unique DEPARTMENT values and their length.
SELECT DISTINCT DEPARTMENT, LEN(DEPARTMENT) AS LENGTH
FROM Worker;

-- 9. Write an SQL query to replace 'a' with 'A' in FIRST_NAME.
SELECT REPLACE(FIRST_NAME,'a','A')
FROM Worker;

-- 10. Write an SQL query to print FIRST_NAME and LAST_NAME as COMPLETE_NAME.
SELECT FIRST_NAME + ' ' + LAST_NAME AS COMPLETE_NAME
FROM Worker;

-- 11. Write an SQL query to print all Worker details ordered by FIRST_NAME ascending.
SELECT *
FROM Worker
ORDER BY FIRST_NAME ASC;

-- 12. Write an SQL query to print Worker details ordered by FIRST_NAME ASC and DEPARTMENT DESC.
SELECT *
FROM Worker
ORDER BY FIRST_NAME ASC, DEPARTMENT DESC;

-- 13. Write an SQL query to print details for workers with FIRST_NAME 'Vipul' and 'Satish'.
SELECT *
FROM Worker
WHERE FIRST_NAME IN ('Vipul','Satish');


-- 14. Write an SQL query to print details excluding FIRST_NAME 'Vipul' and 'Satish'.
SELECT *
FROM Worker
WHERE FIRST_NAME NOT IN ('Vipul','Satish');


-- 15. Write an SQL query to print workers with DEPARTMENT 'Admin'.
SELECT *
FROM Worker
WHERE DEPARTMENT='Admin';


-- 16. Write an SQL query to print workers whose FIRST_NAME contains 'a'.
SELECT *
FROM Worker
WHERE FIRST_NAME LIKE '%a%';


-- 17. Write an SQL query to print workers whose FIRST_NAME ends with 'a'.
SELECT *
FROM Worker
WHERE FIRST_NAME LIKE '%a';


-- 18. Write an SQL query to print workers whose FIRST_NAME ends with 'h' and has six letters.
SELECT *
FROM Worker
WHERE FIRST_NAME LIKE '_____h';


-- 19. Write an SQL query to print workers whose SALARY lies between 100000 and 500000.
SELECT *
FROM Worker
WHERE SALARY BETWEEN 100000 AND 500000;


-- 20. Write an SQL query to print workers who joined in Feb 2014.
SELECT *
FROM Worker
WHERE YEAR(JOINING_DATE)=2014
AND MONTH(JOINING_DATE)=2;

-- 21. Write an SQL query to fetch worker names with salary between 50000 and 100000.
SELECT FIRST_NAME, SALARY
FROM Worker
WHERE SALARY BETWEEN 50000 AND 100000;


-- 22. Write an SQL query to fetch number of workers for each department in descending order.
SELECT DEPARTMENT, COUNT(*) AS TOTAL_WORKERS
FROM Worker
GROUP BY DEPARTMENT
ORDER BY TOTAL_WORKERS DESC;


-- 23. Write an SQL query to print details of workers who are Managers.
SELECT W.*
FROM Worker W
JOIN Title T
ON W.WORKER_ID = T.WORKER_REF_ID
WHERE T.WORKER_TITLE='Manager';


-- 24. Write an SQL query to show current date and time.
SELECT GETDATE() AS CURRENT_DATE_TIME;


-- 25. Write an SQL query to show top 10 records from a table.
SELECT TOP 10 *
FROM Worker;

