create database WebP
go
use WebP
go
create table Prods
	(
	Id uniqueidentifier primary key,
	Nome varchar(25) not null,
	Prezzo decimal(10,2) null
	)
go
insert Prods values('75042d42-9b8b-4093-b39b-b3f5379c41d0','Prod0',0.0)
insert Prods values('75042d42-9b8b-4093-b39b-b3f5379c41d1','Prod1',1.01)
insert Prods values('75042d42-9b8b-4093-b39b-b3f5379c41d2','Prod2',2.02)
insert Prods values('75042d42-9b8b-4093-b39b-b3f5379c41d3','Prod3',3.03)
insert Prods values('75042d42-9b8b-4093-b39b-b3f5379c41d4','Prod4',4.04)
insert Prods values('75042d42-9b8b-4093-b39b-b3f5379c41d5','Prod5',5.05)
insert Prods values('75042d42-9b8b-4093-b39b-b3f5379c41d6','Prod6',6.06)
insert Prods values('75042d42-9b8b-4093-b39b-b3f5379c41d7','Prod7',7.07)
insert Prods values('75042d42-9b8b-4093-b39b-b3f5379c41d8','Prod8',8.08)
insert Prods values('75042d42-9b8b-4093-b39b-b3f5379c41d9','Prod9',9.09)
go
select * from Prods