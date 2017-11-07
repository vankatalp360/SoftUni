
USE Gringotts 

SELECT *
FROM INFORMATION_SCHEMA.TABLES

--Problem 1.	Records’ Count

SELECT COUNT(*) AS [Count]
FROM WizzardDeposits

--Problem 2.	Longest Magic Wand

----EXEC sp_rename 'WizzardDeposits.LongestMagicWand', 'MagicWandSize', 'COLUMN'; 

----EXEC sp_rename 'WizzardDeposits.MagicWandSize', 'LongestMagicWand', 'COLUMN'; 



SELECT MAX(MagicWandSize) AS [LongestMagicWand]
FROM WizzardDeposits

----EXEC sp_rename 'WizzardDeposits.LongestMagicWand', 'MagicWandSize', 'COLUMN'; 

--Problem 3.	Longest Magic Wand per Deposit Groups

SELECT W. DepositGroup, 
 MAX(W.MagicWandSize) AS 'LongestMagicWand'
FROM WizzardDeposits AS W
GROUP BY W.DepositGroup


--Problem 4.	* Smallest Deposit Group per Magic Wand Size

SELECT W. DepositGroup
FROM WizzardDeposits AS W
GROUP BY W.DepositGroup
HAVING AVG(W.MagicWandSize)=(
SELECT MIN(WandSizeTable.AverageSizes) AS MinimalSize
FROM
(SELECT AVG(W.MagicWandSize) AS  AverageSizes
FROM WizzardDeposits AS W
GROUP BY W.DepositGroup) AS WandSizeTable)

--Problem 5.	Deposits Sum

SELECT W.DepositGroup,SUM(W.DepositAmount) AS [TotalSum]
FROM WizzardDeposits AS W
GROUP BY W.DepositGroup

--Problem 6.	Deposits Sum for Ollivander Family

--Problem 7.	Deposits Filter

SELECT  W.DepositGroup,SUM(W.DepositAmount) AS [TotalSum]
FROM WizzardDeposits AS W
WHERE W.MagicWandCreator LIKE 'Ollivander family'
GROUP BY W.DepositGroup
HAVING SUM(W.DepositAmount)<150000
ORDER BY TotalSum DESC


SELECT W. DepositGroup 
FROM WizzardDeposits AS W
GROUP BY W.DepositGroup
HAVING MIN(W.MagicWandSize)=(
SELECT MIN(WandSizeTable.MinSizes) AS MinimalSize
FROM
(SELECT MIN(W.MagicWandSize) AS  MinSizes,DepositGroup
FROM WizzardDeposits AS W
GROUP BY W.DepositGroup) AS WandSizeTable)

SELECT W. DepositGroup, MagicWandCreator,*
FROM WizzardDeposits AS W
WHERE DepositGroup='Blue Phoenix'

SELECT W.DepositGroup,W.MagicWandCreator,W.DepositCharge
FROM WizzardDeposits AS W
ORDER BY W.MagicWandCreator,W.DepositGroup

SELECT DepositGroup,MIN(W.DepositCharge) AS  MinDepositCharge
FROM WizzardDeposits AS W
GROUP BY W.DepositGroup


ORDER BY W.DepositGroup

SELECT W.DepositGroup,W.MagicWandCreator,W.DepositCharge
FROM WizzardDeposits AS W
WHERE W.DepositCharge=1

SELECT DepositGroup, MagicWandCreator, MIN(DepositCharge) AS MinDepositCharge 
FROM WizzardDeposits
GROUP BY DepositGroup, MagicWandCreator
ORDER BY MagicWandCreator, DepositGroup

SELECT DepositGroup, MagicWandCreator,DepositCharge 
FROM WizzardDeposits
WHERE MagicWandCreator='Antioch Peverell'
ORDER BY DepositGroup

SELECT DepositGroup, MagicWandCreator, DepositCharge
FROM WizzardDeposits
ORDER BY MagicWandCreator, DepositGroup

--Problem 8.	 Deposit Charge

SELECT DepositGroup, MagicWandCreator,DepositCharge
FROM WizzardDeposits
GROUP BY DepositGroup, MagicWandCreator,DepositCharge 
ORDER BY MagicWandCreator, DepositGroup


SELECT COUNT(Age) AS '[11-20]'
FROM WizzardDeposits AS W 
WHERE W.Age BETWEEN 11 AND 20

SELECT W. DepositGroup
FROM WizzardDeposits AS W
GROUP BY W.DepositGroup
HAVING AVG(W.MagicWandSize)=(
SELECT MIN(WandSizeTable.AverageSizes) AS MinimalSize
FROM
(SELECT AVG(W.MagicWandSize) AS  AverageSizes
FROM WizzardDeposits AS W
GROUP BY W.DepositGroup) AS WandSizeTable)


SELECT COUNT(Age)
FROM WizzardDeposits AS W 
WHERE W.Age BETWEEN 11 AND 20


SELECT 
	CASE 
		WHEN W.Age >=0 AND W.Age<=10 THEN '[0-10]'
		WHEN W.Age >=11 AND W.Age<=20 THEN '[11-20]'
		WHEN W.Age >=21 AND W.Age<=30 THEN '[21-30]'
		WHEN W.Age >=31 AND W.Age<=40 THEN '[31-40]'
		WHEN W.Age >=41 AND W.Age<=50 THEN '[41-50]'
		WHEN W.Age >=51 AND W.Age<=60 THEN '[51-60]'
		WHEN W.Age >=61  THEN '[61+]'
	END
AS [AgeGroup], COUNT(W.Age),Age
FROM WizzardDeposits AS W
GROUP BY Age

SELECT '[0-10]' AS [AgeGroup], COUNT(wd.id) AS [WizardCount]
	   FROM WizzardDeposits AS wd
	   WHERE wd.age BETWEEN 11 AND 20

--Problem 9.	Age Groups

SELECT 
	CASE
	  WHEN w.Age BETWEEN 0 AND 10 THEN '[0-10]'
	  WHEN w.Age BETWEEN 11 AND 20 THEN '[11-20]'
	  WHEN w.Age BETWEEN 21 AND 30 THEN '[21-30]'
	  WHEN w.Age BETWEEN 31 AND 40 THEN '[31-40]'
	  WHEN w.Age BETWEEN 41 AND 50 THEN '[41-50]'
	  WHEN w.Age BETWEEN 51 AND 60 THEN '[51-60]'
	  WHEN w.Age >= 61 THEN '[61+]'
	END AS [AgeGroup],
COUNT(*) AS [WizardCount]
	FROM WizzardDeposits AS w
GROUP BY CASE
	  WHEN w.Age BETWEEN 0 AND 10 THEN '[0-10]'
	  WHEN w.Age BETWEEN 11 AND 20 THEN '[11-20]'
	  WHEN w.Age BETWEEN 21 AND 30 THEN '[21-30]'
	  WHEN w.Age BETWEEN 31 AND 40 THEN '[31-40]'
	  WHEN w.Age BETWEEN 41 AND 50 THEN '[41-50]'
	  WHEN w.Age BETWEEN 51 AND 60 THEN '[51-60]'
	  WHEN w.Age >= 61 THEN '[61+]'
	END

	
--Problem 9.	Age Groups

ALTER FUNCTION ufn_GetAgeBoundaries(@Age INT)
RETURNS VARCHAR(10)
AS
BEGIN
	DECLARE @Result VARCHAR(10);
	DECLARE @Lb DECIMAL(10,2);
			SET @Lb = CONVERT(DECIMAL(10,2), @Age);
			IF (@Age<=0)
				RETURN NULL;
			IF(@Age<=60)
				SET @Result = '['+CAST((CEILING(@Lb/10)-1) AS VARCHAR(3)) +'1-'+CAST((CEILING(@Lb/10)) AS VARCHAR(3)) +'0]';
			ELSE 
				SET @Result='[61+]';
	RETURN @Result;
END

	
SELECT [dbo].[ufn_GetAgeBoundaries] (Age) AS [AgeGroup],COUNT(*) AS [WizardCount]
FROM WizzardDeposits
GROUP BY[dbo].[ufn_GetAgeBoundaries] (Age)

--Problem 10.	First Letter

SELECT SUBSTRING(W.FirstName,1,1) AS FirstLetter
FROM WizzardDeposits AS W
WHERE W.DepositGroup='Troll Chest'
GROUP BY SUBSTRING(W.FirstName,1,1)

--Problem 11.	Average Interest 

SELECT W. DepositGroup,W. IsDepositExpired,AVG(W.DepositInterest) AS [AverageInterest]
FROM WizzardDeposits AS W
WHERE W.DepositStartDate>='1985-01-01'
GROUP BY W.DepositGroup , W.IsDepositExpired
ORDER BY W.DepositGroup DESC, W.IsDepositExpired


SELECT *
FROM WizzardDeposits AS W

SELECT 
CASE
WHEN Id=1 THEN W.DepositAmount
ELSE (-1*W.DepositAmount)
END AS DepositesFirstAndLast
FROM WizzardDeposits AS W
WHERE Id=1 OR Id=(SELECT MAX(W.Id)
FROM WizzardDeposits AS W)

SELECT MAX(W.Id)
FROM WizzardDeposits AS W

SELECT SUM(WandSizeTable.AverageSizes) AS MinimalSize
FROM
(SELECT AVG(W.MagicWandSize) AS  AverageSizes
FROM WizzardDeposits AS W
GROUP BY W.DepositGroup) AS WandSizeTable

--Problem 12.	* Rich Wizard, Poor Wizard

SELECT SUM(WandDepositTable.DepositesFirstAndLast) AS SumDifference
FROM
(SELECT 
CASE
WHEN Id=1 THEN W.DepositAmount
ELSE (-1*W.DepositAmount)
END AS DepositesFirstAndLast
FROM WizzardDeposits AS W
WHERE Id=1 OR Id=(SELECT MAX(W.Id)
FROM WizzardDeposits AS W)) AS WandDepositTable

USE SoftUni

SELECT *
FROM INFORMATION_SCHEMA.TABLES
WHERE TABLE_CATALOG LIKE 'SoftUni'

SELECT *
FROM Employees

--Problem 13.	Departments Total Salaries

SELECT DepartmentID, SUM(E.Salary) AS [TotalSalary]
FROM Employees AS E
GROUP BY E.DepartmentID
ORDER BY E.DepartmentID

--Problem 14.	Employees Minimum Salaries

SELECT DepartmentID,MIN(E.Salary) AS [MinimumSalary]
FROM Employees AS E
WHERE E.DepartmentID IN (2,5,7) AND E.HireDate>='2000-01-01'
GROUP BY E.DepartmentID

--Problem 15.	Employees Average Salaries

SELECT *
INTO NewTable
FROM Employees AS E
WHERE E.Salary>30000

DELETE FROM NewTable
WHERE ManagerID=42

UPDATE NewTable
SET Salary+=5000
WHERE DepartmentID=1

SELECT DepartmentID, AVG(Salary) AS [AverageSalary]
FROM NewTable
GROUP BY DepartmentID

DROP TABLE NewTable

--Problem 16.	Employees Maximum Salaries

SELECT E.DepartmentID AS [DepartmentID], MAX(E.Salary) AS [MaxSalary]
FROM Employees AS E
GROUP BY E.DepartmentID
HAVING MAX(E.Salary) NOT BETWEEN 30000 AND 70000

--Problem 17.	Employees Count Salaries

SELECT COUNT(*) AS [Count]
FROM Employees
WHERE ManagerID IS NULL

--Problem 18.	*3rd Highest Salary

SELECT E.DepartmentID, MIN(E.Salary) AS [ThirdHighestSalary]
FROM Employees AS E
WHERE (
   SELECT count(*) 
   FROM Employees as M
   WHERE
		M.DepartmentID = E.DepartmentID AND M.Salary <= E.Salary
) <= 3
GROUP BY E.DepartmentID

--Problem 18.	*3rd Highest Salary

SELECT DepartmentID, 
(SELECT DISTINCT Salary 
FROM Employees 
WHERE DepartmentID = e.DepartmentID 
ORDER BY Salary DESC 
OFFSET 2 ROWS FETCH NEXT 1 ROWS ONLY) AS ThirdHighestSalary
FROM Employees AS e
WHERE (SELECT DISTINCT Salary 
FROM Employees 
WHERE DepartmentID = e.DepartmentID 
ORDER BY Salary DESC 
OFFSET 2 ROWS FETCH NEXT 1 ROWS ONLY) IS NOT NULL
GROUP BY DepartmentID

--Problem 19.	**Salary Challenge

SELECT  E.FirstName, E.LastName, E.DepartmentID
FROM Employees AS E
WHERE E.Salary> (
SELECT AVG(E2.Salary)
FROM Employees AS E2
WHERE E2.DepartmentID=E.DepartmentID
)
ORDER BY E.DepartmentID



