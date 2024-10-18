create database LoginCore;
use LoginCore;

create table Cliente(
Id int auto_increment primary key,
Nome Varchar(50) not null,
Nascimento DateTime not null,
Sexo char(1),
CPF Varchar(15) not null,
Telefone Varchar(14) not null,
Email Varchar(50) not null,
Senha Varchar(8) not null,
ConfirmacaoSenha Varchar(8) not null,
Situacao char(1) not null
);

create table Colaborador(
Id int auto_increment primary key,
Nome Varchar(50) not null,
Email Varchar(50) not null,
Senha Varchar(8) not null,
Tipo Varchar(8) not null
);


select * from cliente where Email ="nilsonalcise@gmail.com" and Senha = "123456";
select * from cliente where Email = @Email and Senha = @Senha;

insert into Cliente(Nome, Nascimento, Sexo,  CPF, Telefone, Email, Senha, Situacao)
Values("NILSON JOSE ALCIDES","1978-05-01", "M", 
"02587564120", "(11)5872-1919", "nilsonalcise@gmail.com", "123456", "A");

alter table Colaborador add column CPF varchar(11);
alter table Colaborador add column Telefone varchar(14);

desc Colaborador;

insert into Colaborador (Nome, Email, Senha, Tipo)
values("Thiago Alcides","Thiago@gmal.com","123456","G"),
("Bruno Eduaardo","bruno@gmail.com","123456","C");
select * from Colaborador where Email ="Thiago@gmail.com" and Senha = "123456";
update Colaborador set CPF="45645678910", Telefone="11965478596" where Id = 2;
select * from Colaborador where Email ="bruno@gmail.com" and Senha = "123456";
SELECT * FROM COLABORADOR;