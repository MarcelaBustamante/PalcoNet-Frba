/*SCRIPT DE MIGRACIÓN*/
USE GD2C2018 -- Indica la base de datos a utilizar
GO
/* CREACIÓN DEL ESQUEMA */
CREATE SCHEMA CAMPUS_ANALYTICA AUTHORIZATION gdEspectaculos2018
GO
-- tables
-- Table: Canjes
print('Creando tablas...')
CREATE TABLE Canjes (
    Id int  NOT NULL IDENTITY,
    Fecha_canje Date  NOT NULL,
    Puntos_canjeados int  NOT NULL,
    Cliente_Id int  NOT NULL,
    Premios_Id int  NOT NULL,
    CONSTRAINT Canjes_pk PRIMARY KEY  (Id)
);

-- Table: Cliente
CREATE TABLE Cliente (
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
    Fecha_baja Date  NOT NULL,
    Estado char  NOT NULL default 'A',
    Cliente_frecuente int  NOT NULL,
    Puntos int  NOT NULL,
    Fecha_venc_puntos Date  NOT NULL,
    Usuarios_Id int  NOT NULL,
    CONSTRAINT Cliente_pk PRIMARY KEY  (Id)
);

-- Table: ClienteDireccion
CREATE TABLE ClienteDireccion (
    Cliente_id int  NOT NULL IDENTITY,
    Direccion_id int  NOT NULL,
    Fecha_Alta datetime  NOT NULL,
    Fecha_Baja datetime  NOT NULL,
    Clientes_Id int  NOT NULL,
    Direccion_Id int  NOT NULL,
    CONSTRAINT ClienteDireccion_pk PRIMARY KEY  (Cliente_id,Direccion_id)
);

-- Table: Compra
CREATE TABLE Compra (
    Id int  NOT NULL IDENTITY,
    Fecha datetime  NOT NULL,
    Tajetas_Nro_tarjeta int  NOT NULL,
    Cliente_Id int  NOT NULL,
    Cantidad numeric(18,0)  NOT NULL,
    CONSTRAINT Compra_pk PRIMARY KEY  (Id)
);

-- Table: Direccion
CREATE TABLE Direccion (
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
CREATE TABLE Empresa (
    Id int  NOT NULL IDENTITY,
    Razon_social nvarchar(255)  NOT NULL UNIQUE,
    Mail nvarchar(50)  NULL,
    Telefono varchar(50)  NOT NULL,
    CUIT nvarchar(255)  NOT NULL UNIQUE,
    Estado binary  NOT NULL,
    Fecha_alta datetime  NOT NULL,
    Fecha_baja datetime  NOT NULL,
    Usuarios_Id int  NOT NULL,
    Fecha_Creacion datetime  NOT NULL,
    CONSTRAINT Empresa_pk PRIMARY KEY  (Id)
);

-- Table: EmpresaDireccion
CREATE TABLE EmpresaDireccion (
    Cliente_id int  NOT NULL IDENTITY,
    Direccion_id int  NOT NULL,
    Fecha_Alta datetime  NOT NULL,
    Fecha_Baja datetime  NOT NULL,
    Direccion_Id int  NOT NULL,
    Empresa_Id int  NOT NULL,
    CONSTRAINT EmpresaDireccion_pk PRIMARY KEY  (Cliente_id,Direccion_id)
);

-- Table: Facturas
CREATE TABLE Facturas (
    Id int  NOT NULL IDENTITY,
    Fecha Date  NOT NULL,
    Empresa_Id int  NOT NULL,
    Numero numeric(18,0)  NOT NULL,
    Total numeric(18,2)  NOT NULL,
    CONSTRAINT Facturas_pk PRIMARY KEY  (Id)
);

-- Table: Funcionalidad
CREATE TABLE Funcionalidad (
    Id int  NOT NULL IDENTITY,
    Nombre varchar(50)  NOT NULL,
    CONSTRAINT Funcionalidad_pk PRIMARY KEY  (Id)
);

-- Table: Grados_publicacion
CREATE TABLE Grados_publicacion (
    Id int  NOT NULL IDENTITY,
    Comision int  NOT NULL,
    CONSTRAINT Grados_publicacion_pk PRIMARY KEY  (Id)
);

-- Table: Items_factura
CREATE TABLE Items_factura (
    Monto numeric(18,2)  NOT NULL ,
    Cantidad numeric(18,0)  NOT NULL,
    Facturas_Id int  NOT NULL,
    Descripcion nvarchar(60)  NOT NULL,
    CONSTRAINT Items_factura_pk PRIMARY KEY  (Facturas_Id)
);

-- Table: Premios
CREATE TABLE Premios (
    Id int  NOT NULL IDENTITY,
    Descripcion varchar(50)  NOT NULL,
    Puntos_necesarios int  NOT NULL,
    Condiciones varchar(50)  NOT NULL,
    Fecha_alta Date  NOT NULL,
    Fecha_baja Date  NOT NULL,
    CONSTRAINT Premios_pk PRIMARY KEY  (Id)
);

-- Table: Publicaciones
CREATE TABLE Publicaciones (
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
CREATE TABLE Rol (
    Id int  NOT NULL IDENTITY,
    Nombre varchar(50)  NOT NULL,
    Estado char  NOT NULL  DEFAULT 'A',--A:alta y B: baja
    CONSTRAINT Rol_pk PRIMARY KEY  (Id)
);


-- Table: Rol_Funcionalidad
CREATE TABLE Rol_Funcionalidad (
    Funcionalidad_id int  NOT NULL,
    Rol_id int  NOT NULL,
    Fecha_Alta datetime  NOT NULL,
    Fecha_Baja datetime  NOT NULL,
    Funcionalidad_Id int  NOT NULL,
    Rol_Id int  NOT NULL,
    CONSTRAINT Rol_Funcionalidad_pk PRIMARY KEY  (Funcionalidad_id,Rol_id)
);

-- Table: Rubros
CREATE TABLE Rubros (
    Id int  NOT NULL IDENTITY,
    Descripcion nvarchar(255)  NOT NULL,
    CONSTRAINT Rubros_pk PRIMARY KEY  (Id)
);

-- Table: Tajetas
CREATE TABLE Tajetas (
    Nro_tarjeta int  NOT NULL,
    Banco varchar(50)  NOT NULL,
    Tipo varchar(50)  NOT NULL,
    Fecha_vencimiento varchar(50)  NOT NULL,
    Estado binary  NOT NULL,
    Cliente_Id int  NOT NULL,
    CONSTRAINT Tajetas_pk PRIMARY KEY  (Nro_tarjeta)
);

-- Table: Tipos_publicacion
CREATE TABLE Tipos_publicacion (
    Id int  NOT NULL IDENTITY,
    Descripcion varchar(100)  NOT NULL,
    Grados_publicacion_Id int  NOT NULL,
    CONSTRAINT Tipos_publicacion_pk PRIMARY KEY  (Id)
);

-- Table: Tipos_usuario
CREATE TABLE Tipos_usuario (
    Id int  NOT NULL IDENTITY,
    Descripcion varchar(50)  NOT NULL,
    CONSTRAINT Tipos_usuario_pk PRIMARY KEY  (Id)
);

-- Table: Ubicacion
CREATE TABLE Ubicacion (
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
CREATE TABLE Usuario (
    Id int  NOT NULL IDENTITY,
    Username varchar(20)  NOT NULL UNIQUE,
    Password varchar(50)  NOT NULL,
    Estado char  NOT NULL DEFAULT 'A',--A:ALTA Y B:BAJA
    Tipos_usuario_Id int  ,
    CONSTRAINT Usuario_pk PRIMARY KEY  (Id)
);
-- Table: Usuario_Rol
CREATE TABLE Usuario_Rol (
    Rol_Id int  NOT NULL,
    Usuario_Id int  NOT NULL,
    Fecha_alta datetime  NOT NULL,
    Fecha_baja int  NOT NULL
);

-- foreign keys
-- Reference: Canjes_Premios (table: Canjes)
ALTER TABLE Canjes ADD CONSTRAINT Canjes_Premios
    FOREIGN KEY (Premios_Id)
    REFERENCES Premios (Id);

-- Reference: ClienteDireccion_Clientes (table: ClienteDireccion)
ALTER TABLE ClienteDireccion ADD CONSTRAINT ClienteDireccion_Clientes
    FOREIGN KEY (Clientes_Id)
    REFERENCES Cliente (Id);

-- Reference: ClienteDireccion_Direccion (table: ClienteDireccion)
ALTER TABLE ClienteDireccion ADD CONSTRAINT ClienteDireccion_Direccion
    FOREIGN KEY (Direccion_Id)
    REFERENCES Direccion (Id);

-- Reference: Clientes_Usuarios (table: Cliente)
ALTER TABLE Cliente ADD CONSTRAINT Clientes_Usuarios
    FOREIGN KEY (Usuarios_Id)
    REFERENCES Usuario (Id);

-- Reference: Compra_Clientes (table: Compra)
ALTER TABLE Compra ADD CONSTRAINT Compra_Clientes
    FOREIGN KEY (Cliente_Id)
    REFERENCES Cliente (Id);

-- Reference: Compra_Tajetas (table: Compra)
ALTER TABLE Compra ADD CONSTRAINT Compra_Tajetas
    FOREIGN KEY (Tajetas_Nro_tarjeta)
    REFERENCES Tajetas (Nro_tarjeta);

-- Reference: EmpresaDireccion_Direccion (table: EmpresaDireccion)
ALTER TABLE EmpresaDireccion ADD CONSTRAINT EmpresaDireccion_Direccion
    FOREIGN KEY (Direccion_Id)
    REFERENCES Direccion (Id);

-- Reference: EmpresaDireccion_Empresa (table: EmpresaDireccion)
ALTER TABLE EmpresaDireccion ADD CONSTRAINT EmpresaDireccion_Empresa
    FOREIGN KEY (Empresa_Id)
    REFERENCES Empresa (Id);

-- Reference: Empresas_Usuarios (table: Empresa)
ALTER TABLE Empresa ADD CONSTRAINT Empresas_Usuarios
    FOREIGN KEY (Usuarios_Id)
    REFERENCES Usuario (Id);

-- Reference: Facturas_Empresas (table: Facturas)
ALTER TABLE Facturas ADD CONSTRAINT Facturas_Empresas
    FOREIGN KEY (Empresa_Id)
    REFERENCES Empresa (Id);

-- Reference: Historial_canje_Clientes (table: Canjes)
ALTER TABLE Canjes ADD CONSTRAINT Historial_canje_Clientes
    FOREIGN KEY (Cliente_Id)
    REFERENCES Cliente (Id);

-- Reference: Items_factura_Facturas (table: Items_factura)
ALTER TABLE Items_factura ADD CONSTRAINT Items_factura_Facturas
    FOREIGN KEY (Facturas_Id)
    REFERENCES Facturas (Id);

-- Reference: Publicaciones_Empresas (table: Publicaciones)
ALTER TABLE Publicaciones ADD CONSTRAINT Publicaciones_Empresas
    FOREIGN KEY (Empresa_Id)
    REFERENCES Empresa (Id);

-- Reference: Publicaciones_Grados_publicacion (table: Publicaciones)
ALTER TABLE Publicaciones ADD CONSTRAINT Publicaciones_Grados_publicacion
    FOREIGN KEY (Grados_publicacion_Id)
    REFERENCES Grados_publicacion (Id);

-- Reference: Publicaciones_Rubros (table: Publicaciones)
ALTER TABLE Publicaciones ADD CONSTRAINT Publicaciones_Rubros
    FOREIGN KEY (Rubros_Id)
    REFERENCES Rubros (Id);

-- Reference: Rol_Funcionalidad_Funcionalidad (table: Rol_Funcionalidad)
ALTER TABLE Rol_Funcionalidad ADD CONSTRAINT Rol_Funcionalidad_Funcionalidad
    FOREIGN KEY (Funcionalidad_Id)
    REFERENCES Funcionalidad (Id);

-- Reference: Rol_Funcionalidad_Rol (table: Rol_Funcionalidad)
ALTER TABLE Rol_Funcionalidad ADD CONSTRAINT Rol_Funcionalidad_Rol
    FOREIGN KEY (Rol_Id)
    REFERENCES Rol (Id);

-- Reference: Tajetas_Clientes (table: Tajetas)
ALTER TABLE Tajetas ADD CONSTRAINT Tajetas_Clientes
    FOREIGN KEY (Cliente_Id)
    REFERENCES Cliente (Id);

-- Reference: Tipos_publicacion_Grados_publicacion (table: Tipos_publicacion)
ALTER TABLE Tipos_publicacion ADD CONSTRAINT Tipos_publicacion_Grados_publicacion
    FOREIGN KEY (Grados_publicacion_Id)
    REFERENCES Grados_publicacion (Id);

-- Reference: Ubicacion_Compra (table: Ubicacion)
ALTER TABLE Ubicacion ADD CONSTRAINT Ubicacion_Compra
    FOREIGN KEY (Compra_Id)
    REFERENCES Compra (Id);

-- Reference: Ubicacion_Publicaciones (table: Ubicacion)
ALTER TABLE Ubicacion ADD CONSTRAINT Ubicacion_Publicaciones
    FOREIGN KEY (Publicaciones_Id)
    REFERENCES Publicaciones (Id);

-- Reference: Usuario_Rol_Rol (table: Usuario_Rol)
ALTER TABLE Usuario_Rol ADD CONSTRAINT Usuario_Rol_Rol
    FOREIGN KEY (Rol_Id)
    REFERENCES Rol (Id);

-- Reference: Usuario_Rol_Usuario (table: Usuario_Rol)
ALTER TABLE Usuario_Rol ADD CONSTRAINT Usuario_Rol_Usuario
    FOREIGN KEY (Usuario_Id)
    REFERENCES Usuario (Id);

	
-- Reference: Usuarios_Tipos_usuario (table: Usuario)
ALTER TABLE Usuario ADD CONSTRAINT Usuarios_Tipos_usuario
    FOREIGN KEY (Tipos_usuario_Id)
    REFERENCES Tipos_usuario (Id);
	
--*******************************INSERT***********************************	--
/* INSERT FUNCIONALIDADES */
print('Cargando tabla de funcionalidad...')
INSERT INTO CAMPUS_ANALYTICA.FUNCIONALIDAD (Funcionalidad_Descripcion) VALUES ('ABM de Rol')
INSERT INTO CAMPUS_ANALYTICA.FUNCIONALIDAD (Funcionalidad_Descripcion) VALUES ('ABM de Usuario')
INSERT INTO CAMPUS_ANALYTICA.FUNCIONALIDAD (Funcionalidad_Descripcion) VALUES ('ABM de Cliente')
INSERT INTO CAMPUS_ANALYTICA.FUNCIONALIDAD (Funcionalidad_Descripcion) VALUES ('ABM de Empresa de espectáculos')
INSERT INTO CAMPUS_ANALYTICA.FUNCIONALIDAD (Funcionalidad_Descripcion) VALUES ('ABM de Categoría')
INSERT INTO CAMPUS_ANALYTICA.FUNCIONALIDAD (Funcionalidad_Descripcion) VALUES ('ABM grado de publicación')
INSERT INTO CAMPUS_ANALYTICA.FUNCIONALIDAD (Funcionalidad_Descripcion) VALUES ('Generar Publicación')
INSERT INTO CAMPUS_ANALYTICA.FUNCIONALIDAD (Funcionalidad_Descripcion) VALUES ('Editar Publicación')
INSERT INTO CAMPUS_ANALYTICA.FUNCIONALIDAD (Funcionalidad_Descripcion) VALUES ('Comprar')
INSERT INTO CAMPUS_ANALYTICA.FUNCIONALIDAD (Funcionalidad_Descripcion) VALUES ('Historial del cliente')
INSERT INTO CAMPUS_ANALYTICA.FUNCIONALIDAD (Funcionalidad_Descripcion) VALUES ('Canje y administración de puntos')
INSERT INTO CAMPUS_ANALYTICA.FUNCIONALIDAD (Funcionalidad_Descripcion) VALUES ('Generar Pago de comisiones')
INSERT INTO CAMPUS_ANALYTICA.FUNCIONALIDAD (Funcionalidad_Descripcion) VALUES ('Listado Estadístico')	


/* INSERT ROLES*/
print('Cargando tabla de rol...')
INSERT INTO CAMPUS_ANALYTICA.ROL (Rol_Nombre) VALUES ('Administrador')
INSERT INTO CAMPUS_ANALYTICA.ROL (Rol_Nombre) VALUES ('Empresa')
INSERT INTO CAMPUS_ANALYTICA.ROL (Rol_Nombre) VALUES ('Cliente')




