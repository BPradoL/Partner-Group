create database DbControlePatrimonio

create table tbPatrimonio
(
MarcaId int primary key,
Nome varchar(20) unique not null,
Descricao varchar(100),
NTombo int identity,
)

create table tbMarca
(
MarcaId int primary key,
Nome varchar(20) unique not null
)

