
CREATE DATABASE ControlEscolar;
GO
USE ControlEscolar;
GO
CREATE TABLE Alumno
(
IdAlumno INT PRIMARY KEY IDENTITY(1,1),
NombreAlumno VARCHAR(50),
ApellidoPaterno VARCHAR(50),
ApellidoMaterno VARCHAR(50)
)

CREATE TABLE Materia
(
IdMateria INT PRIMARY KEY IDENTITY(1,1),
NombreMateria VARCHAR(50),
Costo DECIMAL
)

INSERT INTO Materia (NombreMateria,Costo) VALUES ('Fisica',20)
INSERT INTO Materia (NombreMateria,Costo) VALUES ('Algebra',30)
INSERT INTO Materia (NombreMateria,Costo) VALUES ('Civica',10)
INSERT INTO Materia (NombreMateria,Costo) VALUES ('Geografia',15)
INSERT INTO Materia (NombreMateria,Costo) VALUES ('Historia',25)

INSERT INTO Alumno (NombreAlumno,ApellidoPaterno,ApellidoMaterno) VALUES ('Aldair','Santiago','Garcia')
INSERT INTO Alumno (NombreAlumno,ApellidoPaterno,ApellidoMaterno) VALUES ('Melisa','Chavez','Rojas')
INSERT INTO Alumno (NombreAlumno,ApellidoPaterno,ApellidoMaterno) VALUES ('Isaac','Espinoza','Espinoza')
INSERT INTO Alumno (NombreAlumno,ApellidoPaterno,ApellidoMaterno) VALUES ('Jesus','Torres','Torres')
INSERT INTO Alumno (NombreAlumno,ApellidoPaterno,ApellidoMaterno) VALUES ('Daniel','Lopez','Tejeda')
GO

SELECT IdAlumno,NombreAlumno,ApellidoPaterno,ApellidoMaterno FROM Alumno

SELECT IdMateria,NombreMateria,Costo FROM Materia

GO

CREATE PROCEDURE AlumnoGetAll
AS
	SELECT IdAlumno,
			NombreAlumno,
			ApellidoPaterno,
			ApellidoMaterno
	FROM Alumno

GO

CREATE PROCEDURE AlumnoAdd --'Ilda','Garcia','Jimenez'
@NombreAlumno VARCHAR(50),
@ApellidoPaterno VARCHAR(50),
@ApellidoMaterno VARCHAR(50)
AS
	INSERT INTO 
	Alumno(
			NombreAlumno,
			ApellidoPaterno,
			ApellidoMaterno
			)
	VALUES
			(
			@NombreAlumno,
			@ApellidoPaterno,
			@ApellidoMaterno
			)
GO

CREATE PROCEDURE MateriaGetAll
AS
	SELECT 
		IdMateria,
		NombreMateria,
		Costo 
	FROM Materia

GO



CREATE PROCEDURE AlumnoGetById --3
@IdAlumno INT
AS
	SELECT IdAlumno,
			NombreAlumno,
			ApellidoPaterno,
			ApellidoMaterno
	FROM
		Alumno
	WHERE
		IdAlumno = @IdAlumno
GO
AlumnoGetAll
GO
CREATE PROCEDURE AlumnoUpdate --7,'Jessica','Tejeda','Lopez'
@IdAlumno INT,	
@NombreAlumno VARCHAR(50),
@ApellidoPaterno VARCHAR(50),
@ApellidoMaterno VARCHAR(50)
AS
	UPDATE
		Alumno
	SET 
		NombreAlumno = @NombreAlumno,
		ApellidoPaterno = @ApellidoPaterno,
		ApellidoMaterno = @ApellidoMaterno
	WHERE
		IdAlumno = @IdAlumno
GO

CREATE PROCEDURE AlumnoDelete --1
@IdAlumno INT
AS
	DELETE Alumno
	WHERE IdAlumno = @IdAlumno


GO

CREATE PROCEDURE MateriaAdd --'POO',50
@NombreMateria VARCHAR(50),
@Costo DECIMAL
AS
	INSERT INTO Materia
		(NombreMateria,Costo)
	VALUES
		(@NombreMateria,@Costo)

GO

CREATE PROCEDURE MateriaGetById-- 5
@IdMateria INT
AS
	SELECT [IdMateria]
		  ,[NombreMateria]
          ,[Costo]
	FROM [Materia]
	WHERE
		IdMateria = @IdMateria

GO

CREATE PROCEDURE MateriaUpdate --5,'Historia de Mexico',27
@IdMateria INT,
@NombreMateria VARCHAR(50),
@Costo DECIMAL
AS
	UPDATE
		Materia	
	SET
		NombreMateria = @NombreMateria,
		Costo = @Costo
	WHERE
		IdMateria = @IdMateria

GO

CREATE PROCEDURE MateriaDelete --3
@IdMateria INT
AS
	DELETE Materia	
	WHERE IdMateria = @IdMateria

GO
CREATE TABLE AlumnoMateria
(
IdAlumnoMateria INT PRIMARY KEY IDENTITY(1,1),
IdAlumno INT FOREIGN KEY REFERENCES Alumno(IdAlumno),
IdMateria INT FOREIGN KEY REFERENCES Materia(IdMateria)
)

GO

CREATE PROCEDURE MateriasGetAsignadas-- 2
@IdAlumno INT
AS
	SELECT
		AlumnoMateria.IdAlumnoMateria,
		AlumnoMateria.IdMateria,
		Materia.NombreMateria,
		Materia.Costo
	FROM
		AlumnoMateria
	INNER JOIN
		Materia ON AlumnoMateria.IdMateria = Materia.IdMateria
	WHERE
		IdAlumno = @IdAlumno

GO

CREATE PROCEDURE AlumnoMateriasAdd --2,3
@IdAlumno INT,
@IdMateria INT
AS
	INSERT INTO
		AlumnoMateria(
		IdAlumno,
		IdMateria
		)
	VALUES
	(
		@IdAlumno,
		@IdMateria
	)
GO


CREATE PROCEDURE MateriasGetNoAsignadas-- 1
@IdAlumno INT
AS
	SELECT Materia.IdMateria
			,Materia.NombreMateria
			,Materia.Costo
	FROM Materia
	WHERE Materia.IdMateria NOT IN
		(SELECT AlumnoMateria.IdMateria
		 FROM AlumnoMateria
		 WHERE AlumnoMateria.IdAlumno = @IdAlumno)

GO

CREATE PROCEDURE AlumnoMateriaDelete
@IdAlumnoMateria INT
AS
	DELETE FROM
		AlumnoMateria
	WHERE IdAlumnoMateria = @IdAlumnoMateria
GO
--MateriasGetAsignadas 2
--go
CREATE PROCEDURE SumaCostoMaterias
@IdAlumno INT
AS
	SELECT SUM(Materia.Costo) Total	FROM AlumnoMateria
	INNER JOIN
		Materia ON AlumnoMateria.IdMateria = Materia.IdMateria
	WHERE
		IdAlumno = @IdAlumno
GO
CREATE PROCEDURE AlumnoLogin --'Pedro','Santiago'
@NombreAlumno VARCHAR(50),
@ApellidoPaterno VARCHAR(50)
AS
	SELECT IdAlumno,
			NombreAlumno,
			ApellidoPaterno,
			ApellidoMaterno
	FROM
		Alumno
	WHERE
		NombreAlumno = @NombreAlumno AND ApellidoPaterno = @ApellidoPaterno
GO

--MateriasGetAsignadas 1
--MateriasGetAsignadas 2
--	AlumnoGetAll
--MateriaGetAll
--AlumnoMateriasAdd 2,3
--AlumnoMateriasAdd 2,4

-- MateriasGetNoAsignadas 2