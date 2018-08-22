--1.Database design
CREATE DATABASE WMS
GO

USE WMS
GO

CREATE TABLE Clients (
  ClientId INT NOT NULL IDENTITY,
  FirstName VARCHAR(50) NOT NULL,
  LastName VARCHAR(50) NOT NULL,
  Phone CHAR(12) NOT NULL,

  CONSTRAINT PK_Clients PRIMARY KEY (ClientId)
)

CREATE TABLE Mechanics (
  MechanicId INT NOT NULL IDENTITY,
  FirstName VARCHAR(50) NOT NULL,
  LastName VARCHAR(50) NOT NULL,
  Address VARCHAR(255) NOT NULL,

  CONSTRAINT PK_Mechanics PRIMARY KEY (MechanicId)
)

CREATE TABLE Models (
  ModelId INT NOT NULL IDENTITY,
  Name VARCHAR(50) NOT NULL,

  CONSTRAINT PK_Models PRIMARY KEY (ModelId),

  CONSTRAINT UQ_Models_Name UNIQUE (Name)
)

CREATE TABLE Jobs (
  JobId INT NOT NULL IDENTITY,
  ModelId INT NOT NULL,
  Status VARCHAR(11) NOT NULL DEFAULT 'Pending',
  ClientId INT NOT NULL,
  MechanicId INT,
  IssueDate DATE NOT NULL,
  FinishDate DATE,

  CONSTRAINT PK_Jobs PRIMARY KEY (JobId),

  CONSTRAINT FK_Jobs_Models FOREIGN KEY (ModelId) REFERENCES Models (ModelId),

  CONSTRAINT FK_Jobs_Clients FOREIGN KEY (ClientId) REFERENCES Clients (ClientId),

  CONSTRAINT FK_Jobs_Mechanics FOREIGN KEY (MechanicId) REFERENCES Mechanics (MechanicId),

  CONSTRAINT CHK_Jobs_Status CHECK (Status = 'Pending' OR Status = 'In Progress' OR Status = 'Finished')
)

CREATE TABLE Orders (
  OrderId INT NOT NULL IDENTITY,
  JobId INT NOT NULL,
  IssueDate DATETIME,
  Delivered BIT NOT NULL DEFAULT 'False',

  CONSTRAINT PK_Orders PRIMARY KEY (OrderId),

  CONSTRAINT FK_Orders_Jobs FOREIGN KEY (JobId) REFERENCES Jobs (JobId)
)

CREATE TABLE Vendors (
  VendorId INT NOT NULL IDENTITY,
  Name VARCHAR(50) NOT NULL,

  CONSTRAINT PK_Vendors PRIMARY KEY (VendorId),

  CONSTRAINT UQ_Vendors_Name UNIQUE (Name)
)

CREATE TABLE Parts (
  PartId INT NOT NULL IDENTITY,
  SerialNumber VARCHAR(50) NOT NULL,
  Description VARCHAR(255),
  Price DECIMAL(8, 2) NOT NULL,
  VendorId INT NOT NULL,
  StockQty INT DEFAULT 0,

  CONSTRAINT PK_Parts PRIMARY KEY (PartId),

  CONSTRAINT UQ_Parts_SerialNumber UNIQUE (SerialNumber),

  CONSTRAINT CHK_Parts_Price CHECK (Price > 0),

  CONSTRAINT FK_Parts_Vendors FOREIGN KEY (VendorId) REFERENCES Vendors (VendorId),

  CONSTRAINT CHK_Parts_StockQty CHECK (StockQty >= 0)
)

CREATE TABLE OrderParts (
  OrderId INT,
  PartId INT,
  Quantity INT DEFAULT 1,

  CONSTRAINT PK_OrderParts_Orders_Parts PRIMARY KEY (OrderId, PartId),

  CONSTRAINT FK_OrderParts_Orders FOREIGN KEY (OrderId) REFERENCES Orders (OrderId),
  CONSTRAINT FK_OrderParts_Parts FOREIGN KEY (PartId) REFERENCES Parts (PartId),

  CONSTRAINT CHK_OrderParts CHECK (Quantity > 0)
)

CREATE TABLE PartsNeeded (
  JobId INT,
  PartId INT,
  Quantity INT DEFAULT 1,

  CONSTRAINT PK_PartsNeeded_Jobs_Parts PRIMARY KEY (JobId, PartId),

  CONSTRAINT FK_PartsNeeded_Orders FOREIGN KEY (JobId) REFERENCES Jobs (JobId),
  CONSTRAINT FK_PartsNeeded_Parts FOREIGN KEY (PartId) REFERENCES Parts (PartId),

  CONSTRAINT CHK_PartsNeeded CHECK (Quantity > 0)
)

--2.Insert

INSERT INTO Clients (FirstName, LastName, Phone) VALUES
('Teri',	'Ennaco',	'570-889-5187'),
('Merlyn',	'Lawler',	'201-588-7810'),
('Georgene',	'Montezuma',	'925-615-5185'),
('Jettie',	'Mconnell',	'908-802-3564'),
('Lemuel',	'Latzke',	'631-748-6479'),
('Melodie',	'Knipp',	'805-690-1682'),
('Candida',	'Corbley',	'908-275-8357')

INSERT INTO Parts (SerialNumber, [Description], Price, VendorId) VALUES
  ('WP8182119',	'Door Boot Seal',	117.86,	2),
  ('W10780048',	'Suspension Rod',	42.81,	1),
  ('W10841140',	'Silicone Adhesive', 	6.77,	4),
  ('WPY055980',	'High Temperature Adhesive',	13.94,	3)

--3.Update

UPDATE Jobs
SET MechanicId = 3 ,Status = 'In Progress'
WHERE Status = 'Pending'

--4.Delete

DELETE FROM OrderParts
WHERE OrderId = 19

DELETE FROM Orders
WHERE OrderId = 19

--5.Clients by Name

SELECT
  FirstName,
  LastName,
  Phone
FROM Clients
ORDER BY LastName ASC, ClientId ASC

--6.Job Status

SELECT Status, IssueDate
FROM Jobs
WHERE Status <> 'Finished'
ORDER BY IssueDate, JobId

--7.Mechanic Assignments

SELECT
  m.FirstName + ' ' + m.LastName AS [Mechanic],
  j.Status                       AS [Status],
  j.IssueDate                    AS [IssueDate]
FROM Mechanics AS m
  JOIN Jobs j
    ON m.MechanicId = j.MechanicId
ORDER BY j.MechanicId, IssueDate, JobId

--8.Current Clients

SELECT
  c.FirstName + ' ' + c.LastName           AS [Client],
  datediff(DAY, j.IssueDate, '04/24/2017') AS [Day going],
  j.Status                                 AS [Status]
FROM Clients AS c
  JOIN Jobs j
    ON c.ClientId = j.ClientId
WHERE j.Status <> 'Finished'
ORDER BY [Day going] DESC, c.ClientId

--9.Mechanic Performance

SELECT
  m.FirstName + ' ' + m.LastName AS [Mechanic],
  avg(dayspermechanicid.Days)
FROM Mechanics AS m
JOIN (SELECT MechanicId , DATEDIFF(DAY, IssueDate, FinishDate) AS [Days]
      FROM Jobs
      WHERE Status = 'Finished'
    ) AS DaysPerMechanicId
  ON m.MechanicId = dayspermechanicid.MechanicId
GROUP BY m.FirstName + ' ' + m.LastName, m.MechanicId
ORDER BY m.MechanicId

--10.Hard Earners

SELECT TOP (3)
  m.FirstName + ' ' + m.LastName AS [Mechanic],
  count(*)                       AS [Jobs]
FROM Mechanics m
  JOIN Jobs j
    ON m.MechanicId = j.MechanicId
GROUP BY m.FirstName + ' ' + m.LastName, j.Status, j.MechanicId
HAVING j.Status <> 'Finished' AND count(*) > 1
ORDER BY Jobs DESC, j.MechanicId ASC

--11.Available Mechanics

SELECT m.FirstName + ' ' + m.LastName AS [Mechanic]
FROM Mechanics AS m
  JOIN (
    SELECT *
    FROM Mechanics
    WHERE MechanicId NOT IN (
      SELECT Jobs.MechanicId
      FROM Jobs
      WHERE Status <> 'Finished'
            AND Jobs.MechanicId IS NOT NULL
    )
    ) AS s ON s.MechanicId = m.MechanicId

--12.Parts Cost

SELECT ISNULL(SUM(p.Price * part.Quantity),0) AS [Parts Total]
FROM Orders AS o
  JOIN OrderParts part ON o.OrderId = part.OrderId
  JOIN Parts p ON part.PartId = p.PartId
WHERE o.IssueDate > (DATEADD(WEEK, -3 , '2017/04/24'))

--13.Past Expenses

SELECT
  j.JobId                               AS [Job ID],
  isnull(sum(p.Price * op.Quantity), 0) AS [Total]
FROM Jobs AS j
  FULL JOIN Orders AS o
    ON j.JobId = o.JobId
  FULL JOIN OrderParts AS op
    ON op.OrderId = o.OrderId
  FULL JOIN Parts AS p
    ON op.PartId = p.PartId
WHERE j.Status = 'Finished'
GROUP BY j.JobId
ORDER BY Total DESC, [Job ID] ASC

--14.Model Repair Time

SELECT
  m.ModelId                                                                   AS [ModelId],
  m.Name                                                                      AS [Name],
  cast(avg(datediff(DAY, j.IssueDate, j.FinishDate)) AS VARCHAR(5)) + ' days' AS [Average Service Time]
FROM Jobs AS j
  JOIN Models m
    ON j.ModelId = m.ModelId
WHERE j.Status = 'Finished'
GROUP BY m.Name, m.ModelId
ORDER BY avg(datediff(DAY, j.IssueDate, j.FinishDate))

--15.Faultiest Model

WITH CTE_MaxModel (ModelId, Name, MaxCount) AS
(
    SELECT
      modelscount.ModelId,
      modelscount.Name,
      Count
    FROM (SELECT
            m.ModelId,
            m.Name,
            count(j.JobId) AS [Count]
          FROM Jobs AS j
            JOIN Models m
              ON j.ModelId = m.ModelId
          GROUP BY m.ModelId, m.Name
         ) AS modelsCount
    WHERE modelscount.Count = (SELECT TOP (1) count(j.JobId) AS [Count]
                               FROM Jobs AS j
                                 JOIN Models m
                                   ON j.ModelId = m.ModelId
                               GROUP BY m.ModelId
                               ORDER BY Count DESC))

SELECT
  maxmodel.Name                         AS [Model],
  maxmodel.MaxCount                     AS [Times Serviced],
  isnull(sum(p.Price * part.Quantity), 0) AS [Parts Total]
FROM cte_maxmodel AS maxmodel
  LEFT JOIN Jobs j
    ON j.ModelId = maxmodel.ModelId
  LEFT JOIN Orders o
    ON j.JobId = o.JobId
  LEFT JOIN OrderParts part
    ON o.OrderId = part.OrderId
  LEFT JOIN Parts p ON part.PartId = p.PartId
GROUP BY maxmodel.Name, maxmodel.MaxCount

--16.Missing Parts

SELECT
  p.PartId,
  p.[Description],
  SUM(pn.Quantity)            AS [Required],
  AVG(p.StockQty)             AS [In Stock],
  ISNULL(SUM(op.Quantity), 0) AS [Ordered]
FROM Parts AS p
  JOIN PartsNeeded AS pn
    ON pn.PartId = p.PartId
  JOIN Jobs AS j
    ON j.JobId = pn.JobId
  LEFT JOIN Orders AS o
    ON o.JobId = j.JobId
  LEFT JOIN OrderParts AS op
    ON op.OrderId = o.OrderId
WHERE j.Status <> 'Finished'
GROUP BY p.PartId, p.Description
HAVING SUM(pn.Quantity) > AVG(p.StockQty) + ISNULL(SUM(op.Quantity), 0)
ORDER BY p.PartId

--17.Cost of Order

CREATE FUNCTION udf_GetCost(@jobsId INT)
  RETURNS DECIMAL(8, 2)
AS
  BEGIN
    DECLARE @totalCost DECIMAL(8, 2) = (SELECT ISNULL(sum(p.Price * part.Quantity), 0)
                                        FROM Jobs AS j
                                          JOIN Orders o
                                            ON j.JobId = o.JobId
                                          JOIN OrderParts part
                                            ON o.OrderId = part.OrderId
                                          JOIN Parts p
                                            ON part.PartId = p.PartId
                                        WHERE j.JobId = @jobsId)

    RETURN @totalCost
  END

--18.Place Order

CREATE PROCEDURE usp_PlaceOrder(@jobId INT, @serialNumberPart VARCHAR(20), @quantity INT)
AS
  BEGIN
    IF (@quantity <= 0)
      BEGIN
        RAISERROR ('Part quantity must be more than zero!', 16, 1)
        RETURN;
      END

    DECLARE @JobIdSelect INT = (
      SELECT JobId
      FROM Jobs
      WHERE JobId = @jobId
    )

    IF (@JobIdSelect IS NULL)
      BEGIN
        RAISERROR ('Job not found!', 16, 1)
      END

    DECLARE @JobStatus VARCHAR(50) = (
      SELECT Status
      FROM Jobs
      WHERE JobId = @jobId
    )

    IF (@JobStatus = 'Finished')
      BEGIN
        RAISERROR ('This job is not active!', 16, 1)
      END

    DECLARE @PartId INT = (
      SELECT PartId
      FROM Parts
      WHERE SerialNumber = @serialNumberPart
    )

    IF (@PartId IS NULL)
      BEGIN
        RAISERROR ('Part not found!', 16, 1)
      END

    DECLARE @OrderId INT = (
      SELECT o.OrderId
      FROM Orders AS o
        JOIN OrderParts part
          ON o.OrderId = part.OrderId
        JOIN Parts p
          ON part.PartId = p.PartId
      WHERE o.JobId = @jobId AND p.PartId = @PartId AND o.IssueDate IS NULL
    )

    IF (@OrderId IS NULL)
      BEGIN
        INSERT INTO Orders (JobId, IssueDate) VALUES
          (@jobId, NULL)

        INSERT INTO OrderParts (OrderId, PartId, Quantity) VALUES
          (IDENT_CURRENT('Orders'), @PartId, @quantity)
      END
    ELSE
      BEGIN
        DECLARE @PartExistanceOrder INT = (
          SELECT @@ROWCOUNT
          FROM OrderParts
          WHERE OrderId = @OrderId AND PartId = @PartId
        )

        IF (@PartExistanceOrder IS NULL)
          BEGIN
            INSERT INTO OrderParts (OrderId, PartId, Quantity) VALUES
              (@OrderId, @PartId, @quantity)
          END
        ELSE
          BEGIN
            UPDATE OrderParts
            SET Quantity += @quantity
            WHERE OrderId = @OrderId AND PartId = @PartId
          END
      END

  END

  DECLARE @err_msg AS NVARCHAR(MAX);
BEGIN TRY
  EXEC usp_PlaceOrder 1, 'ZeroQuantity', 0
END TRY

BEGIN CATCH
  SET @err_msg = ERROR_MESSAGE();
  SELECT @err_msg
END CATCH

--19.Detect Delivery

CREATE TRIGGER UpdateStockQty
  ON Orders
  AFTER UPDATE
AS
  BEGIN

	DECLARE @OldStatus INT = (SELECT Delivered from deleted)
	DECLARE @NewStatus INT = (SELECT Delivered from inserted)

	IF(@OldStatus = 0 AND @NewStatus = 1)
	BEGIN
		UPDATE Parts
		SET StockQty += op.Quantity
		FROM Parts AS p
		JOIN OrderParts AS op ON op.PartId = p.PartId
		JOIN Orders AS o ON o.OrderId = op.OrderId
		JOIN inserted AS i ON i.OrderId = o.OrderId
		JOIN deleted AS d ON d.OrderId = i.OrderId

	END
END

--20.Vendor Preference

SELECT
  m.FirstName + ' ' + m.LastName AS [Mechanic],
  v.Name                         AS [Vendor],
  sum(
      part.Quantity)             AS [Parts],
  cast(cast((cast(sum(part.Quantity) AS DECIMAL(6, 2)) / totalcount.TotalCount) * 100 AS INT) AS VARCHAR(50)) +
  '%'                            AS [Preference]
FROM Mechanics AS m
  JOIN Jobs j
    ON m.MechanicId = j.MechanicId
  JOIN Orders o
    ON j.JobId = o.JobId
  JOIN OrderParts part
    ON o.OrderId = part.OrderId
  JOIN Parts p
    ON part.PartId = p.PartId
  JOIN Vendors v
    ON p.VendorId = v.VendorId
  JOIN (
         SELECT
           m.MechanicId,
           sum(part.Quantity) AS [TotalCount]
         FROM Mechanics AS m
           JOIN Jobs j
             ON m.MechanicId = j.MechanicId
           JOIN Orders o
             ON j.JobId = o.JobId
           JOIN OrderParts part
             ON o.OrderId = part.OrderId
           JOIN Parts p
             ON part.PartId = p.PartId
           JOIN Vendors v
             ON p.VendorId = v.VendorId
         GROUP BY m.MechanicId
       ) AS TotalCount
    ON totalcount.MechanicId = m.MechanicId
GROUP BY m.FirstName + ' ' + m.LastName, v.Name, totalcount.TotalCount
ORDER BY Mechanic ASC, Parts DESC, Vendor ASC

--Dataset
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