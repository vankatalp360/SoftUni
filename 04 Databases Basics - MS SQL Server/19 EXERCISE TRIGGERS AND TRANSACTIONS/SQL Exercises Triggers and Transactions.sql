
--PART I – Queries for Bank Database

--Problem 14.	Deposit Money

USE BANK

GO

DROP PROC usp_DepositMoney

CREATE OR ALTER PROC usp_DepositMoney  (@AccountId INT, @moneyAmount MONEY)
AS
BEGIN
	IF(@AccountId<=0)
			BEGIN
				RAISERROR ('Invalide account!',16,3);
				RETURN;
			END;
		IF(@moneyAmount<0)
			BEGIN
				RAISERROR ('Invalide deposit amount!',16,2);
				RETURN;
			END;	
		
	BEGIN TRANSACTION
	  UPDATE Accounts
	  SET Balance += @moneyAmount
	  WHERE (Id = @AccountId)
  
	  IF (@@ROWCOUNT <> 1) 
		BEGIN
		  ROLLBACK;
		  RAISERROR ('Invalid account!', 16, 1);
		  RETURN;
		END
	 COMMIT;
END;
SELECT * FROM Accounts
EXEC usp_DepositMoney 1, 100

GO

--Problem 15.	Withdraw Money

DROP PROC usp_WithdrawMoney

CREATE OR ALTER PROC usp_WithdrawMoney (@AccountId INT, @moneyAmount MONEY)
AS
BEGIN
		IF(@AccountId<=0)
			BEGIN
				RAISERROR ('Invalide account!',16,4);
				RETURN;
			END;
		IF(@moneyAmount<0)
			BEGIN
				RAISERROR ('Invalide deposit amount!',16,3);
				RETURN;
			END;
		IF((SELECT Balance 
			FROM Accounts
			WHERE Id=@AccountId)<@moneyAmount)
			BEGIN
				RAISERROR ('Insufficient funds!',16,2);
				RETURN;
			END;

		BEGIN TRANSACTION
		  UPDATE Accounts
		  SET Balance -= @moneyAmount
		  WHERE Id = @accountId

		  IF (@@ROWCOUNT <> 1)
		  BEGIN
			ROLLBACK;
			RAISERROR ('Invalid account!', 16, 1);
			RETURN;
		  END
		 COMMIT;
END;

SELECT * FROM Accounts

EXEC usp_WithdrawMoney 1, 100

GO
--Problem 16.	Money Transfer

CREATE OR ALTER PROC usp_TransferMoney(@senderId INT, @receiverId INT, @amount MONEY)
AS 
BEGIN
	BEGIN TRANSACTION

		EXEC usp_WithdrawMoney @senderId, @amount;
		
		EXEC usp_DepositMoney @receiverId, @amount;
		
	COMMIT
END 

SELECT * FROM Accounts

EXEC bank.dbo.usp_TransferMoney 1, 2, 100

--Problem 1.	Create Table Logs

CREATE TABLE Logs 
(LogId INT PRIMARY KEY IDENTITY,
 AccountId INT FOREIGN KEY REFERENCES ACCOUNTS(ID), 
 OldSum MONEY NOT NULL,
 NewSum MONEY NOT NULL)

 CREATE OR ALTER TRIGGER T_Accounts_After_Update ON Accounts AFTER UPDATE
 AS 
 BEGIN
	INSERT INTO	Logs (AccountId, OldSum, NewSum)
	SELECT d.Id , d.Balance, i.Balance
	FROM deleted AS d
	JOIN inserted AS i 
	ON d.Id=i.Id 
 END

 SELECT * FROM Accounts

 UPDATE Accounts 
 SET Balance-=100
 WHERE Id=1

 SELECT * FROM Logs

 --Problem 2.	Create Table Emails

 SELECT *
 FROM Accounts

 DROP TRIGGER  T_Logs_After_Update
 DROP TABLE NotificationEmails

 CREATE  TABLE NotificationEmails
 (Id INT IDENTITY PRIMARY KEY, 
 Recipient INT FOREIGN KEY REFERENCES Accounts(Id), 
 Subject VARCHAR(MAX) NOT NULL, 
 Body VARCHAR(MAX) NOT NULL)

 CREATE OR ALTER TRIGGER  T_Logs_After_Update ON Logs AFTER INSERT
 AS
 BEGIN
	DECLARE @recipient int = (SELECT AccountId FROM inserted);
	DECLARE @oldBalance money = (SELECT OldSum FROM inserted);
	DECLARE @newBalance money = (SELECT NewSum FROM inserted);
	DECLARE @subject varchar(200) = CONCAT('Balance change for account: ', @recipient);
	DECLARE @body varchar(200) = 
		CONCAT('On ', GETDATE(), ' your balance was changed from ', @oldBalance, ' to ', @newBalance, '.');  

	INSERT INTO NotificationEmails (Recipient, Subject, Body) 
	VALUES (@recipient, @subject, @body)
 END

  UPDATE Accounts 
 SET Balance-=100
 WHERE Id=1

 SELECT *
 FROM NotificationEmails

 select *
 from Accounts

 select *
 from AccountHolders

 --PART II – Queries for Diablo Database
  USE Diablo

 --Problem 6.	Trigger
 CREATE OR ALTER TRIGGER T_Items_Buying_Restrictions ON UserGameItems FOR INSERT
 AS
BEGIN
  DECLARE @userGameLevel int = (
    SELECT ug.Level
    FROM inserted AS ugi -- UserGameItems
    JOIN UsersGames AS ug ON ugi.UserGameId = ug.Id
  );
  DECLARE @itemMinLevel int = (
    SELECT i.MinLevel
    FROM inserted AS ugi -- UserGameItems
    JOIN Items AS i on i.Id = ugi.ItemId
  );
  IF(@itemMinLevel > @userGameLevel)
    BEGIN
      ROLLBACK;
      RAISERROR('Higher user game level required for item purchase!', 16, 1);
      RETURN;
    END
END

DELETE FROM USERGAMEITEMS 
WHERE ItemId=3 AND UserGameId=3

SELECT * FROM USERGAMEITEMS
SELECT * FROM ITEMS WHERE ID =3
SELECT * FROM USERSGAMES WHERE ID = 4

 INSERT INTO USERGAMEITEMS (ItemId, UserGameId) VALUES (3, 3);


 CREATE OR ALTER PROC udp_Add_Bonus_Cash 
 AS
 BEGIN
	IF OBJECT_ID('ListOfUserId', 'TABLE') IS NOT NULL 
		BEGIN
			DROP TABLE DBO.ListOfUserId;
		END;
	DECLARE @moneyAmount MONEY =50000;
	DECLARE @GameName NVARCHAR(50) = 'Bali';
	DECLARE @GameId INT = (SELECT G.Id 
								FROM Games AS G 
								WHERE G.Name = @GameName);
	DECLARE @ListOfUserId TABLE (Id INT);
	INSERT INTO @ListOfUserId 
			SELECT U.Id 
			FROM Users AS U 
			WHERE U.Username IN 
				('baleremuda', 'loosenoise', 'inguinalself', 'buildingdeltoid', 'monoxidecos');

	UPDATE UsersGames 
	SET Cash +=@moneyAmount
		WHERE UserId IN (SELECT Id FROM @ListOfUserId) AND GameId=@GameId;

	IF OBJECT_ID('ListOfUserId', 'TABLE') IS NOT NULL 
		BEGIN
			DROP TABLE DBO.ListOfUserId;
		END;
 END;
 

 EXEC udp_Add_Bonus_Cash

 SELECT UG.Cash
FROM UserGameItems AS UGI
JOIN UsersGames AS UG
ON UG.Id = UGI.UserGameId
JOIN Users AS U
ON U.Id = UG.UserId
JOIN Games AS G
ON G.Id = UG.GameId
WHERE U.Username IN ('baleremuda', 'loosenoise', 'inguinalself', 'buildingdeltoid', 'monoxidecos') 
	AND G.Name LIKE 'Bali'


CREATE OR ALTER TRIGGER T_Take_Cash_For_Bough_Item ON UserGameItems FOR INSERT
AS
BEGIN
	DECLARE @ItemId INT = (SELECT ItemId FROM inserted);
	DECLARE @UserGameId INT = (SELECT UserGameId FROM inserted);

	DECLARE @ItemPrice MONEY = (SELECT Price 
								FROM Items 
								WHERE Id =@ItemId );
	BEGIN TRANSACTION 

	UPDATE UsersGames 
	SET Cash -=@ItemPrice
		WHERE Id =@UserGameId;

	IF((SELECT Cash FROM UsersGames WHERE Id =@UserGameId)< 0) 
		BEGIN
		  ROLLBACK; 
		  RAISERROR('You have no enough cash!', 16, 3);
		  RETURN;
		END;

	IF(@@ROWCOUNT <> 1) 
		BEGIN
		  ROLLBACK; RAISERROR('Could not buy the item', 16, 2);
		  RETURN;
		END;
END;

CREATE OR ALTER PROC udp_Add_Items
AS
BEGIN
	IF OBJECT_ID('UserGameItemsTable', 'TABLE') IS NOT NULL 
		BEGIN
			DROP TABLE DBO.UserGameItemsTable;
		END;
	DECLARE @UserGameItemsTable TABLE (ItemId INT, UserGameId INT);
	INSERT INTO @UserGameItemsTable
	SELECT I.Id,UG.Id 
			FROM UsersGames AS UG
			CROSS JOIN Items AS I
			WHERE UG.GameId =(SELECT G.Id 
								FROM Games AS G 
								WHERE G.Name = 'Bali') 
			AND UG.UserId IN 
				(SELECT U.Id 
					FROM Users AS U 
					WHERE U.Username IN 
						('baleremuda', 'loosenoise', 'inguinalself', 'buildingdeltoid', 'monoxidecos'))
			AND ((I.Id BETWEEN 251 AND 299) OR (I.Id BETWEEN 501 AND 539))
			AND UG.Level>=I.MinLevel;	
	
	INSERT INTO UserGameItems(ItemId,UserGameId)
	(SELECT UT.ItemId, UT.UserGameId
	FROM @UserGameItemsTable AS UT
	LEFT JOIN UserGameItems AS UGI
	ON UT.ItemId=UGI.ItemId AND UT.UserGameId=UGI.UserGameId
	WHERE UGI.ItemId IS NULL OR UGI.UserGameId IS NULL );

END;


begin transaction
exec udp_Add_Items
rollback

SELECT U.Username , G.Name , UG.Cash , I.Name AS [Item Name]
FROM UserGameItems AS UGI
JOIN UsersGames AS UG
ON UG.Id = UGI.UserGameId
JOIN Users AS U
ON U.Id = UG.UserId
JOIN Games AS G
ON G.Id = UG.GameId
JOIN Items AS I
ON I.Id = UGI.ItemId
WHERE U.Username IN ('baleremuda', 'loosenoise', 'inguinalself', 'buildingdeltoid', 'monoxidecos') 
	AND G.Name LIKE 'Bali'
ORDER BY U.Username,I.Name

--Problem 7.	*Massive Shopping

DECLARE @UserId INT = (SELECT Id FROM Users WHERE Username LIKE 'Stamat')
DECLARE @GameId INT = (SELECT Id FROM Games WHERE [Name] LIKE 'Safflower')
DECLARE @UserGameId INT = (SELECT Id FROM UsersGames WHERE UserId=@UserId AND GameId=@GameId)
BEGIN TRY
	BEGIN TRANSACTION
		DECLARE @ItemsCost DECIMAL (15,4) = (SELECT SUM(Price)
											FROM Items 
											WHERE MinLevel BETWEEN 11 AND 12);
		UPDATE UsersGames 
		SET Cash -= @ItemsCost
		WHERE Id = @UserGameId;

		IF (SELECT Cash FROM UsersGames WHERE Id = @UserGameId)<0
			BEGIN
				ROLLBACK;
			END;
		 
		
		INSERT INTO UserGameItems (ItemId, UserGameId)
		SELECT Id,  @UserGameId
			FROM Items 
			WHERE MinLevel BETWEEN 11 AND 12;
		COMMIT;
END TRY
BEGIN CATCH
	ROLLBACK;
END CATCH
BEGIN TRY
	BEGIN TRANSACTION
		SET @ItemsCost = (SELECT SUM(Price)
											FROM Items 
											WHERE MinLevel BETWEEN 19 AND 21);
		UPDATE UsersGames 
		SET Cash -= @ItemsCost
		WHERE Id = @UserGameId;

		IF (SELECT Cash FROM UsersGames WHERE Id = @UserGameId)<0
			BEGIN
				ROLLBACK;
			END;
		 
		
		INSERT INTO UserGameItems (ItemId, UserGameId)
		SELECT Id,  @UserGameId
			FROM Items 
			WHERE MinLevel BETWEEN 19 AND 21 
		COMMIT;
END TRY
BEGIN CATCH
	ROLLBACK;
END CATCH

SELECT NAME
FROM ITEMS AS I
JOIN USERGAMEITEMS AS UGI
ON I.ID = UGI . ITEMID
WHERE @UserGameId = UGI.UserGameId
ORDER BY NAME

 --Part III – Queries for SoftUni Database

 USE SoftUni

 --Problem 1.	Employees with Three Projects
 GO
CREATE PROC usp_AssignProject(@EmployeeID INT, @ProjectID INT) --SoftUni Solution
AS 
BEGIN
	DECLARE @maxEmployeeProjectsCount INT = 3
	DECLARE @employeeProjectsCount INT
	SET @employeeProjectsCount = (SELECT COUNT(*) 
					FROM [dbo].[EmployeesProjects] AS ep
				   WHERE ep.EmployeeId = @EmployeeID)
	BEGIN TRAN
		INSERT INTO [dbo].[EmployeesProjects]  (EmployeeID, ProjectID) VALUES (@EmployeeID, @ProjectID)

		IF(@employeeProjectsCount >= @maxEmployeeProjectsCount)
		  BEGIN
		   RAISERROR('The employee has too many projects!', 16, 1)
		   ROLLBACK
		  END
		ELSE
		   COMMIT
END



CREATE OR ALTER PROC usp_AssignProject(@EmployeeID INT, @ProjectID INT) --My solution
AS 
BEGIN
	DECLARE @maxEmployeeProjectsCount INT = 3;
	DECLARE @employeeProjectsCount INT
	SET @employeeProjectsCount = (SELECT COUNT(*) 
					FROM [dbo].[EmployeesProjects] AS ep
				   WHERE ep.EmployeeId = @EmployeeID);
	IF(@employeeProjectsCount >= @maxEmployeeProjectsCount)
		  BEGIN
		   RAISERROR('The employee has too many projects!', 16, 1);
		   END
		ELSE
			BEGIN
				BEGIN TRAN
				INSERT INTO [dbo].[EmployeesProjects]  (EmployeeID, ProjectID) VALUES (@EmployeeID, @ProjectID)

				IF(@@ROWCOUNT<>1)
				  BEGIN
				   RAISERROR('The employee has too many projects!', 16, 1)
				   ROLLBACK
				  END
				ELSE
				   COMMIT
			END;	
END

SELECT *
FROM EmployeesProjects AS EP
WHERE EP.EmployeeID=1

EXEC usp_AssignProject 1, 1

--Problem 9.	Delete Employees

USE SoftUni

DROP TABLE Deleted_Employees
SELECT * FROM EMPLOYEES
ALTER TABLE EMPLOYEES DROP COLUMN Deleted

CREATE TABLE Deleted_Employees
(
EmployeeID INT PRIMARY KEY identity,
FirstName VARCHAR(50) NOT NULL,
LastName VARCHAR(50) NOT NULL,
MiddleName VARCHAR(50),
JobTitle VARCHAR(50),
DepartmentID INT NOT NULL,
Salary MONEY NOT NULL
)

 CREATE OR ALTER TRIGGER T_Employees_After_Delete ON Employees AFTER  DELETE
 AS 
 BEGIN
	SET IDENTITY_INSERT Deleted_Employees ON

	INSERT INTO	Deleted_Employees (EmployeeID, FirstName , LastName, MiddleName, JobTitle, DepartmentID, Salary)
	SELECT E.EmployeeID , E.FirstName, E.LastName , E.MiddleName, E.JobTitle, E.DepartmentID, E.Salary
	FROM deleted AS E

	SET IDENTITY_INSERT Deleted_Employees OFF

 END
 
 DELETE FROM EMPLOYEES WHERE EMPLOYEEID=1
