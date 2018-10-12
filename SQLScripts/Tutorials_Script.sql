/*
	Version 1.0
	basic scheme of the database for the backend
	Esquema básico de la base de datos para el backend
*/

CREATE database TutorialsDB
go
use TutorialsDB
go

-- Definimos las tablas basicas

CREATE TABLE Teachers(
	ID int identity(1,1) primary key NOT NULL,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	Email VARCHAR(120) NOT NULL,
	UserName VARCHAR(32) NOT NULL,
	Password VARCHAR(32) NOT NULL
)

CREATE TABLE Students(
	ID int identity(1,1) primary key NOT NULL,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	Email VARCHAR(120) NOT NULL,
	UserName VARCHAR(32) NOT NULL,
	Password VARCHAR(32) NOT NULL
)

CREATE TABLE Subjects(
	ID int identity(1,1) primary key NOT NULL,
	SubjectsName VARCHAR(255) NOT NULL
)

CREATE TABLE ClassRoom(
	ID int identity(1,1) primary key NOT NULL,
	ClassName VARCHAR(50) NOT NULL,
	TeachersID int NOT NULL,
	SubjectsID int NOT NULL,
	CONSTRAINT FK_Teachers_ClassRoom FOREIGN KEY (TeachersID) REFERENCES Teachers(ID),
	CONSTRAINT FK_Subjects_ClassRoom FOREIGN KEY (SubjectsID) REFERENCES Subjects(ID)
)

CREATE TABLE StudentsClassRoom(
	ID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	ClassRoomID INT NOT NULL,
	StudentsID INT NOT NULL,
	CONSTRAINT FK_ClassRoom_StudentsClassRoom FOREIGN KEY (ClassRoomID) REFERENCES ClassRoom(ID),
	CONSTRAINT FK_Students_StudentsClassRoom FOREIGN KEY (StudentsID) REFERENCES Students(ID)
)

-- Cargamos algunos datos para pruebas

INSERT INTO Teachers VALUES ('Roberto', 'Espejo', 'RobertoEspejo', 'robertoespejo@email.com', CONVERT(VARCHAR(32), HashBytes('MD5', '1234'), 2))
INSERT INTO Teachers VALUES ('Micaela', 'Barrios', 'MicaelaBarrios', 'micaelabarrios@email.com', CONVERT(VARCHAR(32), HashBytes('MD5', '1234'), 2))
INSERT INTO Teachers VALUES ('Milagros', 'Barrios', 'MilagrosBarrios', 'micaelabarrios@email.com', CONVERT(VARCHAR(32), HashBytes('MD5', '1234'), 2))
INSERT INTO Teachers VALUES ('Sabina', 'Scaparoni', 'SabinaScaparoni', 'sabinascaparoni@email.com', CONVERT(VARCHAR(32), HashBytes('MD5', '1234'), 2))
INSERT INTO Teachers VALUES ('Manuel', 'Ponce', 'ManuelPonce', 'manuelponce@email.com', CONVERT(VARCHAR(32), HashBytes('MD5', '1234'), 2))

INSERT INTO Students VALUES ('Juan', 'Perez', 'JuanPerez', 'juanperez@email.com', CONVERT(VARCHAR(32), HashBytes('MD5', 'abc'), 2))
INSERT INTO Students VALUES ('Jose', 'Rodriguez', 'JoseRodriguez', 'joserodriguez@email.com', CONVERT(VARCHAR(32), HashBytes('MD5', 'abc'), 2))
INSERT INTO Students VALUES ('Paula', 'Jerez', 'PaulaJerez', 'paulajerez@email.com', CONVERT(VARCHAR(32), HashBytes('MD5', 'abc'), 2))
INSERT INTO Students VALUES ('Carla', 'Perez', 'CarlaPerez', 'carlaperez@email.com', CONVERT(VARCHAR(32), HashBytes('MD5', 'abc'), 2))

INSERT INTO Subjects VALUES ('Matematicas'), ('Fisica'), ('Quimica'), ('Biologia'), ('Dibujo Tecnico'), ('Ingles'), ('Lengua')

INSERT INTO ClassRoom VALUES ('Tutoria Matematica', 1, 1)
INSERT INTO ClassRoom VALUES ('Tutoria Quimica', 4, 3)

INSERT INTO StudentsClassRoom VALUES (1, 1), (1,2), (1,3), (2,3), (2,4)

-- Mostramos los datos

/* 
	SELECT * FROM Teachers
   	SELECT * FROM Students
   	SELECT * FROM Subjects
	SELECT * FROM ClassRoom
	SELECT * FROM StudentsClassRoom
 */
