USE [master]
GO
/****** Object:  Database [ProyPrograAvan]    Script Date: 4/23/2024 5:44:53 PM ******/
CREATE DATABASE [ProyPrograAvan]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ProyPrograAvan', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\ProyPrograAvan.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ProyPrograAvan_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\ProyPrograAvan_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [ProyPrograAvan] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ProyPrograAvan].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ProyPrograAvan] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ProyPrograAvan] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ProyPrograAvan] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ProyPrograAvan] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ProyPrograAvan] SET ARITHABORT OFF 
GO
ALTER DATABASE [ProyPrograAvan] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ProyPrograAvan] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ProyPrograAvan] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ProyPrograAvan] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ProyPrograAvan] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ProyPrograAvan] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ProyPrograAvan] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ProyPrograAvan] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ProyPrograAvan] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ProyPrograAvan] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ProyPrograAvan] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ProyPrograAvan] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ProyPrograAvan] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ProyPrograAvan] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ProyPrograAvan] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ProyPrograAvan] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ProyPrograAvan] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ProyPrograAvan] SET RECOVERY FULL 
GO
ALTER DATABASE [ProyPrograAvan] SET  MULTI_USER 
GO
ALTER DATABASE [ProyPrograAvan] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ProyPrograAvan] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ProyPrograAvan] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ProyPrograAvan] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ProyPrograAvan] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ProyPrograAvan] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'ProyPrograAvan', N'ON'
GO
ALTER DATABASE [ProyPrograAvan] SET QUERY_STORE = ON
GO
ALTER DATABASE [ProyPrograAvan] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [ProyPrograAvan]
GO
/****** Object:  Table [dbo].[Errores]    Script Date: 4/23/2024 5:44:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Errores](
	[ID_error] [bigint] IDENTITY(1,1) NOT NULL,
	[fecha_registro] [datetime] NULL,
	[descripcion] [varchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_error] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Habitaciones]    Script Date: 4/23/2024 5:44:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Habitaciones](
	[ID_habitacion] [bigint] IDENTITY(1,1) NOT NULL,
	[tipo_habitacion] [varchar](255) NULL,
	[capacidad] [int] NULL,
	[tarifa] [decimal](10, 2) NULL,
	[disponibilidad] [bit] NULL,
	[ID_localidad] [bigint] NULL,
	[img] [varchar](250) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_habitacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Localidades]    Script Date: 4/23/2024 5:44:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Localidades](
	[ID_localidad] [bigint] IDENTITY(1,1) NOT NULL,
	[nombre_localidad] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_localidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Opiniones]    Script Date: 4/23/2024 5:44:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Opiniones](
	[ID_opinion] [bigint] IDENTITY(1,1) NOT NULL,
	[id_usuario] [bigint] NULL,
	[ID_reserva] [bigint] NULL,
	[opinion_texto] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_opinion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reservas]    Script Date: 4/23/2024 5:44:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reservas](
	[ID_reserva] [bigint] IDENTITY(1,1) NOT NULL,
	[id_usuario] [bigint] NULL,
	[ID_habitacion] [bigint] NULL,
	[fecha_entrada] [datetime] NULL,
	[fecha_salida] [datetime] NULL,
	[servicios_adicionales] [varchar](255) NULL,
	[estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_reserva] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 4/23/2024 5:44:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[ID_rol] [bigint] IDENTITY(1,1) NOT NULL,
	[nombre_rol] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_rol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 4/23/2024 5:44:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[id_usuario] [bigint] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](255) NULL,
	[correo_electronico] [varchar](255) NULL,
	[contrasena] [varchar](255) NULL,
	[ID_rol] [bigint] NULL,
	[estado] [bit] NULL,
	[Vencimiento] [datetime] NOT NULL,
	[Temporal] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Errores] ON 
GO
GO
SET IDENTITY_INSERT [dbo].[Errores] OFF
GO
SET IDENTITY_INSERT [dbo].[Habitaciones] ON 
GO
INSERT [dbo].[Habitaciones] ([ID_habitacion], [tipo_habitacion], [capacidad], [tarifa], [disponibilidad], [ID_localidad], [img]) VALUES (1, N'Individual', 1, CAST(50.00 AS Decimal(10, 2)), 1, 1, N'https://i.pinimg.com/originals/8f/a5/71/8fa571bf5e890bdbe1a292acc3052604.jpg')
GO
INSERT [dbo].[Habitaciones] ([ID_habitacion], [tipo_habitacion], [capacidad], [tarifa], [disponibilidad], [ID_localidad], [img]) VALUES (2, N'Doble', 2, CAST(80.00 AS Decimal(10, 2)), 1, 1, N'https://i.pinimg.com/originals/d0/6a/4a/d06a4a531480ba3cf0298b59918ae316.jpg')
GO
INSERT [dbo].[Habitaciones] ([ID_habitacion], [tipo_habitacion], [capacidad], [tarifa], [disponibilidad], [ID_localidad], [img]) VALUES (3, N'Doble', 2, CAST(80.00 AS Decimal(10, 2)), 1, 2, N'https://www.florenciaplazahotel.com/wp-content/uploads/2019/11/FPH-Habitacion-doble.jpg')
GO
INSERT [dbo].[Habitaciones] ([ID_habitacion], [tipo_habitacion], [capacidad], [tarifa], [disponibilidad], [ID_localidad], [img]) VALUES (4, N'Suite', 4, CAST(150.00 AS Decimal(10, 2)), 1, 3, N'https://cf.bstatic.com/xdata/images/hotel/max1024x768/309694982.jpg?k=6cb63aeac7aba2a92118773436e8ce29aa6892372ad27d14d72298ccd8113101&o=&hp=1')
GO
SET IDENTITY_INSERT [dbo].[Habitaciones] OFF
GO
SET IDENTITY_INSERT [dbo].[Localidades] ON 
GO
INSERT [dbo].[Localidades] ([ID_localidad], [nombre_localidad]) VALUES (1, N'Guanacaste')
GO
INSERT [dbo].[Localidades] ([ID_localidad], [nombre_localidad]) VALUES (2, N'Manuel Antonio')
GO
INSERT [dbo].[Localidades] ([ID_localidad], [nombre_localidad]) VALUES (3, N'Limon')
GO
SET IDENTITY_INSERT [dbo].[Localidades] OFF
GO
SET IDENTITY_INSERT [dbo].[Opiniones] ON 
GO
SET IDENTITY_INSERT [dbo].[Opiniones] OFF
GO
SET IDENTITY_INSERT [dbo].[Reservas] ON 
GO
SET IDENTITY_INSERT [dbo].[Reservas] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 
GO
INSERT [dbo].[Roles] ([ID_rol], [nombre_rol]) VALUES (1, N'Administrador')
GO
INSERT [dbo].[Roles] ([ID_rol], [nombre_rol]) VALUES (2, N'Usuario')
GO
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuarios] ON 
GO
INSERT [dbo].[Usuarios] ([id_usuario], [nombre], [correo_electronico], [contrasena], [ID_rol], [estado], [Vencimiento], [Temporal]) VALUES (1, N'Ana Martínez', N'ana@example.com', N'32B26972', 2, 1, CAST(N'2024-04-19T17:35:48.660' AS DateTime), 0)
GO
INSERT [dbo].[Usuarios] ([id_usuario], [nombre], [correo_electronico], [contrasena], [ID_rol], [estado], [Vencimiento], [Temporal]) VALUES (2, N'Carlos Rodríguez', N'carlos@example.com', N'seguridad', 1, 1, CAST(N'2024-04-18T14:30:00.000' AS DateTime), 0)
GO
INSERT [dbo].[Usuarios] ([id_usuario], [nombre], [correo_electronico], [contrasena], [ID_rol], [estado], [Vencimiento], [Temporal]) VALUES (3, N'Sofía López', N'sofia@example.com', N'9BD50988', 2, 1, CAST(N'2024-04-19T15:47:50.047' AS DateTime), 1)
GO
INSERT [dbo].[Usuarios] ([id_usuario], [nombre], [correo_electronico], [contrasena], [ID_rol], [estado], [Vencimiento], [Temporal]) VALUES (6, N'Jose Pablo', N'jflores50158@ufide.ac.cr', N'123456', 2, 1, CAST(N'2024-04-23T15:05:02.517' AS DateTime), 0)
GO
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Usuarios__5B8A0682EEED37E1]    Script Date: 4/23/2024 5:44:54 PM ******/
ALTER TABLE [dbo].[Usuarios] ADD UNIQUE NONCLUSTERED 
(
	[correo_electronico] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Habitaciones]  WITH CHECK ADD FOREIGN KEY([ID_localidad])
REFERENCES [dbo].[Localidades] ([ID_localidad])
GO
ALTER TABLE [dbo].[Opiniones]  WITH CHECK ADD FOREIGN KEY([ID_reserva])
REFERENCES [dbo].[Reservas] ([ID_reserva])
GO
ALTER TABLE [dbo].[Opiniones]  WITH CHECK ADD FOREIGN KEY([id_usuario])
REFERENCES [dbo].[Usuarios] ([id_usuario])
GO
ALTER TABLE [dbo].[Reservas]  WITH CHECK ADD FOREIGN KEY([id_usuario])
REFERENCES [dbo].[Usuarios] ([id_usuario])
GO
ALTER TABLE [dbo].[Reservas]  WITH CHECK ADD FOREIGN KEY([ID_habitacion])
REFERENCES [dbo].[Habitaciones] ([ID_habitacion])
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD FOREIGN KEY([ID_rol])
REFERENCES [dbo].[Roles] ([ID_rol])
GO
/****** Object:  StoredProcedure [dbo].[ActualizarHabitacion]    Script Date: 4/23/2024 5:44:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
/****** Object:  StoredProcedure [dbo].[ActualizarReserva]    Script Date: 4/23/2024 5:44:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
/****** Object:  StoredProcedure [dbo].[ActualizarUsuario]    Script Date: 4/23/2024 5:44:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[ActualizarUsuario]
    @id_usuario BIGINT,
    @nombre VARCHAR(255),
    @correo_electronico VARCHAR(255),
    @contrasena VARCHAR(255),
    @ID_rol BIGINT,
    @estado bit
AS
BEGIN
    UPDATE Usuarios
    SET nombre = @nombre,
        correo_electronico = @correo_electronico,
        contrasena = @contrasena,
        ID_rol = @ID_rol,
        estado = @estado
    WHERE id_usuario = @id_usuario;
END
GO
/****** Object:  StoredProcedure [dbo].[AgregarOpinion]    Script Date: 4/23/2024 5:44:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AgregarOpinion]
    @id_usuario BIGINT,
    @ID_reserva BIGINT,
    @opinion_texto TEXT
AS
BEGIN
    INSERT INTO Opiniones (id_usuario, ID_reserva, opinion_texto)
    VALUES (@id_usuario, @ID_reserva, @opinion_texto);
END;
GO
/****** Object:  StoredProcedure [dbo].[CambiarContrasena]    Script Date: 4/23/2024 5:44:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[CambiarContrasena]
    
    @correo_electronico VARCHAR(255),
	@codigo VARCHAR(255),
    @contrasena VARCHAR(255)
AS
BEGIN

	DECLARE @id_usuario BIGINT
	select @id_usuario = id_usuario from Usuarios where correo_electronico = @correo_electronico and contrasena = @codigo and Temporal =1

   if @id_usuario is not null
   begin 
     UPDATE Usuarios
    SET 
		Temporal = 0,
        contrasena = @contrasena
        
    WHERE id_usuario = @id_usuario;
   end 
END
GO
/****** Object:  StoredProcedure [dbo].[ConsultarCasas]    Script Date: 4/23/2024 5:44:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[ConsultarCasas]
	@MostrarTodos bit
as
begin

 if @MostrarTodos = 1
    begin 
    SELECT [IdCasa]
      ,[DescripcionCasa]
      ,[PrecioCasa]
      ,[UsuarioAlquiler]
	  ,CASE
        WHEN UsuarioAlquiler IS NULL THEN 'Disponible'
        ELSE 'Reservada'
    END AS Estado,
    FechaAlquiler AS Fecha
  FROM [dbo].[CasasSistema]
  where PrecioCasa >  115000 and PrecioCasa <  180000
  order by Estado asc
  end
  else 
  SELECT [IdCasa]
      ,[DescripcionCasa]
      ,[PrecioCasa]
      ,[UsuarioAlquiler]
	  ,CASE
        WHEN UsuarioAlquiler IS NULL THEN 'Disponible'
        ELSE 'Reservada'
    END AS Estado,
    FechaAlquiler AS Fecha
  FROM [dbo].[CasasSistema]
  where PrecioCasa >  115000 and PrecioCasa <  180000 and UsuarioAlquiler is null
  order by Estado asc
 
end
GO
/****** Object:  StoredProcedure [dbo].[ConsultarCasaUno]    Script Date: 4/23/2024 5:44:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ConsultarCasaUno]
	@Consecutivo BIGINT
AS
BEGIN


SELECT [IdCasa]
      ,[DescripcionCasa]
      ,[PrecioCasa]
      ,[UsuarioAlquiler]
      ,[FechaAlquiler]
  FROM [dbo].[CasasSistema] where IdCasa = @Consecutivo
end
GO
/****** Object:  StoredProcedure [dbo].[ConsultarHabitacion]    Script Date: 4/23/2024 5:44:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[ConsultarHabitacion]
    @Consecutivo BIGINT
AS
BEGIN
    SELECT tipo_habitacion ,
           tarifa ,
           capacidad,
           disponibilidad ,
           ID_localidad,
		   img
    FROM Habitaciones
    WHERE ID_habitacion = @Consecutivo;
END
GO
/****** Object:  StoredProcedure [dbo].[ConsultarHabitaciones]    Script Date: 4/23/2024 5:44:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

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
/****** Object:  StoredProcedure [dbo].[ConsultarLocalidad]    Script Date: 4/23/2024 5:44:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ConsultarLocalidad]
AS
BEGIN
    SELECT ID_localidad,nombre_localidad
    FROM Localidades
    
END
GO
/****** Object:  StoredProcedure [dbo].[ConsultarReserva]    Script Date: 4/23/2024 5:44:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

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
/****** Object:  StoredProcedure [dbo].[ConsultarReservas]    Script Date: 4/23/2024 5:44:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

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
/****** Object:  StoredProcedure [dbo].[ConsultarReservaUsuario]    Script Date: 4/23/2024 5:44:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE PROCEDURE [dbo].[ConsultarReservaUsuario]
    @id_usuario BIGINT,
	@uno bit
AS
BEGIN
    If (@uno = 1)
	begin 
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
    WHERE r.id_usuario = @id_usuario and r.estado = 1;
	end 
	else 
	begin 
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
    WHERE r.id_usuario = @id_usuario and r.estado = 0;
	end 
END
GO
/****** Object:  StoredProcedure [dbo].[ConsultarUsuario]    Script Date: 4/23/2024 5:44:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ConsultarUsuario]
    @id_usuario BIGINT
AS
BEGIN
    SELECT nombre,
           correo_electronico,
           contrasena,
           ID_rol,
           estado
    FROM Usuarios
    WHERE id_usuario = @id_usuario;
END
GO
/****** Object:  StoredProcedure [dbo].[ConsultarUsuarios]    Script Date: 4/23/2024 5:44:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ConsultarUsuarios]
AS
BEGIN

SELECT [id_usuario]
      ,[nombre]
      ,[correo_electronico]
      ,[contrasena]
      ,u.[ID_rol]
	  ,r.nombre_rol
      ,[estado]
	  ,[Vencimiento]
	  ,[temporal]
  FROM Usuarios u
  join roles r on u.ID_rol = r.ID_rol
    
END
GO
/****** Object:  StoredProcedure [dbo].[ConsultarUsuariosAdmin]    Script Date: 4/23/2024 5:44:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create PROCEDURE [dbo].[ConsultarUsuariosAdmin]
AS
BEGIN
   

SELECT [id_usuario]
      ,[nombre]
  FROM [dbo].[Usuarios]
  where estado = 1;




END
GO
/****** Object:  StoredProcedure [dbo].[EliminadoTotalReserva]    Script Date: 4/23/2024 5:44:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EliminadoTotalReserva]
    @ID_reserva BIGINT
AS
BEGIN
    Delete from Reservas
	where ID_reserva = @ID_reserva
END
GO
/****** Object:  StoredProcedure [dbo].[EliminarHabitacion]    Script Date: 4/23/2024 5:44:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EliminarHabitacion]
    @Consecutivo BIGINT
AS
BEGIN
    UPDATE Habitaciones
    SET disponibilidad = 0
    WHERE ID_habitacion = @Consecutivo;
END
GO
/****** Object:  StoredProcedure [dbo].[EliminarReserva]    Script Date: 4/23/2024 5:44:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EliminarReserva]
    @ID_reserva BIGINT
AS
BEGIN
     UPDATE Reservas
    SET estado = 0
    WHERE ID_reserva = @ID_reserva;
END
GO
/****** Object:  StoredProcedure [dbo].[EliminarUsuario]    Script Date: 4/23/2024 5:44:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[EliminarUsuario]
    @id_usuario BIGINT
AS
BEGIN
    UPDATE Usuarios
    SET estado = 0
    WHERE id_usuario = @id_usuario;
END
GO
/****** Object:  StoredProcedure [dbo].[GuardarErrores]    Script Date: 4/23/2024 5:44:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GuardarErrores]
 @descripcion varchar(200)
AS
BEGIN
   

INSERT INTO [dbo].Errores
           ([fecha_registro]
           ,[descripcion])
     VALUES
	 (GETDATE(),@descripcion)

END;
GO
/****** Object:  StoredProcedure [dbo].[IniciarSesionUsuario]    Script Date: 4/23/2024 5:44:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[IniciarSesionUsuario]
    @correo_electronico    VARCHAR(200),
    @contrasena          VARCHAR(10)
AS
BEGIN
    
        SELECT id_usuario, nombre, correo_electronico,contrasena, u.ID_rol, r.nombre_rol,Temporal,Vencimiento
        FROM dbo.Usuarios u  
        INNER JOIN dbo.Roles R ON U.ID_rol = R.ID_rol
        WHERE U.correo_electronico = @correo_electronico AND U.contrasena = @contrasena and estado = 1 
    
END
GO
/****** Object:  StoredProcedure [dbo].[MostrarOpiniones]    Script Date: 4/23/2024 5:44:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MostrarOpiniones]
AS
BEGIN
    SELECT * FROM Opiniones;
END;
GO
/****** Object:  StoredProcedure [dbo].[RecuperarAccesoUsuario]    Script Date: 4/23/2024 5:44:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RecuperarAccesoUsuario]
    @CorreoElectronico	varchar(200)
AS
BEGIN

	DECLARE @id_usuario BIGINT

	SELECT	@id_usuario = id_usuario
	FROM	dbo.Usuarios WHERE  correo_electronico = @CorreoElectronico
						AND Estado = 1

	IF @id_usuario IS NOT NULL
	BEGIN
		UPDATE	Usuarios
		SET		contrasena = LEFT(NEWID(),8),
				Temporal = 1,
				Vencimiento = DATEADD(HOUR, 1, GETDATE())  
		WHERE	id_usuario = @id_usuario
	END

	SELECT	id_usuario,contrasena,nombre,correo_electronico,estado,Temporal,Vencimiento
	FROM	dbo.Usuarios
	WHERE	id_usuario = @id_usuario

END
GO
/****** Object:  StoredProcedure [dbo].[RegistrarAlquiler]    Script Date: 4/23/2024 5:44:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[RegistrarAlquiler]
	@IdCasa bigint,
	@Fecha datetime,
	@UsuarioAlquiler varchar(200)
AS
BEGIN

UPDATE [dbo].[CasasSistema]
   SET UsuarioAlquiler = @UsuarioAlquiler
      ,[FechaAlquiler] = @Fecha
 WHERE IdCasa= @IdCasa



end
GO
/****** Object:  StoredProcedure [dbo].[RegistrarHabitacion]    Script Date: 4/23/2024 5:44:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[RegistrarHabitacion]
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
/****** Object:  StoredProcedure [dbo].[RegistrarReserva]    Script Date: 4/23/2024 5:44:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RegistrarReserva]
    @id_usuario BIGINT,
    @ID_habitacion BIGINT,
    @fecha_entrada DATETIME,
    @fecha_salida DATETIME,
    @servicios_adicionales VARCHAR(255)
AS
BEGIN
    IF NOT EXISTS(
        SELECT 1 
        FROM Reservas 
        WHERE ID_habitacion = @ID_habitacion
          AND (
               (fecha_entrada BETWEEN @fecha_entrada AND @fecha_salida)
            OR (fecha_salida BETWEEN @fecha_entrada AND @fecha_salida)
            OR (fecha_entrada <= @fecha_entrada AND fecha_salida >= @fecha_salida)
          )
    )
    BEGIN
        INSERT INTO Reservas(id_usuario, ID_habitacion, fecha_entrada, fecha_salida, servicios_adicionales, estado)
        VALUES (@id_usuario, @ID_habitacion, @fecha_entrada, @fecha_salida, @servicios_adicionales, 1);
    END
END
GO
/****** Object:  StoredProcedure [dbo].[RegistrarUsuario]    Script Date: 4/23/2024 5:44:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[RegistrarUsuario]
    @Contrasena        varchar(10),
    @Nombre                varchar(200),
    @CorreoElectronico    varchar(200)
AS
BEGIN

     IF NOT EXISTS(SELECT 1 FROM dbo.Usuarios WHERE correo_electronico = @CorreoElectronico)
    BEGIN

          INSERT INTO dbo.Usuarios(Nombre, correo_electronico, Contrasena, ID_rol,estado,Vencimiento,Temporal)
    VALUES (@Nombre, @CorreoElectronico, @Contrasena, 2,1,GETDATE(),0)
    END

END
GO
USE [master]
GO
ALTER DATABASE [ProyPrograAvan] SET  READ_WRITE 
GO
