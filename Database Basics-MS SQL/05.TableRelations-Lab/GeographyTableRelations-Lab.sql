USE Demo
GO

CREATE TABLE Countries(
CountryID INT NOT NULL IDENTITY,
Name NVARCHAR(50),
CONSTRAINT PK_Countries
PRIMARY KEY (CountryID)
)

CREATE TABLE Towns(
TownID INT NOT NULL IDENTITY,
Name NVARCHAR(5) NOT NULL,
CountryID INT NOT NULL,

CONSTRAINT PK_Towns PRIMARY KEY (TownID),

CONSTRAINT FK_Towns_Countries FOREIGN KEY (CountryID) REFERENCES Countries(CountryID)
)


INSERT INTO Countries
VALUES
('Bulgaria'),
('Germany'),
('Russia')

DROP TABLE Towns

INSERT INTO Towns
VALUES
('Sliven', 1),
('Plovdiv', 1),
('Berlin', 2),
('Sofia', 1),
('Moscow', 3),
('Munhen', 2)


SELECT *
FROM Countries AS c
JOIN Towns AS t
ON t.CountryID = c.Name

CREATE TABLE Mountains(
MountainID INT NOT NULL IDENTITY,
[Name] NVARCHAR(50) NOT NULL

CONSTRAINT PK_Mountains
PRIMARY KEY (MountainID)
)

CREATE TABLE Peaks(
PeakID INT NOT NULL,
[Name] NVARCHAR(50) NOT NULL,
MountainID INT NOT NULL,

CONSTRAINT PK_Peaks PRIMARY KEY (PeakID),

CONSTRAINT FK_Peaks_Mountains
FOREIGN KEY (MountainID)
REFERENCES Mountains(MountainID)
)

--Association tables/Table Mapping
CREATE TABLE Employees(
EmployeeID INT NOT NULL,
Name NVARCHAR(50) NOT NULL,

CONSTRAINT PK_Employees
PRIMARY KEY (EmployeeID)
)

CREATE TABLE Projects(
ProjectID INT NOT NULL,
Name NVARCHAR(32) NOT NULL,

CONSTRAINT PK_Projects
PRIMARY KEY (ProjectID)
)

CREATE TABLE EmployeesProjects(
EmployeeID INT NOT NULL,
ProjectID INT NOT NULL

CONSTRAINT PK_EmployeesProjects
PRIMARY KEY(EmployeeID, ProjectID)

CONSTRAINT FK_EmployeesProjects_Employees
FOREIGN KEY (EmployeeID)
REFERENCES Employees(EmployeeID),


CONSTRAINT FK_EmployeesProjects_Projects
FOREIGN KEY (ProjectID)
REFERENCES Projects(ProjectID)
)

INSERT INTO Employees
VALUES
(1, 'Ivan'),
(2, 'Pesho'),
(3, 'Gosho')


INSERT INTO Projects
VALUES
(1, 'MS SQL Server'),
(2, 'Java Project'),
(3, 'Swift Project')

SELECT * FROM Employees
SELECT * FROM Projects


INSERT INTO  EmployeesProjects
VALUES
(1,2),--Ivan works on Java Project
(1,3),--Ivan works on Swift Project
(2,2)--Pesho also works on Java Project

SELECT * FROM EmployeesProjects


CREATE TABLE DRivers(
DriverID INT PRIMARY KEY NOT NULL,
Name NVARCHAR(50) NOT NULL
)

CREATE TABLE Cars(
CarID INT PRIMARY KEY NOT NULL,
DriverID INT UNIQUE NOT NULL,

CONSTRAINT FK_Cars_Drivers
FOREIGN KEY(DriverID)
REFERENCES Drivers(DriverID)
)


--Joins

USE Geography

SELECT * FROM Mountains
SELECT * FROM Peaks

SELECT m.MountainRange, p.PeakName, p.Elevation
FROM Mountains AS m
JOIN Peaks AS p
ON p.MountainId = m.Id
WHERE MountainId=17
ORDER BY Elevation DESC


--Cascades
--Delete
CREATE TABLE Drivers(

DriverID INT PRIMARY KEY,

DriverName VARCHAR(50)

)

CREATE TABLE Cars(

CarID INT PRIMARY KEY,

DriverID INT,

CONSTRAINT FK_Car_Driver FOREIGN KEY(DriverID)

REFERENCES Drivers(DriverID) ON DELETE CASCADE
)

INSERT INTO Drivers
VALUES
(1, 'Gosho'),
(2, 'Pesho')

INSERT INTO Cars
VALUES
(1, 1),
(2, 2)

--Update
CREATE TABLE Products(

BarcodeId INT PRIMARY KEY,

Name VARCHAR(50)

)

CREATE TABLE Stock(

Id INT PRIMARY KEY,

Barcode INT,

CONSTRAINT FK_Stock_Products FOREIGN KEY(BarcodeId)

REFERENCES Products(BarcodeId) ON UPDATE CASCADE
)