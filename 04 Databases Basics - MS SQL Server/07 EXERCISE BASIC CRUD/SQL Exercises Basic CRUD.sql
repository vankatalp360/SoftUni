--1.	Examine the Databases

--Part I – Queries for SoftUni Database
use softuni

--2.	Find All Information About Departments

SELECT * FROM Departments
GO

--3.	Find all Department Names

SELECT [Name] FROM Departments
GO

--4.	Find Salary of Each Employee

SELECT [FirstName],[LastName],[Salary] FROM Employees

--5.	Find Full Name of Each Employee

SELECT FirstName,MiddleName,LastName FROM Employees

--6.	Find Email Address of Each Employee

SELECT FirstName+'.'+LastName+'@softuni.bg' AS [Full Email Address] FROM Employees

--7.	Find All Different Employee’s Salaries

SELECT DISTINCT Salary FROM Employees
ORDER BY Salary

--8.	Find all Information About Employees

SELECT EmployeeID AS ID,FirstName AS [FirstName] ,
LastName AS [LastName],
MiddleName AS [MiddleName],
JobTitle AS [JobTitle],
DepartmentID AS [DeptID],
ManagerID AS [MngrID],
HireDate AS [HireDate],
Salary,
AddressID
FROM Employees

--9.	Find Names of All Employees by Salary in Range

SELECT FirstName+' '+MiddleName+' '+LastName AS [Full Name] FROM Employees
WHERE Salary=25000 OR Salary=14000 OR Salary=12500 OR Salary=23600

--10.	 Find Names of All Employees 

SELECT FirstName+' '+MiddleName+' '+LastName AS [Full Name] FROM Employees
WHERE Salary IN (25000,14000,12500,23600)

--11.	 Find All Employees Without Manager


  SELECT FirstName,LastName
FROM Employees
WHERE ManagerID IS NULL

SELECT FirstName, LastName 
FROM Employees
WHERE JobTitle NOT LIKE '%manager%'

--12.	 Find All Employees with Salary More Than 50000

SELECT FirstName,LastName,Salary
FROM Employees
WHERE Salary>50000
ORDER BY Salary DESC

--13.	 Find 5 Best Paid Employees.

SELECT TOP(5) FirstName,LastName
FROM Employees
ORDER BY Salary DESC

--14.	Find All Employees Except Marketing

SELECT FirstName,LastName
FROM Employees
WHERE DepartmentID NOT LIKE 4

--15.	Sort Employees Table

SELECT *
FROM Employees
ORDER BY Salary DESC, FirstName , LastName DESC, MiddleName 

--16.	 Create View Employees with Salaries

CREATE VIEW V_EmployeesSalaries  AS
  SELECT FirstName, LastName, Salary FROM Employees
  go

  --17.	Create View Employees with Job Titles

CREATE VIEW V_EmployeeNameJobTitle AS
SELECT FirstName + ' ' + ISNULL(MiddleName, '') + ' ' + LastName AS [Full Name], JobTitle 
FROM Employees

--18.	 Distinct Job Titles

CREATE VIEW V_EmployeeNameJobTitle AS
SELECT FirstName+' '+
    CASE
        WHEN MiddleName IS NULL THEN ' '+LastName
        ELSE MiddleName+' '+LastName
    END
AS [Full Name], JobTitle FROM Employees

  DROP VIEW V_EmployeeNameJobTitle

  SELECT DISTINCT JobTitle
FROM Employees

--19.	Find First 10 Started Projects

	  SELECT TOP (10) * 
	FROM Projects
	ORDER BY StartDate, [Name]

--20.	 Last 7 Hired Employees

SELECT TOP (7) FirstName,LastName,HireDate 
FROM Employees
ORDER BY HireDate DESC

--21.	Increase Salaries

  SELECT * 
FROM Employees WHERE JobTitle LIKE '%Engineering%' 
OR JobTitle LIKE'%Tool Design%' 
OR JobTitle LIKE'%Marketing%' 
OR JobTitle LIKE'%Information Services%'

UPDATE Employees
   SET Salary *= 1.12
 WHERE DepartmentID IN 
	(SELECT DepartmentID 
	   FROM Departments
	  WHERE [Name] IN 
		('Engineering', 'Tool Design', 'Marketing', 'Information Services'))
						
SELECT Salary 
  FROM Employees

--Part II – Queries for Geography Database

--22.	 All Mountain Peaks

  SELECT PeakName 
  FROM Peaks
  ORDER BY PeakName

--23.	 Biggest Countries by Population

    SELECT TOP (30) CountryName,[Population]
  FROM Countries
  WHERE ContinentCode LIKE 'EU'
  ORDER BY Population DESC

--24.	 *Countries and Currency (Euro / Not Euro)

   SELECT CountryName,CountryCode, 
   CASE 
   WHEN CurrencyCode LIKE 'EUR' THEN 'Euro'
   ELSE
   'Not Euro'
   END
   AS CurrencyCode
   FROM Countries
   ORDER BY CountryName

    SELECT CountryName,CurrencyCode 
  FROM Countries
  WHERE CurrencyCode LIKE 'EUR'


--Part III – Queries for Diablo Database

use Diablo

--25.	 All Diablo Characters

      SELECT [Name]
  FROM Characters
  ORDER BY [Name]

        SELECT *
  FROM Characters
