create database Mercado;
USE Mercado;

CREATE TABLE Categorias(
    nome_categoria varchar(100) PRIMARY KEY NOT NULL
);

create table Produtos(
	id_produto INT AUTO_INCREMENT PRIMARY KEY,
	nome_produto varchar(100) NOT NULL,
    preco decimal(10,2) NOT NULL,
    quantidade_estoque int NOT NULL,
    nome_categoria varchar(100) NOT NULL,
    fornecedor varchar(100) NOT NULL,
    foreign key(nome_categoria) references Categorias (nome_categoria)
);

