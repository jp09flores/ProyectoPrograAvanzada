USE [master]
GO

CREATE DATABASE ProyPrograAvan
GO

USE ProyPrograAvan
GO

CREATE TABLE Logs (
  ID_log BIGINT PRIMARY KEY IDENTITY,
  fecha_registro DATETIME,
  descripcion TEXT
);

CREATE TABLE Roles (
  ID_rol BIGINT PRIMARY KEY IDENTITY,
  nombre_rol VARCHAR(255)
);

CREATE TABLE Usuarios (
  id_usuario BIGINT PRIMARY KEY IDENTITY,
  nombre VARCHAR(255),
  correo_electronico VARCHAR(255) UNIQUE,
  contrasena VARCHAR(255),
  ID_rol BIGINT,
  estado bit,
  FOREIGN KEY (ID_rol) REFERENCES Roles(ID_rol)
);

CREATE TABLE Localidades (
  ID_localidad BIGINT PRIMARY KEY IDENTITY,
  nombre_localidad VARCHAR(255)
);

CREATE TABLE Habitaciones (
  ID_habitacion BIGINT PRIMARY KEY IDENTITY,
  tipo_habitacion VARCHAR(255),
  capacidad INT,
  tarifa DECIMAL(10, 2),
  disponibilidad BIT,
  ID_localidad BIGINT,
  img varchar(250)
  FOREIGN KEY (ID_localidad) REFERENCES Localidades(ID_localidad)
);

CREATE TABLE Reservas (
  ID_reserva BIGINT PRIMARY KEY IDENTITY,
  id_usuario BIGINT,
  ID_habitacion BIGINT,
  fecha_entrada DATETIME,
  fecha_salida DATETIME,
  servicios_adicionales VARCHAR(255),
  estado bit 
  FOREIGN KEY (id_usuario) REFERENCES Usuarios(id_usuario),
  FOREIGN KEY (ID_habitacion) REFERENCES Habitaciones(ID_habitacion)
);

CREATE TABLE Opiniones (
  ID_opinion BIGINT PRIMARY KEY IDENTITY,
  id_usuario BIGINT,
  ID_reserva BIGINT,
  opinion_texto TEXT,
  FOREIGN KEY (id_usuario) REFERENCES Usuarios(id_usuario),
  FOREIGN KEY (ID_reserva) REFERENCES Reservas(ID_reserva)
);


CREATE PROCEDURE [dbo].ConsultarLocalidad
AS
BEGIN
    SELECT ID_localidad,nombre_localidad
    FROM Localidades
    
END
-- Inserts para la tabla Logs
INSERT INTO Logs (fecha_registro, descripcion) VALUES ('2024-03-22 10:00:00', 'Usuario Juan inició sesión.');
INSERT INTO Logs (fecha_registro, descripcion) VALUES ('2024-03-22 11:30:00', 'Error: No se pudo completar la transacción.');

-- Inserts para la tabla Roles
INSERT INTO Roles (nombre_rol) VALUES ('Administrador');
INSERT INTO Roles (nombre_rol) VALUES ('Usuario');

-- Inserts para la tabla Usuarios
INSERT INTO Usuarios (nombre, correo_electronico, contrasena, ID_rol, estado) VALUES ('Ana Martínez', 'ana@example.com', 'clave123', 2, 1);
INSERT INTO Usuarios (nombre, correo_electronico, contrasena, ID_rol, estado) VALUES ('Carlos Rodríguez', 'carlos@example.com', 'seguridad456', 1, 1);
INSERT INTO Usuarios (nombre, correo_electronico, contrasena, ID_rol, estado) VALUES ('Sofía López', 'sofia@example.com', 'contraseña789', 2, 1);

-- Inserts para la tabla Localidades
INSERT INTO Localidades ( nombre_localidad) VALUES ( 'Guanacaste');
INSERT INTO Localidades ( nombre_localidad) VALUES ( 'Manuel Antonio');
INSERT INTO Localidades (nombre_localidad) VALUES ( 'Limon');

-- Inserts para la tabla Habitaciones
INSERT INTO Habitaciones (tipo_habitacion, capacidad, tarifa, disponibilidad, ID_localidad) VALUES ('Individual', 1, 50.00, 1, 1);
INSERT INTO Habitaciones (tipo_habitacion, capacidad, tarifa, disponibilidad, ID_localidad) VALUES ('Doble', 2, 80.00, 1, 2);

-- Inserts para la tabla Reservas
INSERT INTO Reservas (id_usuario, ID_habitacion, fecha_entrada, fecha_salida, servicios_adicionales,estado) VALUES (1, 1, '2024-04-10', '2024-04-15', 'Desayuno incluido',1);
INSERT INTO Reservas (id_usuario, ID_habitacion, fecha_entrada, fecha_salida, servicios_adicionales,estado) VALUES (2, 2, '2024-05-20', '2024-05-25', 'Wifi gratis',1);

-- Inserts para la tabla Opiniones
INSERT INTO Opiniones (id_usuario, ID_reserva, opinion_texto) VALUES (1, 1, 'Excelente servicio, habitación limpia y cómoda.');
INSERT INTO Opiniones (id_usuario, ID_reserva, opinion_texto) VALUES (2, 2, 'Buena ubicación, personal amable.');










-- ===============================================
--               CRUD HABITACIONES

-- ------------------Select TODOS---------------------

Create PROCEDURE [dbo].[ConsultarHabitaciones]
 @MostrarTodos bit
AS
BEGIN

	 IF (@MostrarTodos =1)
    BEGIN
        SELECT h.ID_habitacion ,
	h.tipo_habitacion ,
           h.tarifa ,
           h.capacidad,
           h.disponibilidad ,
		   h.ID_localidad ,
           l.nombre_localidad,
		   h.img
    FROM dbo.Habitaciones h 
	join dbo.Localidades l on l.ID_localidad = h.ID_localidad;

    END
	ELSE
	BEGIN
		 SELECT h.ID_habitacion ,
	h.tipo_habitacion ,
           h.tarifa ,
           h.capacidad,
           h.disponibilidad ,
		   h.ID_localidad ,
           l.nombre_localidad,
		   h.img
    FROM dbo.Habitaciones h 
	join dbo.Localidades l on l.ID_localidad = h.ID_localidad
	where disponibilidad =1;
	END
    
END
GO




-- ------------------Select UNO---------------------

CREATE PROCEDURE [dbo].[ConsultarHabitacion]
    @Consecutivo BIGINT
AS
BEGIN
    SELECT tipo_habitacion ,
           tarifa ,
           capacidad,
           disponibilidad ,
           ID_localidad,
		   h.img
    FROM Habitaciones
    WHERE ID_habitacion = @Consecutivo;
END
GO

-- ------------------Insert---------------------

Alter PROCEDURE [dbo].[RegistrarHabitacion]
    @tipo_habitacion VARCHAR(200),
	@Capacidad INT,
	@Tarifa DECIMAL(10,2),
	@img VARCHAR(250),
    @ID_localidad  BIGINT   
AS
BEGIN
    IF NOT EXISTS(SELECT 1 FROM Habitaciones WHERE tipo_habitacion = @tipo_habitacion and capacidad = @Capacidad)
    BEGIN
        INSERT INTO Habitaciones(tipo_habitacion,capacidad, tarifa, disponibilidad, ID_localidad,img)
        VALUES (@tipo_habitacion,@Capacidad,@Tarifa,1,@ID_localidad,@img);

    END
END
GO

-- ------------------Update---------------------

Create PROCEDURE [dbo].[ActualizarHabitacion]
	@ID_habitacion BIGINT,
    @tipo_habitacion VARCHAR(200),
	@Capacidad INT,
	@Tarifa DECIMAL(10,2),
	@Disponibilidad bit,
	@img VARCHAR(250),
    @ID_localidad  BIGINT   
AS
BEGIN
    UPDATE Habitaciones
    SET tipo_habitacion = @tipo_habitacion,
        tarifa = @Tarifa,
		disponibilidad = @Disponibilidad, 
        capacidad = @Capacidad,
        ID_localidad = @ID_localidad,
		img = @img
    WHERE ID_habitacion = @ID_habitacion;
END
GO

-- ------------------Delete---------------------

CREATE PROCEDURE [dbo].[EliminarHabitacion]
    @Consecutivo BIGINT
AS
BEGIN
    UPDATE Habitaciones
    SET disponibilidad = 0
    WHERE ID_habitacion = @Consecutivo;
END
GO

-- ===============================================




-- ===============================================
--               CRUD RESERVAS

-- ------------------Select TODOS---------------------

CREATE PROCEDURE [dbo].[ConsultarReservas]
	@MostrarTodos bit
AS
BEGIN

	 IF (@MostrarTodos =1)
    BEGIN
        SELECT r.ID_reserva ,
           r.id_usuario ,
           r.ID_habitacion,
		   h.tipo_habitacion,
           r.fecha_entrada ,
           r.fecha_salida ,
           r.servicios_adicionales,
		   r.estado,
		   u.nombre as 'nombre_usuario'
    FROM Reservas r
	join Usuarios u on u.id_usuario = r.id_usuario
	join Habitaciones h on h.ID_habitacion = r.ID_habitacion;
    END
	ELSE
	BEGIN
		 SELECT r.ID_reserva ,
           r.id_usuario ,
           r.ID_habitacion,
		   h.tipo_habitacion,
           r.fecha_entrada ,
           r.fecha_salida ,
           r.servicios_adicionales,
		   r.estado,
		   u.nombre as 'nombre_usuario'
    FROM Reservas r
	join Usuarios u on u.id_usuario = r.id_usuario
	join Habitaciones h on h.ID_habitacion = r.ID_habitacion
	where r.estado =1;
	END
    
END
GO

-- ------------------Select UNO---------------------

CREATE PROCEDURE [dbo].[ConsultarReserva]
    @ID_reserva BIGINT
AS
BEGIN
    SELECT id_usuario ,
           ID_habitacion ,
           fecha_entrada ,
           fecha_salida ,
           servicios_adicionales,
		   estado
    FROM Reservas
    WHERE ID_reserva = @ID_reserva;
END
GO

-- ------------------Insert---------------------

CREATE PROCEDURE [dbo].[RegistrarReserva]
    @id_usuario BIGINT,
    @ID_habitacion BIGINT,
    @fecha_entrada DATETIME,
    @fecha_salida DATETIME,
    @servicios_adicionales VARCHAR(255)
AS
BEGIN
	 IF NOT EXISTS(SELECT 1 FROM Reservas WHERE id_usuario = @id_usuario and ID_habitacion = @ID_habitacion and fecha_entrada =@fecha_entrada)
    BEGIN
        INSERT INTO Reservas(id_usuario, ID_habitacion, fecha_entrada, fecha_salida, servicios_adicionales,estado)
    VALUES (@id_usuario, @ID_habitacion, @fecha_entrada, @fecha_salida, @servicios_adicionales,1);

    END
   
END
GO

-- ------------------Update---------------------

create PROCEDURE [dbo].[ActualizarReserva]
    @ID_reserva BIGINT,
    @id_usuario BIGINT,
    @ID_habitacion BIGINT,
    @fecha_entrada DATETIME,
    @fecha_salida DATETIME,
	@estado bit,
    @servicios_adicionales VARCHAR(255)
AS
BEGIN
    UPDATE Reservas
    SET id_usuario = @id_usuario,
        ID_habitacion = @ID_habitacion,
        fecha_entrada = @fecha_entrada,
        fecha_salida = @fecha_salida,
        servicios_adicionales = @servicios_adicionales,
		estado = @estado
    WHERE ID_reserva = @ID_reserva;
END
GO

-- ------------------Delete---------------------

CREATE PROCEDURE [dbo].[EliminarReserva]
    @ID_reserva BIGINT
AS
BEGIN
     UPDATE Reservas
    SET estado = 0
    WHERE ID_reserva = @ID_reserva;
END
GO
 ----------------------------- -----------------------
 create PROCEDURE [dbo].[ConsultarUsuariosAdmin]
AS
BEGIN
   

SELECT [id_usuario]
      ,[nombre]
  FROM [dbo].[Usuarios]
  where estado = 1;




END
GO
-- ===============================================





CREATE PROCEDURE [dbo].[RegistrarUsuario]
    @Contrasena        varchar(10),
    @Nombre                varchar(200),
    @CorreoElectronico    varchar(200)
AS
BEGIN

     IF NOT EXISTS(SELECT 1 FROM dbo.Usuarios WHERE correo_electronico = @CorreoElectronico)
    BEGIN

          INSERT INTO dbo.Usuarios(Nombre, correo_electronico, Contrasena, ID_rol,estado)
    VALUES (@Nombre, @CorreoElectronico, @Contrasena, 1,1)
    END

END
GO


CREATE PROCEDURE [dbo].[IniciarSesionUsuario]
    @correo_electronico    VARCHAR(200),
    @contrasena          VARCHAR(10)
AS
BEGIN
    
        SELECT id_usuario, nombre, correo_electronico,contrasena, u.ID_rol, r.nombre_rol
        FROM dbo.Usuarios u  
        INNER JOIN dbo.Roles R ON U.ID_rol = R.ID_rol
        WHERE U.correo_electronico = @correo_electronico AND U.contrasena = @contrasena  
    
END