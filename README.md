
# Projeto Final

Projeto de finalização da academia de .Net da Atos em Parceria com a UFN


## Referência

 - [Entity Framework](https://learn.microsoft.com/en-us/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/creating-an-entity-framework-data-model-for-an-asp-net-mvc-application)
 - [ASP .NET Core](https://learn.microsoft.com/pt-br/aspnet/core/release-notes/aspnetcore-7.0?view=aspnetcore-7.0)
 
## Autores

- [@colovatto](https://github.com/colovatto)


## Rodando localmente

Clone o projeto

```bash
  git clone https://github.com/colovatto/ProjetoFinal.git
```

Entre no diretório do projeto

```bash
  cd my-project
```

Instale as dependências

```bash
  npm install
```

Inicie o servidor

```bash
  npm run start
```


## Screenshots

![App Screenshot](https://i.imgur.com/BUw5j0H.png)

![App Screenshot](https://i.imgur.com/4tYXKac.png)


## Stack utilizada

**Front-end:** Html5, CSS3

**Back-end:** ASP .Net Core MVC


## Criar DataBase

No Sql Server faça o seguinte comando

```bash
  create database ServiceDesk

create table Usuario 
( 
serId integer identity primary key not null,
userNome varchar(100) not null, 
userLogin varchar(20) not null,
userSenha varchar(16) not null, )

create table Ticket ( 
ticketId integer identity primary key not null,
ticketNome varchar(100) not null, 
ticketEmail varchar(50) not null,
ticketTel varchar(50) not null, 
ticketHora varchar(50) not null, ticketEvidencia varbinary(max), 
ticketCategoria varchar(100) not null, 
ticketDescricao varchar(2000) not null
)
```
    
