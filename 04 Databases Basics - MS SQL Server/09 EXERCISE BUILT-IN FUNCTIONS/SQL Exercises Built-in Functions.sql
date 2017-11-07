--Exercises: Built-in Functions

USE SoftUni

--Problem 1.	Find Names of All Employees by First Name

SELECT FirstName, LastName 
FROM Employees
WHERE FirstName LIKE 'SA%'

--Problem 2.	  Find Names of All employees by Last Name 

SELECT FirstName, LastName 
FROM Employees
WHERE LastName LIKE '%ei%'

--Problem 3.	Find First Names of All Employees

SELECT FirstName
FROM Employees
WHERE DepartmentID IN (3,10) AND YEAR(HireDate) >=1995 AND YEAR(HireDate)<=2005

--Problem 4.	Find All Employees Except Engineers

SELECT FirstName, LastName 
FROM Employees
WHERE JobTitle NOT LIKE '%engineer%'

--Problem 5.	Find Towns with Name Length

SELECT [Name]
FROM Towns
WHERE LEN(Towns.Name) IN (5,6)
ORDER BY [Name]

--Problem 6.	 Find Towns Starting With

SELECT *
FROM Towns
WHERE LEFT([Name],1) IN ('M','K','B','E')
ORDER BY [Name]

--Problem 7.	 Find Towns Not Starting With

SELECT *
FROM Towns
WHERE LEFT([Name],1) NOT IN ('R','B','D')
ORDER BY [Name]

--Problem 8.	Create View Employees Hired After 2000 Year

CREATE VIEW V_EmployeesHiredAfter2000 AS
SELECT FirstName, LastName FROM Employees
WHERE YEAR(HireDate)>2000

--Problem 9.	Length of Last Name

SELECT FirstName, LastName 
FROM Employees
WHERE LEN(LastName)=5


--Part II – Queries for Geography Database 

USE Geography

--Problem 10.	Countries Holding ‘A’ 3 or More Times

SELECT CountryName,IsoCode
FROM Countries
WHERE LEN(UPPER(CountryName))-LEN(REPLACE(UPPER(CountryName),'A',''))>=3
ORDER BY IsoCode

--Problem 11.	 Mix of Peak and River Names

SELECT PeakName,RiverName,CONCAT(LOWER(PeakName), SUBSTRING(LOWER(RiverName), 2, LEN(RiverName)))
    AS [Mix]
FROM Peaks
JOIN Rivers ON LEFT(RiverName,1)=RIGHT(Peaks.PeakName,1)
ORDER BY Mix

--Part III – Queries for Diablo Database

USE Diablo

--Problem 12.	Games from 2011 and 2012 year

SELECT TOP(50) [Name] AS Game,  FORMAT([Start], 'yyyy-MM-dd')
AS [Start]
FROM Games
WHERE YEAR([Start]) IN (2011,2012)
ORDER BY [Start], Game

--Problem 13.	 User Email Providers

SELECT  Username,SUBSTRING(Email,CHARINDEX('@',Email,0)+1,LEN(Email)) AS [Email Provider]
FROM Users
ORDER BY [Email Provider],Username

--Problem 14.	 Get Users with IPAdress Like Pattern

SELECT  Username,IpAddress
FROM Users
WHERE [IpAddress] LIKE '___.1_%._%.___'
ORDER BY Username

--Problem 15.	 Show All Games with Duration and Part of the Day

SELECT G.Name,
    CASE
        WHEN (DATEPART(HOUR, G.Start)) BETWEEN 0 AND 11 THEN 'Morning'
        WHEN (DATEPART(HOUR, G.Start)) BETWEEN 12 AND 17 THEN 'Afternoon'
        WHEN (DATEPART(HOUR, G.Start)) BETWEEN 18 AND 23 THEN 'Evening'
    END AS [Part of Day],
    CASE
        WHEN G.Duration <= 3 THEN 'Extra Short'
        WHEN G.Duration BETWEEN 4 AND 6 THEN 'Short'
        WHEN G.Duration IS NULL THEN 'Extra Long'
        ELSE 'Long'
    END AS [Duration]
FROM Games AS G
ORDER BY G.Name ASC,
    [Duration],
    [Part of Day]

--Part IV – Date Functions Queries
	
USE Orders;

--Problem 16.	 Orders Table

SELECT ProductName,OrderDate,DATEADD(DAY,3,OrderDate) AS [Pay Due], DATEADD(MONTH,1,OrderDate) AS [Deliver Due]
FROM Orders
