--1

CREATE DATABASE Bakery
GO

USE Bakery
GO

CREATE TABLE Countries (
  Id INT IDENTITY,
  Name NVARCHAR(50),

  CONSTRAINT PK_Countries PRIMARY KEY (Id),

  CONSTRAINT UQ_Countries_Name UNIQUE (Name)
)


CREATE TABLE Distributors (
  Id INT IDENTITY,
  Name NVARCHAR(25),
  AddressText NVARCHAR(30),
  Summary NVARCHAR(200),
  CountryId INT,

  CONSTRAINT PK_Distributors PRIMARY KEY (Id),

  CONSTRAINT UQ_Distributors_Name UNIQUE (Name),

  CONSTRAINT FK_Distributors_Countries FOREIGN KEY (CountryId) REFERENCES Countries (Id)
)


CREATE TABLE Ingredients (
  Id INT IDENTITY,
  Name NVARCHAR(30),
  Description NVARCHAR(200),
  OriginCountryId INT,
  DistributorId INT,

  CONSTRAINT PK_Ingredients PRIMARY KEY (Id),

  CONSTRAINT FK_Ingredients_Countries FOREIGN KEY (OriginCountryId) REFERENCES Countries (Id),

  CONSTRAINT FK_Ingredients_Distributors FOREIGN KEY (DistributorId) REFERENCES Distributors (Id)
)


CREATE TABLE Products (
  Id INT IDENTITY,
  Name NVARCHAR(25),
  Description NVARCHAR(250),
  Recipe NVARCHAR(MAX),
  Price MONEY,

  CONSTRAINT PK_Products PRIMARY KEY (Id),

  CONSTRAINT UQ_Products_Name UNIQUE (Name),

  CONSTRAINT CHK_Products_Price CHECK (Price >= 0)
)


CREATE TABLE ProductsIngredients (
  ProductId INT,
  IngredientId INT,

  CONSTRAINT PK_ProductsIngredients PRIMARY KEY (ProductId, IngredientId),

  CONSTRAINT FK_ProductsIngredients_Products FOREIGN KEY (ProductId) REFERENCES Products (Id),
  CONSTRAINT FK_ProductsIngredients_Ingredients FOREIGN KEY (IngredientId) REFERENCES Ingredients (Id)
)


CREATE TABLE Customers (
  Id INT IDENTITY,
  FirstName NVARCHAR(25),
  LastName NVARCHAR(25),
  Gender CHAR(1),
  Age INT,
  PhoneNumber CHAR(10),
  CountryId INT,

  CONSTRAINT PK_Customers PRIMARY KEY (Id),

  CONSTRAINT CHK_Customers_Gender CHECK (Gender IN ('M', 'F')),
  CONSTRAINT CHK_Customers_PhoneNumber CHECK (LEN(PhoneNumber) = 10),

  CONSTRAINT FK_Customers_Countries FOREIGN KEY (CountryId) REFERENCES Countries (Id)
)


CREATE TABLE Feedbacks (
  Id INT IDENTITY,
  Description NVARCHAR(255),
  Rate DECIMAL(10, 2),
  ProductId INT,
  CustomerId INT,

  CONSTRAINT PK_Feedbacks PRIMARY KEY (Id),

  CONSTRAINT CHK_Feedbacks_Rate CHECK (Rate BETWEEN 0 AND 10),

  CONSTRAINT FK_Feedbacks_Products FOREIGN KEY (ProductId) REFERENCES Products (Id),
  CONSTRAINT FK_Feedbacks_Customers FOREIGN KEY (CustomerId) REFERENCES Customers (Id)
)

--2

INSERT INTO Distributors (Name, CountryId, AddressText, Summary) VALUES

  ('Deloitte & Touche', 2, '6 Arch St #9757', 'Customizable neutral traveling'),
  ('Congress Title', 13, '58 Hancock St', 'Customer loyalty'),
  ('Kitchen People', 1, '3 E 31st St #77', 'Triple-buffered stable delivery'),
  ('General Color Co Inc', 21, '6185 Bohn St #72', 'Focus group'),
  ('Beck Corporation', 23, '21 E 64th Ave', 'Quality-focused 4th generation hardware')


INSERT INTO Customers (FirstName, LastName, Age, Gender, PhoneNumber, CountryId) VALUES
  ('Francoise', 'Rautenstrauch', 15, 'M', '0195698399', 5),
  ('Kendra', 'Loud', 22, 'F', '0063631526', 11),
  ('Lourdes', 'Bauswell', 50, 'M', '0139037043', 8),
  ('Hannah', 'Edmison', 18, 'F', '0043343686', 1),
  ('Tom', 'Loeza', 31, 'M', '0144876096', 23),
  ('Queenie', 'Kramarczyk', 30, 'F', '0064215793', 29),
  ('Hiu', 'Portaro', 25, 'M', '0068277755', 16),
  ('Josefa', 'Opitz', 43, 'F', '0197887645', 17)


--3

UPDATE Ingredients
SET DistributorId = 35
WHERE Name IN ('Poppy', 'Paprika', 'Bay Leaf')

UPDATE Ingredients
SET OriginCountryId = 14
WHERE OriginCountryId = 8

--4

DELETE FROM Feedbacks
WHERE CustomerId = 14 OR ProductId = 5

--5

SELECT Name, Price, Description
FROM Products
ORDER BY Price DESC, Name

--6

SELECT
  Name,
  Description,
  OriginCountryId
FROM Ingredients
WHERE OriginCountryId IN (1, 10, 20)
ORDER BY Id

--7

SELECT TOP (15)
  i.Name,
  i.Description,
  c.Name
FROM Ingredients i
  JOIN Countries c
    ON i.OriginCountryId = c.Id
WHERE c.Name IN ('Bulgaria', 'Greece')
ORDER BY i.Name, c.Name

--8

SELECT TOP (10)
  p.Name,
  p.Description,
  avg(f.Rate) AS [AverageRate],
  count(*)    AS [FeedbacksAmount]
FROM Products p
  JOIN Feedbacks f
    ON p.Id = f.ProductId
GROUP BY p.Name, p.Description
ORDER BY avg(f.Rate) DESC, count(*) DESC


--9

SELECT
  f.ProductId,
  f.Rate,
  f.Description,
  c.Id,
  c.Age,
  c.Gender
FROM Feedbacks f
  JOIN Customers c
    ON f.CustomerId = c.Id
WHERE f.Rate < 5
ORDER BY f.ProductId DESC, f.Rate

--10

SELECT
  concat(c.FirstName, ' ', c.LastName) AS [CustomerName],
  c.PhoneNumber,
  c.Gender
FROM Customers c
  LEFT JOIN Feedbacks f
    ON c.Id = f.CustomerId
WHERE f.Id IS NULL
ORDER BY c.Id


--11

WITH CTE_CustomersCount (CustomerId, FeedbackCount) AS
(SELECT
   CustomerId AS [CustomerId],
   count(*)   AS [FeedbackCount]
 FROM Feedbacks
 GROUP BY CustomerId
 HAVING count(*) >= 3)

SELECT
  f.ProductId                          AS [ProductId],
  concat(c.FirstName, ' ', c.LastName) AS [CustomerName],
  isnull(f.Description, '')            AS [FeedbackDescription]
FROM cte_customerscount cte
  JOIN Customers c
    ON cte.CustomerId = c.Id
  JOIN Feedbacks f
    ON c.Id = f.CustomerId
ORDER BY f.ProductId, CustomerName, f.Id

--12

SELECT
  FirstName,
  Age,
  PhoneNumber
FROM Customers
WHERE (Age >= 21 AND FirstName LIKE '%an%') OR
  (RIGHT(PhoneNumber,2) = '38' and CountryId <> 31)
ORDER BY FirstName, Age DESC

--13

SELECT
  d.Name,
  i.Name,
  p.Name,
  avg(f.Rate)
FROM Feedbacks AS f
  JOIN Products AS p
    ON f.ProductId = p.Id
  JOIN ProductsIngredients AS pp
    ON p.Id = pp.ProductId
  JOIN Ingredients i
    ON pp.IngredientId = i.Id
  JOIN Distributors d
    ON i.DistributorId = d.Id
GROUP BY d.Name, i.Name, p.Name
HAVING avg(f.Rate) BETWEEN 5 AND 8
ORDER BY d.Name, i.Name, p.Name


--14

SELECT TOP 1 WITH TIES
  c2.Name     AS [CountryName],
  avg(f.Rate) AS [FeedbackRate]
FROM Feedbacks AS f
  JOIN Customers c
    ON f.CustomerId = c.Id
  JOIN Countries c2
    ON c.CountryId = c2.Id
GROUP BY c2.Name
ORDER BY FeedbackRate DESC

--15

SELECT CountryName, DistributorName
FROM (
  SELECT
    c.Name AS [CountryName],
    d.Name AS [DistributorName],
    COUNT(i.Id) AS [IngredientsCount],
    DENSE_RANK()
    OVER ( PARTITION BY c.Name
      ORDER BY count(i.Id) DESC ) AS Rank
  FROM Countries c
    JOIN Distributors d
      ON d.CountryId = c.Id
    JOIN Ingredients i
      ON i.DistributorId = d.Id
  GROUP BY c.Name, d.Name
) AS Ordered
WHERE ordered.rank = 1
ORDER BY CountryName, DistributorName


--16

CREATE VIEW v_UserWithCountries AS
  SELECT
    concat(c.FirstName, ' ', c.LastName) AS [CustomerName],
    c.Age                                AS [Age],
    c.Gender                             AS [Gender],
    c2.Name                              AS [CountryName]
  FROM Customers c
    JOIN Countries c2
      ON c.CountryId = c2.Id

--17

CREATE FUNCTION udf_GetRating(@productName NVARCHAR(25))
  RETURNS NVARCHAR(10)
AS
  BEGIN

    DECLARE @productRate DECIMAL(10, 2) = (
      SELECT avg(f.Rate)
      FROM Products p
        JOIN Feedbacks f
          ON p.Id = f.ProductId
      WHERE p.Name = @productName
    )


    IF (@productRate < 5)
      BEGIN
        RETURN 'Bad'
      END
    ELSE IF (@productRate BETWEEN 5 AND 8)
      BEGIN
        RETURN 'Average'
      END
    ELSE IF (@productRate > 8)
      BEGIN
        RETURN 'Good'
      END

    RETURN 'No rating'

  END

--18

CREATE PROCEDURE usp_SendFeedback(@customerId INT, @productId INT, @rate DECIMAL(10, 2), @description NVARCHAR(255))
AS
  BEGIN
    DECLARE @feedbackCount INT = (
      SELECT count(*)
      FROM Feedbacks
      WHERE CustomerId = @customerId
    )

    IF (@feedbackCount >= 3)
      BEGIN
        RAISERROR ('You are limited to only 3 feedbacks per product!', 16, 1)
      END

    INSERT INTO Feedbacks (Description, Rate, ProductId, CustomerId) VALUES
      (@description, @rate, @productId, @customerId)

  END

--19

CREATE TRIGGER TR_DeleteProductRelations
  ON Products
  INSTEAD OF DELETE
AS
  BEGIN
    DECLARE @productId INT = (
      SELECT Id
      FROM deleted
    )

    DELETE FROM ProductsIngredients
    WHERE ProductId = @productId

    DELETE FROM Feedbacks
    WHERE ProductId = @productId

    DELETE FROM Products
    WHERE Id = @productId
  END

--20

WITH cte_SingleDist (ProductId) AS
(SELECT p.Id
 FROM Products p
   JOIN ProductsIngredients pro
     ON p.Id = pro.ProductId
   JOIN Ingredients i
     ON pro.IngredientId = i.Id
   JOIN Distributors AS d
     ON i.DistributorId = d.Id
 GROUP BY p.Id
 HAVING count(DISTINCT d.Id) = 1)

SELECT
  ProductName,
  AverageRate,
  DistributorName,
  DistributorCountry
FROM (
       SELECT
         p.Name      AS [ProductName],
         avg(f.Rate) AS [AverageRate],
         d.Name      AS [DistributorName],
         c.Name      AS [DistributorCountry]
       FROM cte_singledist s
         JOIN Products p
           ON s.ProductId = p.Id
         JOIN ProductsIngredients pro
           ON p.Id = pro.ProductId
         JOIN Ingredients i
           ON pro.IngredientId = i.Id
         JOIN Distributors d
           ON i.DistributorId = d.Id
         JOIN Countries c
           ON d.CountryId = c.Id
         JOIN Feedbacks f
           ON p.Id = f.ProductId
       GROUP BY p.Name, d.Name, c.Name) AS Result
  JOIN Products p2
    ON result.ProductName = p2.Name
ORDER BY p2.Id