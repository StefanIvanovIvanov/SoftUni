--1

CREATE DATABASE TheNerdHerd
GO


USE TheNerdHerd
GO

CREATE TABLE Credentials (
  Id INT PRIMARY KEY IDENTITY,
  Email VARCHAR(30),
  Password VARCHAR(20)
)

CREATE TABLE Locations (
  Id INT PRIMARY KEY IDENTITY (1, 1),
  Latitude FLOAT,
  Longitude FLOAT
)

CREATE TABLE Users (
  Id INT PRIMARY KEY IDENTITY (1, 1),
  Nickname VARCHAR(25),
  Gender CHAR(1),
  Age INT,
  LocationId INT FOREIGN KEY REFERENCES Locations (Id),
  CredentialId INT UNIQUE FOREIGN KEY REFERENCES Credentials (Id)
)

CREATE TABLE Chats (
  Id INT PRIMARY KEY IDENTITY (1, 1),
  Title VARCHAR(32),
  StartDate DATE,
  IsActive BIT
)

CREATE TABLE UsersChats (
  UserId INT,
  ChatId INT,
  CONSTRAINT PK_ChatId_UserId PRIMARY KEY (ChatId, UserId),
  CONSTRAINT FK_UserId_Users FOREIGN KEY (UserId) REFERENCES Users (Id),
  CONSTRAINT FK_ChatId_Chats FOREIGN KEY (ChatId) REFERENCES Chats (Id)
)

CREATE TABLE Messages (
  Id INT PRIMARY KEY IDENTITY (1, 1),
  Content VARCHAR(200),
  SentOn DATE,
  ChatId INT FOREIGN KEY REFERENCES Chats (Id),
  UserId INT FOREIGN KEY REFERENCES Users (Id)
)

--2

INSERT INTO Messages (Content, SentOn, ChatId, UserId)
SELECT
  concat(u.Age, '-', u.Gender, '-', l.Latitude, '-', l.Longitude) AS [Content],
  CONVERT(DATE, getdate())                                        AS [SentOn],
  CASE
  WHEN u.Gender = 'F'
    THEN CEILING(sqrt(u.Age * 2))
  ELSE
    CEILING(power((u.Age /18),3))
  END                                                             AS [ChatId],
  u.Id                                                            AS [UserId]
FROM Users u
  JOIN Locations l
    ON u.LocationId = l.Id
WHERE u.Id BETWEEN 10 AND 20


--3

UPDATE Chats
SET StartDate = dates.Date
FROM (
       SELECT
         c.Id,
         min(m.SentOn) AS [Date]
       FROM Chats c
         JOIN Messages m
           ON c.Id = m.ChatId
       WHERE datediff(DAY, c.StartDate, m.SentOn) < 0
       GROUP BY c.Id
     ) AS dates
  JOIN Messages m
    ON m.ChatId = dates.Id
WHERE Chats.Id = dates.Id


--4

delete FROM Locations
WHERE Id IN (
  SELECT l.Id
  FROM Locations l LEFT JOIN Users u ON l.Id = u.LocationId
  WHERE u.Id IS NULL
)

--5

SELECT Nickname, Gender, Age
FROM Users
WHERE Age BETWEEN 22 AND 37

--6

SELECT
  Content,
  SentOn
FROM Messages
WHERE Content LIKE '%just%' AND datediff(DAY, SentOn, '2014-05-12') < 0
ORDER BY Id DESC

--7

SELECT
  Title,
  IsActive
FROM Chats
WHERE IsActive = 0 AND LEN(Title) < 5
      OR (substring(Title, 3, 2) = 'tl')
ORDER BY Title DESC

--8

SELECT
  c.Id,
  c.Title,
  m2.Id
FROM Chats c
  JOIN Messages m2
    ON c.Id = m2.ChatId
WHERE datediff(DAY, m2.SentOn, '2012-03-26') > 0
      AND right(c.Title, 1) = 'x'
ORDER BY c.Id, m2.Id

--9

SELECT TOP (5) c.Id, count(*) AS [TotalMessages]
FROM Chats c
  RIGHT JOIN Messages m2
    ON c.Id = m2.ChatId
WHERE m2.Id < 90
GROUP BY c.Id
ORDER BY TotalMessages DESC, c.Id ASC

--10

SELECT
  u.Nickname,
  c.Email,
  c.Password
FROM Users u
  JOIN Credentials c
    ON u.CredentialId = c.Id
WHERE c.Email LIKE '%co.uk'
ORDER BY c.Email

--11

SELECT Id, Nickname, Age
FROM Users
WHERE LocationId IS NULL

--12

SELECT
  Id,
  ChatId,
  UserId
FROM Messages
WHERE ChatId = 17 AND UserId NOT IN (
  SELECT UserId
  FROM UsersChats
  WHERE ChatId = 17
) OR UserId IS NULL
ORDER BY Id DESC

--13

SELECT
  u.Nickname,
  c.Title,
  l.Latitude,
  l.Longitude
FROM Users u
  JOIN Locations l
    ON u.LocationId = l.Id
  JOIN UsersChats uc
    ON uc.UserId = u.Id
  JOIN Chats c
    ON uc.ChatId = c.Id
WHERE (l.Latitude >= 41.139999 AND l.Latitude <= 44.12999) AND
      (l.Longitude >= 22.20999 AND l.Longitude <= 28.35999)
ORDER BY c.Title ASC

--14

WITH cte_lastChat (ChatId, Title) AS
(
    SELECT TOP 1
      Id,
      Title
    FROM Chats
    GROUP BY Id, Title
    ORDER BY max(StartDate) DESC
)

SELECT
  cte.Title,
  m.Content
FROM cte_lastchat cte
  LEFT JOIN Messages m
    ON cte.ChatId = m.ChatId
GROUP BY cte.Title, m.Content
ORDER BY MIN(m.SentOn) DESC

--15

CREATE FUNCTION udf_GetRadians(@degrees FLOAT)
  RETURNS FLOAT
AS
  BEGIN
    DECLARE @result FLOAT = (@degrees * PI()) / 180

    RETURN @result
  END

--16

CREATE PROCEDURE udp_ChangePassword(@email VARCHAR(30), @newPassword VARCHAR(20))
AS
  BEGIN
    DECLARE @CredId INT = (
      SELECT Id
      FROM Credentials
      WHERE Email = @email
    )

    IF (@CredId IS NULL)
      BEGIN
        RAISERROR ('The email does''t exist!', 16, 1)
      END

    UPDATE Credentials
    SET Password = @newPassword
    WHERE Email = @email
  END

--17

CREATE PROCEDURE udp_SendMessage(@userId INT, @chatId INT, @content VARCHAR(200))
AS
  BEGIN
    IF (EXISTS(
        SELECT *
        FROM UsersChats
        WHERE UserId = @userId AND ChatId = @chatId
    ))
      BEGIN
        INSERT INTO Messages (Content, SentOn, ChatId, UserId) VALUES
          (@content, GETDATE(), @chatId, @userId)
      END
    ELSE
      BEGIN
        RAISERROR ('There is no chat with that user!', 16, 1)
      END
  END

--18

CREATE TRIGGER TR_Logs
  ON Messages
  AFTER DELETE
AS
  BEGIN
    INSERT INTO MessageLogs (Id, Content, SentOn, ChatId, UserId)
      SELECT
        Id,
        Content,
        SentOn,
        ChatId,
        UserId
      FROM deleted;
  END

--19

CREATE TRIGGER TR_DeleteUser
  ON Users
  INSTEAD OF DELETE
AS
  BEGIN
    DECLARE @UserId INT = (
      SELECT Id
      FROM deleted
    )

    DELETE FROM UsersChats
    WHERE UserId = @UserId

    DELETE FROM Messages
    WHERE UserId = @UserId

    DELETE FROM Users
    WHERE Id = @UserId

  END