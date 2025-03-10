create database[db_envios_final]
USE [db_envios_final]
GO
/****** Object:  Table [dbo].[T_Detalles_Envio]    Script Date: 03-02-2025 17:19:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Detalles_Envio](
	[id_envio] [int] NOT NULL,
	[detalle] [int] NOT NULL,
	[id_producto] [int] NOT NULL,
	[cantidad] [int] NOT NULL,
	[comentario] [varchar](200) NULL,
 CONSTRAINT [PK_T_Detalles_Envio] PRIMARY KEY CLUSTERED 
(
	[id_envio] ASC,
	[detalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Envios]    Script Date: 03-02-2025 17:19:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Envios](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fecha] [datetime] NOT NULL,
	[dniCliente] [varchar](10) NOT NULL,
	[direccion] [varchar](100) NOT NULL,
	[palabraSecreta] [varchar](11) NOT NULL,
	[estado] [varchar](10) NOT NULL,
 CONSTRAINT [PK_T_Envios] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Productos]    Script Date: 03-02-2025 17:19:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Productos](
	[id_producto] [int] IDENTITY(1,1) NOT NULL,
	[n_producto] [varchar](50) NOT NULL,
	[precio] [float] NOT NULL,
 CONSTRAINT [PK_T_Productos] PRIMARY KEY CLUSTERED 
(
	[id_producto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[T_Detalles_Envio] ([id_envio], [detalle], [id_producto], [cantidad], [comentario]) VALUES (1, 1, 1, 2, N'Test')
INSERT [dbo].[T_Detalles_Envio] ([id_envio], [detalle], [id_producto], [cantidad], [comentario]) VALUES (1, 2, 2, 1, N'S/C')
INSERT [dbo].[T_Detalles_Envio] ([id_envio], [detalle], [id_producto], [cantidad], [comentario]) VALUES (2, 1, 1, 1, NULL)
GO
SET IDENTITY_INSERT [dbo].[T_Envios] ON 

INSERT [dbo].[T_Envios] ([id], [fecha], [dniCliente], [direccion], [palabraSecreta], [estado]) VALUES (1, CAST(N'2024-02-03T00:00:00.000' AS DateTime), N'5489633', N'dire test 123', N'132465789', N'Cargado')
INSERT [dbo].[T_Envios] ([id], [fecha], [dniCliente], [direccion], [palabraSecreta], [estado]) VALUES (2, CAST(N'2025-02-03T00:00:00.000' AS DateTime), N'21231', N'dire', N'dafDFDF', N'Nuevo')
SET IDENTITY_INSERT [dbo].[T_Envios] OFF
GO
SET IDENTITY_INSERT [dbo].[T_Productos] ON 

INSERT [dbo].[T_Productos] ([id_producto], [n_producto], [precio]) VALUES (1, N'PROD01', 120000)
INSERT [dbo].[T_Productos] ([id_producto], [n_producto], [precio]) VALUES (2, N'PROD02', 2560)
INSERT [dbo].[T_Productos] ([id_producto], [n_producto], [precio]) VALUES (3, N'PROD03', 9650)
SET IDENTITY_INSERT [dbo].[T_Productos] OFF
GO
ALTER TABLE [dbo].[T_Detalles_Envio] ADD  CONSTRAINT [DF_T_Detalles_Envio_cantidad]  DEFAULT ((1)) FOR [cantidad]
GO
ALTER TABLE [dbo].[T_Envios] ADD  CONSTRAINT [DF_T_Envios_estado]  DEFAULT ('En preparación') FOR [estado]
GO
ALTER TABLE [dbo].[T_Detalles_Envio]  WITH CHECK ADD  CONSTRAINT [FK_T_Detalles_Envio_T_Envios] FOREIGN KEY([id_envio])
REFERENCES [dbo].[T_Envios] ([id])
GO
ALTER TABLE [dbo].[T_Detalles_Envio] CHECK CONSTRAINT [FK_T_Detalles_Envio_T_Envios]
GO
ALTER TABLE [dbo].[T_Detalles_Envio]  WITH CHECK ADD  CONSTRAINT [FK_T_Detalles_Envio_T_Productos] FOREIGN KEY([id_producto])
REFERENCES [dbo].[T_Productos] ([id_producto])
GO
ALTER TABLE [dbo].[T_Detalles_Envio] CHECK CONSTRAINT [FK_T_Detalles_Envio_T_Productos]
GO
/****** Object:  StoredProcedure [dbo].[SP_CONSULTAR_ENVIOS]    Script Date: 03-02-2025 17:19:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_CONSULTAR_ENVIOS] 
    @dire VARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        T.*,
        T1.cantidad,
        T1.comentario,
        T1.id_producto,
        T2.n_producto,
        T2.precio
    FROM 
        T_Envios T
    INNER JOIN 
        T_Detalles_Envio T1 ON T1.id_envio = T.id
    INNER JOIN 
        T_Productos T2 ON T1.id_producto = T2.id_producto
    WHERE 
        (T.direccion LIKE '%' + @dire + '%');
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_ENTREGAR_ENVIO]    Script Date: 03-02-2025 17:19:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_ENTREGAR_ENVIO]
	@id int
AS
BEGIN
	UPDATE T_Envios SET estado = 'Sin_Entrega' WHERE id = @id;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_INSERTAR_DETALLE]    Script Date: 03-02-2025 17:19:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_INSERTAR_DETALLE]
	@id_envio int, 
	@detalle int,
	@cantidad int,
	@id_producto int,
	@comentario varchar(200) = null
AS
BEGIN
	INSERT INTO T_Detalles_Envio(id_envio, detalle, id_producto,cantidad, comentario)
	VALUES (@id_envio, @detalle, @id_producto, @cantidad, @comentario);
END
GO
/****** Object:  StoredProcedure [dbo].[SP_INSERTAR_ENVIO]    Script Date: 03-02-2025 17:19:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_INSERTAR_ENVIO]
    @dniCliente VARCHAR(10),
    @direccion VARCHAR(100),
    @id INT OUTPUT
AS
BEGIN
    DECLARE @fechaActual VARCHAR(10);
    DECLARE @palabraSecreta VARCHAR(20);

    SET @fechaActual = CONVERT(VARCHAR(10), GETDATE(), 103); 
    SET @fechaActual = REPLACE(@fechaActual, '/', '');       

    SET @palabraSecreta = LEFT(@dniCliente, 3) + @fechaActual;

    -- Insertar el nuevo envío
    INSERT INTO T_Envios (dniCliente, direccion, palabraSecreta, fecha)
    VALUES (@dniCliente, @direccion, @palabraSecreta, GETDATE());

    -- Obtener el último ID insertado
    SET @id = SCOPE_IDENTITY();
END;
GO
