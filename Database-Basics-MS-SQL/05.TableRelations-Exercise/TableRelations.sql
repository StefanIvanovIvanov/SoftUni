--Problem 1.One-To-One Relationship

CREATE TABLE Persons (
	PersonID INT IDENTITY,
	FirstName VARCHAR(50) NOT NULL,
	Salary DECIMAL(15, 2),
	PassportID INT
)

CREATE TABLE Passports (
	PassportID INT IDENTITY(101, 1),
	PassportNumber VARCHAR(30) NOT NULL
)

ALTER TABLE Persons
ADD PRIMARY KEY (PersonID)

ALTER TABLE Passports
ADD PRIMARY KEY (PassportID)

ALTER TABLE Persons
ADD FOREIGN KEY (PassportID) REFERENCES Passports(PassportID)

--Problem 2.One-To-Many Relationship

CREATE TABLE Manufacturers (
	ManufacturerID INT PRIMARY KEY IDENTITY,
	Name VARCHAR(30) NOT NULL,
	EstablishedOn DATE
)

CREATE TABLE Models (
	ModelID INT PRIMARY KEY IDENTITY(101, 1),
	Name VARCHAR(30) NOT NULL,
	ManufacturerID INT FOREIGN KEY REFERENCES Manufacturers(ManufacturerID)
)

--Problem 3.Many-To-Many Relationship

CREATE TABLE Students (
	StudentID INT PRIMARY KEY IDENTITY,
	Name VARCHAR(50) NOT NULL
)

CREATE TABLE Exams (
	ExamID INT PRIMARY KEY IDENTITY(101, 1),
	Name VARCHAR(50) NOT NULL
)

CREATE TABLE StudentsExams (
	StudentID INT FOREIGN KEY REFERENCES Students(StudentID),
	ExamID INT FOREIGN KEY REFERENCES Exams(ExamID),
	CONSTRAINT PK_Students_Exams PRIMARY KEY(StudentID, ExamID)
)

--Problem 4.Self-Referencing

CREATE TABLE Teachers (
	TeacherID INT PRIMARY KEY IDENTITY(101, 1),
	Name VARCHAR(50) NOT NULL,
	ManagerID INT FOREIGN KEY REFERENCES Teachers(TeacherID)
)

UPDATE Teachers
SET ManagerID = 106
WHERE TeacherID = 102 OR TeacherID = 103

UPDATE Teachers
SET ManagerID = 105
WHERE TeacherID = 104


--Problem 5.Online Store Database

CREATE TABLE Cities(
	CityID INT PRIMARY KEY NOT NULL,
	Name VARCHAR(50) NOT NULL
)

CREATE TABLE Customers(
	CustomerID INT PRIMARY KEY NOT NULL,
	Name VARCHAR(50) NOT NULL,
	Birthday DATE,
	CityID INT FOREIGN KEY REFERENCES Cities(CityID) NOT NULL
)

CREATE TABLE Orders(
	OrderID INT PRIMARY KEY NOT NULL,
	CustomerID INT FOREIGN KEY REFERENCES Customers(CustomerID) NOT NULL
)

CREATE TABLE ItemTypes(
	ItemTypeID INT PRIMARY KEY NOT NULL,
	Name VARCHAR(50) NOT NULL
)

CREATE TABLE Items (
	ItemID INT PRIMARY KEY NOT NULL,
	Name VARCHAR(50) NOT NULL,
	ItemTypeID INT FOREIGN KEY REFERENCES ItemTypes(ItemTypeID) NOT NULL
)

CREATE TABLE OrderItems (
	OrderID INT FOREIGN KEY REFERENCES Orders(OrderID) NOT NULL,
	ItemID INT FOREIGN KEY REFERENCES Items(ItemID) NOT NULL
	CONSTRAINT PK_Order_Items PRIMARY KEY (OrderID, ItemID)
)

--Always start with the table that is not dependable of other tables

CREATE TABLE Cities(
CityID INT NOT NULL,--add primary key
[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Customers(
CustomerID INT NOT NULL,--add primary key
[Name] VARCHAR(50) NOT NULL,--add check constraint
Birthday DATE NOT NULL,
CityID INT NOT NULL--add foreign key
)

--Problem 6.University Database

CREATE TABLE Majors (
	MajorID INT PRIMARY KEY NOT NULL,
	Name VARCHAR(50) NOT NULL
)

CREATE TABLE Students (
	StudentID INT PRIMARY KEY NOT NULL,
	StudentNumber VARCHAR(15) NOT NULL,
	StudentName VARCHAR(50) NOT NULL,
	MajorID INT FOREIGN KEY REFERENCES Majors(MajorID)
)

CREATE TABLE Payments (
	PaymentID INT PRIMARY KEY NOT NULL,
	PaymentDate DATETIME NOT NULL,
	PaymentAmount DECIMAL(6, 2) NOT NULL,
	StudentID INT FOREIGN KEY REFERENCES Students(StudentID)
)

CREATE TABLE Subjects (
	SubjectID INT PRIMARY KEY NOT NULL,
	SubjectName VARCHAR(35) NOT NULL
)

CREATE TABLE Agenda (
	StudentID INT FOREIGN KEY REFERENCES Students(StudentID),
	SubjectID INT FOREIGN KEY REFERENCES Subjects(SubjectID)
	CONSTRAINT PK_Agenda PRIMARY KEY (StudentID, SubjectID)
)