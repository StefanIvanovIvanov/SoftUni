CREATE DATABASE Supermarket

USE Supermarket

--1
CREATE TABLE Categories(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(30) NOT NULL,

)

CREATE TABLE Items(
Id INT IDENTITY,
[Name] NVARCHAR(30) NOT NULL,
Price DECIMAL(15,2) NOT NULL,
CategoryId INT NOT NULL,

CONSTRAINT PK_Items PRIMARY KEY (Id),
CONSTRAINT FK_Items_Categories FOREIGN KEY (CategoryId) REFERENCES Categories(Id)
)

CREATE TABLE Employees(
Id INT PRIMARY KEY Identity,
FirstName NVARCHAR(50) NOT NULL,
LastName NVARCHAR(50) NOT NULL,
Phone CHAR(12) NOT NULL,
Salary DECIMAL(15,2) NOT NULL,

CONSTRAINT CH_PhoneLenght CHECK(LEN(Phone)=12)
)

CREATE TABLE Orders(
Id INT IDENTITY,
[DateTime] DATETIME NOT NULL,
EmployeeId INT NOT NULL,

CONSTRAINT PK_Orders PRIMARY KEY(Id),
CONSTRAINT PK_Orders_Employees FOREIGN KEY (EmployeeId) REFERENCES Employees(Id) 
)

CREATE TABLE OrderItems(
OrderId INT NOT NULL,
ItemId INT NOT NULL,
Quantity INT NOT NULL,

CONSTRAINT PK_OrderItems PRIMARY KEY(OrderId, ItemId),
CONSTRAINT FK_OrderItems_Orders FOREIGN KEY (OrderId) REFERENCES Orders(Id),
CONSTRAINT FK_OrderItems_Items FOREIGN KEY (ItemId) REFERENCES Items(Id),
CONSTRAINT CH_CheckQuantity CHECK(Quantity>=1)
)

CREATE TABLE Shifts(
Id INT IDENTITY,
EmployeeId INT NOT NULL,
CheckIn DATETIME NOT NULL,
CheckOut DATETIME NOT NULL,

CONSTRAINT PK_Shifts PRIMARY KEY (Id, EmployeeId),
CONSTRAINT FK_Shifts_Employees FOREIGN KEY(EmployeeId) REFERENCES  Employees(Id),
CONSTRAINT CH_CheckOut CHECK (CheckOut>=CheckIn)
)


--2

INSERT INTO Employees (FirstName, LastName, Phone, Salary)
VALUES
('Stoyan', 'Petrov', '888-785-8573', '500.25'),
('Stamat', 'Nikolov', '789-613-1122', '999995.25'),
('Evgeni', 'Petkov', '645-369-9517', '1234.51'),
('Krasimir', 'Vidolov', '321-471-9982', '50.25')

INSERT INTO Items([Name], Price, CategoryId)
VALUES
('Tesla battery', 154.25, 8),
('Chess', 30.25, 8),
('Juice', 5.32, 1),
('Glasses', 10, 8),
('Bottle of water', 1, 1)

--3

UPDATE Items
SET Price+=Price*0.27
WHERE CategoryId IN (1,2,3)


--4
DELETE FROM OrderItems
WHERE OrderId = 48

DELETE FROM Orders
WHERE Id = 48

--5

SELECT Id, FirstName
FROM Employees
WHERE Salary>6500
ORDER By FirstName, Id

--6

SELECT FirstName+ ' '+LastName AS [Full Name],
Phone AS [Phone Number]
FROM Employees
WHERE Phone LIKE '3%'
ORDER BY FirstName, Phone

--7
SELECT 
e.FirstName,
e.LastName,
COUNT(o.Id) AS [Count]
 FROM Employees AS e
JOIN Orders AS o
ON o.EmployeeId=e.Id
GROUP BY e.FirstName, e.LastName
ORDER BY COUNT(o.Id) DESC, FirstName


--8
SELECT e.FirstName,
e.LastName,
AVG(DATEDIFF(HOUR, s.CheckIn, s.CheckOut)) AS [Work hours]
FROM Employees AS e
JOIN Shifts AS s
ON s.EmployeeId=e.Id
GROUP BY e.FirstName, e.LastName, e.Id
HAVING AVG(DATEDIFF(HOUR, s.CheckIn, s.CheckOut))>7
ORDER BY [Work hours] DESC, e.Id

--9

SELECT TOP 1
oi.OrderId AS [OrderId],
SUM(i.Price*oi.Quantity) AS [TotalPrice]
FROM OrderItems AS oi
JOIN Items AS i
ON i.Id=oi.ItemId
GROUP BY oi.OrderId
ORDER BY TotalPrice DESC


--10

SELECT TOP (10) 
oi.OrderId AS OrderId,
MAX(i.Price) AS ExpensivePrice,
MIN(i.Price) AS CheapPrice
FROM Orders AS o
JOIN OrderItems AS oi
ON oi.OrderId=o.Id
JOIN Items AS i
ON i.Id=oi.ItemId
GROUP BY oi.OrderId
ORDER BY ExpensivePrice DESC, oi.OrderId ASC

--11

SELECT DISTINCT e.Id, e.FirstName, e.LastName
FROM Employees AS e
LEFT JOIN Orders AS o
ON o.EmployeeId=e.Id
WHERE o.EmployeeId IS NOT NULL
ORDER BY e.Id

--12

SELECT DISTINCT e.Id,
CONCAT(e.FirstName, ' ', e.LastName) AS [Full Name]
FROM Employees AS e
JOIN Shifts AS s
ON s.EmployeeId=e.Id
WHERE DATEDIFF(HOUR, s.CheckIn, s.CheckOut)<4
AND s.CheckOut IS NOT NULL
ORDER BY e.Id

--13

SELECT TOP 10 E.FirstName + ' ' + E.LastName AS [Full Name],
       SUM(OI.Quantity  * I.Price) AS [Total Price],
       SUM(OI.Quantity) AS ItemsCount
FROM Orders O
JOIN Employees E on O.EmployeeId = E.Id
JOIN OrderItems OI on O.Id = OI.OrderId
JOIN Items I on OI.ItemId = I.Id
WHERE O.DateTime < '2018-06-15'
GROUP BY E.Id, E.FirstName, E.LastName
ORDER BY [Total Price] DESC, ItemsCount DESC

--14

SELECT
  e.FirstName + ' ' + e.LastName AS FullName,
  CASE
  WHEN DATEPART(WEEKDAY, s.CheckIn) = 2
    THEN 'Monday'
  WHEN DATEPART(WEEKDAY, s.CheckIn) = 3
    THEN 'Tuesday'
  WHEN DATEPART(WEEKDAY, s.CheckIn) = 4
    THEN 'Wednesday'
  WHEN DATEPART(WEEKDAY, s.CheckIn) = 5
    THEN 'Thursday'
  WHEN DATEPART(WEEKDAY, s.CheckIn) = 6
    THEN 'Friday'
  WHEN DATEPART(WEEKDAY, s.CheckIn) = 7
    THEN 'Saturday'
  WHEN DATEPART(WEEKDAY, s.CheckIn) = 1
    THEN 'Sunday'
  END                            as DayOfWeek
FROM Employees AS e
  LEFT JOIN Orders AS o ON o.EmployeeId = e.Id
  JOIN Shifts AS s ON s.EmployeeId = e.Id
WHERE o.Id IS NULL AND DATEDIFF(HOUR, s.CheckIn, s.CheckOut) > 12
ORDER BY e.Id

--15

SELECT emp.FirstName + ' ' + emp.LastName AS FullName, DATEDIFF(HOUR, s.CheckIn, s.CheckOut) AS WorkHours, e.TotalPrice AS TotalPrice FROM 
 (
    SELECT o.EmployeeId, SUM(oi.Quantity * i.Price) AS TotalPrice, o.DateTime,
	ROW_NUMBER() OVER (PARTITION BY o.EmployeeId ORDER BY o.EmployeeId, SUM(i.Price * oi.Quantity) DESC ) AS Rank
    FROM Orders AS o
    JOIN OrderItems AS oi ON oi.OrderId = o.Id
    JOIN Items AS i ON i.Id = oi.ItemId
GROUP BY o.EmployeeId, o.Id, o.DateTime
) AS e 
JOIN Employees AS emp ON emp.Id = e.EmployeeId
JOIN Shifts AS s ON s.EmployeeId = e.EmployeeId
WHERE e.Rank = 1 AND e.DateTime BETWEEN s.CheckIn AND s.CheckOut
ORDER BY FullName, WorkHours DESC, TotalPrice DESC

--16

SELECT
DATEPART(DAY, o.DateTime)  AS [DayOfMonth],
CAST(AVG(i.Price * oi.Quantity)  AS decimal(15, 2)) AS TotalPrice
FROM Orders AS o
JOIN OrderItems AS oi ON oi.OrderId = o.Id
JOIN Items AS i ON i.Id = oi.ItemId
GROUP BY DATEPART(DAY, o.DateTime)
ORDER BY DayOfMonth ASC

--17

SELECT
  i.Name,
  c.Name,
  SUM(oi.Quantity)  As [Count],
  SUM(i.Price * oi.Quantity) AS TotalPrice
FROM Orders AS o
  JOIN OrderItems AS oi ON oi.OrderId = o.Id
  RIGHT JOIN Items AS i ON i.Id = oi.ItemId
  JOIN Categories AS c ON c.Id = i.CategoryId
GROUP BY i.Name, c.Name
ORDER BY TotalPrice DESC, [Count] DESC

--18

CREATE FUNCTION udf_GetPromotedProducts(@CurrentDate DATETIME, @StartDate DATETIME, @EndDate DATETIME, @Discount INT, @FirstItemId INT, @SecondItemId INT, @ThirdItemId INT)
RETURNS VARCHAR(80)
AS
BEGIN
	DECLARE @FirstItemPrice DECIMAL(15,2) = (SELECT Price FROM Items WHERE Id = @FirstItemId)
	DECLARE @SecondItemPrice DECIMAL(15,2) = (SELECT Price FROM Items WHERE Id = @SecondItemId)
	DECLARE @ThirdItemPrice DECIMAL(15,2) = (SELECT Price FROM Items WHERE Id = @ThirdItemId)

	IF (@FirstItemPrice IS NULL OR @SecondItemPrice IS NULL OR @ThirdItemPrice IS NULL)
	BEGIN
	 RETURN 'One of the items does not exists!'
	END

	IF (@CurrentDate <= @StartDate OR @CurrentDate >= @EndDate)
	BEGIN
	 RETURN 'The current date is not within the promotion dates!'
	END

	DECLARE @NewFirstItemPrice DECIMAL(15,2) = @FirstItemPrice - (@FirstItemPrice * @Discount / 100)
	DECLARE @NewSecondItemPrice DECIMAL(15,2) = @SecondItemPrice - (@SecondItemPrice * @Discount / 100)
	DECLARE @NewThirdItemPrice DECIMAL(15,2) = @ThirdItemPrice - (@ThirdItemPrice * @Discount / 100)

	DECLARE @FirstItemName VARCHAR(50) = (SELECT [Name] FROM Items WHERE Id = @FirstItemId)
	DECLARE @SecondItemName VARCHAR(50) = (SELECT [Name] FROM Items WHERE Id = @SecondItemId)
	DECLARE @ThirdItemName VARCHAR(50) = (SELECT [Name] FROM Items WHERE Id = @ThirdItemId)

	RETURN @FirstItemName + ' price: ' + CAST(ROUND(@NewFirstItemPrice,2) as varchar) + ' <-> ' +
		   @SecondItemName + ' price: ' + CAST(ROUND(@NewSecondItemPrice,2) as varchar)+ ' <-> ' +
		   @ThirdItemName + ' price: ' + CAST(ROUND(@NewThirdItemPrice,2) as varchar)
END

SELECT dbo.udf_GetPromotedProducts('2018-08-02', '2018-08-01', '2018-08-03',13, 3,4,5)



--19

CREATE PROCEDURE usp_CancelOrder(@OrderId INT, @CancelDate DATE)
AS
BEGIN
DECLARE @Id INT = (SELECT o.Id
FROM Orders AS o
WHERE o.Id=@OrderId)

IF(@Id IS NULL)
BEGIN
	RAISERROR ('The order does not exist!', 16, 1);
	END

DECLARE @IssueDate DATE = (SELECT o.DateTime 
FROM Orders AS o
WHERE o.Id=@OrderId)

IF(DATEDIFF(DAY, @IssueDate, @CancelDate)>3)
BEGIN
	RAISERROR ('You cannot cancel the order!', 16, 1);
		
	END

DELETE FROM OrderItems
WHERE OrderId = @Id

DELETE FROM Orders
WHERE Id = @Id

END

--20

CREATE TABLE DeletedOrders(
OrderId INT,
ItemId INT,
ItemQuantity INT
)

CREATE TRIGGER t_DeleteOrder
	ON OrderItems
	AFTER DELETE
AS
	BEGIN
		INSERT INTO DeletedOrders(OrderId, ItemId, ItemQuantity)
		SELECT OrderId, ItemId, Quantity FROM deleted
	END