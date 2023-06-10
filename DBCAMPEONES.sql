--CREATE DATABASE BDCAMPEONES
--GO
USE BDCAMPEONES
GO

CREATE TABLE CAMPEON(
IdCampeon int identity,
Nombres varchar (100),
Rol varchar (100),
Ataque varchar (100),
Da�o varchar (100)
)

insert INTO CAMPEON (Nombres,Rol,Ataque,Da�o) values
('Cho Gath','Tanque','Cuerpo a Cuerpo','Fisico y magico'),
('Illaoi','Asesino Tanque','Cuerpo a Cuerpo','Fisico'),
('Neeko','Mago Tirador','Distancia','Magico'),
('Pantheon','Asesino','Cuerpo a Cuerpo','Fisico'),
('Vex','Mago','Distancia','Magico')

SELECT * FROM CAMPEON
GO

CREATE PROCEDURE PA_CREARCAMPEON(
@Nombre varchar (100),
@Rol varchar (100),
@Ataque varchar (100),
@Da�o varchar (100)
)
as
begin
	insert INTO CAMPEON (Nombres,Rol,Ataque,Da�o) values (@Nombre,@Rol,@Ataque,@Da�o)
END
GO


CREATE PROCEDURE PA_EDITARCAMPEON(
@IdCampeon Int,
@Nombre varchar (100),
@Rol varchar (100),
@Ataque varchar (100),
@Da�o varchar (100)
)
as
begin
	UPDATE CAMPEON SET Nombres = @Nombre , Rol = @Rol, Ataque = @Ataque, Da�o = @Da�o where IdCampeon = @IdCampeon
END
go

CREATE PROCEDURE PA_ELIMINARCAMPEON(
@IdCampeon Int
)
as
begin
	DELETE FROM CAMPEON where IdCampeon = @IdCampeon
END
