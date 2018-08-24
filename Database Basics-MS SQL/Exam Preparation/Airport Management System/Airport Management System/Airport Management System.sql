--1
CREATE TABLE Flights (
  FlightID INT,
  DepartureTime DATETIME NOT NULL,
  ArrivalTime DATETIME NOT NULL,
  Status VARCHAR(9) NOT NULL CHECK (Status IN ('Departing', 'Delayed', 'Arrived', 'Cancelled')),
  OriginAirportID INT NOT NULL,
  DestinationAirportID INT NOT NULL,
  AirlineID INT NOT NULL,

  CONSTRAINT PK_Flights PRIMARY KEY (FlightID),
  CONSTRAINT FK_Flights_Airports_Origin FOREIGN KEY (OriginAirportID) REFERENCES Airports (AirportID),
  CONSTRAINT FK_Flights_Airports_Destination FOREIGN KEY (DestinationAirportID) REFERENCES Airports (AirportID),
  CONSTRAINT FK_Flights_Airports_Airlines FOREIGN KEY (AirlineID) REFERENCES Airlines (AirlineID)
)

CREATE TABLE Tickets (
  TicketID INT,
  Price DECIMAL(8, 2) NOT NULL,
  Class VARCHAR(6) NOT NULL CHECK (Class IN ('First', 'Second', 'Third')),
  Seat VARCHAR(5) NOT NULL,
  CustomerID INT NOT NULL,
  FlightID INT NOT NULL,

  CONSTRAINT PK_Tickets PRIMARY KEY (TicketID),
  CONSTRAINT FK_Tickets_Customers FOREIGN KEY (CustomerID) REFERENCES Customers (CustomerID),
  CONSTRAINT FK_Tickets_Flights FOREIGN KEY (FlightID) REFERENCES Flights (FlightID)
)

--2

INSERT INTO Flights (FlightID, DepartureTime, ArrivalTime, Status, OriginAirportID, DestinationAirportID, AirlineID)
VALUES
  (1, '2016-10-13 06:00 AM', '2016-10-13 10:00 AM', 'Delayed', 1, 4, 1),
  (2, '2016-10-12 12:00 PM', '2016-10-12 12:01 PM', 'Departing', 1, 3, 2),
  (3, '2016-10-14 03:00 PM', '2016-10-20 04:00 AM', 'Delayed', 4, 2, 4),
  (4, '2016-10-12 01:24 PM', '2016-10-12 4:31 PM', 'Departing', 3, 1, 3),
  (5, '2016-10-12 08:11 AM', '2016-10-12 11:22 PM', 'Departing', 4, 1, 1),
  (6, '1995-06-21 12:30 PM', '1995-06-22 08:30 PM', 'Arrived', 2, 3, 5),
  (7, '2016-10-12 11:34 PM', '2016-10-13 03:00 AM', 'Departing', 2, 4, 2),
  (8, '2016-11-11 01:00 PM', '2016-11-12 10:00 PM', 'Delayed', 4, 3, 1),
  (9, '2015-10-01 12:00 PM', '2015-12-01 01:00 AM', 'Arrived', 1, 2, 1),
  (10, '2016-10-12 07:30 PM', '2016-10-13 12:30 PM', 'Departing', 2, 1, 7)

INSERT INTO Tickets (TicketID, Price, Class, Seat, CustomerID, FlightID) VALUES
  (1, 3000.00, 'First', '233-A', 3, 8),
  (2, 1799.90, 'Second', '123-D', 1, 1),
  (3, 1200.50, 'Second', '12-Z', 2, 5),
  (4, 410.68, 'Third', '45-Q', 2, 8),
  (5, 560.00, 'Third', '201-R', 4, 6),
  (6, 2100.00, 'Second', '13-T', 1, 9),
  (7, 5500.00, 'First', '98-O', 2, 7)

  --3

UPDATE Flights
SET AirlineID = 1
WHERE Status = 'Arrived'

--4

UPDATE Tickets
SET Price *= 1.50
WHERE TicketID IN (
  SELECT t.TicketID
  FROM Airlines a
    JOIN Flights f
      ON a.AirlineID = f.AirlineID
    JOIN Tickets t
      ON f.FlightID = t.FlightID
  WHERE a.AirlineID = (
    SELECT TOP 1 AirlineID
    FROM Airlines
    ORDER BY Rating DESC
  )
)

--5

CREATE TABLE CustomerReviews (
  ReviewID INT PRIMARY KEY,
  ReviewContent VARCHAR(255) NOT NULL,
  ReviewGrade INT CHECK (ReviewGrade BETWEEN 0 AND 10),
  AirlineID INT FOREIGN KEY REFERENCES Airlines (AirlineID),
  CustomerID INT FOREIGN KEY REFERENCES Customers (CustomerID),
)

CREATE TABLE CustomerBankAccounts (
  AccountID INT PRIMARY KEY,
  AccountNumber VARCHAR(10) NOT NULL UNIQUE,
  Balance DECIMAL(10, 2) NOT NULL,
  CustomerID INT FOREIGN KEY REFERENCES Customers (CustomerID)
)

INSERT INTO CustomerReviews (ReviewID, ReviewContent, ReviewGrade, AirlineID, CustomerID) VALUES
  (1, 'Me is very happy. Me likey this airline. Me good.', 10, 1, 1),
  (2, 'Ja, Ja, Ja... Ja, Gut, Gut, Ja Gut! Sehr Gut!', 10, 1, 4),
  (3, 'Meh...', 5, 4, 3),
  (4, 'Well Ive seen better, but Ive certainly seen a lot worse...', 7, 3, 5)

INSERT INTO CustomerBankAccounts (AccountID, AccountNumber, Balance, CustomerID) VALUES
  (1, '123456790', 2569.23, 1),
  (2, '18ABC23672', 14004568.23, 2),
  (3, 'F0RG0100N3', 19345.20, 5)

--6

SELECT TicketID, Price, Class, Seat
FROM Tickets
ORDER BY TicketID

--7

SELECT CustomerID,
  concat(FirstName, ' ', LastName) AS [FullName],
  Gender
FROM Customers
ORDER BY FullName, CustomerID

--8

SELECT FlightID, DepartureTime, ArrivalTime
FROM Flights
WHERE Status = 'Delayed'
ORDER BY FlightID

--9

SELECT TOP 5 *
FROM (
  SELECT DISTINCT
    a.AirlineID,
    a.AirlineName,
    a.Nationality,
    a.Rating
  FROM Flights f
    LEFT JOIN Airlines a
      ON f.AirlineID = a.AirlineID
) AS a
ORDER BY a.Rating DESC, a.AirlineID

--10

SELECT t.TicketID,
  a.AirportName AS [Destination],
  concat(c.FirstName,' ', c.LastName) AS [CustomerName]
FROM (
  SELECT *
  FROM Tickets
  WHERE Price < 5000 AND Class = 'First'
) AS t
left JOIN Flights f ON f.FlightID = t.FlightID
LEFT JOIN Airports a ON f.DestinationAirportID = a.AirportID
LEFT JOIN Customers c ON c.CustomerID = t.CustomerID
ORDER BY t.TicketID

--11

SELECT DISTINCT
  c.CustomerID                         AS [CustomerID],
  concat(c.FirstName, ' ', c.LastName) AS [FullName],
  t2.TownName                          AS [HomeTown]
FROM Customers c
  JOIN Tickets t
    ON c.CustomerID = t.CustomerID
  JOIN Flights f
    ON t.FlightID = f.FlightID
  JOIN Airports a
    ON f.OriginAirportID = a.AirportID
  JOIN Towns t2
    ON a.TownID = t2.TownID AND c.HomeTownID = a.TownID
ORDER BY c.CustomerID

--12

SELECT DISTINCT
  c.CustomerID,
  concat(c.FirstName, ' ', c.LastName)      AS [FullName],
  datediff(YEAR, c.DateOfBirth, '2016-1-1') AS [Age]
FROM Tickets t
  JOIN Flights f
    ON t.FlightID = f.FlightID
  JOIN Customers c
    ON t.CustomerID = c.CustomerID
WHERE f.Status = 'Departing'
ORDER BY Age, c.CustomerID

--13

SELECT TOP 3
  c.CustomerID,
  concat(c.FirstName, ' ', c.LastName) AS [FullName],
  t.Price                              AS [TicketPrice],
  a.AirportName                        AS [Destination]
FROM Tickets t
  JOIN Flights f
    ON t.FlightID = f.FlightID
  JOIN Customers c
    ON t.CustomerID = c.CustomerID
  JOIN Airports a
    ON f.DestinationAirportID = a.AirportID
WHERE f.Status = 'Delayed'
ORDER BY TicketPrice DESC

--14

SELECT
  f.FlightID,
  f.DepartureTime,
  f.ArrivalTime,
  originA.AirportName AS [Origin],
  destA.AirportName   AS [Destination]
FROM (
       SELECT TOP 5 *
       FROM Flights f
       WHERE Status = 'Departing'
       ORDER BY DepartureTime DESC
     ) AS f
  JOIN Airports destA
    ON f.DestinationAirportID = destA.AirportID
  JOIN Airports originA
    ON f.OriginAirportID = originA.AirportID
ORDER BY f.DepartureTime, f.FlightID ASC

--15

SELECT DISTINCT
  c.CustomerID,
  concat(c.FirstName, ' ', c.LastName)      AS [FullName],
  datediff(YEAR, c.DateOfBirth, '2016-1-1') AS [Age]
FROM Customers c
  JOIN Tickets t
    ON c.CustomerID = t.CustomerID
  LEFT JOIN Flights f
    ON t.FlightID = f.FlightID
WHERE datediff(YEAR, c.DateOfBirth, '2016-1-1') < 21
      AND f.Status = 'Arrived'
ORDER BY Age DESC, c.CustomerID

--16

SELECT
  a.AirportID,
  a.AirportName,
  count(c.CustomerID) AS [Passengers]
FROM Airports a
  JOIN Flights f
    ON a.AirportID = f.OriginAirportID
  JOIN Tickets t
    ON f.FlightID = t.FlightID
  JOIN Customers c
    ON t.CustomerID = c.CustomerID
WHERE f.Status = 'Departing'
GROUP BY a.AirportID, a.AirportName
HAVING count(c.CustomerID) > 0
ORDER BY a.AirportID

--17

CREATE PROCEDURE usp_SubmitReview(@customerId    INT,
                                  @reviewContent VARCHAR(255),
                                  @reviewGrade   INT,
                                  @airlineName   VARCHAR(30))
AS
  BEGIN

    DECLARE @AirlineId INT = (
      SELECT AirlineID
      FROM Airlines
      WHERE AirlineName = @airlineName
    )

    IF (@AirlineId IS NULL)
      BEGIN
        RAISERROR ('Airline does not exist.', 16, 1)
        RETURN
      END

    DECLARE @LastId INT = ISNULL((SELECT IDENT_CURRENT('CustomerReviews')), 0) + 1

    INSERT INTO CustomerReviews (ReviewID, ReviewContent, ReviewGrade, AirlineID, CustomerID) VALUES
      (@LastId, @reviewContent, @reviewGrade, @AirlineId, @customerId)
  END


  SELECT *
  FROM Airlines;

--18

CREATE PROCEDURE usp_PurchaseTicket(@CustomerID  INT,
                                    @FlightID    INT,
                                    @TicketPrice DECIMAL(8, 2),
                                    @Class       VARCHAR(6),
                                    @Seat        VARCHAR(5))
AS
  BEGIN
    DECLARE @CustomerBalance DECIMAL(10, 2) = (
      SELECT Balance
      FROM CustomerBankAccounts
      WHERE CustomerID = @CustomerID
    )

    IF (@TicketPrice > isnull(@CustomerBalance, 0))
      BEGIN
        RAISERROR ('Insufficient bank account balance for ticket purchase.', 16, 1)
        RETURN
      END

    DECLARE @TicketLastID INT = isnull((SELECT MAX(TicketID)
                                        FROM Tickets), 0) + 1

    INSERT INTO Tickets (TicketID, Price, Class, Seat, CustomerID, FlightID) VALUES
      (@TicketLastID, @TicketPrice, @Class, @Seat, @CustomerID, @FlightID)

    UPDATE CustomerBankAccounts
    SET Balance -= @TicketPrice
    WHERE CustomerID = @CustomerID
  END

--19

CREATE TRIGGER TR_ArrivedFlights
  ON Flights
  FOR UPDATE
AS
  BEGIN
    INSERT INTO ArrivedFlights (FlightID, ArrivalTime, Origin, Destination, Passengers)
      (SELECT
         i.FlightID,
         i.ArrivalTime,
         ao.AirportName,
         ad.AirportName,
         ISNULL(COUNT(ti.CustomerID), 0)
       FROM inserted AS i
         JOIN Airports AS ao
           ON ao.AirportID = i.OriginAirportID
         JOIN Airports AS ad
           ON ad.AirportID = i.DestinationAirportID
         LEFT JOIN Tickets AS ti
           ON ti.FlightID = i.FlightID
       WHERE i.Status = 'Arrived'
       GROUP BY i.FlightID, i.ArrivalTime, ao.AirportName, ad.AirportName
      )
  END
