CREATE DATABASE Bank
GO

USE Bank

CREATE TABLE Clients (
Id INT PRIMARY KEY ,
FirstName NVARCHAR(50) NOT NULL,
LastName NVARCHAR(50) NOT NULL
)

CREATE TABLE AccountTypes(
Id INT PRIMARY KEY NOT NULL,
[Name] VARCHAR(50) NOT NULL
 )

 CREATE TABLE Accounts (
 Id INT PRIMARY KEY NOT NULL,
 AccountTypeId INT FOREIGN KEY REFERENCES AccountTypes(Id) NOT NULL,
 ClientId INT FOREIGN KEY REFERENCES Clients(Id) NOT NULL,
 Balance DECIMAL(15, 2)
 /* 15 digits in total, 13 in front ot the ',' and 2 after it*/
 )

 INSERT INTO Clients (Id, FirstName, LastName)
 VALUES
 (1,'Ivan', 'Ivanov'),
 (2, 'Pesho','Petrov'),
 (3, 'Merry','Ivanova')

 INSERT INTO AccountTypes (Id, Name)
 VALUES
 (1, 'Savings'),
 (2, 'Checkings')

 SELECT * FROM Clients
 SELECT FirstName FROM Clients

 INSERT INTO Accounts(Id, AccountTypeId, ClientId, Balance)
 VALUES
 (1,1,2,540.43)
 /*Account 1, Savings, to Ivan Ivanov, Balance 540.43 */


 GO
 CREATE FUNCTION    f_CalculateTotalBalance ( @ClientId INT)
 RETURNS DECIMAL (15,2)
 BEGIN
 DECLARE @result AS DECIMAL(15,2)=(
 SELECT SUM(Balance)
 FROM Accounts
 WHERE ClientId=@ClientId
 )
 RETURN @result;
 END

 GO
 SELECT [dbo].f_CalculateTotalBalance(2)
 AS [Total Balance]


 GO
 CREATE PROCEDURE p_AddAccount @Id INT, @ClientId INT, @AccountType INT AS
  INSERT INTO Accounts(Id, ClientId, AccountTypeId)
  VALUES(@Id, @ClientId, @AccountType)

  GO
  p_AddAccount 5,2,1


  GO
  CREATE PROC p_Deposit @AccountId INT, @Amount DECIMAL (15,2) AS
  UPDATE Accounts
  SET Balance +=@Amount
  WHERE Id=@AccountId

  GO
  p_Deposit 2,100


  GO
  CREATE PROC p_Withdraw @AccountId INT, @Amount DECIMAL (15,2) AS
BEGIN
DECLARE @OldBalance DECIMAL(15,2)
SELECT @OldBalance=Balance FROM Accounts WHERE Id = @AccountId
IF(@OldBalance-@Amount>=0)
BEGIN
UPDATE Accounts
SET Balance -=@Amount
WHERE Id=@AccountId
END
ELSE
BEGIN
RAISERROR('Insufficient funds', 10,1)
END
END

--p_Withdraw 2, 150

SELECT Balance AS [Balance After Withdraw]
FROM Accounts 
WHERE ID =2


CREATE TABLE Transactions (
Id INT PRIMARY KEY IDENTITY, 
--IDENTITY increases the value of the variable by 1 or by the given value (e.g. in INT PRIMARY KEY IDENTITY(100, 10) by 10, starting from 100)
AccountId INT FOREIGN KEY REFERENCES Accounts(Id) NOT NULL,
OldBalance DECIMAL (15,2) NOT NULL,
NewBalance DECIMAL (15,2) NOT NULL,
Amount As NewBalance - OldBalance,
[DateTme] DATETIME2
)


GO
CREATE TRIGGER tr_Transaction ON Accounts
AFTER UPDATE
AS
	INSERT INTO Transactions (AccountId, OldBalance, NewBalance, [DateTime])
	SELECT inserted.Id, deleted.Balance, inserted.Balance, GETDATE() FROM inserted
	JOIN deleted ON inserted.Id = deleted.Id

	SELECT * FROM Transactions