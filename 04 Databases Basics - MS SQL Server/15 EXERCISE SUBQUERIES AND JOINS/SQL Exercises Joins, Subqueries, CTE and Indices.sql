USE SOFTUNI

--Problem 1.	Employee Address

SELECT TOP (5) E.EmployeeID AS [EmployeeId],
		E.JobTitle AS [JobTitle],
		E.AddressID AS [AddressId],
		A.AddressText AS [AddressText]
FROM Employees AS E
JOIN Addresses AS A
ON E.AddressID=A.AddressID
ORDER BY E.AddressID

--Problem 2.	Addresses with Towns

SELECT TOP (50) E.FirstName AS [FirstName],
				E.LastName AS [LastName], 
				T.Name AS [Town], 
				A.AddressText AS [AddressText]
FROM Employees AS E
JOIN Addresses AS A
ON E.AddressID=A.AddressID
JOIN Towns AS T
ON A.TownID=T.TownID
ORDER BY E.FirstName , E.LastName 

--Problem 3.	Sales Employee

SELECT E.EmployeeID,
		E.FirstName,
		E.LastName,
		D.Name AS [DepartmentName]
FROM Employees AS E
JOIN Departments AS D
ON E.DepartmentID=D.DepartmentID
WHERE D.Name = 'Sales'
ORDER BY E.EmployeeID

--Problem 4.	Employee Departments

SELECT TOP (5) E.EmployeeID,
		E.FirstName,
		E.Salary,
		D.Name AS [DepartmentName]
FROM Employees AS E
JOIN Departments AS D
ON E.DepartmentID=D.DepartmentID
WHERE E.Salary>15000
ORDER BY E.DepartmentID

--Problem 5.	Employees Without Project

SELECT TOP (3) 
		E.EmployeeID,
		E.FirstName
FROM Employees AS E
LEFT OUTER JOIN EmployeesProjects AS EP
ON E.EmployeeID=EP.EmployeeID
LEFT OUTER  JOIN Projects AS P
ON EP.ProjectID=P.ProjectID
WHERE P.Name IS NULL
ORDER BY E.EmployeeID

--Problem 6.	Employees Hired After

SELECT 
		E.FirstName,
		E.LastName,
		E.HireDate,
		D.Name AS [DeptName]
FROM Employees AS E
JOIN Departments AS D
ON (E.DepartmentID = D.DepartmentID AND E.HireDate>'1/1/1999'
AND D.Name IN ('Sales','Finance'))
ORDER BY E.HireDate

--Problem 7.	Employees with Project

SELECT TOP (5)
		E.EmployeeID,
		E.FirstName,
		P.Name AS [ProjectName]
FROM Employees AS E
JOIN EmployeesProjects AS EP
ON E.EmployeeID= EP.EmployeeID
JOIN Projects AS P
ON (EP.ProjectID=P.ProjectID AND P.StartDate>'2002-08-13' AND P.EndDate IS NULL)
ORDER BY E.EmployeeID

--Problem 8.	Employee 24

SELECT 
		E.EmployeeID,
		E.FirstName,
		CASE
		WHEN DATEPART(YEAR, P.StartDate)>=2005 THEN NULL
		ELSE P.Name
		END AS [ProjectName]
FROM Employees AS E
JOIN EmployeesProjects AS EP
ON E.EmployeeID= EP.EmployeeID
JOIN Projects AS P
ON (EP.ProjectID=P.ProjectID AND E.EmployeeID=24)

--Problem 9.	Employee Manager

SELECT E.EmployeeID,
		E.FirstName,
		E.ManagerID,
		M.FirstName AS [ManagerName]
FROM Employees AS E
JOIN Employees AS M
ON E.ManagerID=M.EmployeeID
WHERE (E.ManagerID IN (3,7))
ORDER BY E.EmployeeID

--Problem 10.	Employee Summary

SELECT TOP (50)
		E.EmployeeID,
		E.FirstName+' '+E.LastName AS [EmployeeName],
		M.FirstName + ' '+M.LastName AS [ManagerName],
		D.Name AS [DepartmentName]
FROM Employees AS E
JOIN Employees AS M
ON E.ManagerID = M.EmployeeID
JOIN Departments AS D
ON E.DepartmentID=D.DepartmentID
ORDER BY E.EmployeeID

--Problem 11.	Min Average Salary

SELECT MIN([AvetageSalaries]) AS [MinAverageSalary]
FROM
(SELECT AVG(Salary) AS [AvetageSalaries]
FROM Employees
GROUP BY DepartmentID) AS AVGSalaries

USE Geography

--Problem 12.	Highest Peaks in Bulgaria

SELECT C.CountryCode,
		M.MountainRange,
		P.PeakName,
		P.Elevation
FROM Countries AS C
JOIN MountainsCountries AS MC
ON C.CountryCode=MC.CountryCode
JOIN Mountains AS M
ON MC.MountainId=M.Id
JOIN Peaks AS P
ON MC.MountainId=P.MountainId AND P.Elevation>2835 AND C.CountryCode='BG'
ORDER BY P.Elevation DESC

--Problem 13.	Count Mountain Ranges

SELECT CountryCode, COUNT(*) AS [MountainRanges]
FROM 
(SELECT C.CountryCode,
		M.MountainRange
FROM Countries AS C
JOIN MountainsCountries AS MC
ON C.CountryCode=MC.CountryCode AND C.COUNTRYCODE IN ('BG','RU','US')
JOIN Mountains AS M
ON MC.MountainId=M.Id) AS NT
GROUP BY CountryCode

--Problem 14.	Countries with Rivers

SELECT TOP(5)
		C.CountryName,
		R.RiverName
FROM Countries AS C
JOIN Continents AS CO
ON C.ContinentCode=CO.ContinentCode AND CO.ContinentName='Africa'
LEFT OUTER JOIN  CountriesRivers AS CR
ON C.CountryCode=CR.CountryCode
LEFT OUTER JOIN  Rivers AS R
ON CR.RiverId=R.Id
ORDER BY C.CountryName

--Problem 15.	*Continents and Currencies

SELECT NT2.ContinentCode, MT.CurrencyCode, NT2.CurrencyUsage
FROM
(
SELECT NT.ContinentCode, MAX(NT.CURRENCYCOUNT) AS [CurrencyUsage]
FROM 
(SELECT C.ContinentCode, C.CurrencyCode , COUNT(C.CurrencyCode) AS [CurrencyCount]
FROM Countries AS C
GROUP BY C.ContinentCode,C.CurrencyCode
HAVING   COUNT(C.CurrencyCode)>1) AS NT
GROUP BY NT.ContinentCode 
) AS NT2
JOIN (
SELECT C.ContinentCode, C.CurrencyCode , COUNT(C.CurrencyCode) AS [CurrencyCount]
FROM Countries AS C
GROUP BY C.ContinentCode,C.CurrencyCode
HAVING   COUNT(C.CurrencyCode)>1) AS MT
ON MT.ContinentCode=NT2.ContinentCode AND MT.CurrencyCount=NT2.CurrencyUsage
ORDER BY NT2.ContinentCode

--Problem 16.	Countries without any Mountains

SELECT COUNT(NT.CountryCode) AS [CountryCode]
FROM
(SELECT C.CountryCode, MC.MountainId
FROM Countries AS C 
LEFT OUTER JOIN MountainsCountries AS MC
ON C.CountryCode=MC.CountryCode) AS NT
WHERE NT.MountainId IS NULL

--Problem 17.	Highest Peak and Longest River by Country

SELECT TOP(5) NT.CountryName, MAX(NT.Elevation) AS [HighestPeakElevation], MAX(NT.Length) AS [LongestRiverLength]   
FROM
(SELECT C.CountryName, P.Elevation,R.Length
FROM Countries AS C
LEFT OUTER JOIN MountainsCountries AS MC
ON C.CountryCode = MC.CountryCode
LEFT OUTER JOIN Peaks AS P
ON P.MountainId=MC.MountainId
LEFT OUTER JOIN CountriesRivers AS CR
ON C.CountryCode=CR.CountryCode
LEFT OUTER JOIN Rivers AS R
ON R.Id=CR.RiverId) AS NT
GROUP BY NT.CountryName
ORDER BY MAX(NT.Elevation) DESC, MAX(NT.Length) DESC, NT.CountryName

--Problem 18.	* Highest Peak Name and Elevation by Country

SELECT TOP(5)
NT4.CountryName,
CASE 
WHEN NT4.HighestPeakName IS NULL THEN '(no highest peak)'
ELSE NT4.HighestPeakName
END AS [HighestPeakName],
CASE 
WHEN NT4.HighestPeakElevation IS NULL THEN 0
ELSE NT4.HighestPeakElevation
END AS [HighestPeakElevation],
CASE 
WHEN NT4.Mountain IS NULL THEN '(no mountain)'
ELSE NT4.Mountain
END AS [Mountain]
FROM
(SELECT NT2.CountryName,NT3.PeakName AS [HighestPeakName],NT2.HighestPeakElevation, NT3.MountainRange AS [Mountain]
FROM(
SELECT NT.CountryName, MAX(NT.Elevation) AS [HighestPeakElevation]
FROM
(SELECT C.CountryName, M.MountainRange, P.Elevation, P.PeakName
FROM Countries AS C
LEFT OUTER JOIN MountainsCountries AS MC
ON C.CountryCode=MC.CountryCode
LEFT OUTER JOIN Mountains AS M
ON MC.MountainId = M.Id
LEFT OUTER JOIN Peaks AS P
ON P.MountainId = M.Id) AS NT
GROUP BY NT.CountryName) AS NT2
LEFT OUTER JOIN  (SELECT C.CountryName, M.MountainRange, P.Elevation, P.PeakName
FROM Countries AS C
LEFT OUTER JOIN MountainsCountries AS MC
ON C.CountryCode=MC.CountryCode
LEFT OUTER JOIN Mountains AS M
ON MC.MountainId = M.Id
LEFT OUTER JOIN Peaks AS P
ON P.MountainId = M.Id)  AS NT3
ON NT2.HighestPeakElevation=NT3.Elevation AND NT2.CountryName = NT3.CountryName) AS NT4
ORDER BY NT4.CountryName, NT4.HighestPeakName