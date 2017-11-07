
--Problem 1.	One-To-One Relationship

CREATE TABLE Passports (
    PassportID INT NOT NULL ,
    PassportNumber NVARCHAR(50),
    )
CREATE TABLE Persons(
    PersonID INT NOT NULL ,
    FirstName NVARCHAR(50),
    Salary DECIMAL(10,2),
    PassportID INT NOT NULL UNIQUE
)

ALTER TABLE Persons
  ADD CONSTRAINT PK_PersonID PRIMARY KEY (PersonID)

ALTER TABLE Passports
  ADD CONSTRAINT PK_PassportId PRIMARY KEY (PassportId)

ALTER TABLE Persons
ADD CONSTRAINT FK_Persons_Passports
FOREIGN KEY (PassportId) REFERENCES Passports(PassportId);

ALTER TABLE Persons
ADD CONSTRAINT FK_PassportId
UNIQUE(PassportId);

INSERT INTO Passports (PassportId, PassportNumber)
VALUES 
(101,'N34FG21B'),
(102,'K65LO4R7'),
(103,'ZE657QP2')

INSERT INTO Persons (PersonID, FirstName, Salary, PassportId)
VALUES 
(1,'Roberto',43300.00,101),
(2,'Tom',56100.00,102),
(3,'Yana',60200.00,103)


--INSERT INTO Persons (PersonID, FirstName, Salary, PassportId)
--VALUES 
--(4,'Roberto',43300.00,101),
--(5,'Tom',56100.00,102),
--(6,'Yana',60200.00,103)

--Problem 2.	One-To-Many Relationship

 CREATE TABLE Models
 (
 ModelID INT NOT NULL ,
 [Name] VARCHAR(50),
 ManufacturerID INT NOT NULL 
 )

 CREATE TABLE Manufacturers
 (
 ManufacturerID INT NOT NULL ,
 [Name] VARCHAR (50),
 EstablishedOn DATE
 )

 INSERT INTO Models (ModelID, [Name],ManufacturerID)
 VALUES
 (101, 'X1',1),
  (102, 'i6',1),
   (103, 'Model S',2),
    (104, 'Model X',2),
	 (105, 'Model 3',2),
	  (106, 'Nova',3)

INSERT INTO Manufacturers (ManufacturerID, [Name],EstablishedOn)
 VALUES
 (1, 'BMW','1916-03-07'),
  (2, 'Tesla','2003-01-01'),
   (3, 'Lada','1966-05-01')
  
ALTER TABLE Models
  ADD CONSTRAINT PK_ModelID PRIMARY KEY (ModelID)

ALTER TABLE Manufacturers
  ADD CONSTRAINT PK_ManufacturerID PRIMARY KEY (ManufacturerID)

ALTER TABLE Models
  ADD CONSTRAINT FK_Models_Manufacturers 
  FOREIGN KEY (ManufacturerID) REFERENCES Manufacturers(ManufacturerID);


--Problem 3.	Many-To-Many Relationship

CREATE TABLE Students
(
StudentID INT NOT NULL UNIQUE,
[Name] VARCHAR(50)
)

INSERT INTO Students(StudentID, [Name])
VALUES
(1, 'Mila'),
(2, 'Toni'),
(3, 'Ron')

CREATE TABLE Exams
(
ExamID INT NOT NULL UNIQUE,
[Name] VARCHAR(50)
)

INSERT INTO Exams(ExamID, [Name])
VALUES
(101, 'SpringMVC'),
(102, 'Neo4j'),
(103, 'Oracle 11g')

CREATE TABLE StudentsExams
(
StudentID INT NOT NULL,
ExamID INT NOT NULL
)

INSERT INTO StudentsExams(StudentID, ExamID)
VALUES
(1, 101),
(1, 102),
(2, 101),
(3, 103),
(2, 102),
(2, 103)

ALTER TABLE Students
  ADD CONSTRAINT PK_Students PRIMARY KEY (StudentID)
  
ALTER TABLE Exams
  ADD CONSTRAINT PK_Exams PRIMARY KEY (ExamID)

ALTER TABLE StudentsExams
  ADD CONSTRAINT PK_StudentsExams PRIMARY KEY (StudentID,ExamID)

ALTER TABLE StudentsExams
  ADD CONSTRAINT FK_StudentsExams_Students 
  FOREIGN KEY (StudentID) REFERENCES Students(StudentID);

ALTER TABLE StudentsExams
  ADD CONSTRAINT FK_StudentsExams_Exams 
  FOREIGN KEY (ExamID) REFERENCES Exams(ExamID);


--Problem 4.	Self-Referencing 

CREATE TABLE Teachers
(
TeacherID INT NOT NULL UNIQUE,
[Name] VARCHAR (50) NOT NULL,
ManagerID INT
)

SELECT * FROM Teachers

INSERT INTO Teachers(TeacherID,[Name],ManagerID)
VALUES
(101	,'John',	NULL),
(102	,'Maya',	106),
(103	,'Silvia',	106),
(104	,'Ted',	105),
(105	,'Mark',	101),
(106	,'Greta',	101)

ALTER TABLE Teachers 
 ADD CONSTRAINT PK_TeacherID
 PRIMARY KEY (TeacherID)

 ALTER TABLE Teachers 
 ADD CONSTRAINT FK_ManagerID
 FOREIGN KEY (ManagerID) REFERENCES Teachers(TeacherID)

--Problem 5.	Online Store Database

CREATE TABLE Cities
(
CityID INT IDENTITY PRIMARY KEY,
[Name] varchar(50)
)

CREATE TABLE Customers
(
CustomerID INT IDENTITY PRIMARY KEY,
[Name] varchar(50),
Birthday DATE,
CityID INT FOREIGN KEY REFERENCES Cities(CityID) 
)

CREATE TABLE Orders
(
OrderID INT IDENTITY PRIMARY KEY,
CustomerID INT FOREIGN KEY REFERENCES Customers(CustomerId)
)

CREATE TABLE ItemTypes
(
ItemTypeID INT IDENTITY PRIMARY KEY,
[Name] varchar(50)
)

CREATE TABLE Items
(
ItemID INT IDENTITY PRIMARY KEY,
[Name] varchar(50),
ItemTypeID INT FOREIGN KEY REFERENCES ItemTypes(ItemTypeID)
)

CREATE TABLE OrderItems
(
OrderID INT NOT NULL,
ItemID INT NOT NULL,
)

ALTER TABLE OrderItems
ADD CONSTRAINT PK_Order_Item PRIMARY KEY (OrderID,ItemID)

ALTER TABLE OrderItems
ADD CONSTRAINT FK_OrderItems_OrderID
FOREIGN KEY (OrderID) REFERENCES Orders(OrderID);

ALTER TABLE OrderItems
ADD CONSTRAINT FK_OrderItems_ItemID
FOREIGN KEY (ItemID) REFERENCES Items(ItemID);

--Problem 6.	University Database

MajorID INT IDENTITY PRIMARY KEY,
[Name] varchar(50)
)

CREATE TABLE Subjects
(
SubjectID INT IDENTITY PRIMARY KEY,
SubjectName varchar(50)
)

CREATE TABLE Students
(
StudentID INT IDENTITY PRIMARY KEY,
StudentNumber INT UNIQUE,
SubjectName varchar(50),
MajorID INT FOREIGN KEY REFERENCES Majors(MajorID)
)

CREATE TABLE Payments
(
PaymentID INT IDENTITY PRIMARY KEY,
PaymentDate DATE,
PaymentAmount MONEY,
StudentID INT FOREIGN KEY REFERENCES Students(StudentID)
)

CREATE TABLE Agenda
(
StudentID INT NOT NULL,
SubjectID INT NOT NULL
)

ALTER TABLE Agenda
ADD CONSTRAINT PK_Student_Subject PRIMARY KEY (StudentID,SubjectID)

ALTER TABLE Agenda
ADD CONSTRAINT FK_Agenda_StudentID
FOREIGN KEY (StudentID) REFERENCES Students(StudentID);

ALTER TABLE Agenda
ADD CONSTRAINT FK_Agenda_SubjectID
FOREIGN KEY (SubjectID) REFERENCES Subjects(SubjectID);

--Problem 7.	SoftUni Design

--Problem 8.	Geography Design

--Problem 9.	*Peaks in Rila

SELECT M.MountainRange,P.PeakName,P.Elevation
FROM Mountains AS M
JOIN Peaks AS P ON M.Id=P.MountainId
WHERE M.MountainRange='Rila'
ORDER BY P.Elevation DESC