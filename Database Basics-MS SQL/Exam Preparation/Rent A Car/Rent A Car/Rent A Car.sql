--1

CREATE DATABASE RentACar;

USE RentACar;

CREATE TABLE Clients (
  Id INT IDENTITY,
  FirstName NVARCHAR(30) NOT NULL,
  LastName NVARCHAR(30) NOT NULL,
  Gender VARCHAR(1) CHECK(Gender = 'M' OR Gender = 'F'),
  BirthDate DATETIME,
  CreditCard NVARCHAR(30) NOT NULL,
  CardValidity DATETIME,
  Email NVARCHAR(50) NOT NULL,
  CONSTRAINT PK_Clients PRIMARY KEY (Id)
)

CREATE TABLE Towns (
  Id INT IDENTITY,
  Name NVARCHAR(50) NOT NULL,
  CONSTRAINT PK_Towns PRIMARY KEY (Id)
)

CREATE TABLE Offices (
  Id INT IDENTITY,
  Name NVARCHAR(40),
  ParkingPlaces INT,
  TownId INT,
  CONSTRAINT PK_Offices PRIMARY KEY (Id),
  CONSTRAINT FK_Offices_Towns FOREIGN KEY (TownId) REFERENCES Towns (Id)
)

CREATE TABLE Models (
  Id INT IDENTITY,
  Manufacturer NVARCHAR(50) NOT NULL,
  Model NVARCHAR(50) NOT NULL,
  ProductionYear DATETIME,
  Seats INT,
  Class NVARCHAR(10),
  Consumption DECIMAL(14, 2),
  CONSTRAINT PK_Models PRIMARY KEY (Id)
)

CREATE TABLE Vehicles (
  Id INT IDENTITY,
  ModelId INT,
  OfficeId INT,
  Mileage INT,
  CONSTRAINT PK_Vehicles PRIMARY KEY (Id),
  CONSTRAINT FK_Vehicles_Models FOREIGN KEY (ModelId) REFERENCES Models (Id),
  CONSTRAINT FK_Vehicles_Offices FOREIGN KEY (OfficeId) REFERENCES Offices (Id)
)

CREATE TABLE Orders (
  Id INT IDENTITY,
  ClientId INT,
  TownId INT,
  VehicleId INT,
  CollectionDate DATETIME NOT NULL,
  CollectionOfficeId INT,
  ReturnDate DATETIME,
  ReturnOfficeId INT,
  Bill DECIMAL(14, 2),
  TotalMileage INT,
  CONSTRAINT PK_Orders PRIMARY KEY (Id),
  CONSTRAINT FK_Orders_Clients FOREIGN KEY (ClientId) REFERENCES Clients (Id),
  CONSTRAINT FK_Orders_Towns FOREIGN KEY (TownId) REFERENCES Towns (Id),
  CONSTRAINT FK_Orders_Vehicles FOREIGN KEY (VehicleId) REFERENCES Vehicles (Id),
  CONSTRAINT FK_Orders_Offices_CollectionOffice FOREIGN KEY (CollectionOfficeId) REFERENCES Offices (Id),
  CONSTRAINT FK_Orders_Offices_ReturnOffice FOREIGN KEY (ReturnOfficeId) REFERENCES Offices (Id)
)

--2

INSERT INTO Models (Manufacturer, Model, ProductionYear, Seats, Class, Consumption)
VALUES
  ('Chevrolet', 'Astro', '2005-07-27 00:00:00.000', 4, 'Economy', 12.60),
  ('Toyota', 'Solara', '2009-10-15 00:00:00.000', 7, 'Family', 13.80),
  ('Volvo', 'S40', '2010-10-12 00:00:00.000', 3, 'Average', 11.30),
  ('Suzuki', 'Swift', '2000-02-03 00:00:00.000', 7, 'Economy', 16.20)


INSERT INTO Orders (ClientId, TownId, VehicleId, CollectionDate, CollectionOfficeId, ReturnDate, ReturnOfficeId, Bill, TotalMileage)
VALUES
  (17, 2, 52, '2017-08-08', 30, '2017-09-04', 42, 2360.00, 7434),
  (78, 17, 50, '2017-04-22', 10, '2017-05-09', 12, 2326.00, 7326),
  (27, 13, 28, '2017-04-25', 21, '2017-05-09', 34, 597.00, 1880)



--3

UPDATE Models
SET Class = 'Luxury'
WHERE Consumption > 20

--4

DELETE FROM Orders
WHERE ReturnDate IS NULL

--5

SELECT
  Manufacturer,
  Model
FROM Models
ORDER BY Manufacturer ASC, Id DESC

--6

SELECT
  FirstName,
  LastName
FROM Clients
WHERE BirthDate BETWEEN '1977' AND '1995'
ORDER BY FirstName ASC, LastName ASC, Id ASC

--7

SELECT
  t.Name          AS [TownName],
  o.Name          AS [OfficeName],
  o.ParkingPlaces AS [ParkingPlaces]
FROM Offices AS o
  JOIN Towns AS t
    ON o.TownId = t.Id
WHERE ParkingPlaces > 25
ORDER BY t.Name ASC, o.Id ASC

--8

SELECT
  m.Model   AS [Model],
  m.Seats   AS [Seats],
  v.Mileage AS [Milage]
FROM Vehicles AS v
  LEFT JOIN Models AS m
    ON v.ModelId = m.Id
WHERE v.Id NOT IN (
  SELECT VehicleId
  FROM Orders
  WHERE ReturnDate IS NULL
)
ORDER BY v.Mileage ASC, m.Seats DESC, m.Id ASC

--9

SELECT
  t.Name      AS [TownName],
  count(o.Id) AS [OfficesNumber]
FROM Towns AS t
  JOIN Offices AS o
    ON t.Id = o.TownId
GROUP BY t.Name
ORDER BY OfficesNumber DESC, TownName ASC

--10

SELECT
  m.Manufacturer     AS [Manufacturer],
  m.Model            AS [Model],
  count(o.VehicleId) AS [TimesOrdered]
FROM Vehicles AS v
  JOIN Models AS m
    ON v.ModelId = m.Id
  LEFT JOIN Orders AS o
    ON v.Id = o.VehicleId
GROUP BY m.Manufacturer, m.Model
ORDER BY TimesOrdered DESC, Manufacturer DESC, Model ASC

--11

WITH chp AS
(SELECT
   c.FirstName + ' ' + c.LastName   AS [Name],
   m.Class                          AS [Class],
   DENSE_RANK()
   OVER ( PARTITION BY c.FirstName + ' ' + c.LastName
     ORDER BY count(m.Class) DESC ) AS rn
 FROM Clients AS c
   LEFT JOIN Orders AS o
     ON c.Id = o.ClientId
   LEFT JOIN Vehicles AS v
     ON o.VehicleId = v.Id
   LEFT JOIN Models AS m
     ON v.ModelId = m.Id
 GROUP BY c.FirstName + ' ' + c.LastName, m.Class)

SELECT
  chp.Name  AS [Name],
  chp.Class AS [Class]
FROM chp
WHERE rn = 1 AND chp.Class IS NOT NULL
ORDER BY chp.Name ASC, chp.Class ASC


--12

SELECT
  CASE
  WHEN c.BirthDate BETWEEN '1970' AND '1980'
    THEN '70''s'
  WHEN c.BirthDate BETWEEN '1980' AND '1990'
    THEN '80''s'
  WHEN c.BirthDate BETWEEN '1990' AND '2000'
    THEN '90''s'
  WHEN c.BirthDate NOT BETWEEN '1970' AND '2000'
    THEN 'Others'
  END                 AS AgeGroup,
  SUM(o.Bill)         AS Revenue,
  AVG(o.TotalMileage) AS AverageMileage
FROM Clients AS c
  LEFT JOIN Orders AS o
    ON c.Id = o.ClientId
  JOIN Vehicles AS v
    ON o.VehicleId = v.Id
GROUP BY (CASE
          WHEN c.BirthDate BETWEEN '1970' AND '1980'
            THEN '70''s'
          WHEN c.BirthDate BETWEEN '1980' AND '1990'
            THEN '80''s'
          WHEN c.BirthDate BETWEEN '1990' AND '2000'
            THEN '90''s'
          WHEN c.BirthDate NOT BETWEEN '1970' AND '2000'
            THEN 'Others'
          END)
ORDER BY AgeGroup ASC

--13

SELECT
  m.Manufacturer     AS [Manufacturer],
  avg(m.Consumption) AS [AverageConsumption]
FROM
  (SELECT TOP 7
     m.Id,
     count(o.VehicleId) AS [OrdersCount]
   FROM Orders o
     JOIN Vehicles v
       ON o.VehicleId = v.Id
     JOIN Models m
       ON v.ModelId = m.Id
   GROUP BY m.Id
   ORDER BY count(o.VehicleId) DESC
  ) AS mostOrdered
  JOIN Models m
    ON m.Id = mostordered.Id
GROUP BY m.Manufacturer
HAVING avg(m.Consumption) BETWEEN 5 AND 15

--14

WITH cte_Ranked (ClientName, Bill, Email, TownName, Rank, ClientId) AS
(
    SELECT
      concat(c.FirstName, ' ', c.LastName) AS [Category Name],
      o.Bill,
      c.Email,
      t.Name,
      DENSE_RANK()
      OVER ( PARTITION BY t.Id
        ORDER BY o.Bill DESC )             AS Rank,
      c.Id
    FROM Towns t
      JOIN Orders o
        ON t.Id = o.TownId
      JOIN Clients c
        ON o.ClientId = c.Id
    WHERE datediff(DAY, c.CardValidity, o.CollectionDate) > 0 AND o.Bill IS NOT NULL
    GROUP BY t.Id, o.Bill, concat(c.FirstName, ' ', c.LastName), t.Name, c.Email, c.Id
)

SELECT
  cte.ClientName AS [Category Name],
  cte.Email      AS [Email],
  cte.Bill       AS [Bill],
  cte.TownName   AS [Town]
FROM cte_ranked AS cte
WHERE cte.Rank = 1 OR cte.Rank = 2
ORDER BY cte.TownName, cte.Bill, cte.ClientId

--15


SELECT t.Name, mp.MelaPercent, fp.FemalePercent
FROM Towns AS t
LEFT JOIN (SELECT
      t.Id,
      (COUNT(*) * 100) / tc.TotalCount AS [MelaPercent]
    FROM Clients AS c
      JOIN Orders o
        ON c.Id = o.ClientId
     FULL JOIN Towns t
        ON o.TownId = t.Id
      JOIN
      (
        SELECT
          t.Name   AS [TownName],
          COUNT(*) AS [TotalCount]
        FROM Clients AS c
          JOIN Orders o
            ON c.Id = o.ClientId
         FULL JOIN Towns t
            ON o.TownId = t.Id
        GROUP BY t.Name
      ) tc
        ON tc.TownName = t.Name
    WHERE c.Gender = 'M'
    GROUP BY t.Id, tc.TotalCount) AS mp ON mp.Id = t.Id
LEFT JOIN (SELECT
      t.Id,
      (COUNT(*) * 100) / tc.TotalCount AS [FemalePercent]
    FROM Clients AS c
      JOIN Orders o
        ON c.Id = o.ClientId
     FULL JOIN Towns t
        ON o.TownId = t.Id
      JOIN
      (
        SELECT
          t.Name   AS [TownName],
          COUNT(*) AS [TotalCount]
        FROM Clients AS c
          JOIN Orders o
            ON c.Id = o.ClientId
         FULL JOIN Towns t
            ON o.TownId = t.Id
        GROUP BY t.Name
      ) tc
        ON tc.TownName = t.Name
    WHERE c.Gender = 'F'
    GROUP BY t.Id, tc.TotalCount) as fp ON  fp.Id = t.Id
ORDER BY t.Name, t.Id

--16

WITH CTE_C (ReturnOfficeId, OfficeId, VehicleId, Manufacturer, Model)
AS
(
    SELECT
      W.ReturnOfficeId,
      W.OfficeId,
      W.Id,
      W.Manufacturer,
      W.Model
    FROM
      (SELECT
         DENSE_RANK()
         OVER ( PARTITION BY V.Id
           ORDER BY O.CollectionDate DESC ) AS [RANK],
         O.ReturnOfficeId,
         V.OfficeId,
         V.Id,
         M.Manufacturer,
         M.Model
       FROM Models AS M
         JOIN Vehicles AS V
           ON M.Id = V.ModelId
         LEFT JOIN Orders AS O
           ON O.VehicleId = V.Id) AS W
    WHERE W.RANK = 1
)

SELECT
  CONCAT(C.Manufacturer, ' - ', C.Model) AS [Vehicle],
  CASE
  WHEN (SELECT COUNT(*)
        FROM Orders
        WHERE VehicleId = C.VehicleId) = 0 OR C.OfficeId = C.ReturnOfficeId
    THEN 'home'
  WHEN C.ReturnOfficeId IS NULL
    THEN 'on a rent'
  WHEN C.OfficeId <> C.ReturnOfficeId
    THEN (SELECT CONCAT([To].Name, ' - ', [Of].Name)
          FROM Offices AS [Of]
            JOIN Towns AS [To]
              ON [To].Id = [Of].TownId
          WHERE C.ReturnOfficeId = [Of].Id)
  END                                    AS [Location]
FROM CTE_C AS C
ORDER BY Vehicle, C.VehicleId

--17

CREATE FUNCTION udf_CheckForVehicle(@townName NVARCHAR(50), @seatsNumber INT)
  RETURNS NVARCHAR(MAX)
AS
  BEGIN
    DECLARE @result NVARCHAR(MAX) = (SELECT TOP 1 o.Name + ' - ' + m2.Model
                                     FROM Towns AS t
                                       JOIN Offices o
                                         ON t.Id = o.TownId
                                       JOIN Vehicles v
                                         ON o.Id = v.OfficeId
                                       JOIN Models m2
                                         ON v.ModelId = m2.Id
                                     WHERE t.Name = @townName AND m2.Seats = @seatsNumber
                                     GROUP BY o.Name, m2.Model
                                     ORDER BY o.Name ASC)

    IF (@result IS NULL)
      BEGIN
        RETURN 'NO SUCH VEHICLE FOUND'
      END

    RETURN @result
  END

--18

CREATE PROCEDURE usp_MoveVehicle(@vehicleId INT, @officeId INT)
AS
  BEGIN
    BEGIN TRANSACTION
    DECLARE @officePlaces INT = (
      SELECT ParkingPlaces
      FROM Offices
      WHERE Id = @officeId
    )

    DECLARE @currentPlaces INT = (
      SELECT count(v.OfficeId)
      FROM Vehicles v
        JOIN Offices o
          ON v.OfficeId = o.Id
      WHERE o.Id = @officeId
      GROUP BY o.Name
    )

    IF (@officePlaces IS NULL OR @currentPlaces IS NULL OR @currentPlaces >= @officePlaces)
      BEGIN
        ROLLBACK;
        RAISERROR ('Not enough room in this office!', 16, 1);
      END

    UPDATE Vehicles
    SET OfficeId = @officeId
    WHERE Id = @vehicleId

    COMMIT;
  END

--19

CREATE TRIGGER TR_AddMileage
  ON Orders
  AFTER UPDATE
AS
  BEGIN
    DECLARE @newTotalMileage INT = (
      SELECT TotalMileage
      FROM inserted
    )
    DECLARE @vehicleId INT = (
      SELECT VehicleId
      FROM inserted
    )

    DECLARE @oldTotalMileage INT = (
      SELECT TotalMileage
      FROM deleted
    )

    IF (@oldTotalMileage IS NULL AND @vehicleId IS NOT NULL)
      BEGIN
        UPDATE Vehicles
        SET Mileage += @newTotalMileage
        WHERE Id = @vehicleId
      END
  END