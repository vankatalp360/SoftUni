
--Part I – Queries for SoftUni Database

USE SoftUni

--Problem 1.	Employees with Salary Above 35000

CREATE PROCEDURE usp_GetEmployeesSalaryAbove35000 AS 
BEGIN
SELECT FirstName AS [First Name],LastName AS [Last Name]
FROM Employees
WHERE Salary>35000
END

--Problem 2.	Employees with Salary Above Number

CREATE PROCEDURE usp_GetEmployeesSalaryAboveNumber(@NUMBER DECIMAL(18,4))  AS 
BEGIN
SELECT FirstName AS [First Name],LastName AS [Last Name]
FROM Employees
WHERE Salary>=@NUMBER
END


--Problem 3.	Town Names Starting With

CREATE PROCEDURE usp_GetTownsStartingWith (@STRING NVARCHAR(50))  AS 
BEGIN
SELECT Name AS [Town]
FROM Towns
WHERE Name LIKE @STRING+'%'
END


--Problem 4.	Employees from Town

CREATE PROCEDURE usp_GetEmployeesFromTown  (@townName NVARCHAR(50))  AS 
BEGIN
SELECT E.FirstName AS [First Name],E.LastName AS [Last Name]
FROM Towns AS T
JOIN Addresses AS A
ON A.TownID=T.TownID
JOIN Employees AS E
ON E.AddressID=A.AddressID
WHERE T.Name LIKE @townName
END

--Problem 5.	Salary Level Function

CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))  
RETURNS VARCHAR(10)
AS
  BEGIN
    DECLARE @Result VARCHAR(10)
    SET @Result = 
CASE
WHEN @salary<30000 THEN 'Low'
WHEN @salary BETWEEN 30000 AND 50000 THEN 'Average'
WHEN @salary>50000 THEN 'High'
END
    RETURN @Result
  END


--Problem 6.	Employees by Salary Level

CREATE PROCEDURE usp_EmployeesBySalaryLevel   (@SalaryLevel VARCHAR(10))  AS 
BEGIN
SELECT E.FirstName AS [First Name],E.LastName AS [Last Name]
FROM Employees AS E
WHERE [dbo].[ufn_GetSalaryLevel](e.Salary) LIKE @SalaryLevel
END


--Problem 7.	Define Function

CREATE FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(50), @word VARCHAR(50))  
RETURNS BIT
AS
  BEGIN
    DECLARE @Result BIT;
	SET @Result = 1;
	DECLARE @Index INT;
	SET @Index=1;
	DECLARE @Lenght INT;
	SET @Lenght=LEN(@word);
	WHILE @Index <= @Lenght
		BEGIN
			DECLARE @Current INT;
			DECLARE @CurrentChar CHAR(1);
			SET @CurrentChar = SUBSTRING(@word,@Index,1);
			SET @Current = (SELECT CHARINDEX(@CurrentChar, @setOfLetters));  
			IF @Current=0 
				SET @Result=0;
			ELSE
			SET @Index = @Index + 1
			IF (@Result=0) BREAK
		END;
    RETURN @Result;
  END


--Problem 8.	* Delete Employees and Departments

CREATE OR ALTER PROC usp_DeleteEmployeesFromDepartment (@departmentId INT) 
AS
BEGIN
	BEGIN TRANSACTION
	ALTER TABLE Departments
		ALTER COLUMN ManagerID INT NULL

	DELETE FROM EmployeesProjects
		WHERE EmployeeID IN (SELECT EmployeeID
								FROM Employees
								WHERE DepartmentID = @departmentId)
		ALTER TABLE Employees
				DROP CONSTRAINT FK_Employees_Departments
		ALTER TABLE Employees
				DROP CONSTRAINT FK_Employees_Employees
		ALTER TABLE Departments
				DROP CONSTRAINT FK_Departments_Employees

	ALTER TABLE Employees
		ALTER COLUMN ManagerID INT NULL
	
	DELETE FROM Employees
		WHERE DepartmentID = @departmentId
	
	DELETE FROM Departments
		WHERE DepartmentID = @departmentId
	IF @@ROWCOUNT <> 1
		BEGIN
		  ROLLBACK;
		  RAISERROR('Invalid account!', 16, 1)
		  RETURN
		END
	SELECT COUNT(*)
		FROM Employees
		WHERE DepartmentID = @departmentId
	ROLLBACK;
END  


EXEC [dbo].usp_DeleteEmployeesFromDepartment 1

SELECT *
FROM Departments


--Problem 8.	* Delete Employees and Departments -- SECOND SOLUTION

CREATE OR ALTER PROC usp_DeleteEmployeesFromDepartment (@departmentId INT) 
AS
BEGIN
	BEGIN TRANSACTION

	ALTER TABLE Departments
		ALTER COLUMN ManagerID INT NULL

	ALTER TABLE Employees
		ALTER COLUMN DepartmentID INT NULL

	DELETE EmployeesProjects
		FROM EmployeesProjects AS EP
		INNER JOIN Employees AS E
		ON EP.EmployeeID=E.EmployeeID
		INNER JOIN Departments AS D
		ON D.DepartmentID=E.DepartmentID
			WHERE D.DepartmentID = @departmentId

	UPDATE Departments SET ManagerID = NULL WHERE DepartmentID = @departmentId

	UPDATE Employees SET DepartmentID = NULL WHERE DepartmentID = @departmentId

	DELETE Employees
		FROM Employees AS E
		INNER JOIN Departments AS D
		ON D.DepartmentID=E.DepartmentID
			WHERE D.DepartmentID = @departmentId


	DELETE Departments
			WHERE DepartmentID = @departmentId
	

	SELECT COUNT(*)
		FROM Employees
			WHERE DepartmentID = @departmentId
	ROLLBACK;
END  

EXEC [dbo].usp_DeleteEmployeesFromDepartment 1



--PART II – Queries for Bank Database

USE Bank

--Problem 9.	Find Full Name

CREATE PROC usp_GetHoldersFullName 
AS 
BEGIN
SELECT FirstName+' '+LastName as [Full Name]
FROM AccountHolders
END

EXEC usp_GetHoldersFullName

GO


--Problem 10.	People with Balance Higher Than

CREATE PROC usp_GetHoldersWithBalanceHigherThan (@sum MONEY)
AS
BEGIN
		SELECT FirstName AS [First Name], LastName AS [Last Name] FROM
	(
		SELECT FirstName, LastName, SUM(a.Balance) AS TotalBalance FROM AccountHolders AS ah
		JOIN Accounts AS a
		ON a.AccountHolderId = ah.Id
		GROUP BY ah.FirstName, ah.LastName
	) AS tb
	WHERE tb.TotalBalance > @sum
END

EXEC usp_GetHoldersWithBalanceHigherThan 100.55

GO


--Problem 11.	Future Value Function
CREATE OR ALTER FUNCTION ufn_CalculateFutureValue (@Sum MONEY, @YearlyInterestRate FLOAT, @NumberOfYears INT)
RETURNS MONEY
AS
BEGIN
	DECLARE @Result MONEY = @Sum*POWER ((1+@YearlyInterestRate),@NumberOfYears) ;
	RETURN @Result;
END

SELECT DBO.ufn_CalculateFutureValue(1000, 0.11111, 5)


--Problem 12.	Calculating Interest

CREATE OR ALTER PROC usp_CalculateFutureValueForAccount (@AccountId INT , @InterestRate FLOAT)
AS 
BEGIN
	SELECT 
		AH.Id, 
		AH.FirstName, 
		AH.LastName, 
		A.Balance AS [Current Balance],
		[dbo].ufn_CalculateFutureValue(A.Balance, @InterestRate, 5) AS [Balance in 5 years]
	FROM AccountHolders AS AH
	JOIN Accounts AS A
	ON AH.Id=A.AccountHolderId
	WHERE A.Id = @AccountId
END

exec usp_CalculateFutureValueForAccount 1,0.1

--PART III – Queries for Diablo Database

USE Diablo

--Problem 13.	*Scalar Function: Cash in User Games Odd Rows

SELECT *
FROM INFORMATION_SCHEMA.TABLES

go

CREATE OR ALTER FUNCTION ufn_CashInUsersGames (@GameName nvarchar(50))
RETURNS @rtnTable TABLE 
( 
-- columns returned by the function
SumCash MONEY
)
AS
BEGIN
		DECLARE @SumCash MONEY = (SELECT SUM(SortUG.Cash) AS [SumCash]
		FROM (SELECT Cash, ROW_NUMBER() OVER (ORDER BY Cash DESC) AS RoWNum
					FROM UsersGames AS UG
					JOIN Games AS G
					ON G.Id=UG.GameID
					WHERE G.Name  LIKE @GameName) AS SortUG
					WHERE SortUG.RoWNum%2=1)
		INSERT  @rtnTable SELECT @SumCash
		RETURN
END

SELECT * FROM  [dbo].ufn_CashInUsersGames ('Lily Stargazer')

SELECT * FROM  [dbo].ufn_CashInUsersGames ('Love in a mist')


SELECT *  INTO TestTable FROM [dbo].ufn_CashInUsersGames ('Lily Stargazer') 

SELECT *
FROM TESTTABLE

DROP TABLE TestTable




