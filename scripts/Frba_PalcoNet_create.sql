/*SCRIPT DE MIGRACIÓN*/
USE GD2C2018 -- Indica la base de datos a utilizar
GO
/* CREACIÓN DEL ESQUEMA */
CREATE SCHEMA CAMPUS_ANALYTICA AUTHORIZATION gdEspectaculos2018
GO

-- tables
-- Table: Canjes
print('Creando tablas...')
CREATE TABLE [CAMPUS_ANALYTICA].Canjes (
    Id int  NOT NULL IDENTITY,
    Fecha_canje Date  NOT NULL,
    Puntos_canjeados int  NOT NULL,
    Cliente_Id int  NOT NULL,
    Premios_Id int  NOT NULL,
    CONSTRAINT Canjes_pk PRIMARY KEY  (Id)
);

-- Table: Cliente
CREATE TABLE [CAMPUS_ANALYTICA].Cliente (
    Id int  NOT NULL IDENTITY,
    Nombre nvarchar(255)  NOT NULL,
    Apellido nvarchar(255)  NOT NULL,
    Tipo_documento int  NOT NULL,
    Nro_documento numeric(18,0)  NOT NULL,
    CUIL varchar(50)  NOT NULL,
    Mail nvarchar(255)  NOT NULL,
    Telefono varchar(20)  NOT NULL,
    Fecha_nacimiento datetime  NOT NULL,
    Fecha_alta Date  NOT NULL,
    Fecha_baja Date  ,
    Estado char  NOT NULL default 'A',
    Cliente_frecuente int  NOT NULL,
    Puntos int  NOT NULL,
    Fecha_venc_puntos Date  NOT NULL,
    Usuarios_Id int  NOT NULL,
    CONSTRAINT Cliente_pk PRIMARY KEY  (Id)
);

-- Table: ClienteDireccion
CREATE TABLE [CAMPUS_ANALYTICA].ClienteDireccion (
    Cliente_id int  NOT NULL IDENTITY,
    Direccion_id int  NOT NULL,
    Fecha_Alta datetime  NOT NULL,
    Fecha_Baja datetime  ,
    CONSTRAINT ClienteDireccion_pk PRIMARY KEY  (Cliente_id,Direccion_id)
);

-- Table: Compra
CREATE TABLE [CAMPUS_ANALYTICA].Compra (
    Id int  NOT NULL IDENTITY,
    Fecha datetime  NOT NULL,
    Tajetas_Nro_tarjeta int  NOT NULL,
    Cliente_Id int  NOT NULL,
    Cantidad numeric(18,0)  NOT NULL,
    CONSTRAINT Compra_pk PRIMARY KEY  (Id)
);

-- Table: Direccion
CREATE TABLE [CAMPUS_ANALYTICA].Direccion (
    Id int  NOT NULL IDENTITY,
    Calle nvarchar(50)  NOT NULL,
    Numero numeric(18,0)  NULL,
    Piso numeric(18,0)  NOT NULL,
    Codigo_postal nvarchar(50)  NOT NULL,
    Localidad varchar(50)  NOT NULL,
    Depoto nvarchar(50)  NOT NULL,
    CONSTRAINT Direccion_pk PRIMARY KEY  (Id)
);

-- Table: Empresa
CREATE TABLE [CAMPUS_ANALYTICA].Empresa (
    Id int  NOT NULL IDENTITY,
    Razon_social nvarchar(255)  NOT NULL UNIQUE,
    Mail nvarchar(50)  NULL,
    Telefono varchar(50)  ,
    CUIT nvarchar(255)  NOT NULL UNIQUE,
    Estado char  NOT NULL default 'A',
    Fecha_alta datetime  NOT NULL,
    Fecha_baja datetime  ,
    Usuarios_Id int  NOT NULL,
    Fecha_Creacion datetime  ,
    CONSTRAINT Empresa_pk PRIMARY KEY  (Id)
);

-- Table: EmpresaDireccion
CREATE TABLE [CAMPUS_ANALYTICA].EmpresaDireccion (
    Empresa_id int  NOT NULL ,
    Direccion_id int  NOT NULL,
    Fecha_Alta datetime  NOT NULL,
    Fecha_Baja datetime  ,
    CONSTRAINT EmpresaDireccion_pk PRIMARY KEY  (Empresa_id,Direccion_id)
);

-- Table: Facturas
CREATE TABLE [CAMPUS_ANALYTICA].Facturas (
    Id int  NOT NULL IDENTITY,
    Fecha Date  NOT NULL,
    Empresa_Id int  NOT NULL,
    Numero numeric(18,0)  NOT NULL,
    Total numeric(18,2)  NOT NULL,
    CONSTRAINT Facturas_pk PRIMARY KEY  (Id)
);

-- Table: Funcionalidad
CREATE TABLE [CAMPUS_ANALYTICA].Funcionalidad (
    Id int  NOT NULL IDENTITY,
    Nombre varchar(50)  NOT NULL,
    CONSTRAINT Funcionalidad_pk PRIMARY KEY  (Id)
);

-- Table: Grados_publicacion
CREATE TABLE [CAMPUS_ANALYTICA].Grados_publicacion (
    Id int  NOT NULL IDENTITY,
    Comision int  NOT NULL,
    CONSTRAINT Grados_publicacion_pk PRIMARY KEY  (Id)
);

-- Table: Items_factura
CREATE TABLE [CAMPUS_ANALYTICA].Items_factura (
    Monto numeric(18,2)  NOT NULL ,
    Cantidad numeric(18,0)  NOT NULL,
    Facturas_Id int  NOT NULL,
    Descripcion nvarchar(60)  NOT NULL,
    CONSTRAINT Items_factura_pk PRIMARY KEY  (Facturas_Id)
);

-- Table: Premios
CREATE TABLE [CAMPUS_ANALYTICA].Premios (
    Id int  NOT NULL IDENTITY,
    Descripcion varchar(50)  NOT NULL,
    Puntos_necesarios int  NOT NULL,
    Condiciones varchar(50)  NOT NULL,
    Fecha_alta Date  NOT NULL,
    Fecha_baja Date  ,
    CONSTRAINT Premios_pk PRIMARY KEY  (Id)
);

-- Table: Publicaciones
CREATE TABLE [CAMPUS_ANALYTICA].Publicaciones (
    Id int  NOT NULL IDENTITY,
    Estado nvarchar(255)  NOT NULL,
    Fecha_inicio datetime  NOT NULL,
    Fecha_Vencimiento datetime  NOT NULL,
    Localidades int  NOT NULL,
    Descripcion nvarchar(255)  NOT NULL,
    Direccion varchar(100)  NOT NULL,
    Empresa_Id int  NOT NULL,
    Grados_publicacion_Id int  NOT NULL,
    Rubros_Id int  NOT NULL,
    CONSTRAINT Publicaciones_pk PRIMARY KEY  (Id)
);

-- Table: Rol
CREATE TABLE [CAMPUS_ANALYTICA].Rol (
    Id int  NOT NULL IDENTITY,
    Nombre varchar(50)  NOT NULL,
    Estado char  NOT NULL  DEFAULT 'A',--A:alta y B: baja
    CONSTRAINT Rol_pk PRIMARY KEY  (Id)
);


-- Table: Rol_Funcionalidad
CREATE TABLE [CAMPUS_ANALYTICA].Rol_Funcionalidad (
    Funcionalidad_id int  NOT NULL,
    Rol_id int  NOT NULL,
    Fecha_Alta datetime  NOT NULL,
    Fecha_Baja datetime  ,
    CONSTRAINT Rol_Funcionalidad_pk PRIMARY KEY  (Funcionalidad_id,Rol_id)
);

-- Table: Rubros
CREATE TABLE [CAMPUS_ANALYTICA].Rubros (
    Id int  NOT NULL IDENTITY,
    Descripcion nvarchar(255)  NOT NULL,
    CONSTRAINT Rubros_pk PRIMARY KEY  (Id)
);

-- Table: Tajetas
CREATE TABLE [CAMPUS_ANALYTICA].Tajetas (
    Nro_tarjeta int  NOT NULL,
    Banco varchar(50)  NOT NULL,
    Tipo varchar(50)  NOT NULL,
    Fecha_vencimiento varchar(50)  NOT NULL,
    Estado binary  NOT NULL,
    Cliente_Id int  NOT NULL,
    CONSTRAINT Tajetas_pk PRIMARY KEY  (Nro_tarjeta)
);

-- Table: Tipos_publicacion
CREATE TABLE [CAMPUS_ANALYTICA].Tipos_publicacion (
    Id int  NOT NULL IDENTITY,
    Descripcion varchar(100)  NOT NULL,
    Grados_publicacion_Id int  NOT NULL,
    CONSTRAINT Tipos_publicacion_pk PRIMARY KEY  (Id)
);

-- Table: Tipos_usuario
CREATE TABLE [CAMPUS_ANALYTICA].Tipos_usuario (
    Id int  NOT NULL IDENTITY,
    Descripcion varchar(50)  NOT NULL,
    CONSTRAINT Tipos_usuario_pk PRIMARY KEY  (Id)
);

-- Table: Ubicacion
CREATE TABLE [CAMPUS_ANALYTICA].Ubicacion (
    Id int  NOT NULL IDENTITY,
    Fila varchar(3)  NOT NULL,
    Asiento numeric(10,0)  NOT NULL,
    Precio numeric(18,0)  NOT NULL,
    Comprada binary  NOT NULL,
    Publicaciones_Id int  NOT NULL,
    sin_numerar bit  NOT NULL,
    Tipo_Codigo numeric(18,0)  NOT NULL,
    Tipo_descripcion nvarchar(255)  NOT NULL,
    Compra_Id int  NOT NULL,
    CONSTRAINT Ubicacion_pk PRIMARY KEY  (Id,Fila)
);
CREATE TABLE [CAMPUS_ANALYTICA].Usuario (
    Id int  NOT NULL IDENTITY,
    Username varchar(20)  NOT NULL UNIQUE,
    Password varchar(50)  NOT NULL,
    Estado char  NOT NULL DEFAULT 'A',--A:ALTA Y B:BAJA
    Tipos_usuario_Id int  ,
    CONSTRAINT Usuario_pk PRIMARY KEY  (Id)
);
-- Table: Usuario_Rol
CREATE TABLE [CAMPUS_ANALYTICA].Usuario_Rol (
    Rol_Id int  NOT NULL,
    Usuario_Id int  NOT NULL,
    Fecha_alta datetime  NOT NULL,
    Fecha_baja int  
);


-- foreign keys
-- Reference: Canjes_Premios (table: Canjes)
ALTER TABLE [CAMPUS_ANALYTICA].Canjes ADD CONSTRAINT Canjes_Premios
    FOREIGN KEY (Premios_Id)
    REFERENCES [CAMPUS_ANALYTICA].Premios (Id);

-- Reference: ClienteDireccion_Clientes (table: ClienteDireccion)
ALTER TABLE [CAMPUS_ANALYTICA].ClienteDireccion ADD CONSTRAINT ClienteDireccion_Clientes
    FOREIGN KEY (Clientes_Id)
    REFERENCES [CAMPUS_ANALYTICA].Cliente (Id);

-- Reference: ClienteDireccion_Direccion (table: ClienteDireccion)
ALTER TABLE [CAMPUS_ANALYTICA].ClienteDireccion ADD CONSTRAINT ClienteDireccion_Direccion
    FOREIGN KEY (Direccion_Id)
    REFERENCES [CAMPUS_ANALYTICA].Direccion (Id);

-- Reference: Clientes_Usuarios (table: Cliente)
ALTER TABLE [CAMPUS_ANALYTICA].Cliente ADD CONSTRAINT Clientes_Usuarios
    FOREIGN KEY (Usuarios_Id)
    REFERENCES [CAMPUS_ANALYTICA].Usuario (Id);

-- Reference: Compra_Clientes (table: Compra)
ALTER TABLE [CAMPUS_ANALYTICA].Compra ADD CONSTRAINT Compra_Clientes
    FOREIGN KEY (Cliente_Id)
    REFERENCES [CAMPUS_ANALYTICA].Cliente (Id);

-- Reference: Compra_Tajetas (table: Compra)
ALTER TABLE [CAMPUS_ANALYTICA].Compra ADD CONSTRAINT Compra_Tajetas
    FOREIGN KEY (Tajetas_Nro_tarjeta)
    REFERENCES [CAMPUS_ANALYTICA].Tajetas (Nro_tarjeta);

-- Reference: EmpresaDireccion_Direccion (table: EmpresaDireccion)
ALTER TABLE [CAMPUS_ANALYTICA].EmpresaDireccion ADD CONSTRAINT EmpresaDireccion_Direccion
    FOREIGN KEY (Direccion_Id)
    REFERENCES [CAMPUS_ANALYTICA].Direccion (Id);

-- Reference: EmpresaDireccion_Empresa (table: EmpresaDireccion)
ALTER TABLE [CAMPUS_ANALYTICA].EmpresaDireccion ADD CONSTRAINT EmpresaDireccion_Empresa
    FOREIGN KEY (Empresa_Id)
    REFERENCES [CAMPUS_ANALYTICA].Empresa (Id);

-- Reference: Empresas_Usuarios (table: Empresa)
ALTER TABLE [CAMPUS_ANALYTICA].Empresa ADD CONSTRAINT Empresas_Usuarios
    FOREIGN KEY (Usuarios_Id)
    REFERENCES [CAMPUS_ANALYTICA].Usuario (Id);

-- Reference: Facturas_Empresas (table: Facturas)
ALTER TABLE [CAMPUS_ANALYTICA].Facturas ADD CONSTRAINT Facturas_Empresas
    FOREIGN KEY (Empresa_Id)
    REFERENCES [CAMPUS_ANALYTICA].Empresa (Id);

-- Reference: Historial_canje_Clientes (table: Canjes)
ALTER TABLE [CAMPUS_ANALYTICA].Canjes ADD CONSTRAINT Historial_canje_Clientes
    FOREIGN KEY (Cliente_Id)
    REFERENCES [CAMPUS_ANALYTICA].Cliente (Id);

-- Reference: Items_factura_Facturas (table: Items_factura)
ALTER TABLE [CAMPUS_ANALYTICA].Items_factura ADD CONSTRAINT Items_factura_Facturas
    FOREIGN KEY (Facturas_Id)
    REFERENCES [CAMPUS_ANALYTICA].Facturas (Id);

-- Reference: Publicaciones_Empresas (table: Publicaciones)
ALTER TABLE [CAMPUS_ANALYTICA].Publicaciones ADD CONSTRAINT Publicaciones_Empresas
    FOREIGN KEY (Empresa_Id)
    REFERENCES [CAMPUS_ANALYTICA].Empresa (Id);

-- Reference: Publicaciones_Estados (table: Publicaciones)
ALTER TABLE [CAMPUS_ANALYTICA].Publicaciones ADD CONSTRAINT Publicaciones_Estados
    FOREIGN KEY (Estados_Estado_id)
    REFERENCES [CAMPUS_ANALYTICA].Estados (Estado_id);

-- Reference: Publicaciones_Grados_publicacion (table: Publicaciones)
ALTER TABLE [CAMPUS_ANALYTICA].Publicaciones ADD CONSTRAINT Publicaciones_Grados_publicacion
    FOREIGN KEY (Grados_publicacion_Id)
    REFERENCES [CAMPUS_ANALYTICA].Grados_publicacion (Id);

-- Reference: Publicaciones_Rubros (table: Publicaciones)
ALTER TABLE [CAMPUS_ANALYTICA].Publicaciones ADD CONSTRAINT Publicaciones_Rubros
    FOREIGN KEY (Rubros_Id)
    REFERENCES [CAMPUS_ANALYTICA].Rubros (Id);

-- Reference: Rol_Funcionalidad_Funcionalidad (table: Rol_Funcionalidad)
ALTER TABLE [CAMPUS_ANALYTICA].Rol_Funcionalidad ADD CONSTRAINT Rol_Funcionalidad_Funcionalidad
    FOREIGN KEY (Funcionalidad_Id)
    REFERENCES [CAMPUS_ANALYTICA].Funcionalidad (Id);

-- Reference: Rol_Funcionalidad_Rol (table: Rol_Funcionalidad)
ALTER TABLE [CAMPUS_ANALYTICA].Rol_Funcionalidad ADD CONSTRAINT Rol_Funcionalidad_Rol
    FOREIGN KEY (Rol_Id)
    REFERENCES [CAMPUS_ANALYTICA].Rol (Id);

-- Reference: Tajetas_Clientes (table: Tajetas)
ALTER TABLE [CAMPUS_ANALYTICA].Tajetas ADD CONSTRAINT Tajetas_Clientes
    FOREIGN KEY (Cliente_Id)
    REFERENCES [CAMPUS_ANALYTICA].Cliente (Id);

-- Reference: Tipos_publicacion_Grados_publicacion (table: Tipos_publicacion)
ALTER TABLE [CAMPUS_ANALYTICA].Tipos_publicacion ADD CONSTRAINT Tipos_publicacion_Grados_publicacion
    FOREIGN KEY (Grados_publicacion_Id)
    REFERENCES [CAMPUS_ANALYTICA].Grados_publicacion (Id);

-- Reference: Ubicacion_Compra (table: Ubicacion)
ALTER TABLE [CAMPUS_ANALYTICA].Ubicacion ADD CONSTRAINT Ubicacion_Compra
    FOREIGN KEY (Compra_Id)
    REFERENCES [CAMPUS_ANALYTICA].Compra (Id);

-- Reference: Ubicacion_Publicaciones (table: Ubicacion)
ALTER TABLE [CAMPUS_ANALYTICA].Ubicacion ADD CONSTRAINT Ubicacion_Publicaciones
    FOREIGN KEY (Publicaciones_Id)
    REFERENCES [CAMPUS_ANALYTICA].Publicaciones (Id);

-- Reference: Usuario_Rol_Rol (table: Usuario_Rol)
ALTER TABLE [CAMPUS_ANALYTICA].Usuario_Rol ADD CONSTRAINT Usuario_Rol_Rol
    FOREIGN KEY (Rol_Id)
    REFERENCES [CAMPUS_ANALYTICA].Rol (Id);

-- Reference: Usuario_Rol_Usuario (table: Usuario_Rol)
ALTER TABLE [CAMPUS_ANALYTICA].Usuario_Rol ADD CONSTRAINT Usuario_Rol_Usuario
    FOREIGN KEY (Usuario_Id)
    REFERENCES [CAMPUS_ANALYTICA].Usuario (Id);

-- Reference: Usuarios_Tipos_usuario (table: Usuario)
ALTER TABLE [CAMPUS_ANALYTICA].Usuario ADD CONSTRAINT Usuarios_Tipos_usuario
    FOREIGN KEY (Tipos_usuario_Id)
    REFERENCES [CAMPUS_ANALYTICA].Tipos_usuario (Id);

	
--*******************************INSERT***********************************	--
/* INSERT FUNCIONALIDADES */
print('Cargando tabla de funcionalidad...')
INSERT INTO CAMPUS_ANALYTICA.FUNCIONALIDAD (Nombre) VALUES ('ABM de Rol');
INSERT INTO CAMPUS_ANALYTICA.FUNCIONALIDAD (Nombre) VALUES ('ABM de Usuario');
INSERT INTO CAMPUS_ANALYTICA.FUNCIONALIDAD (Nombre) VALUES ('ABM de Cliente');
INSERT INTO CAMPUS_ANALYTICA.FUNCIONALIDAD (Nombre) VALUES ('ABM de Empresa de espectáculos');
INSERT INTO CAMPUS_ANALYTICA.FUNCIONALIDAD (Nombre) VALUES ('ABM de Categoría');
INSERT INTO CAMPUS_ANALYTICA.FUNCIONALIDAD (Nombre) VALUES ('ABM grado de publicación');
INSERT INTO CAMPUS_ANALYTICA.FUNCIONALIDAD (Nombre) VALUES ('Generar Publicación');
INSERT INTO CAMPUS_ANALYTICA.FUNCIONALIDAD (Nombre) VALUES ('Editar Publicación');
INSERT INTO CAMPUS_ANALYTICA.FUNCIONALIDAD (Nombre) VALUES ('Comprar');
INSERT INTO CAMPUS_ANALYTICA.FUNCIONALIDAD (Nombre) VALUES ('Historial del cliente');
INSERT INTO CAMPUS_ANALYTICA.FUNCIONALIDAD (Nombre) VALUES ('Canje y administración de puntos');
INSERT INTO CAMPUS_ANALYTICA.FUNCIONALIDAD (Nombre) VALUES ('Generar Pago de comisiones');
INSERT INTO CAMPUS_ANALYTICA.FUNCIONALIDAD (Nombre) VALUES ('Listado Estadístico');	

/* INSERT ROLES*/
print('Cargando tabla de rol...')
INSERT INTO CAMPUS_ANALYTICA.ROL (Nombre) VALUES ('Administrador');
INSERT INTO CAMPUS_ANALYTICA.ROL (Nombre) VALUES ('Empresa');
INSERT INTO CAMPUS_ANALYTICA.ROL (Nombre) VALUES ('Cliente');

/* INSERT ROL y funcionalidad*/
print('Cargando tabla de rol_funcionalidad...')
INSERT INTO CAMPUS_ANALYTICA.Rol_Funcionalidad (Funcionalidad_id,rol_id,fecha_alta) values (1,1,GETDATE());
INSERT INTO CAMPUS_ANALYTICA.Rol_Funcionalidad (Funcionalidad_id,rol_id,fecha_alta) values (2,1,GETDATE());
INSERT INTO CAMPUS_ANALYTICA.Rol_Funcionalidad (Funcionalidad_id,rol_id,fecha_alta) values (3,1,GETDATE());
INSERT INTO CAMPUS_ANALYTICA.Rol_Funcionalidad (Funcionalidad_id,rol_id,fecha_alta) values (4,1,GETDATE());
INSERT INTO CAMPUS_ANALYTICA.Rol_Funcionalidad (Funcionalidad_id,rol_id,fecha_alta) values (5,1,GETDATE());
INSERT INTO CAMPUS_ANALYTICA.Rol_Funcionalidad (Funcionalidad_id,rol_id,fecha_alta) values (6,1,GETDATE());
INSERT INTO CAMPUS_ANALYTICA.Rol_Funcionalidad (Funcionalidad_id,rol_id,fecha_alta) values (7,1,GETDATE());
INSERT INTO CAMPUS_ANALYTICA.Rol_Funcionalidad (Funcionalidad_id,rol_id,fecha_alta) values (8,1,GETDATE());
INSERT INTO CAMPUS_ANALYTICA.Rol_Funcionalidad (Funcionalidad_id,rol_id,fecha_alta) values (9,1,GETDATE());
INSERT INTO CAMPUS_ANALYTICA.Rol_Funcionalidad (Funcionalidad_id,rol_id,fecha_alta) values (10,1,GETDATE());
INSERT INTO CAMPUS_ANALYTICA.Rol_Funcionalidad (Funcionalidad_id,rol_id,fecha_alta) values (11,1,GETDATE());
INSERT INTO CAMPUS_ANALYTICA.Rol_Funcionalidad (Funcionalidad_id,rol_id,fecha_alta) values (12,1,GETDATE());
INSERT INTO CAMPUS_ANALYTICA.Rol_Funcionalidad (Funcionalidad_id,rol_id,fecha_alta) values (13,1,GETDATE());
INSERT INTO CAMPUS_ANALYTICA.Rol_Funcionalidad (Funcionalidad_id,rol_id,fecha_alta) values (6,2,GETDATE());
INSERT INTO CAMPUS_ANALYTICA.Rol_Funcionalidad (Funcionalidad_id,rol_id,fecha_alta) values (7,2,GETDATE());
INSERT INTO CAMPUS_ANALYTICA.Rol_Funcionalidad (Funcionalidad_id,rol_id,fecha_alta) values (8,2,GETDATE());
INSERT INTO CAMPUS_ANALYTICA.Rol_Funcionalidad (Funcionalidad_id,rol_id,fecha_alta) values (12,2,GETDATE());
INSERT INTO CAMPUS_ANALYTICA.Rol_Funcionalidad (Funcionalidad_id,rol_id,fecha_alta) values (9,3,GETDATE());
INSERT INTO CAMPUS_ANALYTICA.Rol_Funcionalidad (Funcionalidad_id,rol_id,fecha_alta) values (10,3,GETDATE());
INSERT INTO CAMPUS_ANALYTICA.Rol_Funcionalidad (Funcionalidad_id,rol_id,fecha_alta) values (11,3,GETDATE());

GO
/* INSERT tipo usuario*/
print('Cargando tabla de tipo_usuario...')
INSERT INTO [CAMPUS_ANALYTICA].[Tipos_usuario]
           ([Descripcion])
     VALUES
           ('Administrador General')
INSERT INTO [CAMPUS_ANALYTICA].[Tipos_usuario]
           ([Descripcion])
     VALUES
           ('Empresa')
INSERT INTO [CAMPUS_ANALYTICA].[Tipos_usuario]
           ([Descripcion])
     VALUES
           ('Cliente')		   
		   
GO

/* INSERT  usuario general*/
print('Cargando tabla de usuario general...')
INSERT INTO [CAMPUS_ANALYTICA].[Usuario] ([Username],[Password],[Estado],[Tipos_usuario_Id])
		 VALUES  ('admin','w23e','A',1)
GO


/**********CREACION DE PROCEDURES************/
--use GD2C2018
GO
--funciones
CREATE FUNCTION Encriptar (@clave varchar(16))
RETURNS VARBINARY(255)
AS
BEGIN
	
	DECLARE @pass AS VARBINARY(255)
	SET @pass = ENCRYPTBYPASSPHRASE('123', @clave)
	RETURN @pass
END

GO
CREATE FUNCTION Desencriptar (@clave varbinary(255))
RETURNS VARCHAR(16)
AS
BEGIN
	DECLARE @pass AS VARCHAR(16)
	SET @pass = DECRYPTBYPASSPHRASE('123', @clave)
	RETURN @pass
END
 

 
/************************************************ CREACIÓN DE PROCEDIMIENTOS ************************************************/

/* PROCEDIMIENTO QUE MIGRA LOS CLIENTES Y LES ASIGNA USUARIO */
GO
CREATE PROCEDURE MigraEmpresas AS
BEGIN TRANSACTION  
	DECLARE @v_Razon_Social nvarchar(255)
	DECLARE @v_Empresa_Mail nvarchar(255)
	DECLARE @v_cod_Postal nvarchar(255)
	DECLARE @v_Cuit nvarchar(255)
	DECLARE @v_Depto nvarchar(255)
    DECLARE @v_Fecha_Creacion datetime
	DECLARE @v_Dom_Calle nvarchar(255)
	DECLARE @v_Nro_Calle numeric
	DECLARE @v_Piso numeric
	DECLARE @usuario_id int
	DECLARE @Password binary
	DECLARE @direccion_id int

	DECLARE ElCursor CURSOR STATIC LOCAL FORWARD_ONLY FOR
		select distinct [Espec_Empresa_Razon_Social]
						,[Espec_Empresa_Cuit]
						,[Espec_Empresa_Fecha_Creacion]
						,[Espec_Empresa_Mail]
						,[Espec_Empresa_Dom_Calle]
						,[Espec_Empresa_Nro_Calle]
						,[Espec_Empresa_Piso]
						,[Espec_Empresa_Depto]
						,[Espec_Empresa_Cod_Postal]					
		from gd_esquema.Maestra		 

    SET @usuario_id = 1
	SET @direccion_id = 1
	OPEN ElCursor FETCH NEXT FROM ElCursor INTO @v_Razon_Social, @v_Cuit, @v_Fecha_Creacion, @v_Empresa_Mail, @v_Dom_Calle, @v_Piso,
												@v_Depto,@v_cod_Postal 
				
		WHILE (@@FETCH_STATUS = 0) BEGIN
		
			INSERT INTO [CAMPUS_ANALYTICA].[Empresa]
           ([Razon_social]
           ,[Mail]
           ,[Telefono]
           ,[CUIT]
           ,[Estado]
           ,[Fecha_alta]
           ,[Fecha_baja]
           ,[Usuarios_Id]
           ,[Fecha_Creacion])
				VALUES (@v_Razon_Social,@v_Empresa_Mail,null,@v_Cuit,'A',@v_Fecha_Creacion,null,@usuario_id,getdate())

			SET IDENTITY_INSERT [CAMPUS_ANALYTICA].[Direccion] ON
			INSERT INTO [CAMPUS_ANALYTICA].[Direccion]
           ([Id]
		   ,[Calle]
           ,[Numero]
           ,[Piso]
           ,[Codigo_postal]
           ,[Localidad]
           ,[Depoto])
     VALUES
           (@direccion_id,@v_Dom_Calle,@v_Nro_Calle,@v_Piso,@v_cod_Postal,'caba',@v_Depto)	
		   			
			SET @Password = ' 0x010000009ECE0B9919D92706570D94462D18A99E82D5C70FCC18D93C' -- La password por defecto es '123'				
			
				
			INSERT INTO [CAMPUS_ANALYTICA].[Usuario]
           ([Username]
           ,[Password]
           ,[Estado]
           ,[Tipos_usuario_Id])
				VALUES (@v_Razon_Social, @Password,'A',2 )
				
			
			SET @usuario_id = @usuario_id + 1
			
			FETCH NEXT FROM ElCursor INTO @v_Razon_Social, @v_Cuit, @v_Fecha_Creacion, @v_Empresa_Mail, @CliDomNro, @CliDomPiso,
												@v_Depto,@v_cod_Postal 
		END
	CLOSE ElCursor
	DEALLOCATE ElCursor
END
GO

