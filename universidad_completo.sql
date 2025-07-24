
-- CREACIÓN DE BASE DE DATOS
CREATE DATABASE UNIVERSIDAD;
GO
USE UNIVERSIDAD;
GO

-- Tabla: Estudiante
CREATE TABLE Estudiante (
    EstudianteID INT PRIMARY KEY IDENTITY,
    Nombre NVARCHAR(100) NOT NULL,
    Apellido NVARCHAR(100) NOT NULL,
    FechaNacimiento DATE,
    Correo NVARCHAR(150) UNIQUE
);
GO

-- Tabla: Profesor
CREATE TABLE Profesor (
    ProfesorID INT PRIMARY KEY IDENTITY,
    Nombre NVARCHAR(100) NOT NULL,
    Apellido NVARCHAR(100) NOT NULL,
    Especialidad NVARCHAR(100),
    Correo NVARCHAR(150) UNIQUE
);
GO

-- Tabla: Materia
CREATE TABLE Materia (
    MateriaID INT PRIMARY KEY IDENTITY,
    Nombre NVARCHAR(100) NOT NULL,
    Codigo NVARCHAR(20) UNIQUE NOT NULL,
    Creditos INT NOT NULL
);
GO

-- Tabla: Curso
CREATE TABLE Curso (
    CursoID INT PRIMARY KEY IDENTITY,
    MateriaID INT NOT NULL,
    ProfesorID INT NOT NULL,
    Anio INT NOT NULL,
    Semestre TINYINT NOT NULL CHECK (Semestre IN (1, 2)),
    FOREIGN KEY (MateriaID) REFERENCES Materia(MateriaID),
    FOREIGN KEY (ProfesorID) REFERENCES Profesor(ProfesorID)
);
GO

-- Tabla: Matricula
CREATE TABLE Matricula (
    MatriculaID INT PRIMARY KEY IDENTITY,
    EstudianteID INT NOT NULL,
    CursoID INT NOT NULL,
    FechaMatricula DATE NOT NULL DEFAULT GETDATE(),
    NotaFinal DECIMAL(5,2) NULL,
    RegistradoPorProfesorID INT NULL,
    FOREIGN KEY (EstudianteID) REFERENCES Estudiante(EstudianteID),
    FOREIGN KEY (CursoID) REFERENCES Curso(CursoID),
    FOREIGN KEY (RegistradoPorProfesorID) REFERENCES Profesor(ProfesorID),
    CONSTRAINT UQ_Matricula UNIQUE (EstudianteID, CursoID)
);
GO

-- Procedimientos para Estudiante
CREATE PROCEDURE pa_Estudiante_Insertar
    @Nombre NVARCHAR(100),
    @Apellido NVARCHAR(100),
    @FechaNacimiento DATE,
    @Correo NVARCHAR(150)
AS
BEGIN
    INSERT INTO Estudiante (Nombre, Apellido, FechaNacimiento, Correo)
    VALUES (@Nombre, @Apellido, @FechaNacimiento, @Correo);
END;
GO

CREATE PROCEDURE pa_Estudiante_Actualizar
    @EstudianteID INT,
    @Nombre NVARCHAR(100),
    @Apellido NVARCHAR(100),
    @FechaNacimiento DATE,
    @Correo NVARCHAR(150)
AS
BEGIN
    UPDATE Estudiante
    SET Nombre = @Nombre,
        Apellido = @Apellido,
        FechaNacimiento = @FechaNacimiento,
        Correo = @Correo
    WHERE EstudianteID = @EstudianteID;
END;
GO

CREATE PROCEDURE pa_Estudiante_Eliminar
    @EstudianteID INT
AS
BEGIN
    DELETE FROM Matricula WHERE EstudianteID = @EstudianteID;
    DELETE FROM Estudiante WHERE EstudianteID = @EstudianteID;
END;
GO

CREATE PROCEDURE pa_Estudiante_ObtenerTodos 
AS 
BEGIN 
	SELECT * FROM Estudiante; 
END; 
GO

CREATE PROCEDURE pa_Estudiante_ObtenerPorID 
	@EstudianteID INT 
AS 
BEGIN 
	SELECT * FROM Estudiante WHERE EstudianteID = @EstudianteID; 
END; 
GO

-- Procedimientos para Profesor
CREATE PROCEDURE pa_Profesor_Insertar 
	@Nombre NVARCHAR(100), 
	@Apellido NVARCHAR(100), 
	@Especialidad NVARCHAR(100), 
	@Correo NVARCHAR(150)
AS 
BEGIN 
	INSERT INTO Profesor (Nombre, Apellido, Especialidad, Correo) VALUES (@Nombre, @Apellido, @Especialidad, @Correo); 
END; 
GO

CREATE PROCEDURE pa_Profesor_Actualizar 
	@ProfesorID INT, 
	@Nombre NVARCHAR(100), 
	@Apellido NVARCHAR(100), 
	@Especialidad NVARCHAR(100), 
	@Correo NVARCHAR(150)
AS 
BEGIN 
	UPDATE Profesor 
	SET Nombre = @Nombre, Apellido = @Apellido, Especialidad = @Especialidad, Correo = @Correo 
	WHERE ProfesorID = @ProfesorID; 
END; 
GO

CREATE PROCEDURE pa_Profesor_Eliminar 
	@ProfesorID INT
AS 
BEGIN 
	DELETE FROM Matricula WHERE RegistradoPorProfesorID = @ProfesorID; 
	DELETE FROM Curso WHERE ProfesorID = @ProfesorID; 
	DELETE FROM Profesor WHERE ProfesorID = @ProfesorID; 
END; 
GO

CREATE PROCEDURE pa_Profesor_ObtenerTodos 
AS 
BEGIN 
	SELECT * FROM Profesor; 
END; 
GO

CREATE PROCEDURE pa_Profesor_ObtenerPorID 
	@ProfesorID INT 
AS 
BEGIN 
	SELECT * FROM Profesor WHERE ProfesorID = @ProfesorID; 
END; 
GO

-- Procedimientos para Materia
CREATE PROCEDURE pa_Materia_Insertar 
	@Nombre NVARCHAR(100), 
	@Codigo NVARCHAR(20), 
	@Creditos INT
AS 
BEGIN 
	INSERT INTO Materia (Nombre, Codigo, Creditos) VALUES (@Nombre, @Codigo, @Creditos); 
END; 
GO

CREATE PROCEDURE pa_Materia_Actualizar 
	@MateriaID INT, 
	@Nombre NVARCHAR(100), 
	@Codigo NVARCHAR(20), 
	@Creditos INT
AS 
BEGIN 
	UPDATE Materia SET Nombre = @Nombre, Codigo = @Codigo, Creditos = @Creditos WHERE MateriaID = @MateriaID; 
END; 
GO

CREATE PROCEDURE pa_Materia_Eliminar
	@MateriaID INT
AS 
BEGIN 
	DELETE FROM Curso WHERE MateriaID = @MateriaID; 
	DELETE FROM Materia WHERE MateriaID = @MateriaID; 
END; 
GO

CREATE PROCEDURE pa_Materia_ObtenerTodos 
AS 
BEGIN 
	SELECT * FROM Materia; 
END;
GO

CREATE PROCEDURE pa_Materia_ObtenerPorID 
	@MateriaID INT 
AS 
BEGIN 
	SELECT * FROM Materia WHERE MateriaID = @MateriaID;
END; 
GO


-- Procedimientos para Curso
CREATE PROCEDURE pa_Curso_Insertar 
	@MateriaID INT, 
	@ProfesorID INT, 
	@Anio INT, 
	@Semestre TINYINT
AS 
BEGIN 
	INSERT INTO Curso (MateriaID, ProfesorID, Anio, Semestre) VALUES (@MateriaID, @ProfesorID, @Anio, @Semestre); 
END; 
GO


CREATE PROCEDURE pa_Curso_Actualizar 
	@CursoID INT, 
	@MateriaID INT, 
	@ProfesorID INT, 
	@Anio INT, 
	@Semestre TINYINT
AS 
BEGIN 
	UPDATE Curso SET MateriaID = @MateriaID, ProfesorID = @ProfesorID, Anio = @Anio, Semestre = @Semestre WHERE CursoID = @CursoID; 
END; 
GO


CREATE PROCEDURE pa_Curso_Eliminar 
	@CursoID INT
AS 
BEGIN 
	DELETE FROM Matricula WHERE CursoID = @CursoID; 
	DELETE FROM Curso WHERE CursoID = @CursoID; 
END; 
GO


CREATE PROCEDURE pa_Curso_ObtenerTodos 
AS 
BEGIN 
	SELECT * FROM Curso; 
END; 
GO

CREATE PROCEDURE pa_Curso_ObtenerPorID 
	@CursoID INT 
AS 
BEGIN 
	SELECT * FROM Curso WHERE CursoID = @CursoID; 
END; 
GO


-- Procedimientos para Matricula
CREATE PROCEDURE pa_Matricula_Insertar 
	@EstudianteID INT, 
	@CursoID INT, 
	@RegistradoPorProfesorID INT = NULL
AS 
BEGIN 
	INSERT INTO Matricula (EstudianteID, CursoID, RegistradoPorProfesorID) VALUES (@EstudianteID, @CursoID, @RegistradoPorProfesorID); 
END; 
GO


CREATE PROCEDURE pa_Matricula_ActualizarNota 
	@MatriculaID INT, 
	@NotaFinal DECIMAL(5,2), 
	@RegistradoPorProfesorID INT
AS 
BEGIN 
	UPDATE Matricula SET NotaFinal = @NotaFinal, RegistradoPorProfesorID = @RegistradoPorProfesorID WHERE MatriculaID = @MatriculaID; 
END; 
GO


CREATE PROCEDURE pa_Matricula_Eliminar 
	@MatriculaID INT 
AS 
BEGIN 
	DELETE FROM Matricula WHERE MatriculaID = @MatriculaID; 
END; 
GO


CREATE PROCEDURE pa_Matricula_ObtenerPorEstudiante 
	@EstudianteID INT 
AS 
BEGIN 
	SELECT * FROM Matricula WHERE EstudianteID = @EstudianteID; 
END; 
GO

CREATE PROCEDURE pa_Matricula_ObtenerPorCurso 
	@CursoID INT 
AS 
	BEGIN SELECT * FROM Matricula WHERE CursoID = @CursoID; 
END; 
GO


ALTER PROCEDURE pa_Estudiante_Insertar
    @Nombre NVARCHAR(100),
    @Apellido NVARCHAR(100),
    @FechaNacimiento DATE,
    @Correo NVARCHAR(150),
	@IdEstudiante INT OUTPUT,
	@CodError VARCHAR(5) OUTPUT,
	@Mensaje NVARCHAR(1000) OUTPUT
AS
BEGIN
	SET NOCOUNT ON;
	BEGIN TRY
    		INSERT INTO Estudiante (Nombre, Apellido, FechaNacimiento, Correo)
    		VALUES (@Nombre, @Apellido, @FechaNacimiento, @Correo);
		SET @IdEstudiante = SCOPE_IDENTITY();
		SET @CodError = '00000';
		SET @Mensaje = 'Estudiante insertado correctamente';
	END TRY
	BEGIN CATCH
		SET @IdEstudiante = 0;
		SET @CodError = ERROR_NUMBER();
		SET @Mensaje = ERROR_MESSAGE();
	END CATCH
END;
GO

ALTER PROCEDURE pa_Estudiante_Actualizar
    @EstudianteID INT,
    @Nombre NVARCHAR(100),
    @Apellido NVARCHAR(100),
    @FechaNacimiento DATE,
    @Correo NVARCHAR(150),
	@IdEstudiante INT OUTPUT,
	@CodError VARCHAR(5) OUTPUT,
	@Mensaje NVARCHAR(1000) OUTPUT
AS
BEGIN
	SET NOCOUNT ON;
	BEGIN TRY
		UPDATE Estudiante
		SET Nombre = @Nombre,
			Apellido = @Apellido,
			FechaNacimiento = @FechaNacimiento,
			Correo = @Correo
		WHERE EstudianteID = @EstudianteID;
		SET @IdEstudiante = SCOPE_IDENTITY();
		SET @CodError = '00000';
		SET @Mensaje = 'Estudiante actualizado correctamente';
	END TRY
	BEGIN CATCH
		SET @IdEstudiante = 0;
		SET @CodError = ERROR_NUMBER();
		SET @Mensaje = ERROR_MESSAGE();
	END CATCH
END;
GO


ALTER PROCEDURE pa_Estudiante_Eliminar
    @EstudianteID INT,
	@IdEstudiante INT OUTPUT,
	@CodError VARCHAR(5) OUTPUT,
	@Mensaje NVARCHAR(1000) OUTPUT
AS
BEGIN
	SET NOCOUNT ON;
	BEGIN TRY
		DELETE FROM Matricula WHERE EstudianteID = @EstudianteID;
		DELETE FROM Estudiante WHERE EstudianteID = @EstudianteID;
		SET @IdEstudiante = SCOPE_IDENTITY();
		SET @CodError = '00000';
		SET @Mensaje = 'Estudiante eliminado correctamente';
	END TRY
	BEGIN CATCH
		SET @IdEstudiante = 0;
		SET @CodError = ERROR_NUMBER();
		SET @Mensaje = ERROR_MESSAGE();
	END CATCH
END;
GO


ALTER PROCEDURE pa_Materia_Insertar 
	@Nombre NVARCHAR(100), 
	@Codigo NVARCHAR(20), 
	@Creditos INT,
	@IdMateria INT OUTPUT,
	@CodError VARCHAR(5) OUTPUT,
	@Mensaje NVARCHAR(1000) OUTPUT
AS 
BEGIN 
	SET NOCOUNT ON;
	BEGIN TRY
	INSERT INTO Materia (Nombre, Codigo, Creditos) VALUES (@Nombre, @Codigo, @Creditos); 
	SET @IdMateria = SCOPE_IDENTITY();
		SET @CodError = '00000';
		SET @Mensaje = 'Materia insertada correctamente';
	END TRY
	BEGIN CATCH
		SET @IdMateria = 0;
		SET @CodError = ERROR_NUMBER();
		SET @Mensaje = ERROR_MESSAGE();
	END CATCH
END; 
GO

ALTER PROCEDURE pa_Materia_Actualizar 
	@MateriaID INT, 
	@Nombre NVARCHAR(100), 
	@Codigo NVARCHAR(20), 
	@Creditos INT,
	@IdMateria INT OUTPUT,
	@CodError VARCHAR(5) OUTPUT,
	@Mensaje NVARCHAR(1000) OUTPUT
AS 
BEGIN 
	SET NOCOUNT ON;
	BEGIN TRY
	UPDATE Materia SET Nombre = @Nombre, Codigo = @Codigo, Creditos = @Creditos WHERE MateriaID = @MateriaID; 
	SET @IdMateria = SCOPE_IDENTITY();
		SET @CodError = '00000';
		SET @Mensaje = 'Materia actualizada correctamente';
	END TRY
	BEGIN CATCH
		SET @IdMateria = 0;
		SET @CodError = ERROR_NUMBER();
		SET @Mensaje = ERROR_MESSAGE();
	END CATCH
END; 
GO

ALTER PROCEDURE pa_Materia_Eliminar
	@MateriaID INT,
	@IdMateria INT OUTPUT,
	@CodError VARCHAR(5) OUTPUT,
	@Mensaje NVARCHAR(1000) OUTPUT
AS 
	SET NOCOUNT ON;
	BEGIN TRY
	DELETE FROM Curso WHERE MateriaID = @MateriaID; 
	DELETE FROM Materia WHERE MateriaID = @MateriaID; 
	SET @IdMateria = SCOPE_IDENTITY();
		SET @CodError = '00000';
		SET @Mensaje = 'Materia eliminada correctamente';
	END TRY
	BEGIN CATCH
		SET @IdMateria = 0;
		SET @CodError = ERROR_NUMBER();
		SET @Mensaje = ERROR_MESSAGE();
	END CATCH
END 
GO