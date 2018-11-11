


-- foreign keys
ALTER TABLE Canjes DROP CONSTRAINT Canjes_Premios;

ALTER TABLE ClienteDireccion DROP CONSTRAINT ClienteDireccion_Clientes;

ALTER TABLE ClienteDireccion DROP CONSTRAINT ClienteDireccion_Direccion;

ALTER TABLE Cliente DROP CONSTRAINT Clientes_Usuarios;

ALTER TABLE Compra DROP CONSTRAINT Compra_Clientes;

ALTER TABLE Compra DROP CONSTRAINT Compra_Tajetas;

ALTER TABLE EmpresaDireccion DROP CONSTRAINT EmpresaDireccion_Direccion;

ALTER TABLE EmpresaDireccion DROP CONSTRAINT EmpresaDireccion_Empresa;

ALTER TABLE Empresa DROP CONSTRAINT Empresas_Usuarios;

ALTER TABLE Facturas DROP CONSTRAINT Facturas_Empresas;

ALTER TABLE Canjes DROP CONSTRAINT Historial_canje_Clientes;

ALTER TABLE Items_factura DROP CONSTRAINT Items_factura_Facturas;

ALTER TABLE Publicaciones DROP CONSTRAINT Publicaciones_Empresas;

ALTER TABLE Publicaciones DROP CONSTRAINT Publicaciones_Grados_publicacion;

ALTER TABLE Publicaciones DROP CONSTRAINT Publicaciones_Rubros;

ALTER TABLE Rol_Funcionalidad DROP CONSTRAINT Rol_Funcionalidad_Funcionalidad;

ALTER TABLE Rol_Funcionalidad DROP CONSTRAINT Rol_Funcionalidad_Rol;

ALTER TABLE Tajetas DROP CONSTRAINT Tajetas_Clientes;

ALTER TABLE Tipos_publicacion DROP CONSTRAINT Tipos_publicacion_Grados_publicacion;

ALTER TABLE Ubicacion DROP CONSTRAINT Ubicacion_Compra;

ALTER TABLE Ubicacion DROP CONSTRAINT Ubicacion_Publicaciones;

ALTER TABLE Usuario_Rol DROP CONSTRAINT Usuario_Rol_Rol;

ALTER TABLE Usuario_Rol DROP CONSTRAINT Usuario_Rol_Usuario;

ALTER TABLE Usuario DROP CONSTRAINT Usuarios_Tipos_usuario;

-- tables
DROP TABLE Canjes;

DROP TABLE Cliente;

DROP TABLE ClienteDireccion;

DROP TABLE Compra;

DROP TABLE Direccion;

DROP TABLE Empresa;

DROP TABLE EmpresaDireccion;

DROP TABLE Facturas;

DROP TABLE Funcionalidad;

DROP TABLE Grados_publicacion;

DROP TABLE Items_factura;

DROP TABLE Premios;

DROP TABLE Publicaciones;

DROP TABLE Rol;

DROP TABLE Rol_Funcionalidad;

DROP TABLE Rubros;

DROP TABLE Tajetas;

DROP TABLE Tipos_publicacion;

DROP TABLE Tipos_usuario;

DROP TABLE Ubicacion;

DROP TABLE Usuario;

DROP TABLE Usuario_Rol;

-- End of file.

