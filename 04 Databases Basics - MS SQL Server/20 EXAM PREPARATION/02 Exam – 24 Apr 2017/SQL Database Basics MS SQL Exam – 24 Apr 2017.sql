use master
DROP DATABASE WMS

--Database Basics MS SQL Exam – 24 Apr 2017

CREATE DATABASE WMS

USE WMS

--Section 1. DDL (30 pts)
--1.	Database design
CREATE TABLE Clients 
(
ClientId INT  PRIMARY KEY IDENTITY,
FirstName VARCHAR(50) NOT NULL,
LastName VARCHAR(50) NOT NULL,
Phone CHAR(12) NOT NULL
)


CREATE TABLE Mechanics 
(
MechanicId INT IDENTITY PRIMARY KEY,
FirstName VARCHAR(50) NOT NULL,
LastName VARCHAR(50) NOT NULL,
Address VARCHAR(255) NOT NULL
)


CREATE TABLE Models 
(
ModelId INT  PRIMARY KEY IDENTITY,
Name VARCHAR(50) UNIQUE NOT NULL
)


CREATE TABLE Vendors 
(
VendorId  INT  PRIMARY KEY IDENTITY,
Name VARCHAR(50) UNIQUE NOT NULL
)

CREATE TABLE Jobs 
(
JobId INT  PRIMARY KEY IDENTITY,
ModelId INT FOREIGN KEY REFERENCES Models(ModelId),
Status VARCHAR (11) DEFAULT 'Pending',
CONSTRAINT chk_Status CHECK ( Status IN ('Pending', 'In Progress' , 'Finished')),
ClientId INT FOREIGN KEY REFERENCES Clients(ClientId),
MechanicId INT FOREIGN KEY REFERENCES Mechanics(MechanicId),
IssueDate DATE NOT NULL,
FinishDate DATE
)


CREATE TABLE Orders 
(
OrderId INT  PRIMARY KEY IDENTITY,
JobId INT FOREIGN KEY REFERENCES Jobs(JobId),
IssueDate DATE,
Delivered BIT DEFAULT 0 NOT NULL
)

CREATE TABLE Parts 
(
PartId INT  PRIMARY KEY IDENTITY,
SerialNumber VARCHAR(50) UNIQUE,
Description VARCHAR(255) ,
Price MONEY NOT NULL,
CONSTRAINT chk_Price CHECK (Price  >0 AND Price <=9999.99) ,
VendorId INT FOREIGN KEY REFERENCES Vendors(VendorId),
StockQty INT NOT NULL DEFAULT 0,
CONSTRAINT chk_StockQty CHECK (StockQty  >=0 ) 
)

CREATE TABLE PartsNeeded
(
Id INT NOT NULL IDENTITY,
JobId INT NOT NULL,
PartId INT NOT NULL,
Quantity INT NOT NULL DEFAULT 1,
CONSTRAINT chk_PartsNeeded_Quantity CHECK (Quantity >0),
CONSTRAINT PK_PartsNeeded_JobId_PartId PRIMARY KEY (JobId, PartId),
CONSTRAINT FK_PartsNeeded_Parts FOREIGN KEY (PartId) REFERENCES Parts(PartId),
CONSTRAINT FK_PartsNeeded_Jobs FOREIGN KEY (JobId) REFERENCES Jobs(JobId)
)


CREATE TABLE OrderParts
(
Id INT NOT NULL IDENTITY,
OrderId INT NOT NULL,
PartId INT NOT NULL,
Quantity INT NOT NULL DEFAULT 1,
CONSTRAINT chk_OrderParts_Quantity CHECK (Quantity >0),
CONSTRAINT PK_OrderParts_JobId_PartId PRIMARY KEY (OrderId, PartId),
CONSTRAINT FK_OrderParts_Parts FOREIGN KEY (PartId) REFERENCES Parts(PartId),
CONSTRAINT FK_OrderParts_Jobs FOREIGN KEY (OrderId) REFERENCES Orders(OrderId)
)

--Section 2. DML (10 pts)
--2.	Insert


-- Disable referential integrity
EXEC sp_MSForEachTable 'ALTER TABLE ? NOCHECK CONSTRAINT ALL'
GO

EXEC sp_MSForEachTable 'DELETE FROM ?'
GO

EXEC sp_MSForEachTable 'DBCC CHECKIDENT(''?'', RESEED, 0)'
GO

-- Enable referential integrity 
EXEC sp_MSForEachTable 'ALTER TABLE ? WITH CHECK CHECK CONSTRAINT ALL'
GO


-- Table: Clients
SET IDENTITY_INSERT Clients ON

INSERT INTO Clients (ClientId, FirstName, LastName, Phone) VALUES
(1, 'Shawnda', 'Yori', '407-538-5106'),
(2, 'Mona', 'Delasancha', '307-403-1488'),
(3, 'Gilma', 'Liukko', '516-393-9967'),
(4, 'Janey', 'Gabisi', '608-967-7194'),
(5, 'Lili', 'Paskin', '201-431-2989'),
(6, 'Loren', 'Asar', '570-648-3035'),
(7, 'Dorothy', 'Chesterfield', '858-617-7834'),
(8, 'Gail', 'Similton', '760-616-5388'),
(9, 'Catalina', 'Tillotson', '609-373-3332'),
(10, 'Lawrence', 'Lorens', '401-465-6432'),
(11, 'Carlee', 'Boulter', '785-347-1805'),
(12, 'Thaddeus', 'Ankeny', '916-920-3571'),
(13, 'Jovita', 'Oles', '386-248-4118'),
(14, 'Alesia', 'Hixenbaugh', '202-646-7516'),
(15, 'Lai', 'Harabedian', '415-423-3294'),
(16, 'Brittni', 'Gillaspie', '208-709-1235'),
(17, 'Raylene', 'Kampa', '574-499-1454'),
(18, 'Flo', 'Bookamer', '308-726-2182'),
(19, 'Jani', 'Biddy', '206-711-6498'),
(20, 'Chauncey', 'Motley', '407-413-4842'),
(21, 'Ciara', 'Ventura', '845-823-8877'),
(22, 'Galen', 'Cantres', '216-600-6111'),
(23, 'Truman', 'Feichtner', '973-852-2736'),
(24, 'Gail', 'Kitty', '907-435-9166'),
(25, 'Dalene', 'Schoeneck', '215-268-1275'),
(26, 'Gertude', 'Witten', '513-977-7043'),
(27, 'Lizbeth', 'Kohl', '310-699-1222'),
(28, 'Glenn', 'Berray', '515-370-7348'),
(29, 'Lashandra', 'Klang', '610-809-1818'),
(30, 'Lenna', 'Newville', '919-623-2524'),
(31, 'Laurel', 'Pagliuca', '509-695-5199'),
(32, 'Mireya', 'Frerking', '914-868-5965'),
(33, 'Annelle', 'Tagala', '410-757-1035'),
(34, 'Dean', 'Ketelsen', '516-847-4418'),
(35, 'Levi', 'Munis', '508-456-4907'),
(36, 'Sylvie', 'Ryser', '918-644-9555'),
(37, 'Sharee', 'Maile', '231-467-9978'),
(38, 'Cordelia', 'Storment', '337-566-6001'),
(39, 'Mollie', 'Mcdoniel', '419-975-3182'),
(40, 'Brett', 'Mccullan', '619-461-9984'),
(41, 'Teddy', 'Pedrozo', '203-892-3863'),
(42, 'Tasia', 'Andreason', '201-920-9002'),
(43, 'Hubert', 'Walthall', '330-903-1345'),
(44, 'Arthur', 'Farrow', '201-238-5688'),
(45, 'Vilma', 'Berlanga', '616-737-3085'),
(46, 'Billye', 'Miro', '601-567-5386'),
(47, 'Glenna', 'Slayton', '901-640-9178'),
(48, 'Mitzie', 'Hudnall', '303-402-1940'),
(49, 'Bernardine', 'Rodefer', '901-901-4726'),
(50, 'Staci', 'Schmaltz', '626-866-2339')

SET IDENTITY_INSERT Clients OFF


-- Table: Mechanics
SET IDENTITY_INSERT Mechanics ON

INSERT INTO Mechanics (MechanicId, FirstName, LastName, [Address]) VALUES
(1, 'Joni', 'Breland', '35 E Main St #43'),
(2, 'Malcolm', 'Tromblay', '747 Leonis Blvd'),
(3, 'Ryan', 'Harnos', '13 Gunnison St'),
(4, 'Jess', 'Chaffins', '18 3rd Ave'),
(5, 'Nickolas', 'Juvera', '177 S Rider Trl #52'),
(6, 'Gary', 'Nunlee', '2 W Mount Royal Ave')

SET IDENTITY_INSERT Mechanics OFF


-- Table: Models
SET IDENTITY_INSERT Models ON

INSERT INTO Models (ModelId, [Name]) VALUES
(1, 'Maelstrom L300'),
(2, 'Neko GG'),
(3, 'Samyang SW80'),
(4, 'LN 100F'),
(5, 'Maelstrom L700'),
(6, 'Panussi P74')

SET IDENTITY_INSERT Models OFF


-- Table: Vendors
SET IDENTITY_INSERT Vendors ON

INSERT INTO Vendors (VendorId, [Name]) VALUES
(1, 'Shenzhen Ltd.'),
(2, 'Suzhou Precision Products'),
(3, 'Qingdao Technology'),
(4, 'Fenghua Import Export')

SET IDENTITY_INSERT Vendors OFF


-- Table: Parts
SET IDENTITY_INSERT Parts ON

INSERT INTO Parts (PartId, SerialNumber, [Description], Price, VendorId, StockQty) VALUES
(1, '285753A', 'Motor Coupling', 8.60, 1, 0),
(2, 'WPW10512946', 'Tri-ring Retainer', 4.05, 2, 1),
(3, '285811', 'Agitator Cam', 11.76, 1, 1),
(4, '4681EA2001T', 'Drain Pump', 66.45, 3, 2),
(5, 'DC60-40137A', 'Hex Bolt', 3.85, 4, 0),
(6, 'WP3363394', 'Drain Pump', 24.50, 2, 1),
(7, '3949247V', 'Lid Switch Assembly', 24.50, 3, 0),
(8, '80040', 'Agitator Directional Cogs', 3.65, 1, 2),
(9, 'W10404050', 'Door Lock', 39.10, 4, 2),
(10, '285785', 'Clutch', 23.06, 1, 1),
(11, '285805', 'Water Inlet Valve', 11.76, 1, 0),
(12, 'WH1X2727', 'Shock Dampener', 3.25, 4, 1),
(13, 'WE01X20378', 'Control Knob', 12.75, 4, 1),
(14, 'WP8181846', 'Door Handle', 30.03, 2, 0),
(15, 'WPW10006355', 'Mode Shift Actuator', 41.00, 2, 2),
(16, '5220FR2006H', 'Water Inlet Valve', 20.90, 3, 2),
(17, 'WP8318084', 'Lid Switch Assembly', 20.07, 2, 0),
(18, 'WPW10730972', 'Drain Pump', 140.50, 2, 2),
(19, '12112425', 'Drive Belt', 22.11, 4, 2),
(20, '4738ER1002A', 'Drain Hose', 20.90, 3, 1)

SET IDENTITY_INSERT Parts OFF


-- Table: Jobs
SET IDENTITY_INSERT Jobs ON

INSERT INTO Jobs (JobId, ModelId, [Status], ClientId, IssueDate, FinishDate, MechanicId) VALUES
(1, 1, 'Finished', 13, '2017-01-12', '2017-01-23', 1),
(2, 2, 'Finished', 7, '2017-01-16', '2017-01-18', 5),
(3, 6, 'Finished', 3, '2017-01-17', '2017-01-30', 1),
(4, 4, 'Finished', 25, '2017-01-18', '2017-01-30', 2),
(5, 4, 'Finished', 43, '2017-01-20', '2017-01-23', 4),
(6, 3, 'Finished', 2, '2017-01-23', '2017-02-01', 2),
(7, 2, 'Finished', 17, '2017-01-24', '2017-01-30', 1),
(8, 2, 'Finished', 44, '2017-01-26', '2017-02-03', 5),
(9, 5, 'Finished', 9, '2017-01-30', '2017-02-06', 6),
(10, 1, 'Finished', 39, '2017-01-31', '2017-02-13', 1),
(11, 6, 'Finished', 4, '2017-02-01', '2017-02-08', 6),
(12, 2, 'Finished', 24, '2017-02-03', '2017-02-16', 5),
(13, 4, 'Finished', 25, '2017-02-03', '2017-02-07', 1),
(14, 6, 'Finished', 1, '2017-02-06', '2017-02-17', 1),
(15, 1, 'Finished', 47, '2017-02-07', '2017-02-10', 1),
(16, 3, 'Finished', 10, '2017-02-09', '2017-02-21', 5),
(17, 3, 'Finished', 46, '2017-02-13', '2017-02-27', 2),
(18, 1, 'Finished', 38, '2017-02-14', '2017-02-22', 5),
(19, 6, 'Finished', 42, '2017-02-15', '2017-02-22', 3),
(20, 4, 'Finished', 27, '2017-02-17', '2017-02-28', 4),
(21, 1, 'Finished', 6, '2017-02-20', '2017-03-06', 1),
(22, 4, 'Finished', 21, '2017-02-21', '2017-03-02', 6),
(23, 1, 'Finished', 19, '2017-02-23', '2017-02-28', 5),
(24, 1, 'Finished', 5, '2017-02-27', '2017-03-06', 6),
(25, 2, 'Finished', 29, '2017-02-28', '2017-03-06', 4),
(26, 5, 'Finished', 30, '2017-03-01', '2017-03-02', 3),
(27, 6, 'Finished', 36, '2017-03-03', '2017-03-16', 4),
(28, 1, 'Finished', 50, '2017-03-06', '2017-03-20', 6),
(29, 1, 'Finished', 14, '2017-03-07', '2017-03-13', 5),
(30, 1, 'Finished', 33, '2017-03-09', '2017-03-15', 1),
(31, 2, 'Finished', 18, '2017-03-13', '2017-03-27', 2),
(32, 6, 'Finished', 28, '2017-03-14', '2017-03-23', 1),
(33, 2, 'Finished', 32, '2017-03-15', '2017-03-28', 2),
(34, 5, 'Finished', 34, '2017-03-17', '2017-03-23', 6),
(35, 5, 'Finished', 11, '2017-03-20', '2017-03-31', 5),
(36, 2, 'Finished', 40, '2017-03-21', '2017-03-28', 2),
(37, 3, 'Finished', 45, '2017-03-23', '2017-04-03', 6),
(38, 6, 'Finished', 31, '2017-03-27', '2017-04-03', 4),
(39, 2, 'Finished', 22, '2017-03-28', '2017-04-03', 5),
(40, 2, 'Finished', 23, '2017-03-29', '2017-04-04', 3),
(41, 6, 'Finished', 12, '2017-03-31', '2017-04-12', 1),
(42, 5, 'Finished', 37, '2017-04-03', '2017-04-10', 3),
(43, 2, 'Finished', 7, '2017-04-03', '2017-04-12', 5),
(44, 2, 'Finished', 41, '2017-04-04', '2017-04-12', 4),
(45, 6, 'In Progress', 26, '2017-04-06', null, 5),
(46, 2, 'In Progress', 16, '2017-04-10', null, 2),
(47, 5, 'Finished', 20, '2017-04-11', '2017-04-18', 2),
(48, 2, 'In Progress', 35, '2017-04-12', null, 2),
(49, 4, 'In Progress', 25, '2017-04-13', null, 5),
(50, 1, 'In Progress', 8, '2017-04-14', null, 6),
(51, 6, 'In Progress', 49, '2017-04-17', null, 5),
(52, 3, 'Pending', 15, '2017-04-18', null, null),
(53, 1, 'Pending', 48, '2017-04-20', null, null)

SET IDENTITY_INSERT Jobs OFF


-- Table: Orders
SET IDENTITY_INSERT Orders ON

INSERT INTO Orders (OrderId, JobId, IssueDate, Delivered) VALUES
(1, 1, '2017-01-16', 1),
(2, 3, '2017-01-23', 1),
(3, 1, '2017-01-16', 1),
(4, 6, '2017-01-26', 1),
(5, 8, '2017-01-30', 1),
(6, 10, '2017-02-06', 1),
(7, 10, '2017-02-06', 1),
(8, 12, '2017-02-07', 1),
(9, 17, '2017-02-16', 1),
(10, 19, '2017-02-20', 1),
(11, 20, '2017-02-20', 1),
(12, 25, '2017-03-06', 1),
(13, 28, '2017-03-10', 1),
(14, 31, '2017-03-16', 1),
(15, 35, '2017-03-23', 1),
(16, 38, '2017-03-31', 1),
(17, 41, '2017-04-05', 1),
(18, 44, '2017-04-07', 1),
(19, 45, '2017-04-10', 0),
(20, 47, '2017-04-17', 1),
(21, 51, '2017-04-19', 0)

SET IDENTITY_INSERT Orders OFF


-- Table: OrderParts
INSERT INTO OrderParts (OrderId, PartId, Quantity) VALUES
(1, 15, 1),
(2, 17, 1),
(2, 20, 1),
(3, 9, 1),
(3, 11, 1),
(4, 2, 1),
(4, 5, 6),
(5, 9, 1),
(5, 20, 1),
(6, 1, 1),
(7, 19, 1),
(7, 20, 1),
(8, 18, 1),
(9, 1, 1),
(9, 7, 1),
(9, 18, 1),
(10, 7, 1),
(10, 8, 1),
(11, 6, 1),
(12, 4, 1),
(12, 19, 1),
(13, 3, 1),
(13, 11, 1),
(14, 11, 1),
(15, 14, 1),
(15, 20, 1),
(16, 2, 1),
(16, 16, 2),
(17, 8, 1),
(17, 12, 4),
(18, 16, 1),
(19, 6, 1),
(19, 10, 1),
(20, 13, 1),
(21, 11, 1)


-- Table: PartsNeeded
INSERT INTO PartsNeeded (JobId, PartId, Quantity) VALUES
(1, 15, 1),
(3, 17, 1),
(3, 20, 1),
(1, 9, 1),
(1, 11, 1),
(6, 2, 1),
(6, 5, 6),
(8, 9, 1),
(8, 20, 1),
(10, 1, 1),
(10, 19, 1),
(10, 20, 1),
(12, 18, 1),
(17, 1, 1),
(17, 7, 1),
(17, 18, 1),
(19, 7, 1),
(19, 8, 1),
(20, 6, 1),
(25, 4, 1),
(25, 19, 1),
(28, 3, 1),
(28, 11, 1),
(31, 11, 1),
(35, 14, 1),
(35, 20, 1),
(38, 2, 1),
(38, 16, 2),
(41, 8, 1),
(41, 12, 4),
(44, 16, 1),
(45, 6, 1),
(45, 10, 1),
(47, 13, 1),
(51, 11, 1),
(48, 4, 1),
(50, 14, 1),
(50, 13, 1),
(50, 17, 1),
(2, 4, 1),
(4, 17, 1),
(5, 17, 1),
(7, 20, 1),
(9, 14, 1),
(11, 9, 1),
(13, 5, 1),
(14, 12, 1),
(15, 14, 1),
(16, 1, 1),
(18, 12, 1),
(21, 12, 1),
(22, 3, 1),
(23, 16, 1),
(24, 13, 1),
(26, 5, 1),
(27, 9, 1),
(29, 16, 1),
(30, 7, 1),
(32, 13, 1),
(33, 15, 1),
(34, 7, 1),
(36, 20, 1),
(37, 8, 1),
(39, 12, 1),
(40, 14, 1),
(42, 5, 1),
(43, 10, 1),
(46, 4, 1),
(49, 12, 2)

-- Table: Clients

INSERT INTO Clients ( FirstName, LastName, Phone) VALUES
('Teri','Ennaco','570-889-5187'),
('Merlyn','Lawler','201-588-7810'),
('Georgene','Montezuma','925-615-5185'),
('Jettie','Mconnell','908-802-3564'),
('Lemuel','Latzke','631-748-6479'),
('Melodie','Knipp','805-690-1682'),
('Candida','Corbley','908-275-8357')


-- Table: Parts

INSERT INTO Parts ( SerialNumber, Description, Price , VendorId) VALUES
('WP8182119','Door Boot Seal',117.86,2),
('W10780048','Suspension Rod',42.81,1),
('W10841140','Silicone Adhesive',6.77,4),
('WPY055980','High Temperature Adhesive',13.94,3)


--3.	Update

UPDATE Jobs 
SET 
Status='In Progress',
MechanicId =3
WHERE Status LIKE 'Pending'

--4.	Delete

IF EXISTS (SELECT *
FROM OrderParts
WHERE OrderId=19)
DELETE FROM OrderParts
WHERE OrderId=19

IF EXISTS (SELECT *
FROM Orders
WHERE OrderId=19)
DELETE FROM Orders
WHERE OrderId=19

--Section 3. Querying (45 pts)

--5.	Clients by Name

SELECT FirstName , LastName , Phone
FROM Clients
ORDER BY LastName,ClientId

--6.	Job Status

SELECT Status , IssueDate
FROM Jobs
WHERE Status NOT LIKE 'Finished'
ORDER BY IssueDate, JobId

--7.	Mechanic Assignments

SELECT 
		M.FirstName+' '+M.LastName AS [Mechanic],
		J.Status,
		J.IssueDate
FROM Mechanics AS M
JOIN Jobs AS J
ON M.MechanicId=J.MechanicId
ORDER BY M.MechanicId, IssueDate, JobId

--8.	Current Clients

SELECT 
		C.FirstName+' '+C.LastName AS [Client],
		DATEDIFF(DAY,J.IssueDate,'24 April 2017') AS [Days going],
		J.Status
FROM Clients AS C
JOIN Jobs AS J
ON C.ClientId=J.ClientId
WHERE J.Status NOT LIKE 'Finished'
ORDER BY [Days going] DESC , C.ClientId


--9.	Mechanic Performance

SELECT NT.Mechanic,AVG(NT.[Days FINISHED]) AS [Average Days]
FROM (
SELECT 
		M.MechanicId,
		M.FirstName+' '+M.LastName AS [Mechanic],
		J.FinishDate,
		'24 April 2017' AS [Compaire Date],
		DATEDIFF(DAY,J.IssueDate,J.FinishDate) AS [Days FINISHED],
		J.Status
FROM Mechanics AS M
JOIN Jobs AS J
ON M.MechanicId = J.MechanicId
WHERE J.Status LIKE 'Finished') AS NT
GROUP BY NT.[Mechanic],NT.MechanicId
ORDER BY NT.MechanicId

--10.	Hard Earners

SELECT NT.Mechanic, COUNT(*) AS [Jobs]
FROM (SELECT 
			M.MechanicId, 
			M.FirstName+' '+M.LastName AS [Mechanic],
			J.JobId
FROM Mechanics AS M
JOIN Jobs AS J
ON M.MechanicId=J.MechanicId
WHERE J.Status NOT LIKE 'Finished') AS NT
GROUP BY NT.MechanicId,NT.Mechanic
HAVING COUNT(*)>1
ORDER BY  COUNT(*) DESC , NT.MechanicId DESC

--11.	Available Mechanics

SELECT M.FirstName+' '+M.LastName AS [Available]
FROM Mechanics AS M
WHERE M.MechanicId NOT IN (
SELECT DISTINCT M.MechanicId
FROM Mechanics AS M
JOIN Jobs AS J
ON M.MechanicId=J.MechanicId
WHERE J.Status NOT LIKE 'Finished')

--12.	Parts Cost

SELECT ISNULL(SUM(P.Price*OP.Quantity),0)
FROM Parts AS P
JOIN OrderParts AS OP
ON OP.PartId=P.PartId
JOIN Orders AS O
ON O.OrderId=OP.OrderId
WHERE DATEDIFF(WEEK,O.IssueDate,'04-24-2017')<=3

--13.	Past Expenses

SELECT J.JobId,ISNULL(SUM(P.Price*OP.Quantity),0) AS [Total]
FROM Jobs AS J
LEFT OUTER JOIN Orders AS O
ON O.JobId=J.JobId
LEFT OUTER JOIN OrderParts AS OP
ON OP.OrderId=O.OrderId
LEFT OUTER JOIN Parts AS P
ON P.PartId=OP.PartId
WHERE J.FinishDate IS NOT NULL
GROUP BY J.JobId
ORDER BY [Total] DESC,J.JobId

--14.	Model Repair Time

SELECT M.ModelId,M.Name,CAST(AVG(DATEDIFF(DAY,J.IssueDate,J.FinishDate)) AS VARCHAR(10))+' days' AS [Average Service Time]
FROM Models AS M
JOIN Jobs AS J
ON M.ModelId = J.ModelId
WHERE J.Status LIKE 'Finished'
GROUP BY M.ModelId,M.Name
ORDER BY AVG(DATEDIFF(DAY,J.IssueDate,J.FinishDate))

--15.	Faultiest Model

SELECT TOP 1 WITH TIES
		M.Name AS [Model],
		COUNT(J.JobId) AS [Times Serviced],
		(SELECT ISNULL(SUM(P.Price*OP.Quantity),0)
		FROM Jobs AS J
		JOIN Orders AS O
		ON J.JobId=O.JobId
		JOIN OrderParts AS OP
		ON OP.OrderId=O.OrderId
		JOIN Parts AS P
		ON P.PartId=OP.PartId
		WHERE J.ModelId = M.ModelId) AS [Parts Total]
		
FROM Jobs AS J
JOIN Models AS M
ON J.ModelId=M.ModelId
GROUP BY M.ModelId,M.Name
ORDER BY [Times Serviced] DESC

--16.	Missing Parts

SELECT REQ.PartId AS [PartId],
		(SELECT P.Description
		FROM Parts AS P
		WHERE REQ.PartId=P.PartId) AS [Description],
		REQ.Required,
		AVAI.[In Stock],
		AVAI.Ordered
FROM(
SELECT PN.PartId, ISNULL(SUM(PN.Quantity),0) AS [Required]
FROM PartsNeeded AS PN
JOIN Jobs AS J
ON J.JobId=PN.JobId
WHERE J.Status NOT LIKE 'Finished'
GROUP BY PN.PartId) AS REQ
JOIN (
SELECT STO.PartId,STO.[In Stock],ISNULL(ORD.Ordered,0) AS [Ordered]
FROM (
SELECT P.PartId, ISNULL(SUM(P.StockQty),0) AS [In Stock]
FROM Parts AS P
GROUP BY P.PartId) AS STO
FULL JOIN (
SELECT P.PartId,ISNULL(SUM(OP.Quantity),0) AS [Ordered]
FROM Orders AS O
JOIN OrderParts AS OP
ON OP.OrderId=O.OrderId
JOIN Parts AS P
ON P.PartId=OP.PartId
WHERE O.Delivered = 0
GROUP BY P.PartId) AS ORD
ON ORD.PartId = STO.PartId) AS AVAI
ON AVAI.PartId=REQ.PartId
WHERE [Required]>[Ordered]+[In Stock]
ORDER BY REQ.PartId

--Section 4. Programmability (15 pts)

--17.	Cost of Order
GO
CREATE FUNCTION udf_GetCost (@JobId INT)
RETURNS DECIMAL(6,2)
AS
BEGIN
	DECLARE @Result DECIMAL(6,2) = ISNULL((SELECT SUM(OP.Quantity*P.Price)
			FROM Jobs AS J
			JOIN Orders AS O
			ON O.JobId=J.JobId
			JOIN OrderParts AS OP
			ON OP.OrderId=O.OrderId
			JOIN Parts AS P
			ON P.PartId=OP.PartId
			WHERE J.JobId=@JobId),0) ;
	RETURN @Result;
END

SELECT dbo.udf_GetCost(1)

--18.	Place Order
GO
CREATE OR ALTER PROC usp_PlaceOrder(@JobId INT, @PartSerialNumber VARCHAR(50), @Quantity INT)
AS
BEGIN
	IF (@Quantity <=0)
		BEGIN
			RAISERROR('Part quantity must be more than zero!',16, 1);  
			RETURN;
		END	
	DECLARE @Stadus VARCHAR(10) = (SELECT Status FROM Jobs WHERE JobId=@JobId);
	IF (@Stadus = 'Finished')
		BEGIN
			RAISERROR( 'This job is not active!', 16,1);  
			RETURN;
		END
	IF ((SELECT COUNT(*)
			FROM Jobs
			WHERE JobId=@JobId)<>1)
		BEGIN
			RAISERROR('Job not found!', 16,1);  
			RETURN;
		END	
	IF ((SELECT COUNT(*)
			FROM Parts
			WHERE SerialNumber=@PartSerialNumber)<>1)
		BEGIN
			RAISERROR('Part not found!',16, 1);  
			RETURN;
		END
	DECLARE @PartId INT=(SELECT PartId
			FROM Parts
			WHERE SerialNumber=@PartSerialNumber);
	DECLARE @OrderId INT = (SELECT O.OrderId
						FROM Orders AS O					
						WHERE O.JobId=@JobId AND IssueDate IS NULL);

	IF (@OrderId IS NULL)
		BEGIN
			--Order does not exist --> Create new order
			INSERT INTO Orders (JobId)
			VALUES
			(@JobId)

			INSERT INTO OrderParts(OrderId,PartId,Quantity)
			VALUES
			(IDENT_CURRENT('Orders'),@PartId,@Quantity)
		END
	ELSE
		BEGIN
			DECLARE @OrderAndPartExist INT = (SELECT COUNT(*) FROM OrderParts 
												WHERE PartId=@PartId AND OrderId=@OrderId);
			IF (@OrderAndPartExist IS NULL or @OrderAndPartExist=0)
				BEGIN 
					--Order exists, but part does not exist --> add part to it
					INSERT INTO OrderParts(OrderId,PartId, Quantity)
					VALUES
					(@OrderId, @PartId, @Quantity)
				END
			ELSE
				BEGIN
					--Order and part exist --> update quantity
					UPDATE OrderParts 
					SET Quantity+=@Quantity
					WHERE PartId=@PartId AND OrderId=@OrderId
				END
		END
END

DECLARE @err_msg AS NVARCHAR(MAX);
BEGIN TRY
BEGIN TRANSACTION

  EXEC usp_PlaceOrder 45, '285753A', 100
  ROLLBACK
END TRY

BEGIN CATCH
  SET @err_msg = ERROR_MESSAGE();
  SELECT @err_msg
END CATCH

--19.	Detect Delivery


CREATE OR ALTER TRIGGER T_Delivered_Parts_To_Stock ON Orders FOR UPDATE
AS
BEGIN	
		DECLARE @DeleveredOrders TABLE (OrderId INT);
		INSERT INTO @DeleveredOrders
		SELECT OrderId
		FROM inserted AS O
		WHERE  O.Delivered=1;
		DECLARE @DeleveredPartsAndQuantities TABLE (Id INT PRIMARY KEY IDENTITY, PartId INT , Quantity INT);
		INSERT INTO @DeleveredPartsAndQuantities
		SELECT PartId, Quantity
		FROM OrderParts AS OP
		WHERE OrderId IN (SELECT OrderId FROM @DeleveredOrders);
		DECLARE @Id INT =0;
		DECLARE @MAXID INT = (SELECT MAX(ID) FROM @DeleveredPartsAndQuantities);
		WHILE (@Id <= @MAXID)
			BEGIN
				UPDATE Parts
				SET StockQty+=(SELECT Quantity
								FROM @DeleveredPartsAndQuantities AS DPQ 
								WHERE DPQ.Id=@Id)
				WHERE PartId = (SELECT PartId FROM @DeleveredPartsAndQuantities AS DPQ 
								WHERE DPQ.Id=@Id);
				SET @Id+=1;
			END		
END

BEGIN TRANSACTION

SELECT  P.PARTID,P.StockQty
	FROM Parts AS P
	JOIN OrderParts AS OP
	ON OP.PartId=P.PartId
	JOIN Orders AS O
	ON O.OrderId=OP.OrderId
	WHERE O.OrderId IN (6,9)

UPDATE Orders
SET Delivered = 1
WHERE OrderId = 9


UPDATE Orders
SET Delivered = 1
WHERE OrderId = 6

SELECT P.PARTID,P.StockQty
	FROM Parts AS P
	JOIN OrderParts AS OP
	ON OP.PartId=P.PartId
	JOIN Orders AS O
	ON O.OrderId=OP.OrderId
	WHERE O.OrderId  IN (6,9)

ROLLBACK

--Section 5. Bonus (10 pts)

--20.	Vendor Preference

DECLARE @TotalOrderedParts TABLE (MechanicId INT PRIMARY KEY, SumTotalParts INT NOT NULL);

INSERT INTO @TotalOrderedParts
SELECT M.MechanicId,SUM(OP.Quantity) AS [TotalQuantity]
										FROM Mechanics AS M
										JOIN Jobs AS J
										ON J.MechanicId=M.MechanicId
										JOIN Orders AS O
										ON O.JobId= J.JobId
										JOIN OrderParts AS OP
										ON OP.OrderId=O.OrderId
										JOIN Parts AS P
										ON P.PartId=OP.PartId
										JOIN Vendors AS V
										ON V.VendorId=P.VendorId
										GROUP BY M.MechanicId;

SELECT M.FirstName+' '+M.LastName AS [Mechanic],
		V.Name AS [Vendor],
		SUM(OP.Quantity) AS [Parts],
		CAST(SUM(OP.Quantity)*100 / (SELECT SumTotalParts FROM @TotalOrderedParts
							WHERE MechanicId=M.MechanicId) AS VARCHAR(3))+'%' AS [Preference]
FROM Mechanics AS M
JOIN Jobs AS J
ON J.MechanicId=M.MechanicId
JOIN Orders AS O
ON O.JobId= J.JobId
JOIN OrderParts AS OP
ON OP.OrderId=O.OrderId
JOIN Parts AS P
ON P.PartId=OP.PartId
JOIN Vendors AS V
ON V.VendorId=P.VendorId
GROUP BY M.MechanicId,M.FirstName+' '+M.LastName, V.Name
ORDER BY [Mechanic],[Parts] DESC,[Vendor]