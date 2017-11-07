

--Problem 13.	Movies Database

DROP DATABASE Movies

CREATE DATABASE Movies 

USE Movies

CREATE TABLE Directors
(
Id INT PRIMARY KEY IDENTITY NOT NULL,
DirectorName nvarchar(50) NOT NULL,
Notes nvarchar(MAX) 
)


INSERT INTO Directors (DirectorName,Notes) VALUES
('John Smith', 'sdadsad'),
('Will Alekson', 'SADDSADSAd'),
('Ivan Ivanov', 'ASDASAD'),
('Grishata Grigorov', '564546'),
('Mariika Petkanova-Dimitrova', NULL)


CREATE TABLE Genres
(
Id INT PRIMARY KEY IDENTITY NOT NULL,
GenreName nvarchar(50) NOT NULL,
Notes nvarchar(MAX) 
)


INSERT INTO Genres (GenreName,Notes) VALUES
('Action', 'sdadsad'),
('Triller', 'SADDSADSAd'),
('Commedy', 'ASDASAD'),
('Animation', 'dddd'),
('Documentary', 'dddddd')

CREATE TABLE Categories
(
Id INT PRIMARY KEY IDENTITY NOT NULL,
CategoryName nvarchar(50) NOT NULL,
Notes nvarchar(MAX) 
)


INSERT INTO Categories (CategoryName,Notes) VALUES
('1', NULL),
('2', 'SADDSADSAd'),
('3', NULL),
('4', 'sadsadfsadsad'),
('5', NULL)



CREATE TABLE Movies
(
Id INT PRIMARY KEY IDENTITY NOT NULL,
Title nvarchar(50) NOT NULL,
DirectorId INT FOREIGN KEY REFERENCES Directors(Id) NOT NULL,
CopyrightYear nvarchar(10)NOT NULL,
[Length] nvarchar(50),
GenreId INT FOREIGN KEY REFERENCES Genres(Id) NOT NULL,
CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
Rating DECIMAL(10,2),
Notes nvarchar(MAX) 
)


INSERT INTO Movies (Title,DirectorId,CopyrightYear,[Length],GenreId,CategoryId,Rating,Notes) VALUES
('SSS', 1,'2015','3:22',1,1,NULL,NULL),
('324234', 2,'1111',NULL,1,2,NULL,NULL),
('5dgfhgf', 3,'2222','3:22',4,5,NULL,NULL),
('768876', 4,'2113',NULL,5,2,NULL,NULL),
('hjhgjghj', 5,'2412','3:22',3,3,NULL,NULL)



--Problem 14.	Car Rental Database

CREATE DATABASE CarRental 

USE CarRental

CREATE TABLE Categories 
(
Id INT PRIMARY KEY IDENTITY,
CategoryName nvarchar(50),
DailyRate DECIMAL (10,2),
WeeklyRate DECIMAL (10,2),
MonthlyRate DECIMAL (10,2),
WeekendRate DECIMAL (10,2)
)

INSERT INTO Categories (CategoryName, WeeklyRate) VALUES
('A', 12.5),
('B',13.5),
('C',20.63)

CREATE TABLE Cars  
(
Id INT PRIMARY KEY IDENTITY,
PlateNumber nvarchar(10),
Manufacturer nvarchar(50),
Model nvarchar(50),
CarYear  NVARCHAR(100),
CategoryId  INT FOREIGN KEY REFERENCES Categories(Id),
Doors INT,
Picture varbinary(MAX),
Condition nvarchar(MAX),
Available bit
)

INSERT INTO Cars (PlateNumber,CategoryId) VALUES
('CA1234HT',1),
('C5678HT',2),
('CB0809HT',3)


CREATE TABLE Employees 
(
Id INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(50),
LastName NVARCHAR(50),
Title NVARCHAR(50),
Notes NVARCHAR(50)
)

INSERT INTO Employees (FirstName,LastName) VALUES
('ANNA','ZAHARIEVA'),
('IVAN','IVANOV'),
('DRAGAN','DRAGANOV')

CREATE TABLE Customers 
(
Id INT PRIMARY KEY IDENTITY,
DriverLicenceNumber  NVARCHAR(100),
FullName NVARCHAR(100),
[Address] NVARCHAR(MAX),
City NVARCHAR(20),
ZIPCode NVARCHAR(10),
Notes NVARCHAR(MAX)
)

INSERT INTO Customers (DriverLicenceNumber,FullName,City) VALUES
('65789','ANNA DIMITROVA','SOFIA'),
('7890','KRISTINA DIMITROVA','BURGAS'),
('123123','PETYR PETROV','PLOVDIV')

CREATE TABLE RentalOrders 
(
Id INT PRIMARY KEY IDENTITY,
EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
CustomerId INT FOREIGN KEY REFERENCES Customers(Id),
CarId INT FOREIGN KEY REFERENCES Cars(Id),
TankLevel DECIMAL (10,2),
KilometrageStart INT,
KilometrageEnd INT,
TotalKilometrage AS (KilometrageEnd-KilometrageStart),
StartDate date,
EndDate date,
TotalDays AS DATEDIFF(DAY,StartDate,EndDate),
RateApplied DECIMAL (10,2),
TaxRate AS (DATEDIFF(DAY,StartDate,EndDate)*RateApplied),
OrderStatus nvarchar(50),
Notes nvarchar(50)
)


INSERT INTO RentalOrders (EmployeeId,CustomerId,CarId,KilometrageStart,KilometrageEnd,StartDate,EndDate,RateApplied) VALUES
(1,1,1,0,100,'2015-12-12','2015-12-24',12.5),
(2,2,2,100,105,'2016-11-11','2016-12-24',12.5),
(3,3,3,90,200,'2010-10-10','2010-12-24',12.5)

DROP TABLE Employees

DROP TABLE Customers

DROP TABLE Cars

DROP TABLE RentalOrders

DROP TABLE Categories

USE MASTER
DROP TABLE RentalOrders


--Problem 15.	Hotel Database

CREATE DATABASE Hotel 

USE Hotel 

CREATE TABLE Employees 
(
Id INT PRIMARY KEY IDENTITY,
FirstName nvarchar(50)NOT NULL,
LastName nvarchar(50)NOT NULL,
Title nvarchar(50)NOT NULL,
Notes nvarchar(50)
)

INSERT INTO Employees (FirstName, LastName, Title , Notes) VALUES
('IVAN','IVANOV', 'DIRECTOR', 'BOSS'),
('STOYAN','STOYANOV', 'OFFICER', 'HE'),
('EKATERINA','PETROVA', 'MANAGER', 'SHE')

CREATE TABLE Customers  
(
AccountNumber INT PRIMARY KEY IDENTITY,
FirstName nvarchar(50)NOT NULL,
LastName nvarchar(50)NOT NULL,
PhoneNumber nvarchar(50),
EmergencyName nvarchar(50),
EmergencyNumber nvarchar(50),
Notes nvarchar(50)
)


INSERT INTO Customers ( FirstName, LastName , PhoneNumber) VALUES
('STANY', 'YORDANOV', '+359 888 888 888'),
('ANASTASIQ', 'PETKOVA', NULL),
('IVELIAN', 'PETROVA', '0887 777 777')

CREATE TABLE RoomStatus   
(
RoomStatus INT PRIMARY KEY IDENTITY,
Notes nvarchar(50)
)

INSERT INTO RoomStatus ( Notes) VALUES
('CHECKIN'),
('CHECKOUT'),
('FREE')

CREATE TABLE RoomTypes   
(
RoomType INT PRIMARY KEY IDENTITY,
Notes nvarchar(50)
)

INSERT INTO RoomTypes ( Notes) VALUES
('SINGLE'),
('DOUBLE'),
('APARTMENT')

CREATE TABLE BedTypes   
(
BedType  INT PRIMARY KEY IDENTITY,
Notes nvarchar(50)
)

INSERT INTO BedTypes ( Notes) VALUES
('SINGLE'),
('DOUBLE'),
('EXTRA LARGE')



CREATE TABLE Rooms   
(
RoomNumber INT PRIMARY KEY,
RoomType INT FOREIGN KEY REFERENCES RoomTypes(RoomType),
BedType INT FOREIGN KEY REFERENCES BedTypes(BedType),
Rate DECIMAL(10,2) NOT NULL,
RoomStatus INT FOREIGN KEY REFERENCES RoomStatus(RoomStatus),
Notes nvarchar(50)
)

INSERT INTO Rooms ( RoomNumber,RoomType,BedType,Rate,RoomStatus,Notes ) VALUES
(403,1,1,45.90,1,'A SA'),
(101,2,2,90.90,2,'ASDDSADSA'),
(302,3,3,135.90,3,'SADSADSADA')

CREATE TABLE Payments    
(
Id  INT PRIMARY KEY IDENTITY,
EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
PaymentDate date DEFAULT GETDATE(),
AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber),
FirstDateOccupied date NOT NULL,
LastDateOccupied date DEFAULT GETDATE(),
TotalDays AS DATEDIFF(DAY,FirstDateOccupied,LastDateOccupied),
AmountCharged DECIMAL(10,2)NOT NULL,
TaxRate DECIMAL (10,2)NOT NULL,
TaxAmount DECIMAL (10,2)NOT NULL,
PaymentTotal AS (AmountCharged+TaxAmount),
Notes nvarchar(50)
)


INSERT INTO Payments ( EmployeeId,AccountNumber,FirstDateOccupied,AmountCharged,TaxRate,TaxAmount,Notes ) VALUES
(2,1,'2017-09-01',45.90,5,200.77,'A SA'),
(3,2,'2017-09-05',90.90,10,300.88,'ASDDSADSA'),
(3,3,'2017-09-06',135.90,10,110.88,'SADSADSADA')

CREATE TABLE Occupancies     
(
Id  INT PRIMARY KEY IDENTITY,
EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
DateOccupied date DEFAULT GETDATE(),
AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber),
RoomNumber INT FOREIGN KEY REFERENCES Rooms(RoomNumber),
RateApplied  DECIMAL(10,2)NOT NULL,
PhoneCharge  DECIMAL(10,2)NOT NULL,
Notes nvarchar(50)
)

INSERT INTO Occupancies ( EmployeeId,AccountNumber,RoomNumber,RateApplied,PhoneCharge,Notes ) VALUES
(2,1,403,45.90,5.5,'A SA'),
(3,2,101,90.90,10.22,'ASDDSADSA'),
(1,3,302,135.90,20.54,NULL)




CREATE FUNCTION f_TakeRoomRate (@RoomNumber INT)
RETURNS DECIMAL(10,2)
  BEGIN
	DECLARE @Result AS DECIMAL (10,2) = (
	SELECT (Rate)
	FROM Rooms WHERE @RoomNumber=RoomNumber
	)
	RETURN @Result
  END

 SELECT [Hotel].[dbo].[f_TakeRoomRate](403)

--Problem 16.	Create SoftUni Database

USE master

DROP DATABASE SoftUni

CREATE DATABASE SoftUni 

USE SoftUni

CREATE TABLE Towns 
(
Id INT PRIMARY KEY IDENTITY NOT NULL,
[Name] nvarchar(MAX)  NOT NULL,
)

INSERT INTO Towns([Name]) VALUES
('Sofia'), 
('Plovdiv'), 
('Varna'), 
('Burgas')

CREATE TABLE Addresses 
(
Id INT PRIMARY KEY IDENTITY NOT NULL,
AddressText nvarchar(50) NOT NULL,
TownId INT FOREIGN KEY REFERENCES Towns(Id) 
)

INSERT INTO Addresses(AddressText,TownId) VALUES
('DSADASDSAD',1), 
('SADSAD435',2), 
('TGFRH7U',3), 
('JMKJHK,JHK',4),
('78I76I76865',1)

CREATE TABLE Departments 
(
Id INT PRIMARY KEY IDENTITY NOT NULL,
[Name] nvarchar(50) NOT NULL,
)

INSERT INTO Departments([Name]) VALUES
('Engineering'), 
('Sales'), 
('Marketing'), 
('Software Development'),
('Quality Assurance')


CREATE TABLE Employees 
(
Id INT PRIMARY KEY IDENTITY NOT NULL,
FirstName nvarchar(50) NOT NULL,
MiddleName nvarchar(50),
LastName nvarchar(50) NOT NULL,
JobTitle nvarchar(50) NOT NULL,
DepartmentId INT FOREIGN KEY REFERENCES Departments(Id), 
HireDate VARCHAR(15),
Salary DECIMAL (10,2) NOT NULL,
AddressId INT FOREIGN KEY REFERENCES Addresses(Id), 
)

--Problem 18.	Basic Insert

INSERT INTO Employees(FirstName,MiddleName,LastName,JobTitle,DepartmentId,HireDate,Salary,AddressId) VALUES
('Ivan','Ivanov','Ivanov','.NET Developer',4,'01/02/2013',3500.00,1), 
('Petar','Petrov','Petrov','Senior Engineer',1,'02/03/2004',4000.00,2), 
('Maria','Petrova','Ivanova','Intern',5,'28/08/2016',525.25,3), 
('Georgi','Teziev','Ivanov	','CEO',2,'09/12/2007',3000.00,4), 
('Peter','Pan','Pan','Intern',3,'28/08/2016',599.88,5)

--Problem 19.	Basic Select All Fields

SELECT * FROM Towns


SELECT * FROM Departments 


SELECT * FROM Employees 

DROP TABLE Employees

--Problem 20.	Basic Select All Fields and Order Them

SELECT *
FROM Towns
ORDER BY [Name] ASC;

SELECT *
FROM Departments
ORDER BY [Name] ASC;


SELECT *
FROM Employees
ORDER BY Salary DESC;

--Problem 21.	Basic Select Some Fields

SELECT Name
FROM Towns
ORDER BY [Name] ASC;

SELECT Name
FROM Departments
ORDER BY [Name] ASC;


SELECT FirstName, LastName, JobTitle, Salary
FROM Employees
ORDER BY Salary DESC;


--Problem 22.	Increase Employees Salary

UPDATE Employees SET Salary=(Salary*(100+10))/100

SELECT Salary FROM Employees 


--Problem 1.	Create Database

--Problem 2.	Create Tables

--Problem 3.	Alter Minions Table

--Problem 4.	Insert Records in Both Tables

INSERT INTO Towns (Id,[Name]) VALUES
(1,'Sofia'),
(2,'Plovdiv'),
(3,'Varna')


INSERT INTO Minions (Id,[Name],Age,TownId)VALUES
(1,'Kevin', 22, 1),
(2,'Bob', 15, 3),
(3,'Steward',NULL, 2)

--Problem 5.	Truncate Table Minions

--Problem 6.	Drop All Tables

--Problem 7.	Create Table People

CREATE TABLE People 
(
Id INT PRIMARY KEY IDENTITY NOT NULL,
[Name] nvarchar (200) NOT NULL,
Picture varbinary(MAX),
Height DECIMAL (10,2),
[Weight] DECIMAL (10,2),
Gender char(1) NOT NULL CHECK (Gender='m' OR Gender='f'),
Birthdate date NOT NULL,
Biography nvarchar(MAX) 
)

INSERT INTO People ([Name],Picture,[Height],[Weight],Gender,Birthdate,Biography) VALUES
('Kevin KKK',NULL, 160.5, 90.55 , 'm','1983-11-11',NULL),
('Daniel DDDD',NULL, 160.5, 95 , 'm','2015-01-11',NULL),
('Ekaterina EEE',NULL, 160.5, 51.05, 'f','2000-05-05','SADSADSAD'),
('Ekaterina EEE',NULL, NULL,NULL, 'f','2000-05-05','DSADASDA'),
('Ekaterina RRR',010101, 194.11,45.11, 'f','2000-05-05','DSADASDA')


--Problem 8.	Create Table Users

CREATE TABLE Users 
(
Id BIGINT PRIMARY KEY IDENTITY NOT NULL,
Username varchar(30) UNIQUE NOT NULL,
[Password] varchar(26) NOT NULL,
ProfilePicture varbinary(MAX),
LastLoginTime datetime,
IsDeleted bit NOT NULL
)


INSERT INTO Users (Username, [Password],ProfilePicture,LastLoginTime,IsDeleted) VALUES
('Aaa','aaa',NULL,NULL,1),
('BBB','bbb',NULL,NULL,0),
('CCC','ccc',NULL,NULL,1),
('DDD','ddd',NULL,NULL,1),
('EEE','eee',NULL,NULL,0)

--Problem 9.	Change Primary Key

--Problem 10.	Add Check Constraint

--Problem 11.	Set Default Value of a Field

--Problem 12.	Set Unique Field

--Problem 13.	Movies Database

CREATE TABLE Directors
(
Id INT PRIMARY KEY IDENTITY NOT NULL,
DirectorName nvarchar(50) NOT NULL,
Notes nvarchar(MAX) 
)


INSERT INTO Directors (DirectorName,Notes) VALUES
('John Smith', 'sdadsad'),
('Will Alekson', 'SADDSADSAd'),
('Ivan Ivanov', 'ASDASAD'),
('Grishata Grigorov', '564546'),
('Mariika Petkanova-Dimitrova', NULL)


CREATE TABLE Genres
(
Id INT PRIMARY KEY IDENTITY NOT NULL,
GenreName nvarchar(50) NOT NULL,
Notes nvarchar(MAX) 
)


INSERT INTO Genres (GenreName,Notes) VALUES
('Action', 'sdadsad'),
('Triller', 'SADDSADSAd'),
('Commedy', 'ASDASAD'),
('Animation', 'dddd'),
('Documentary', 'dddddd')

CREATE TABLE Categories
(
Id INT PRIMARY KEY IDENTITY NOT NULL,
CategoryName nvarchar(50) NOT NULL,
Notes nvarchar(MAX) 
)


INSERT INTO Categories (CategoryName,Notes) VALUES
('1', NULL),
('2', 'SADDSADSAd'),
('3', NULL),
('4', 'sadsadfsadsad'),
('5', NULL)



CREATE TABLE Movies
(
Id INT PRIMARY KEY IDENTITY NOT NULL,
Title nvarchar(50) NOT NULL,
DirectorId INT FOREIGN KEY REFERENCES Directors(Id) NOT NULL,
CopyrightYear nvarchar(10)NOT NULL,
[Length] nvarchar(50),
GenreId INT FOREIGN KEY REFERENCES Genres(Id) NOT NULL,
CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
Rating DECIMAL(10,2),
Notes nvarchar(MAX) 
)


INSERT INTO Movies (Title,DirectorId,CopyrightYear,[Length],GenreId,CategoryId,Rating,Notes) VALUES
('SSS', 1,'2015','3:22',1,1,NULL,NULL),
('324234', 2,'1111',NULL,1,2,NULL,NULL),
('5dgfhgf', 3,'2222','3:22',4,5,NULL,NULL),
('768876', 4,'2113',NULL,5,2,NULL,NULL),
('hjhgjghj', 5,'2412','3:22',3,3,NULL,NULL)

--Problem 14.	Car Rental Database
CREATE TABLE Categories 
(
Id INT PRIMARY KEY IDENTITY,
CategoryName nvarchar(50),
DailyRate DECIMAL (10,2),
WeeklyRate DECIMAL (10,2),
MonthlyRate DECIMAL (10,2),
WeekendRate DECIMAL (10,2)
)

INSERT INTO Categories (CategoryName, WeeklyRate) VALUES
('A', 12.5),
('B',13.5),
('C',20.63)

CREATE TABLE Cars  
(
Id INT PRIMARY KEY IDENTITY,
PlateNumber nvarchar(10),
Manufacturer nvarchar(50),
Model nvarchar(50),
CarYear  NVARCHAR(100),
CategoryId  INT FOREIGN KEY REFERENCES Categories(Id),
Doors INT,
Picture varbinary(MAX),
Condition nvarchar(MAX),
Available bit
)

INSERT INTO Cars (PlateNumber,CategoryId) VALUES
('CA1234HT',1),
('C5678HT',2),
('CB0809HT',3)


CREATE TABLE Employees 
(
Id INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(50),
LastName NVARCHAR(50),
Title NVARCHAR(50),
Notes NVARCHAR(50)
)

INSERT INTO Employees (FirstName,LastName) VALUES
('ANNA','ZAHARIEVA'),
('IVAN','IVANOV'),
('DRAGAN','DRAGANOV')

CREATE TABLE Customers 
(
Id INT PRIMARY KEY IDENTITY,
DriverLicenceNumber  NVARCHAR(100),
FullName NVARCHAR(100),
[Address] NVARCHAR(MAX),
City NVARCHAR(20),
ZIPCode NVARCHAR(10),
Notes NVARCHAR(MAX)
)

INSERT INTO Customers (DriverLicenceNumber,FullName,City) VALUES
('65789','ANNA DIMITROVA','SOFIA'),
('7890','KRISTINA DIMITROVA','BURGAS'),
('123123','PETYR PETROV','PLOVDIV')

CREATE TABLE RentalOrders 
(
Id INT PRIMARY KEY IDENTITY,
EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
CustomerId INT FOREIGN KEY REFERENCES Customers(Id),
CarId INT FOREIGN KEY REFERENCES Cars(Id),
TankLevel DECIMAL (10,2),
KilometrageStart INT,
KilometrageEnd INT,
TotalKilometrage AS (KilometrageEnd-KilometrageStart),
StartDate date,
EndDate date,
TotalDays AS DATEDIFF(DAY,StartDate,EndDate),
RateApplied DECIMAL (10,2),
TaxRate AS (DATEDIFF(DAY,StartDate,EndDate)*RateApplied),
OrderStatus nvarchar(50),
Notes nvarchar(50)
)


INSERT INTO RentalOrders (EmployeeId,CustomerId,CarId,KilometrageStart,KilometrageEnd,StartDate,EndDate,RateApplied) VALUES
(1,1,1,0,100,'2015-12-12','2015-12-24',12.5),
(2,2,2,100,105,'2016-11-11','2016-12-24',12.5),
(3,3,3,90,200,'2010-10-10','2010-12-24',12.5)

--Problem 15.	Hotel Database

CREATE TABLE Employees 
(
Id INT PRIMARY KEY IDENTITY,
FirstName nvarchar(50)NOT NULL,
LastName nvarchar(50)NOT NULL,
Title nvarchar(50)NOT NULL,
Notes nvarchar(50)
)

INSERT INTO Employees (FirstName, LastName, Title , Notes) VALUES
('IVAN','IVANOV', 'DIRECTOR', 'BOSS'),
('STOYAN','STOYANOV', 'OFFICER', 'HE'),
('EKATERINA','PETROVA', 'MANAGER', 'SHE')

CREATE TABLE Customers  
(
AccountNumber INT PRIMARY KEY IDENTITY,
FirstName nvarchar(50)NOT NULL,
LastName nvarchar(50)NOT NULL,
PhoneNumber nvarchar(50),
EmergencyName nvarchar(50),
EmergencyNumber nvarchar(50),
Notes nvarchar(50)
)


INSERT INTO Customers ( FirstName, LastName , PhoneNumber) VALUES
('STANY', 'YORDANOV', '+359 888 888 888'),
('ANASTASIQ', 'PETKOVA', NULL),
('IVELIAN', 'PETROVA', '0887 777 777')

CREATE TABLE RoomStatus   
(
RoomStatus INT PRIMARY KEY IDENTITY,
Notes nvarchar(50)
)

INSERT INTO RoomStatus ( Notes) VALUES
('CHECKIN'),
('CHECKOUT'),
('FREE')

CREATE TABLE RoomTypes   
(
RoomType INT PRIMARY KEY IDENTITY,
Notes nvarchar(50)
)

INSERT INTO RoomTypes ( Notes) VALUES
('SINGLE'),
('DOUBLE'),
('APARTMENT')

CREATE TABLE BedTypes   
(
BedType  INT PRIMARY KEY IDENTITY,
Notes nvarchar(50)
)

INSERT INTO BedTypes ( Notes) VALUES
('SINGLE'),
('DOUBLE'),
('EXTRA LARGE')



CREATE TABLE Rooms   
(
RoomNumber INT PRIMARY KEY,
RoomType INT FOREIGN KEY REFERENCES RoomTypes(RoomType),
BedType INT FOREIGN KEY REFERENCES BedTypes(BedType),
Rate DECIMAL(10,2) NOT NULL,
RoomStatus INT FOREIGN KEY REFERENCES RoomStatus(RoomStatus),
Notes nvarchar(50)
)

INSERT INTO Rooms ( RoomNumber,RoomType,BedType,Rate,RoomStatus,Notes ) VALUES
(403,1,1,45.90,1,'A SA'),
(101,2,2,90.90,2,'ASDDSADSA'),
(302,3,3,135.90,3,'SADSADSADA')

CREATE TABLE Payments    
(
Id  INT PRIMARY KEY IDENTITY,
EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
PaymentDate date DEFAULT GETDATE(),
AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber),
FirstDateOccupied date NOT NULL,
LastDateOccupied date DEFAULT GETDATE(),
TotalDays AS DATEDIFF(DAY,FirstDateOccupied,LastDateOccupied),
AmountCharged DECIMAL(10,2)NOT NULL,
TaxRate DECIMAL (10,2)NOT NULL,
TaxAmount DECIMAL (10,2)NOT NULL,
PaymentTotal AS (AmountCharged+TaxAmount),
Notes nvarchar(50)
)


INSERT INTO Payments ( EmployeeId,AccountNumber,FirstDateOccupied,AmountCharged,TaxRate,TaxAmount,Notes ) VALUES
(2,1,'2017-09-01',45.90,5,200.77,'A SA'),
(3,2,'2017-09-05',90.90,10,300.88,'ASDDSADSA'),
(3,3,'2017-09-06',135.90,10,110.88,'SADSADSADA')

CREATE TABLE Occupancies     
(
Id  INT PRIMARY KEY IDENTITY,
EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
DateOccupied date DEFAULT GETDATE(),
AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber),
RoomNumber INT FOREIGN KEY REFERENCES Rooms(RoomNumber),
RateApplied  DECIMAL(10,2)NOT NULL,
PhoneCharge  DECIMAL(10,2)NOT NULL,
Notes nvarchar(50)
)

INSERT INTO Occupancies ( EmployeeId,AccountNumber,RoomNumber,RateApplied,PhoneCharge,Notes ) VALUES
(2,1,403,45.90,5.5,'A SA'),
(3,2,101,90.90,10.22,'ASDDSADSA'),
(1,3,302,135.90,20.54,NULL)

--Problem 16.	Create SoftUni Database

--Problem 17.	Backup Database

--Problem 18.	Basic Insert

--Problem 19.	Basic Select All Fields

SELECT * FROM Towns


SELECT * FROM Departments 


SELECT * FROM Employees 

--Problem 20.	Basic Select All Fields and Order Them

SELECT *
FROM Towns
ORDER BY [Name] ASC;

SELECT *
FROM Departments
ORDER BY [Name] ASC;


SELECT *
FROM Employees

ORDER BY Salary DESC;

--Problem 21.	Basic Select Some Fields

SELECT Name
FROM Towns
ORDER BY [Name] ASC;

SELECT Name
FROM Departments
ORDER BY [Name] ASC;


SELECT FirstName, LastName, JobTitle, Salary
FROM Employees
ORDER BY Salary DESC;

--Problem 22.	Increase Employees Salary

UPDATE Employees SET Salary=(Salary*(100+10))/100

SELECT Salary FROM Employees 


--Problem 23.	Decrease Tax Rate

UPDATE Payments SET TaxRate=(TaxRate*(100-3))/100

SELECT TaxRate FROM Payments 

--Problem 24.	Delete All Records

 TRUNCATE TABLE Occupancies