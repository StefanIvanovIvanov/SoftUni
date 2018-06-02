CREATE DATABASE Orders;
GO

USE Orders;
GO

--Problem 16.Orders Table

SELECT ProductName,OrderDate,
	DATEADD(DAY, 3,OrderDate) AS [Pay Due],
	DATEADD(MONTH,1,OrderDate) AS [Deliver Due]
FROM Orders

--Problem 17.People Table

CREATE TABLE People(
Id INT	PRIMARY KEY,
[Name] VARCHAR(30),
Birthdate DATETIME
)

INSERT INTO People (Id,	[Name],	Birthdate)
VALUES
(1,	'Victor',	'2000-12-07 00:00:00.000'),
(2,	'Steven',	'1992-09-10 00:00:00.000'),
(3,	'Stephen',	'1910-09-19 00:00:00.000'),
(4,	'John',	'2010-01-06 00:00:00.000')

SELECT [Name],
DATEDIFF(YEAR, Birthdate, GETDATE()) [Age in Years],
DATEDIFF(MONTH, Birthdate, GETDATE()) [Age in Moths],
DATEDIFF(DAY, Birthdate, GETDATE()) [Age in Days],
DATEDIFF(MINUTE, Birthdate, GETDATE()) [Age in Minutes]
FROM People

CREATE TABLE Orders
(
Id INT NOT NULL,
ProductName VARCHAR(50) NOT NULL,
OrderDate DATETIME NOT NULL
CONSTRAINT PK_Orders PRIMARY KEY (Id)
)

INSERT INTO Orders (Id, ProductName, OrderDate) VALUES (1, 'Butter', '20160919');
INSERT INTO Orders (Id, ProductName, OrderDate) VALUES (2, 'Milk', '20160930');
INSERT INTO Orders (Id, ProductName, OrderDate) VALUES (3, 'Cheese', '20160904');
INSERT INTO Orders (Id, ProductName, OrderDate) VALUES (4, 'Bread', '20151220');
INSERT INTO Orders (Id, ProductName, OrderDate) VALUES (5, 'Tomatoes', '20150101');
INSERT INTO Orders (Id, ProductName, OrderDate) VALUES (6, 'Tomatoe2', '20150201');
INSERT INTO Orders (Id, ProductName, OrderDate) VALUES (7, 'Tomatoess', '20150401');
INSERT INTO Orders (Id, ProductName, OrderDate) VALUES (8, 'Tomatoe3', '20150128');
INSERT INTO Orders (Id, ProductName, OrderDate) VALUES (9, 'Tomatoe4', '20150628');
INSERT INTO Orders (Id, ProductName, OrderDate) VALUES (10, 'Tomatoe44s', '20150630');
INSERT INTO Orders (Id, ProductName, OrderDate) VALUES (11, 'Tomatoefggs', '20150228');
INSERT INTO Orders (Id, ProductName, OrderDate) VALUES (12, 'Tomatoesytu', '20160228');
INSERT INTO Orders (Id, ProductName, OrderDate) VALUES (13, 'Toyymatddoehys', '20151231');
INSERT INTO Orders (Id, ProductName, OrderDate) VALUES (14, 'Tom443atoes', '20151215');
INSERT INTO Orders (Id, ProductName, OrderDate) VALUES (15, 'Tomat65434foe23gfhgsPep', '20151004');