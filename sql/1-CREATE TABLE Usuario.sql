create database TodoList;

USE TodoList;

CREATE TABLE Usuario
(
    Id uniqueidentifier PRIMARY KEY,
    Nome varchar(255),
    Email varchar(255),
    Senha varchar(255)
);
