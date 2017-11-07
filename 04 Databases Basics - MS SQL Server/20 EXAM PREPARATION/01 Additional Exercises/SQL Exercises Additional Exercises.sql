--Exercises: Additional Exercises

--PART I – Queries for Diablo Database
USE Diablo
--Problem 1.	Number of Users for Email Provider


SELECT 
	SUBSTRING(u.Email, CHARINDEX('@', u.Email)+LEN('@'),LEN(u.Email)) AS [Email Provider],
	COUNT (U.Username) AS [Number Of Users]
	FROM Users AS U
	GROUP BY SUBSTRING(u.Email, CHARINDEX('@', u.Email)+LEN('@'),LEN(u.Email))
	ORDER BY [Number Of Users] DESC, [Email Provider]


--Problem 2.	All User in Games

SELECT 
	G.Name AS [Game], 
	GT.Name AS [Game Type], 
	U.Username AS [Username],
	UG.Level AS [Level],
	UG.Cash AS [Cash], 
	C.Name AS [Character]
FROM UsersGames AS UG
JOIN Users AS U
ON U.Id=UG.UserId
JOIN Games AS G
ON G.Id=UG.GameId
JOIN GameTypes AS GT
ON GT.Id = G.GameTypeId
JOIN Characters AS C
ON C.Id = UG.CharacterId
ORDER BY UG.Level DESC, U.Username,G.Name

--Problem 3.	Users in Games with Their Items

SELECT U.Username AS [Username],
		G.Name AS [Game],
		COUNT (*) AS [Items Count],
		SUM(I.Price) AS [Items Price]
FROM Games AS G
JOIN UsersGames AS UG
ON UG.GameId=G.Id
JOIN UserGameItems AS UGI
ON UGI.UserGameId = UG.Id
JOIN Items AS I
ON I.Id = UGI.ItemId
JOIN Users AS U
ON U.Id = UG.UserId
GROUP BY G.Name, U.Username
HAVING COUNT(*) >=10
ORDER BY [Items Count] DESC , [Items Price] DESC , [Username]


--Problem 4.	* User in Games with Their Statistics

SELECT U.Username AS [Username],
		G.Name AS [Game], 
		MAX(CH.Name) AS [Character], 
		SUM(S3.Strength)+MAX(S2.Strength)+MAX(S1.Strength) AS [Strength],
		SUM(S3.Defence)+MAX(S2.Defence)+MAX(S1.Defence) AS [Defence],
		SUM(S3.Speed)+MAX(S2.Speed)+MAX(S1.Speed) AS [Speed],
		SUM(S3.Mind)+MAX(S2.Mind)+MAX(S1.Mind) AS [Mind],
		SUM(S3.Luck)+MAX(S2.Luck)+MAX(S1.Luck) AS [Luck]
FROM Games AS G
JOIN UsersGames AS UG
ON UG.GameId=G.Id
JOIN Users AS U
ON U.Id=UG.UserId
JOIN Characters AS CH
ON CH.Id=UG.CharacterId
JOIN GameTypes AS GT
ON GT.Id=G.GameTypeId
JOIN UserGameItems AS UGI
ON UGI.UserGameId=UG.Id
JOIN Items AS I
ON I.Id = UGI.ItemId
LEFT OUTER JOIN [Statistics] AS S1
ON S1.Id=CH.StatisticId 
LEFT OUTER JOIN [Statistics] AS S2
ON S2.Id=GT.BonusStatsId
LEFT OUTER JOIN [Statistics] AS S3
ON S3.Id=I.StatisticId
GROUP BY U.Username, G.Name
ORDER BY [Strength] DESC,[Defence] DESC,[Speed] DESC,[Mind] DESC,[Luck] DESC

--Problem 5.	All Items with Greater than Average Statistics

DECLARE @AvgMind INT = (SELECT AVG(CAST(S.Mind AS decimal(10,2)))
									FROM [Statistics] AS S);

DECLARE @AvgLuck INT = (SELECT AVG(CAST(S.Luck AS decimal(10,2)))
									FROM [Statistics] AS S);

DECLARE @AvgSpeed INT = (SELECT AVG(CAST(S.Speed AS decimal(10,2)))
									FROM [Statistics] AS S);
SELECT 
	I.Name AS [Name],
	I.Price AS [Price],
	I.MinLevel AS [MinLevel],
	S.Strength AS [Strength],
	S.Defence AS [Defence],
	S.Speed AS [Speed],
	S.Luck AS [Luck],
	S.Mind AS [Mind]
FROM Items AS I
JOIN [Statistics] AS S
ON I.StatisticId=S.Id
WHERE S.Mind>@AvgMind AND S.Luck>@AvgLuck AND S.Speed>@AvgSpeed
ORDER BY [Name]

--Problem 6.	Display All Items with Information about Forbidden Game Type

SELECT 
	I.Name AS [Item],
	I.Price AS [Price],
	I.MinLevel AS [MinLevel],
	GT.Name AS [Forbidden Game Type]
FROM Items AS I
LEFT OUTER JOIN GameTypeForbiddenItems AS GTFI
ON GTFI.ItemId=I.Id
LEFT OUTER JOIN GameTypes AS GT
ON GT.Id=GTFI.GameTypeId
ORDER BY [Forbidden Game Type] DESC,[Item]


--Problem 7.	Buy Items for User in Game

DECLARE @GameId INT = (SELECT Id
					FROM Games 
					WHERE Name LIKE 'Edinburgh');
DECLARE @UserId INT = (SELECT Id
						FROM Users
						WHERE Username LIKE 'Alex');
DECLARE @UserGameId INT = (SELECT Id
						FROM UsersGames
						WHERE UserId=@UserId AND GameId=@GameId);
DECLARE @ListOfItemId TABLE (Id INT);
	INSERT INTO @ListOfItemId 
			SELECT I.Id 
			FROM Items AS I 
			WHERE I.Name IN 
				('Blackguard','Bottomless Potion of Amplification',
				'Eye of Etlich (Diablo III)','Gem of Efficacious Toxin',
				'Golden Gorget of Leoric','Hellfire Amulet');
				
BEGIN TRANSACTION

DECLARE @TotalCost DECIMAL(15,4) =(SELECT SUM(I.Price)
									FROM Items AS I
									WHERE I.Id IN (SELECT Id FROM @ListOfItemId));
UPDATE UsersGames
SET Cash-=@TotalCost
WHERE UserId=@UserId AND GameId=@GameId
IF (@@ROWCOUNT <> 1) 
		BEGIN
		  ROLLBACK;
		  RAISERROR ('Invalid accounts!', 16, 1);
		END;
IF ((SELECT Cash
		FROM UsersGames 
		WHERE UserId=@UserId AND GameId=@GameId)<0) 
			BEGIN
			  ROLLBACK;
			  RAISERROR ('No sufficient fund!', 16, 2);
			END;
INSERT INTO UserGameItems(ItemId, UserGameId)
SELECT Id, @UserGameId
FROM @ListOfItemId
IF (@@ROWCOUNT <> (SELECT COUNT(*) FROM @ListOfItemId)) 
		BEGIN
		  ROLLBACK;
		  RAISERROR ('Invalid transaction!', 16, 3);
		END;
COMMIT;

SELECT 
	U.Username AS [Username],
	G.Name AS [Name],
	UG.Cash AS [Cash],
	I.Name AS [Item Name]
FROM Users AS U
JOIN UsersGames AS UG
ON UG.UserId=U.Id
JOIN Games AS G
ON G.Id=UG.GameId
JOIN UserGameItems AS UGI
ON UGI.UserGameId=UG.Id
JOIN Items AS I
ON I.Id=UGI.ItemId
WHERE UG.GameId=@GameId
ORDER BY I.Name

--PART II – Queries for Geography Database

USE Geography

--Problem 8.	Peaks and Mountains

SELECT P.PeakName AS [PeakName],
M.MountainRange [Mountain], 
P.Elevation AS [Elevation]
FROM Peaks AS P
JOIN Mountains AS M
ON P.MountainId=M.Id
ORDER BY P.Elevation DESC, P.PeakName

--Problem 9.	Peaks with Their Mountain, Country and Continent

SELECT P.PeakName AS [PeakName],
		M.MountainRange AS [Mountain],
		CO.CountryName AS [CountryName],
		C.ContinentName AS [ContinentName]
FROM Peaks AS P
JOIN Mountains AS M
ON P.MountainId=M.Id
JOIN MountainsCountries AS MC
ON M.Id=MC.MountainId
JOIN Countries AS CO
ON MC.CountryCode=CO.CountryCode
JOIN Continents AS C
ON C.ContinentCode=CO.ContinentCode
ORDER BY P.PeakName, CO.CountryName

--Problem 10.	Rivers by Country

SELECT C.CountryName AS [CountryName],
		CON.ContinentName AS [ContinentName],
		COUNT(R.RiverName) AS [RiversCount],
		ISNULL(SUM(R.Length),0)  AS [TotalLength]
FROM Countries AS C
JOIN Continents AS CON
ON CON.ContinentCode=C.ContinentCode
LEFT OUTER JOIN CountriesRivers AS CR
ON CR.CountryCode=C.CountryCode
LEFT OUTER JOIN Rivers AS R
ON R.Id=CR.RiverId
GROUP BY C.CountryName, CON.ContinentName
ORDER BY [RiversCount] DESC , [TotalLength] DESC,[CountryName]

--Problem 11.	Count of Countries by Currency

SELECT cu.CurrencyCode, 
		cu.Description AS [Currency], 
		COUNT(co.CurrencyCode) AS [NumberOfCountries]
FROM Currencies AS cu
LEFT JOIN Countries AS co
ON co.CurrencyCode = cu.CurrencyCode
GROUP BY cu.CurrencyCode, cu.Description
ORDER BY NumberOfCountries DESC, Currency

--Problem 12.	Population and Area by Continent

SELECT CON.ContinentName AS [ContinentName],
		SUM(CONVERT(DECIMAL(15,0),COU.AreaInSqKm)) AS [CountriesArea],
		SUM(CONVERT(DECIMAL(15,0),COU.Population)) AS [CountriesPopulation]
FROM Continents AS CON
LEFT OUTER JOIN Countries AS COU
ON COU.ContinentCode=CON.ContinentCode
GROUP BY CON.ContinentName
ORDER BY [CountriesPopulation] DESC

--Problem 13.	Monasteries by Country

CREATE TABLE Monasteries(
Id INT IDENTITY PRIMARY KEY, 
Name NVARCHAR(50), 
CountryCode char(2) FOREIGN KEY REFERENCES Countries(CountryCode)
)

INSERT INTO Monasteries(Name, CountryCode) VALUES
('Rila Monastery “St. Ivan of Rila”', 'BG'), 
('Bachkovo Monastery “Virgin Mary”', 'BG'),
('Troyan Monastery “Holy Mother''s Assumption”', 'BG'),
('Kopan Monastery', 'NP'),
('Thrangu Tashi Yangtse Monastery', 'NP'),
('Shechen Tennyi Dargyeling Monastery', 'NP'),
('Benchen Monastery', 'NP'),
('Southern Shaolin Monastery', 'CN'),
('Dabei Monastery', 'CN'),
('Wa Sau Toi', 'CN'),
('Lhunshigyia Monastery', 'CN'),
('Rakya Monastery', 'CN'),
('Monasteries of Meteora', 'GR'),
('The Holy Monastery of Stavronikita', 'GR'),
('Taung Kalat Monastery', 'MM'),
('Pa-Auk Forest Monastery', 'MM'),
('Taktsang Palphug Monastery', 'BT'),
('Sümela Monastery', 'TR')

ALTER TABLE Countries 
ADD IsDeleted BIT DEFAULT 0;


UPDATE Countries
SET IsDeleted = 1
WHERE CountryCode IN (
SELECT COU.CountryCode
FROM Countries AS COU
JOIN CountriesRivers AS CR
ON CR.CountryCode=COU.CountryCode
JOIN Rivers AS R
ON R.Id=CR.RiverId
GROUP BY COU.CountryCode
HAVING COUNT(R.Id)>3)

SELECT M.Name AS [Monastery],
		COU.CountryName AS [Country]
FROM Monasteries AS M
JOIN Countries AS COU
ON COU.CountryCode=M.CountryCode
WHERE COU.IsDeleted<>1
ORDER BY M.Name

--Problem 14.	Monasteries by Continents and Countries

UPDATE Countries
SET CountryName = 'Burma'
WHERE CountryName LIKE 'Myanmar'

INSERT INTO Monasteries (Name,CountryCode)
VALUES
('Hanga Abbey',(SELECT CountryCode FROM Countries
WHERE CountryName LIKE 'Tanzania')),
('Myin-Tin-Daik', (SELECT CountryCode FROM Countries
WHERE CountryName LIKE 'Myanmar'))

SELECT ContinentName AS [ContinentName], CountryName AS [CountryName], COUNT(M.ID) AS [MonasteriesCount]
FROM Continents AS CON
JOIN Countries AS COU
ON CON.ContinentCode=COU.ContinentCode
LEFT OUTER JOIN Monasteries AS M
ON M.CountryCode=COU.CountryCode
WHERE COU.IsDeleted<>1
GROUP BY ContinentName,CountryName
ORDER BY [MonasteriesCount] DESC,CountryName

SELECT * FROM INFORMATION_SCHEMA.TABLES
