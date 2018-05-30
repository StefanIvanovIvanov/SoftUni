USE DataTypes

--8 Create Table Users
CREATE TABLE Users (
	Id BIGINT UNIQUE IDENTITY,
	Username VARCHAR(30) UNIQUE NOT NULL,
	Password VARCHAR(26) NOT NULL,
	ProfilePicture VARBINARY(MAX) CHECK (DATALENGTH(ProfilePicture) <= 900 * 1024),
	LastLoginTime DATETIME,
	IsDeleted BIT
	CONSTRAINT PK_Users PRIMARY KEY(Id)
)

INSERT INTO Users VALUES
('Pesho', '12345', NULL, NULL, 0),
('Gosho', '12345', NULL, NULL, 1),
('Stamat', '12345', NULL, NULL, 0),
('Jivko', '12345', NULL, NULL, 0),
('Dancho', '12345', NULL, NULL, 1)

--9 Change Primary Key
ALTER TABLE Users
DROP CONSTRAINT PK_Users

ALTER TABLE Users
ADD CONSTRAINT PK_Users PRIMARY KEY(Id, Username)

--10 Add Check Constraint
ALTER TABLE Users
ADD CONSTRAINT PasswordLength CHECK (LEN(Password) >= 5)

--11 Set Default Value of a Field
ALTER TABLE Users
ADD DEFAULT GETDATE() FOR LastLoginTime

--12 Set Unique Field
ALTER TABLE Users
DROP CONSTRAINT PK_Users

ALTER TABLE Users
ADD CONSTRAINT PK_Id
PRIMARY KEY (Id)

ALTER TABLE Users
ADD CONSTRAINT uq_Username
UNIQUE(Username)

ALTER TABLE Users
ADD CONSTRAINT UsernameLength CHECK (LEN(Username) >= 3)