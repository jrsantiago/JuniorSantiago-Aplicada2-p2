create table Articulos(
ArticuloId int primary key identity,
Descripcion varchar(150),
Existencia int,
Precio float
);
go
create table Ventas(
VentaId int primary key identity,
Fecha varchar(150),
Monto float
);
go 
create table VentasDetalle(
Id int primary key identity,
VentaId int references Ventas(VentaId),
ArticuloId int references Articulos(ArticuloId),
Cantidad int,
Precio float
);
go

Insert into Articulos(Descripcion,Existencia,Precio) Values('Lapiz',25,10);
Insert into Articulos(Descripcion,Existencia,Precio) Values('Borra',40,20);
Insert into Articulos(Descripcion,Existencia,Precio) Values('Cuaderno',30,30);
Insert into Articulos(Descripcion,Existencia,Precio) Values('Folder',50,40);
