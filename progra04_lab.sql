USE UNIVERSIDAD;
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
END; 
GO
