
													/*---TABLAS---*/

/*Tabla eventos*/
create table eventos(
id_e				int primary key identity,
id_c				varchar(50),
titulo_e			varchar(180),
descripcion_e		varchar(300),
foto_e				varchar(100),
ubicacion_e			varchar(70),
fecha_e				date,
horainicio_e		varchar(30),
hora_finalizacion_e varchar(30),
entidad_e			varchar(70),
tipo_e              varchar(30)
);
  


/*CREATE*/
GO
create procedure insertar_evento(
@titulo_		varchar(180),
@id_c       	varchar(50),
@descripcion_	varchar(300),
@foto_			varchar(100),
@ubicacion_		varchar(70),
@fecha_			date,
@horainicio_	varchar(30),
@horafin_		varchar(30),
@entidad_		varchar(70),
@tipo_			varchar(30)
) 
as begin
insert into evento (titulo_e, id_c, descripcion_e,foto_e,ubicacion_e, fecha_e, 
horainicio_e, horafin_e,entidad_e,tipo_e) 
values (@titulo_,@id_c,@descripcion_,@foto_,@ubicacion_,@fecha_,
@horainicio_,@horafin_,@entidad_,@tipo_);
end
GO
/*UPDATE*/
alter procedure actualizar_evento
(@id_ int,
@titulo_ varchar(180),
@idc  varchar(50),
@descripcion_ varchar(300),
@foto_ varchar(100),
@ubicacion_ varchar(70),
@fecha_ date null,
@horainicio_ varchar(30),
@horafin_ varchar(30),
@entidad_ varchar(70),
@tipo_ varchar(30))
as begin
update eventos set 
titulo_e = @titulo_,
id_c = @idc,
descripcion_e = @descripcion_,
foto_e = @foto_,
ubicacion_e = @ubicacion_,
fecha_e = @fecha_ ,
horainicio_e = @horainicio_ ,
hora_finalizacion_e = @horafin_ ,
entidad_e = @entidad_,
tipo_e = @tipo_  where id_e = @id_;
end
GO
/*DELETE*/
create procedure eliminar_evento(@id_ int)
as begin
delete from eventos where id_e = @id_;
end
GO

GO
/*READ EVENTOS*/
create procedure busquedaeventos(
@id int null,
@titulo varchar(50) null,
@categoria varchar(30) null)
as begin
	select *from eventos where
	 eventos.id_e = @id or
	 eventos.titulo_e like '%'+@titulo+'%' or
	  eventos.id_c = @categoria;
 end

 exec busquedaeventos null, 'Festival'; 

 /*buscar eventos(datagrid)*/
 go
 alter procedure select_eventos(@id int)
 as begin
 select *from eventos where id_e = @id;
 end

 /*Buscar evento por Titulo y categoria*/
 create procedure buscar_titulo_categoria(
 @titulo varchar(100) null, 
 @categoria varchar(30) null)
 as begin
 select *from eventos where eventos.titulo_e like '%'+ @titulo+ '%' or eventos.id_c = @categoria;
 end

 exec buscar_titulo_categoria 'ds', null;

use testEventos;
select *from eventos;
delete from eventos;
