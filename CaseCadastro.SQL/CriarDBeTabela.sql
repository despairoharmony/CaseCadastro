-- Criar banco de dados
CREATE DATABASE CadastroDatabase;
USE CadastroDatabase;

-- Criar o schema
CREATE SCHEMA CaseCadastro;

-- Criar a tabela no schema
CREATE TABLE CaseCadastro.Cadastro (
    ID INT IDENTITY(1,1)  PRIMARY KEY,
    Nome NVARCHAR(255),
    Sobrenome NVARCHAR(255),
    Idade NVARCHAR(5),
    Pais NVARCHAR(100)
);