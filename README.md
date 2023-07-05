# ProjetoFinal

Victor Colovatto Borioli é o criador do sistema, com o propósito de implementar um projeto para a finalização da Academia de .Net da Atos em parceria com a UFN.
Estudante de Análise e Desenvolvimento de Sistemas, técnico em Informática pelo SENAI e atualmente trabalhando na Atos como analista de Service Desk procura solucionar alguns problemas nas aplicações de Help Desk, como a complexidade dos sistemas e a lentidão.




===============================================================================================================================================================

Realizar criação de banco de dados no sql server:

create database ServiceDesk

create table Usuario
(
	userId integer identity primary key not null,
	userNome varchar(100) not null,
	userLogin varchar(20) not null,
	userSenha varchar(16) not null,
)

create table Ticket
(
	ticketID userId integer identity primary key not null,
	ticketNome varchar(100) not null,
	ticketEmail varchar(50) not null,
	ticketTel varchar(50) not null,
	ticketHora varchar(50) not null,
	ticketEvidencia varbinary(max),
	ticketCategoria varchar(100) not null,
	ticketDescricao varchar(2000) not null
	
)
