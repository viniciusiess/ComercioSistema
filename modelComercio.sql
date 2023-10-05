create database comercio_db;
use comercio_db;

create table Cliente(
	id int unsigned not null auto_increment primary key,
    cpf_cnpj varchar(18) not null,
    nome varchar(100) not null,
    telefone varchar(14) not null,
    email varchar(100) not null,
    logradouro varchar(100) not null,
    numero varchar(20) not null,
    complemento varchar(100),
    bairro varchar(50) not null,
    cidade varchar(50) not null,
    uf char(2) not null,
    cep varchar(10) not null,
    INDEX (nome)
);

create table Fornecedor(
	id int unsigned not null auto_increment primary key,
    cpf_cnpj varchar(18) not null,
    nome varchar(100) not null,
    telefone varchar(14) not null,
    email varchar(100) not null,
    logradouro varchar(100) not null,
    numero varchar(20) not null,
    complemento varchar(100),
    bairro varchar(50) not null,
    cidade varchar(50) not null,
    uf char(2) not null,
    cep varchar(10) not null,
    INDEX (nome)
);

create table ClassificacaoProduto(
	id int unsigned auto_increment primary key,
    nome varchar(100) not null,
    descricao TEXT
);

CREATE TABLE Produto(
	id int unsigned not null auto_increment primary key,
    nome varchar(100) not null,
    estoque int not null,
    preco decimal (10,2) not null,
    unidade varchar(20),
    fornecedor_id int unsigned,
    classificacao_id int unsigned,
    foreign key (fornecedor_id) references Fornecedor(id),
    foreign key (classificacao_id) references ClassificacaoProduto(id),
	INDEX(nome)
);

CREATE TABLE Venda (
	id int unsigned not null auto_increment primary key,
	quantidade int,
    valor_unitario decimal(10,2),
    data_hora_venda datetime,
    total decimal(10,2),
    tipo_pagamento varchar(50),
    parcelado varchar(3),
    parcelamento_vezes int,
    cliente_id int unsigned,
	produto_id int unsigned,
    foreign key (cliente_id) references Cliente(id),
    foreign key (produto_id) references Produto(id)
);
