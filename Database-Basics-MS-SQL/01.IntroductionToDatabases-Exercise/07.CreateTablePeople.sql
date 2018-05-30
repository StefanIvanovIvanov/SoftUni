CREATE DATABASE DataTypes

USE DataTypes

--7 Create Table People
CREATE TABLE People(
Id BIGINT PRIMARY KEY IDENTITY NOT NULL,
[Name] NVARCHAR(200) NOT NULL,
Picture VARBINARY(MAX),
Height DECIMAL(3,2),
[Weight]  DECIMAL(4,2),
Gender CHAR NOT NULL,
Birthdate DATETIME NOT NULL,
Biography TEXT
)

INSERT INTO People([Name], Picture, Height, [Weight], Gender, Birthdate, Biography)
VALUES
('Pesho', NULL, 1.6, 70.00,'m', 12-05-1990, NULL),
('Ivan', NULL, 1.7, 70.00,'m', 12-05-1990, NULL),
('Gosho', NULL, 1.8, 70.00,'m', 12-05-1990, NULL),
('Ana', NULL, 1.5, 70.00,'f', 12-05-1990, NULL),
('Stamat', NULL, 1.7, 70.00,'m', 12-05-1990, NULL)