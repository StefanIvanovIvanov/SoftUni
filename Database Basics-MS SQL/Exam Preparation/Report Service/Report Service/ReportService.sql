--1.Database design

CREATE DATABASE ReportService
GO
USE ReportService
GO

/*
CREATE TABLE Users
(Id        INT NOT NULL IDENTITY,
 Username  NVARCHAR(30) NOT NULL UNIQUE,
 Password  NVARCHAR(50) NOT NULL,
 Name      NVARCHAR(50),
 Gender    CHAR(1),
 BirthDate DATETIME,
 Age       INT,
 Email     NVARCHAR(50) NOT NULL,
 CONSTRAINT PK_Users PRIMARY KEY(Id),
 CONSTRAINT CH_Users_Gender CHECK(Gender IN('M', 'F'))
);

CREATE TABLE Departments
(Id   INT NOT NULL IDENTITY,
 Name NVARCHAR(50) NOT NULL,
 CONSTRAINT PK_Departments PRIMARY KEY(Id)
);

CREATE TABLE Employees
(Id           INT NOT NULL IDENTITY,
 FirstName    NVARCHAR(25),
 LastName     NVARCHAR(25),
 Gender       CHAR(1),
 BirthDate    DATETIME,
 Age          INT,
 DepartmentId INT NOT NULL,
 CONSTRAINT PK_Employees PRIMARY KEY(Id),
 CONSTRAINT FK_Employees_Departments FOREIGN KEY(DepartmentId) REFERENCES Departments(Id),
 CONSTRAINT CH_Employees_Gender CHECK(Gender IN('M', 'F'))
);

CREATE TABLE Categories
(Id           INT NOT NULL IDENTITY,
 Name         NVARCHAR(50) NOT NULL,
 DepartmentId INT,
 CONSTRAINT PK_Categories PRIMARY KEY(Id),
 CONSTRAINT FK_Categories_Departments FOREIGN KEY(DepartmentId) REFERENCES Departments(Id)
);

CREATE TABLE Status
(Id    INT NOT NULL IDENTITY,
 Label NVARCHAR(30) NOT NULL,
 CONSTRAINT PK_Status PRIMARY KEY(Id)
);

CREATE TABLE Reports
(Id          INT NOT NULL IDENTITY,
 CategoryId  INT NOT NULL,
 StatusId    INT NOT NULL,
 OpenDate    DATETIME NOT NULL,
 CloseDate   DATETIME,
 Description NVARCHAR(200),
 UserId      INT NOT NULL,
 EmployeeId  INT,
 CONSTRAINT PK_Reports PRIMARY KEY(Id),
 CONSTRAINT FK_Reports_Categories FOREIGN KEY(CategoryId) REFERENCES Categories(Id),
 CONSTRAINT FK_Reports_Employees FOREIGN KEY(EmployeeId) REFERENCES Employees(Id),
 CONSTRAINT FK_Reports_Status FOREIGN KEY(StatusId) REFERENCES Status(Id),
 CONSTRAINT FK_Reports_Users FOREIGN KEY(UserId) REFERENCES Users(Id)
);
*/

--2.Insert
INSERT INTO Employees(Firstname, Lastname, Gender, Birthdate, DepartmentId)
VALUES
('Marlo', 'O’Malley', 'M', '09/21/1958', '1'),
('Niki', 'Stanaghan', 'F', '11/26/1969', '4'),
('Ayrton', 'Senna', 'M', '03/21/1960 ', '9'),
('Ronnie', 'Peterson', 'M', '02/14/1944', '9'),
('Giovanna', 'Amati', 'F', '07/20/1959', '5')

INSERT INTO Reports(CategoryId, StatusId, OpenDate, CloseDate, [Description], UserId, EmployeeId)
VALUES
('1', '1', '04/13/2017', NULL, 'Stuck Road on Str.133', '6', '2'),
('6', '3', '09/05/2015', '12/06/2015', 'Charity trail running', '3', '5'),
('14', '2', '09/07/2015', NULL, 'Falling bricks on Str.58', '5', '2'),
('4', '3', '07/03/2017', '07/06/2017', 'Cut off streetlight on Str.11', '1', '1')

--3.Update
UPDATE Reports
SET StatusID = 2
WHERE StatusId = 1 AND CategoryId = 4

--4.Delete
DELETE FROM Reports
WHERE StatusId = 4

--5.Users by Age
SELECT Username, Age
FROM Users
ORDER BY Age, Username DESC

--6.Unassigned Reports
SELECT [Description], OpenDate
FROM Reports
WHERE EmployeeId IS NULL
ORDER BY OpenDate, [Description]

--7.Employees & Reports
SELECT e.FirstName, e.LastName, r.[Description], FORMAT(r.OpenDate, 'yyyy-MM-dd') AS [OpenDate]
FROM Reports AS r
JOIN Employees AS e
ON e.ID=r.EmployeeID
WHERE EmployeeId IS NOT NULL
ORDER BY e.Id, r.OpenDate, r.Id

--8.Most reported Category
SELECT c.Name AS [CategoryName],
COUNT(r.Id) AS [ReportsNumber]
FROM Categories AS c
JOIN Reports AS r
ON r.CategoryId = c.Id
GROUP BY c.Name
ORDER BY [ReportsNumber] DESC, c.Name

--9.Employees in Category
SELECT c.Name AS [Category Name], COUNT(e.Id) AS [Employees Number]
FROM Categories AS c
JOIN Departments AS d
ON d.Id = c.DepartmentId
JOIN Employees AS e
ON e.DepartmentId= d.Id
GROUP BY c.Name

--10.Users per Employee
SELECT DISTINCT e.FirstName + ' ' + e.LastName AS [Name],
COUNT(r.UserId) AS [User Number]
FROM Reports AS r
RIGHT JOIN Employees AS e
ON e.Id = r.EmployeeId
GROUP BY e.FirstName + ' '+ e.LastName
ORDER BY [User Number] DESC, Name

--11.Emergency Patrol
SELECT r.OpenDate, r.Description, u.Email AS [Reporter Email]
FROM Reports AS r
JOIN Categories AS c
ON c.Id = r.CategoryId
JOIN Users AS u
ON r.UserId = u.Id
WHERE CloseDate IS NULL
AND LEN(r.Description) > 20
AND Description LIKE '%str%'
AND c.DepartmentId IN(1, 4, 5)
ORDER BY r.OpenDate, [Reporter Email], r.Id

SELECT * FROM Departments

--12.Birthday Report
SELECT DISTINCT c.Name AS [Category Name] FROM Reports AS r
JOIN Categories AS c
ON c.Id = r.CategoryId
JOIN Users AS u
ON u.Id = r.UserId
WHERE DAY(r.OpenDate) = DAY(u.BirthDate)
AND MONTH(r.OpenDate) = MONTH(u.BirthDate)

--13.Numbers Coincidence
SELECT DISTINCT u.Username
FROM Reports AS r
JOIN Categories AS c
ON c.Id = r.CategoryId
JOIN Users AS u
ON u.Id = r.UserId
WHERE LEFT(u.Username, 1) LIKE '[0-9]'
AND CONVERT(VARCHAR(10),c.Id) = LEFT(u.Username, 1)
OR RIGHT (u.Username, 1) LIKE '[0-9]'
AND CONVERT(VARCHAR(10),c.Id) = RIGHT(u.Username, 1)
ORDER BY u.Username

--14.Open/Closed Statistics
SELECT E.Firstname+' '+E.Lastname AS FullName, 
	   ISNULL(CONVERT(varchar, CC.ReportSum), '0') + '/' +        
       ISNULL(CONVERT(varchar, OC.ReportSum), '0') AS [Stats]
FROM Employees AS E
JOIN (SELECT EmployeeId,  COUNT(1) AS ReportSum
	  FROM Reports R
	  WHERE  YEAR(OpenDate) = 2016
	  GROUP BY EmployeeId) AS OC ON OC.Employeeid = E.Id
LEFT JOIN (SELECT EmployeeId,  COUNT(1) AS ReportSum
	       FROM Reports R
	       WHERE  YEAR(CloseDate) = 2016
	       GROUP BY EmployeeId) AS CC ON CC.Employeeid = E.Id
ORDER BY FullName

--15.Average Closing Time
SELECT d.Name, ISNULL(CONVERT(VARCHAR(10), AVG(DATEDIFF(DAY, r.OpenDate, r.CloseDate))), 'no info') AS [Average Duration]
FROM Departments AS d
JOIN Categories AS c
ON c.DepartmentId = d.Id
JOIN Reports AS r
ON r.CategoryId = c.Id
GROUP BY d.Name

--16.Favorite Categories
SELECT Department,
       Category,
       Percentage
FROM
    (SELECT D.Name AS Department,
		    C.Name AS Category,
		    CAST(
			     ROUND(
				       COUNT(1) OVER(PARTITION BY C.Id) * 100.00 / COUNT(1) OVER(PARTITION BY D.Id), 0
					  ) as int
				) AS Percentage
     FROM Categories AS C
		  JOIN Reports AS R ON R.Categoryid = C.Id
		  JOIN Departments AS D ON D.Id = C.Departmentid) AS Stats
GROUP BY Department,
         Category,
         [Percentage]
ORDER BY Department,
         Category,
         Percentage

--17.Employee’s Load
CREATE FUNCTION udf_GetReportsCount(@employeeId INT, @statusId INT)
RETURNS INT
AS
BEGIN
    DECLARE @num INT= (SELECT COUNT(*)
                       FROM reports
                       WHERE Employeeid = @employeeId
                             AND Statusid = @statusId);
    RETURN @num;
END;

--18.Assign Employee
CREATE PROC usp_AssignEmployeeToReport(@employeeId INT, @reportId INT)
AS
BEGIN
    BEGIN TRAN
		DECLARE @categoryId INT= (
								 SELECT Categoryid
								 FROM Reports
								 WHERE Id = @reportId);
		/*IF (@categoryId IS NULL)
		BEGIN;
		   THROW 50011,'Invalid report Id!', 1;
		   return;
		END*/

		DECLARE @employeeDepId INT= (
									SELECT Departmentid
									FROM Employees
									WHERE Id = @employeeId);
		/*IF (@employeeDepId IS NULL)
		BEGIN;
		   THROW 50012,'Invalid employee Id!', 1;
		   RETURN;
		END*/

		DECLARE @categoryDepId INT= (
									SELECT Departmentid
									FROM Categories
									WHERE Id = @categoryId);
		UPDATE Reports
		SET EmployeeId = @employeeId
		WHERE Id = @reportId

		IF @employeeId IS NOT NULL
		   AND @categoryDepId <> @employeeDepId
		BEGIN 
			ROLLBACK;
			THROW 50013,'Employee doesn''t belong to the appropriate department!', 1;
		END;   
    COMMIT; 
END;

EXEC usp_AssignEmployeeToReport 17, 2;
SELECT EmployeeId FROM Reports WHERE id = 17

--19.Close Reports
CREATE TRIGGER T_CloseReport ON Reports
AFTER UPDATE
AS
BEGIN
	UPDATE Reports
	SET StatusId = (SELECT Id FROM Status WHERE Label = 'completed')
	WHERE Id IN (SELECT Id FROM inserted
			     WHERE Id IN (SELECT Id FROM deleted
						      WHERE CloseDate IS NULL)
			           AND CloseDate IS NOT NULL)   
END;

UPDATE Reports
SET CloseDate = GETDATE()
WHERE EmployeeId = 5;

--20.Categories Revision
SELECT c.Name,
	  COUNT(r.Id) AS ReportsNumber,
	  CASE 
	      WHEN InProgressCount > WaitingCount THEN 'in progress'
		  WHEN InProgressCount < WaitingCount THEN 'waiting'
		  ELSE 'equal'
	  END AS MainStatus
FROM Reports AS r
    JOIN Categories AS c ON c.Id = r.CategoryId
    JOIN Status AS s ON s.Id = r.StatusId
    JOIN (SELECT r.CategoryId, 
		         SUM(CASE WHEN s.Label = 'in progress' THEN 1 ELSE 0 END) as InProgressCount,
		         SUM(CASE WHEN s.Label = 'waiting' THEN 1 ELSE 0 END) as WaitingCount
		  FROM Reports AS r
		  JOIN Status AS s on s.Id = r.StatusId
		  WHERE s.Label IN ('waiting','in progress')
		  GROUP BY r.CategoryId
		 ) AS sc ON sc.CategoryId = c.Id
WHERE s.Label IN ('waiting','in progress') 
GROUP BY C.Name,
	     CASE 
		     WHEN InProgressCount > WaitingCount THEN 'in progress'
		     WHEN InProgressCount < WaitingCount THEN 'waiting'
		     ELSE 'equal'
	     END
ORDER BY C.Name, 
		 ReportsNumber, 
		 MainStatus;

CREATE TABLE Users(
Id INT  PRIMARY KEY IDENTITY,
Username NVARCHAR(30) UNIQUE NOT NULL,
[Password] NVARCHAR(50) NOT NULL,
[Name] NVARCHAR(50),
Gender CHAR(1) CHECK(Gender IN ('M', 'F')),
BirthDate DATETIME,
Age INT,
Email NVARCHAR(50) NOT NULL
)

CREATE TABLE Departments(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Employees(
Id INT PRIMARY KEY Identity,
FirstName NVARCHAR(25),
LastName NVARCHAR(25),
Gender CHAR(1) CHECK(Gender IN ('M', 'F')),
BirthDate DATETIME,
Age INT,
DepartmentId INT FOREIGN KEY(DepartmentId) REFERENCES Departments(Id) NOT NULL
)

CREATE TABLE Categories(
Id INT PRIMARY KEY IDENTITY, 
[Name] NVARCHAR(50) NOT NULL,
DepartmentId INT FOREIGN KEY (DepartmentId) REFERENCES Departments(Id)
)

CREATE TABLE Status(
Id INT PRIMARY KEY IDENTITY,
Label VARCHAR(30) NOT NULL
)

CREATE TABLE Reports(
Id INT PRIMARY KEY IDENTITY,
CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
StatusId INT FOREIGN KEY REFERENCES Status(Id) NOT NULL,
OpenDate DATETIME NOT NULL,
CloseDate DATETIME,
[Description] VARCHAR(200),
UserId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL,
EmployeeId INT FOREIGN KEY REFERENCES Employees(Id)
)

USE ReportService
GO

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

--INSERT Departments
SET IDENTITY_INSERT Departments ON;

INSERT INTO Departments(Id, Name)
VALUES(1, 'Infrastructure'), (2, 'Aged Care'), (3, 'Legal'), (4, 'Emergency'), (5, 'Roads Maintenance'), (6, 'Animals Care'), (7, 'Forestry Office'), (8, 'Property Management'), (9, 'Event Management'), (10, 'Environment');

SET IDENTITY_INSERT Departments OFF;


--INSERT Categories
SET IDENTITY_INSERT Categories ON;

INSERT INTO Categories(Id,
                       Name,
                       Departmentid)
VALUES(1, 'Snow Removal', 5), (2, 'Recycling', 10), (3, 'Water/Air Pollution', 10), (4, 'Streetlight', 1), (5, 'Illegal Construction', 8), (6, 'Sports Events', 9), (7, 'Homeless Elders', 2), (8, 'Disabled People', 2), (9, 'Art Events', 9), (10, 'Animal in Danger', 6), (11, 'Destroyed Home', 4), (12, 'Street animal', 6), (13, 'Music Events', 9), (14, 'Dangerous Building', 8), (15, 'Traffic Lights', 5), (16, 'Potholes', 5), (17, 'Green Areas', 7), (18, 'Dangerous Trees', 7);

SET IDENTITY_INSERT Categories OFF;

--INSERT Status
SET IDENTITY_INSERT [Status] ON;

INSERT INTO Status(Id,
                   Label)
VALUES(1, 'waiting'), (2, 'in progress'), (3, 'completed'), (4, 'blocked');

SET IDENTITY_INSERT [Status] OFF;

--INSERT Employees
SET IDENTITY_INSERT Employees ON;

INSERT INTO Employees(Id,
                      Firstname,
                      Lastname,
                      Gender,
                      Birthdate,
                      DepartmentId)
VALUES(1, 'Marlo', 'O''Malley', 'M', '9/21/1958', 1), (2, 'Nolan', 'Meneyer', 'M', '4/29/1961', 6), (3, 'Tarah', 'McWaters', 'F', '5/22/1954', 9), (4, 'Bernetta', 'Bigley', 'F', '10/18/1979', 2), (5, 'Gregory', 'Stithe', 'M', '6/25/1952', 5), (6, 'Bord', 'Hambleton', 'M', NULL, 8), (7, 'Humphrey', 'Tamblyn', 'M', '3/26/1941', 6), (8, 'Dinah', 'Zini', 'F', '9/8/1950', 10), (9, 'Eustace', 'Sharpling', 'M', '10/29/1956', 1), (10, 'Shannon', 'Partridge', 'M', '2/14/1952', 1), (11, 'Nancey', 'Heintsch', 'F', '8/20/1967', 3), (12, 'Niki', 'Stranaghan', 'M', '11/26/1969', 9), (13, 'Dick', 'Wentworth', 'M', '4/29/1983', 4), (14, 'Ives', 'McNeigh', 'M', '11/15/1952', 1), (15, 'Leonardo', 'Shopcott', 'M', '1/15/1939', 6), (16, 'Howard', 'Lovelady', 'M', '6/6/1969', 5), (17, 'Bron', 'Ledur', 'M', '11/26/1996', 10), (18, 'Adelind', 'Benns', 'F', '11/23/1935', 10), (19, 'Imogen', 'Burnup', 'F', '5/8/1952', 3), (20, 'Eldon', 'Gaze', 'M', '8/24/1947', 5), (21, 'Patsy', 'McLenahan', 'F', NULL, 10), (22, 'Jeane', 'Salisbury', 'F', '9/13/1967', 5), (23, 'Tiena', 'Ritchard', 'F', '4/18/1985', 3), (24, 'Hakim', 'Guilaem', 'M', '4/9/1963', 9), (25, 'Corny', 'Pickthall', 'M', '12/18/1979', 2), (26, 'Tam', 'Kornel', 'M', '10/3/1995', 9), (27, 'Abby', 'Brettoner', 'F', '4/16/1992', 9), (28, 'Galven', 'Moston', 'M', '3/20/1945', 5), (29, 'Stefa', 'Jakubovski', 'F', '1/10/1947', 2), (30, 'Hewet', 'Juschke', 'M', '12/26/1997', 7);

SET IDENTITY_INSERT Employees OFF;

--INSERT Users
SET IDENTITY_INSERT Users ON;

INSERT INTO Users(Id,
                  Username,
                  Name,
			   Password,
                  Gender,
                  BirthDate,
		        Age,
                  Email)
VALUES
(1, 'ealpine0', 'Erhart Alpine', 'b8eYD1a7R44', 'F', '07/07/1949', 68, 'ealpine0@squarespace.com'),
(2, 'awight1', 'Anitra Wight', 'hbHhuwBSxqeo', 'F', '05/31/1943', 74, 'awight1@artisteer.com'),
(3, 'fmacane2', 'Faustine MacAne', 'nhpbS3h2rfR', 'M', '11/19/1944', 73, 'fmacane2@is.gd'),
(4, 'fdenrico3', 'Florette D''Enrico', '0iMw1JpVk4', 'F', '10/26/1977', 40, 'fdenrico3@va.gov'),
(5, 'lrow4', 'Lindsey Row', 'neGBinke', 'F', '01/16/1934', 83, 'lrow4@netscape.com'),
(6, 'dfinicj5', 'NULL', '2GDReU', 'F', '05/20/1993', 24, 'shynson5@ihg.com'),
(7, 'llankham6', 'Lishe Lankham', 'ygNzd2f', 'F', '11/05/1951', 66, 'llankham6@histats.com'),
(8, 'tmartensen7', 'Tawnya Martensen', 'KyFw9oA', 'M', '11/21/1980', 37, 'tmartensen7@cornell.edu'),
(9, 'mgobbett8', 'Maud Gobbett', 'anv5ba2pvM', 'F', '10/29/1958', 59, 'mgobbett8@dmoz.org'),
(10, 'vinglese9', 'Veronique Inglese', 'ZCJp511W', 'M', '02/16/1962', 55, 'vinglese9@g.co'),
(11, 'mburdikina', 'Maggi Burdikin', 'MjXufd', 'F', '04/23/1986', 31, 'mburdikina@boston.com'),
(12, 'varkwrightb', 'Vanni Arkwright', 'sWKjjlWE', 'M', '02/29/1964', 53, '6varkwrightb@ucoz.com'),
(13, '5omarkwelleyc', 'Odette Markwelley', 'UfUE4pE', 'F', '05/23/1998', 19, 'omarkwelleyc@alibaba.com'),
(14, 'dpennid', 'Dorene Penni', 'rIBnJ77b', 'F', '09/07/1959', 58, 'dpennid@arizona.edu'),
(15, 'wkicke', 'Wileen Kick', '7bZQ3gntC', 'M', '09/20/1962', 55, 'wkicke@disqus.com'),
(16, '1qiskowf', 'Quent Iskow', 'DCDiR6YTf8', 'F', '12/18/1958', 59, 'qiskowf@opensource.org'),
(17, 'bkaasg', 'Brig Kaas', 'D1oonIJDX3G', 'M', '07/13/1996', 21, 'bkaasg@g.co'),
(18, 'gdiaperh', 'Germaine Diaper', 'YM05Ya6Xpo7', 'F', '05/26/1939', 78, 'gdiaperh@nsw.gov.au'),
(19, '1eallibertoni', 'Emlynn Alliberton', 's8XQ0d7iv', 'F', '07/29/1972', 45, 'eallibertoni@slashdot.org'),
(20, 'jgreggorj', 'Jocko Greggor', 'H1J1AbJW4BEB', 'M', '04/22/1981', 36, 'jgreggorj@whitehouse.gov');

SET IDENTITY_INSERT Users OFF;

--INSERT Reports
SET IDENTITY_INSERT Reports ON;

INSERT INTO Reports(Id,
                    CategoryId,
                    StatusId,
                    OpenDate,
                    CloseDate,
                    Description,
                    UserId,
                    EmployeeId)
VALUES
(1, 1, 4, '04/13/2017', NULL, 'Stuck Road on Str.14', 14, 5),
(2, 2, 3, '09/05/2015', '09/17/2015', '366 kg plastic for recycling.', 10, NULL),
(3, 1, 2, '01/03/2015', NULL, 'Stuck Road on Str.29', 4, 22),
(4, 11, 4, '12/06/2015', NULL, 'Burned facade on Str.183', 7, NULL),
(5, 4, 4, '11/17/2015', NULL, 'Fallen streetlight columns on Str.40', 3, NULL),
(6, 18, 1, '09/07/2015', NULL, 'Fallen Tree on the road on Str.26', 14, 30),
(7, 2, 2, '09/07/2017', NULL, 'High grass in Park Riversqaure', 10, 8),
(8, 18, 3, '04/23/2016', '05/01/2016', 'Fallen Tree on the road on Str.26', 11, NULL),
(9, 10, 4, '12/17/2014', NULL, 'Stuck Road on Str.65', 1, 15),
(10, 2, 4, '08/23/2015', NULL, '399 kg plastic for recycling.', 12, 17),
(11, 4, 3, '07/03/2017', '07/06/2017', 'Fallen streetlight columns on Str.41', 19, 14),
(12, 10, 3, '07/20/2016', '08/13/2016', 'Burned facade on Str.793', 7, 7),
(13, 1, 2, '01/26/2016', NULL, '246 kg plastic for recycling.', 16, 20),
(14, 12, 1, '06/09/2016', NULL, 'Aggressive monkey corner of Str.36 and Str.92', 20, NULL),
(15, 1, 4, '06/20/2015', NULL, 'Stuck Road on Str.133', 17, NULL),
(16, 6, 1, '10/09/2015', NULL, 'Stuck Road on Str.66', 18, 24),
(17, 11, 4, '08/26/2015', NULL, 'Burned facade on Str.560', 14, NULL),
(18, 6, 4, '10/24/2014', NULL, '86 kg plastic for recycling.', 10, 24),
(19, 11, 4, '01/14/2016', NULL, '39 kg plastic for recycling.', 6, 13),
(20, 16, 1, '07/02/2016', NULL, 'Gigantic crater ?n Str.48', 3, NULL),
(21, 2, 4, '03/31/2015', NULL, 'High grass in Park Riversqaure', 14, 17),
(22, 14, 1, '05/15/2016', NULL, 'Falling bricks on Str.17', 14, NULL),
(23, 2, 3, '07/24/2017', '07/27/2017', 'Stuck Road on Str.8', 16, 18),
(24, 1, 3, '05/23/2015', '05/19/2016', 'Stuck Road on Str.123', 13, 16),
(25, 17, 1, '01/11/2016', NULL, '162 kg plastic for recycling.', 19, 30),
(26, 10, 2, '11/10/2016', '11/20/2016', 'Parked car on green area on the sidewalk of Str.74', 20, 15),
(27, 9, 2, '12/17/2014', NULL, 'Art exhibition on July 24', 8, NULL),
(28, 2, 4, '07/12/2017', NULL, 'Stuck Road on Str.13', 2, 18),
(29, 14, 3, '09/25/2015', '10/12/2016', 'Falling bricks on Str.38', 12, 13),
(30, 3, 4, '08/02/2016', NULL, 'Extreme increase in nitrogen dioxide at Litchfield', 4, NULL),
(31, 4, 4, '09/12/2017', NULL, 'Fallen streetlight columns on Str.14', 1, 1),
(32, 6, 3, '06/08/2015', '06/13/2015', 'Sky Run competition on September 8', 19, 12),
(33, 16, 2, '11/17/2015', NULL, 'Gigantic crater ?n Str.19', 1, NULL),
(34, 2, 4, '07/10/2017', NULL, 'Glass Bottles for recycling on Str.105', 5, NULL),
(35, 2, 1, '02/06/2017', NULL, 'Glass Bottles for recycling on Str.28', 5, NULL),
(36, 4, 2, '01/01/2016', NULL, 'Fallen streetlight columns on Str.15', 18, NULL),
(37, 5, 1, '08/28/2017', NULL, 'Glass Bottles for recycling on Str.150', 13, 17),
(38, 7, 2, '02/27/2016', NULL, 'Lonely child on corner of Str.3 and Str.30', 16, NULL),
(39, 9, 1, '02/11/2016', NULL, 'Glass Bottles for recycling on Str.116', 10, NULL),
(40, 7, 1, '11/05/2015', NULL, 'Lonely child on corner of Str.1 and Str.19', 7, 25);

SET IDENTITY_INSERT Reports OFF;