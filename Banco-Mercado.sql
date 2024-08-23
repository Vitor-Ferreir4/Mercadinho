create database Mercado;
USE Mercado;

CREATE TABLE Categorias(
	id_categoria INT auto_increment PRIMARY KEY,
    nome_categoria varchar(100) NOT NULL
);

create table Produtos(
	id_produto INT AUTO_INCREMENT PRIMARY KEY,
	nome_produto varchar(100) NOT NULL,
    preco decimal(10,2) NOT NULL,
    quantidade_estoque int NOT NULL,
    id_categoria INT,
    fornecedor varchar(100) NOT NULL,
    foreign key(id_categoria) references Categorias (id_categoria)
);

