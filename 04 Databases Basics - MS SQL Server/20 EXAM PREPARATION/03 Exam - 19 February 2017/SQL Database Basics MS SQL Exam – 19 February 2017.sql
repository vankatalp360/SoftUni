--Database Basics MS SQL Exam – 19 Feb 2017
use master 
drop database Bakery
CREATE DATABASE Bakery

USE Bakery

--Section 1. DDL (25 pts)

--1.	Database design

CREATE TABLE Products
(
Id INT PRIMARY KEY IDENTITY,
Name NVARCHAR(25) UNIQUE,
Description NVARCHAR(250),
Recipe NVARCHAR(MAX),
Price MONEY,
CONSTRAINT udc_PositivePrice CHECK (Price>=0)
)

CREATE TABLE Countries
(
Id INT PRIMARY KEY IDENTITY,
Name NVARCHAR(50) UNIQUE
)


CREATE TABLE Customers
(
Id INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(25),
LastName NVARCHAR(25),
Gender CHAR(1),
CONSTRAINT udc_Gender CHECK (Gender IN ('M' , 'F')),
Age INT,
CONSTRAINT udc_Age CHECK (Age >=0),
PhoneNumber CHAR(10),
CountryId INT FOREIGN KEY REFERENCES Countries(Id)
)

CREATE TABLE Feedbacks
(
Id INT PRIMARY KEY IDENTITY,
Description NVARCHAR(255),
Rate DECIMAL(10,2),
CONSTRAINT udc_Rate CHECK (Rate BETWEEN 0 AND 10),
ProductId INT FOREIGN KEY REFERENCES Products(Id),
CustomerId INT FOREIGN KEY REFERENCES Customers(Id)
)

CREATE TABLE Distributors
(
Id INT PRIMARY KEY IDENTITY,
Name NVARCHAR(25) UNIQUE,
AddressText NVARCHAR(30),
Summary NVARCHAR(200),
CountryId INT FOREIGN KEY REFERENCES Countries(Id)
)

CREATE TABLE Ingredients
(
Id INT PRIMARY KEY IDENTITY,
Name NVARCHAR(30),
Description NVARCHAR(200),
OriginCountryId INT FOREIGN KEY REFERENCES Countries(Id),
DistributorId INT FOREIGN KEY REFERENCES Distributors(Id)
)

CREATE TABLE ProductsIngredients
(
ProductId INT NOT NULL,
IngredientId INT NOT NULL,
CONSTRAINT PK_ProductsIngredients_ProductId_IngredientId PRIMARY KEY (ProductId, IngredientId),
CONSTRAINT FK_ProductsIngredients_Products FOREIGN KEY (ProductId) REFERENCES Products(Id),
CONSTRAINT FK_ProductsIngredients_Ingredients FOREIGN KEY (IngredientId) REFERENCES Ingredients(Id)
)

--2.	Insert

INSERT INTO Distributors(Name, CountryId,AddressText,Summary)
VALUES
('Deloitte & Touche','2','6 Arch St #9757','Customizable neutral traveling'),
('Congress Title','13','58 Hancock St','Customer loyalty'),
('Kitchen People','1','3 E 31st St #77','Triple-buffered stable delivery'),
('General Color Co Inc','21','6185 Bohn St #72','Focus group'),
('Beck Corporation','23','21 E 64th Ave','Quality-focused 4th generation hardware')

INSERT INTO Customers(FirstName, LastName,Age,Gender,PhoneNumber,CountryId)
VALUES
('Francoise','Rautenstrauch','15','M','0195698399','5'),
('Kendra','Loud','22','F','0063631526','11'),
('Lourdes','Bauswell','50','M','0139037043','8'),
('Hannah','Edmison','18','F','0043343686','1'),
('Tom','Loeza','31','M','0144876096','23'),
('Queenie','Kramarczyk','30','F','0064215793','29'),
('Hiu','Portaro','25','M','0068277755','16'),
('Josefa','Opitz','43','F','0197887645','17')

--3.	Update

UPDATE Ingredients 
SET DistributorId =35
WHERE Name IN ('Bay Leaf', 'Paprika' , 'Poppy') 

UPDATE Ingredients 
SET OriginCountryId =14
WHERE OriginCountryId =8

--4.	Delete

DELETE
FROM Feedbacks
WHERE CustomerId=14 OR ProductId=5

--Section 3. Querying (40 pts)

--5.	Products by Price

SELECT Name, Price,Description
FROM Products 
ORDER BY Price DESC, Name

--6.	Ingredients

SELECT Name,Description,OriginCountryId
FROM Ingredients
WHERE OriginCountryId IN (1,10,20)
ORDER BY Id

--7.	Ingredients from Bulgaria and Greece

SELECT TOP (15) i.Name AS [Name],i.Description AS [Description],c.Name AS [CountryName]
FROM Ingredients AS I
JOIN  Countries AS C
ON C.Id=I.OriginCountryId
WHERE C.Name IN ('Bulgaria','Greece')
ORDER BY I.Name,C.Name

--8.	Best Rated Products

SELECT TOP (10) P.Name,P.Description, AVG(F.Rate) AS [AverageRate], COUNT(F.Id) AS [FeedbacksAmount]
FROM Products AS P
LEFT OUTER JOIN Feedbacks AS F
ON F.ProductId=P.Id
GROUP BY P.Name, P.Description
ORDER BY [AverageRate] DESC,[FeedbacksAmount] DESC

--9.	Negative Feedback

SELECT ProductId,Rate,Description,CustomerId,Age,Gender
FROM Feedbacks AS F
JOIN Customers AS C
ON C.Id=F.CustomerId
WHERE F.Rate<5
ORDER BY ProductId DESC, Rate

--10.	Customers without Feedback

SELECT CONCAT(c.FirstName, ' ', c.LastName) AS CustomerName,
  c.PhoneNumber, c.Gender
FROM Customers AS C
FULL JOIN Feedbacks AS F
ON F.CustomerId=C.Id
WHERE F.CustomerId IS NULL
ORDER BY C.Id


SELECT CONCAT(c.FirstName, ' ', c.LastName) AS CustomerName,
  c.PhoneNumber, c.Gender
FROM Customers AS C
WHERE C.Id NOT IN (SELECT F.CustomerId FROM Feedbacks AS F)
ORDER BY C.Id


--11.	Honorable Mentions

SELECT F.ProductId , C.FirstName+' '+C.LastName AS [CustomerName] , F.Description
FROM
(SELECT  CustomerId
FROM Feedbacks
GROUP BY CustomerId
HAVING COUNT(*)>=3
) AS FNT
JOIN Feedbacks AS F
ON F.CustomerId=FNT.CustomerId
JOIN Customers AS C
ON F.CustomerId=C.Id
ORDER BY F.ProductId, [CustomerName] , F.Id

--12.	Customers by Criteria

SELECT FirstName, Age, PhoneNumber
FROM Customers
WHERE (Age>=21 AND FirstName LIKE '%an%') OR 
(PhoneNumber LIKE '%38' AND CountryId<>(SELECT Id FROM Countries WHERE Name LIKE 'Greece'))
ORDER BY FirstName, Age DESC

--13.	Middle Range Distributors

SELECT DIS.Name AS [DistributorName], 
		I.Name AS [IngredientName],
		P.Name AS [ProductName], 
		AVG(F.Rate) AS [AverageRate]
FROM Distributors AS DIS
JOIN Ingredients AS I
ON I.DistributorId=DIS.Id
JOIN ProductsIngredients AS PI
ON PI.IngredientId=I.Id
JOIN Products AS P
ON P.Id=PI.ProductId
JOIN Feedbacks AS F
ON P.Id=F.ProductId
GROUP BY P.Name, DIS.Name,I.Name
HAVING AVG(F.Rate) BETWEEN 5 AND 8
ORDER BY DIS.Name,I.Name, P.Name

--14.	The Most Positive Country

SELECT TOP (1) WITH TIES
COU.Name AS [CountryName], AVG(F.RATE) AS [FeedbackRate]
FROM Countries AS COU
JOIN Customers AS CU
ON CU.CountryId=COU.Id
JOIN Feedbacks AS F
ON F.CustomerId=CU.Id
GROUP BY COU.Name
ORDER BY [FeedbackRate] DESC

--15.	Country Representative

SELECT CountryName, DistributorName
FROM (
  SELECT 
    co.Name AS CountryName, d.Name AS DistributorName, 
    COUNT(i.Id) AS IngredientsCount,
    DENSE_RANK() OVER (PARTITION BY co.Name ORDER BY COUNT(i.Id) DESC) AS DistributorRank 
	-- ranking for most active distributor by country (delivering max IngredientsCount) 
  FROM Countries AS co
  JOIN Distributors AS d ON d.CountryId = co.Id
  JOIN Ingredients AS i ON i.DistributorId = d.Id
  GROUP BY d.Name, co.Name
) AS CountryDistributorStats
WHERE DistributorRank = 1
ORDER BY CountryName, DistributorName

--Section 4. Programmability (20 pts)

--16.	Customers with Countries

CREATE VIEW v_UserWithCountries 
AS 
SELECT CU.FirstName+' '+CU.LastName AS [CustomerName],CU.Age, CU.Gender, COU.Name
FROM Customers AS CU
LEFT OUTER JOIN Countries AS COU
ON CU.CountryId=COU.Id

SELECT TOP 5 *
  FROM v_UserWithCountries
 ORDER BY Age

 --17.	Feedback by Product Name
 
 CREATE or alter  FUNCTION dbo.udf_GetRating(@Name nvarchar(25))
 RETURNS VARCHAR(10)
 AS
 BEGIN
	DECLARE @Rate DECIMAL(10,6) = (SELECT ISNULL(AVG(F.Rate),0)
										FROM Products AS P
										LEFT OUTER JOIN Feedbacks AS F
										 ON F.ProductId=P.Id
										 WHERE  P.Name = @Name)
	DECLARE @Result VARCHAR(10)= 
				CASE
				WHEN @Rate=0 THEN 'No rating'
				WHEN @Rate<5 THEN 'Bad'
				WHEN @Rate BETWEEN 5 AND 8 THEN 'Average'
				WHEN @Rate>8 THEN 'Good'
				END
	RETURN @Result;
 END
 
 SELECT TOP 5 Id, Name, dbo.udf_GetRating(Name)
  FROM Products
 ORDER BY Id

 --18.	Send Feedback

 GO

 CREATE OR ALTER PROC usp_SendFeedback (@CustomerId INT, @ProductId INT, @Rate DECIMAL(10,2), @Description nvarchar(MAX))
 AS 
 BEGIN
	DECLARE @CustomerFeedbacksCount INT = ( SELECT COUNT(F.ID)
	FROM Feedbacks AS F
	WHERE F.CustomerId=@CustomerId);
	IF (@CustomerFeedbacksCount>=3)
		BEGIN
			RAISERROR('You are limited to only 3 feedbacks per product!',16, 1);  
			RETURN;
		END
	ELSE 
		BEGIN
			INSERT INTO Feedbacks (CustomerId, ProductId , Rate , Description )
			VALUES
			(@CustomerId , @ProductId , @Rate, @Description )
		END
 END
 
 begin transaction
 EXEC usp_SendFeedback 1, 5, 7.50, 'Average experience';
SELECT COUNT(*) FROM Feedbacks WHERE CustomerId = 1 AND ProductId = 5;

 rollback

 --19.	Delete Products
 GO

 CREATE TRIGGER T_DeleteProducts ON Products INSTEAD OF DELETE
 AS LEFT OUTER JOIN
 BEGIN
	DECLARE @ProductId INT = (SELECT Id FROM deleted);

	DELETE FROM ProductsIngredients
	WHERE ProductId = @ProductId;

	DELETE FROM Feedbacks
	WHERE ProductId=@ProductId;

	DELETE FROM Products
	WHERE Id=@ProductId;

 END

 BEGIN TRANSACTION
 DELETE FROM Products WHERE Id = 7
 ROLLBACK 

 --Section 5. Bonus (10 pts)

 WITH CTE_ProductsAndDistributors
 AS
 (SELECT 
		P.Id AS [ProductId], 
		P.Name AS [ProductName],
		D.Id AS [DistributorId], 
		D.Name AS [DistributorName], 
		C.Name AS [DistributorCountry]
 FROM Products AS P
 JOIN ProductsIngredients AS PI
 ON PI.ProductId=P.Id
 JOIN Ingredients AS I
 ON I.Id=PI.IngredientId
 JOIN Distributors AS D
 ON D.Id=I.DistributorId
 JOIN Countries AS C
 ON C.Id=D.CountryId
 JOIN Feedbacks AS F
 ON F.ProductId=P.Id
 )
 ,
 CTE_ProductsWithSingleDistributor (ProductId)
 AS
 (SELECT ProductId
 FROM CTE_ProductsAndDistributors
 GROUP BY ProductId
 HAVING COUNT(DISTINCT DistributorId)=1)
 ,
 CTE_ProductsWithAvgRating(ProductId, ProductAverageRate)
 AS
 (SELECT PSD.ProductId, AVG(F.Rate) AS [AvgRate]
 FROM CTE_ProductsWithSingleDistributor AS PSD
 JOIN Feedbacks AS F
 ON F.ProductId=PSD.ProductId
 GROUP BY PSD.ProductId)
 ,
 CTE_Distributors
 AS
 (SELECT DISTINCT DistributorId
 FROM CTE_ProductsAndDistributors AS PAD
 JOIN CTE_ProductsWithSingleDistributor AS PWSD
 ON PWSD.ProductId=PAD.ProductId)
 ,
 CTE_RenderTable(ProductId,ProductName,ProductAverageRate,DistributorName,DistributorCountry)
 AS
 (SELECT PAD.ProductId, PAD.ProductName, PAR.ProductAverageRate, PAD.DistributorName, PAD.DistributorCountry
 FROM CTE_ProductsAndDistributors AS PAD
 JOIN CTE_ProductsWithSingleDistributor AS PWSD
 ON PWSD.ProductId=PAD.ProductId
 JOIN CTE_ProductsWithAvgRating AS PAR
 ON PAR.ProductId=PAD.ProductId)
 
SELECT  ProductName,ProductAverageRate,DistributorName,DistributorCountry
FROM    
(SELECT  *,
ROW_NUMBER() OVER(PARTITION BY ProductId  ORDER BY DistributorName ASC) [RowNumber]
FROM CTE_RenderTable) t
WHERE   RowNumber = 1
ORDER BY ProductId

-- Second better solution

  SELECT 
    p.Name AS ProductName, AVG(f.Rate) AS ProductAverageRate,
    d.Name AS DistributorName, c.Name AS DistributorCountry
  FROM (
    SELECT p.Id
    FROM Products AS p
    JOIN ProductsIngredients AS pi ON pi.ProductId = p.Id
    JOIN Ingredients AS i ON pi.IngredientId = i.Id
    JOIN Distributors AS d ON i.DistributorId = d.Id
    GROUP BY p.Id
    HAVING COUNT(DISTINCT d.Id) = 1
  ) AS SingleDistProducts
  JOIN Products AS p ON p.Id = SingleDistProducts.Id
  JOIN ProductsIngredients AS pi ON pi.ProductId = p.Id
  JOIN Ingredients AS i ON pi.IngredientId = i.Id
  JOIN Distributors AS d ON d.Id = i.DistributorId
  JOIN Countries AS c ON d.CountryId = c.Id
  JOIN Feedbacks AS f ON p.Id = f.ProductId
  GROUP BY P.Id,P.Name, d.Name, c.Name
  ORDER BY p.Id
