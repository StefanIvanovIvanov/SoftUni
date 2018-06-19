CREATE DATABASE Bank
GO
USE Bank
GO

--Problem 9.Find Full Name

CREATE PROCEDURE usp_GetHoldersFullName AS
BEGIN
	SELECT CONCAT(FirstName, ' ', LastName) AS [Full Name]
	FROM AccountHolders
END

EXEC usp_GetHoldersFullName

--Problem 10.People with Balance Higher Than

CREATE PROCEDURE usp_GetHoldersWithBalanceHigherThan (@inputNumber DECIMAL(15,4)) AS
BEGIN
WITH CTE_AccountHolderBalance(AccountHolderId, Balance) AS (
		SELECT AccountHolderID, SUM(Balance) AS TotalBalance
			FROM Accounts
	GROUP BY AccountHolderId)

	SELECT FirstName, LastName
	FROM AccountHolders AS ah
	JOIN CTE_AccountHolderBalance AS cab ON cab.AccountHolderId = ah.Id
	WHERE cab.Balance > @inputNumber
	ORDER BY ah.LastName, ah.FirstName
END

--Problem 11.Future Value Function

CREATE FUNCTION ufn_CalculateFutureValue (@sum DECIMAL (15,4), @interestRate FLOAT, @years INT)
RETURNS DECIMAL(15,4)
BEGIN
	RETURN @sum* POWER((1 + @interestRate), @years)
END

--Problem 12.Calculating Interest

CREATE PROCEDURE usp_CalculateFutureValueForAccount (@accountID INT, @interestRate FLOAT) AS
BEGIN
	SELECT a.Id, ah.FirstName, ah.LastName, a.Balance, dbo.ufn_CalculateFutureValue(Balance, @interestRate, 5) AS [Balance in 5 years]
	FROM Accounts AS a
	JOIN AccountHolders AS ah ON ah.Id = a.AccountHolderId
	WHERE a.Id = @accountID
END

--Problem 14.Create Table Logs

CREATE TABLE Logs(
LogId INT IDENTITY NOT NULL,
AccountId INT,
OldSum DECIMAL(15, 2),
NewSum DECIMAL(15, 2)
)

CREATE TRIGGER tr_Accounts
On Accounts
FOR UPDATE
AS
INSERT INTO Logs
VALUES(
       (SELECT Id FROM inserted),
	   (SELECT Balance FROM deleted),
	   (SELECT Balance FROM inserted)
	   )

VALUES
(@accountId, @oldSum, @newSum)
END

--Problem 15.Create Table Emails

CREATE TABLE NotificationEmails (
       Id INT PRIMARY KEY IDENTITY,
	     Recipient INT,
	     Subject VARCHAR(MAX),
     Body VARCHAR(MAX)
	   )

CREATE TRIGGER CreateNewNotificationEmail ON Logs
 AFTER INSERT
    AS
 BEGIN
INSERT INTO NotificationEmails
VALUES(
       (SELECT AccountId FROM inserted),
	   (CONCAT('Balance change for account: ', (SELECT AccountId FROM inserted))),
	   (CONCAT('On ',(SELECT GETDATE() FROM inserted),
	    'your balance was changed from ', (SELECT OldSum FROM inserted), 
		'to ', (SELECT NewSum FROM inserted), '.'))
	   )
   END

--Problem 16.Deposit Money


CREATE PROCEDURE usp_DepositMoney (@accountId INT, @moneyAmount DECIMAL(15,4))
AS
BEGIN

	BEGIN TRANSACTION

	UPDATE Accounts
	SET Balance = Balance + @moneyAmount
	WHERE Id = @accountId

	IF (@@ROWCOUNT <> 1)
	BEGIN
		RAISERROR('Invalid account!', 16,2)
		ROLLBACK;
		RETURN;
	END

	COMMIT
END

--Problem 17.Withdraw Money

CREATE PROCEDURE usp_WithdrawMoney (@accountId INT, @moneyAmount DECIMAL(15,4))
AS
BEGIN

DECLARE @balance DECIMAL(15, 2) = (
	SELECT Balance
	FROM Accounts AS a
	WHERE @accountId = a.Id)

	BEGIN TRANSACTION	

	IF(@balance - @moneyAmount < 0)
	BEGIN
	RAISERROR('Insufficient amount!', 16,2)
		ROLLBACK;
		RETURN;
	END

	UPDATE Accounts
	SET Balance = Balance - @moneyAmount
	WHERE Id = @accountId

	IF (@@ROWCOUNT <> 1)
	BEGIN
		RAISERROR('Invalid account!', 16,2)
		ROLLBACK;
		RETURN;
	END

	COMMIT
END

--Problem 18.Money Transfer

CREATE PROCEDURE usp_TransferMoney (@senderId int, @receiverId int, @transferAmount money)
AS
BEGIN 

  DECLARE @senderBalanceBefore money = (SELECT Balance FROM Accounts WHERE Id = @senderId);

  IF(@senderBalanceBefore IS NULL)
  BEGIN
    RAISERROR('Invalid sender account!', 16, 1);
    RETURN;

  END   

  DECLARE @receiverBalanceBefore money = (SELECT Balance FROM Accounts WHERE Id = @receiverId);  

  IF(@receiverBalanceBefore IS NULL)
  BEGIN
    RAISERROR('Invalid receiver account!', 16, 1);
    RETURN;
  END   

  IF(@senderId = @receiverId)
  BEGIN
    RAISERROR('Sender and receiver accounts must be different!', 16, 1);
    RETURN;
  END  

  IF(@transferAmount <= 0)
  BEGIN
    RAISERROR ('Transfer amount must be positive!', 16, 1); 
    RETURN;

  END 

  BEGIN TRANSACTION
  EXEC usp_WithdrawMoney @senderId, @transferAmount;
  EXEC usp_DepositMoney @receiverId, @transferAmount;

  DECLARE @senderBalanceAfter money = (SELECT Balance FROM Accounts WHERE Id = @senderId);
  DECLARE @receiverBalanceAfter money = (SELECT Balance FROM Accounts WHERE Id = @receiverId);  

  IF((@senderBalanceAfter <> @senderBalanceBefore - @transferAmount) OR 
     (@receiverBalanceAfter <> @receiverBalanceBefore + @transferAmount))
    BEGIN
      ROLLBACK;
      RAISERROR('Invalid account balances!', 16, 1);
      RETURN;
    END

  COMMIT;

END

CREATE TABLE AccountHolders
(
Id INT NOT NULL,
FirstName VARCHAR(50) NOT NULL,
LastName VARCHAR(50) NOT NULL,
SSN CHAR(10) NOT NULL
CONSTRAINT PK_AccountHolders PRIMARY KEY (Id)
)

CREATE TABLE Accounts
(
Id INT NOT NULL,
AccountHolderId INT NOT NULL,
Balance MONEY DEFAULT 0
CONSTRAINT PK_Accounts PRIMARY KEY (Id)
CONSTRAINT FK_Accounts_AccountHolders FOREIGN KEY (AccountHolderId) REFERENCES AccountHolders(Id)
)

INSERT INTO AccountHolders (Id, FirstName, LastName, SSN) VALUES (1, 'Susan', 'Cane', '1234567890');
INSERT INTO AccountHolders (Id, FirstName, LastName, SSN) VALUES (2, 'Kim', 'Novac', '1234567890');
INSERT INTO AccountHolders (Id, FirstName, LastName, SSN) VALUES (3, 'Jimmy', 'Henderson', '1234567890');
INSERT INTO AccountHolders (Id, FirstName, LastName, SSN) VALUES (4, 'Steve', 'Stevenson', '1234567890');
INSERT INTO AccountHolders (Id, FirstName, LastName, SSN) VALUES (5, 'Bjorn', 'Sweden', '1234567890');
INSERT INTO AccountHolders (Id, FirstName, LastName, SSN) VALUES (6, 'Kiril', 'Petrov', '1234567890');
INSERT INTO AccountHolders (Id, FirstName, LastName, SSN) VALUES (7, 'Petar', 'Kirilov', '1234567890');
INSERT INTO AccountHolders (Id, FirstName, LastName, SSN) VALUES (8, 'Michka', 'Tsekova', '1234567890');
INSERT INTO AccountHolders (Id, FirstName, LastName, SSN) VALUES (9, 'Zlatina', 'Pateva', '1234567890');
INSERT INTO AccountHolders (Id, FirstName, LastName, SSN) VALUES (10, 'Monika', 'Miteva', '1234567890');
INSERT INTO AccountHolders (Id, FirstName, LastName, SSN) VALUES (11, 'Zlatko', 'Zlatyov', '1234567890');
INSERT INTO AccountHolders (Id, FirstName, LastName, SSN) VALUES (12, 'Petko', 'Petkov Junior', '1234567890');

INSERT INTO Accounts (Id, AccountHolderId, Balance) VALUES (1, 1, 123.12);
INSERT INTO Accounts (Id, AccountHolderId, Balance) VALUES (2, 3, 4354.23);
INSERT INTO Accounts (Id, AccountHolderId, Balance) VALUES (3, 12, 6546543.23);
INSERT INTO Accounts (Id, AccountHolderId, Balance) VALUES (4, 9, 15345.64);
INSERT INTO Accounts (Id, AccountHolderId, Balance) VALUES (5, 11, 36521.20);
INSERT INTO Accounts (Id, AccountHolderId, Balance) VALUES (6, 8, 5436.34);
INSERT INTO Accounts (Id, AccountHolderId, Balance) VALUES (7, 10, 565649.20);
INSERT INTO Accounts (Id, AccountHolderId, Balance) VALUES (8, 11, 999453.50);
INSERT INTO Accounts (Id, AccountHolderId, Balance) VALUES (9, 1, 5349758.23);
INSERT INTO Accounts (Id, AccountHolderId, Balance) VALUES (10, 2, 543.30);
INSERT INTO Accounts (Id, AccountHolderId, Balance) VALUES (11, 3, 10.20);
INSERT INTO Accounts (Id, AccountHolderId, Balance) VALUES (12, 7, 245656.23);
INSERT INTO Accounts (Id, AccountHolderId, Balance) VALUES (13, 5, 5435.32);
INSERT INTO Accounts (Id, AccountHolderId, Balance) VALUES (14, 4, 1.23);
INSERT INTO Accounts (Id, AccountHolderId, Balance) VALUES (15, 6, 0.19);
INSERT INTO Accounts (Id, AccountHolderId, Balance) VALUES (16, 2, 5345.34);
INSERT INTO Accounts (Id, AccountHolderId, Balance) VALUES (17, 11, 76653.20);
INSERT INTO Accounts (Id, AccountHolderId, Balance) VALUES (18, 1, 235469.89);