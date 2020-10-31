﻿CREATE DATABASE QuanLyQuanAo
GO

USE QuanLyQuanAo
GO



CREATE TABLE Type
(
	IDType INT IDENTITY
		CONSTRAINT PK_IDType PRIMARY KEY,
	Name NVARCHAR(50) NOT NULL DEFAULT N'Chưa đặt tên'
)
GO

INSERT INTO Type(Name)
VALUES (N'Không')

SELECT * From Type


CREATE TABLE Branch
(
	IDBranch INT IDENTITY
		CONSTRAINT PK_IDBranch PRIMARY KEY,
	Name NVARCHAR(50) NOT NULL DEFAULT N'Chưa đặt tên'
)
GO

INSERT INTO Branch(Name)
VALUES (N'Không')

SELECT * From Branch

CREATE TABLE Supplier
(	
	IDSupplier INT IDENTITY
		CONSTRAINT PK_IDSupplier PRIMARY KEY,
	Name NVARCHAR(50) NOT NULL,
	Address NVARCHAR(50),
	Phone NVARCHAR(50) NOT NULL,
	Email NVARCHAR(50),
	IDBranch INT DEFAULT 1,
)

INSERT INTO Supplier(Name, Address , Phone, Email)
VALUES (N'Không', N'Không', N'Không', N'Không')

CREATE TABLE BillImport
(
	IDBillImport INT IDENTITY
		CONSTRAINT PK_IDBillImport PRIMARY KEY,
	IDSupplier INT NOT NULL DEFAULT 1,
	DateIn DATETIME NOT NULL,
)
GO

CREATE TABLE BillImportInfo
(
	IDBillImport INT NOT NULL,
	IDProduct INT NOT NULL,
	SoLuong INT DEFAULT 1,
	CONSTRAINT PK_IDImport_IDProduct PRIMARY KEY (IDBillImport, IDProduct)
)
GO

CREATE TABLE Client
(
	IDClient INT IDENTITY
		CONSTRAINT PK_IDClient PRIMARY KEY,
	Name NVARCHAR(50) NOT NULL,
	Address NVARCHAR(50) NOT NULL,
	Phone NVARCHAR(50) NOT NULL,
	Email NVARCHAR(50)
)

INSERT INTO Client (Name, Address, Phone, Email)
VALUES
(N'Không', N'Không', N'Không', N'Không')

SELECT * FROM Client

CREATE TABLE BillExport
(
	IDBillExport INT IDENTITY
		CONSTRAINT PK_IDBillExport PRIMARY KEY,
	IDClient INT NOT NULL DEFAULT 1,
	DateOut DATETIME NOT NULL,
)
GO

CREATE TABLE BillExportInfo
(
	IDBillExport INT NOT NULL,
	IDProduct INT NOT NULL,
	SoLuong INT DEFAULT 1,
	CONSTRAINT PK_IDBillExport_IDProduct PRIMARY KEY (IDBillExport, IDProduct)
)

CREATE TABLE Size
(
	IDSize INT IDENTITY
		CONSTRAINT PK_IDSize PRIMARY KEY,
	Size INT NOT NULL DEFAULT 1
)
GO
INSERT INTO Size(Size)
VALUES (1)

CREATE TABLE Color
(
	IDColor INT IDENTITY
		CONSTRAINT PK_IDColor PRIMARY KEY,
	Color NVARCHAR(20) NOT NULL DEFAULT N'Không'
)
GO
INSERT INTO Color(Color)
VALUES (N'Không')

CREATE TABLE Product
(
	IDProduct INT IDENTITY
		CONSTRAINT PK_IDProduct PRIMARY KEY,
	Name NVARCHAR(50) NOT NULL DEFAULT N'Chưa đặt tên',
	IDType INT NOT NULL DEFAULT 1,
	IDBranch INT NOT NULL DEFAULT 1,
	IDSize INT NOT NULL DEFAULT 1,
	IDColor INT NOT NULL DEFAULT 1,
	Amount INT DEFAULT 1,
	Unit NVARCHAR(50) NOT NULL DEFAULT N'Cái',
	Price DECIMAL(19, 4) DEFAULT 1000
)
GO

ALTER TABLE Supplier
ADD 
	CONSTRAINT FK_Supplier_IDBranch
	FOREIGN KEY (IDBranch) 
	REFERENCES Branch(IDBranch)
	ON UPDATE CASCADE ON DELETE SET DEFAULT

ALTER TABLE BillImport
ADD CONSTRAINT FK_BillImport_IDSupplier
	FOREIGN KEY (IDSupplier)
	REFERENCES Supplier(IDSupplier)
	ON UPDATE CASCADE

ALTER TABLE BillExport
ADD CONSTRAINT FK_BillExport_IDClient
	FOREIGN KEY (IDClient)
	REFERENCES Client(IDClient)
	ON UPDATE CASCADE

ALTER TABLE BillImportInfo
ADD CONSTRAINT FK_BillImportInfo_IDBillImport
	FOREIGN KEY (IDBillImport)
	REFERENCES BillImport(IDBillImport)
	ON UPDATE CASCADE,

    CONSTRAINT FK_BillImportInfo_IDProduct
	FOREIGN KEY (IDProduct)
	REFERENCES Product(IDProduct)
	ON UPDATE CASCADE

ALTER TABLE BillExportInfo
ADD CONSTRAINT FK_BillExportInfo_IDBillExport
	FOREIGN KEY (IDBillExport)
	REFERENCES BillExport(IDBillExport)
	ON UPDATE CASCADE,

    CONSTRAINT FK_BillExportInfo_IDProduct
	FOREIGN KEY (IDProduct)
	REFERENCES Product(IDProduct)
	ON UPDATE CASCADE

ALTER TABLE Product
ADD CONSTRAINT FK_Product_IDType
	FOREIGN KEY (IDType)
	REFERENCES Type(IDType)
	ON UPDATE CASCADE ON DELETE SET DEFAULT,

	CONSTRAINT FK_Product_IDBranch
	FOREIGN KEY (IDBranch)
	REFERENCES Branch(IDBranch),

	CONSTRAINT FK_Product_IDColor
	FOREIGN KEY (IDColor)
	REFERENCES Color(IDColor)
	ON UPDATE CASCADE ON DELETE SET DEFAULT,

	CONSTRAINT FK_Product_IDSize
	FOREIGN KEY (IDSize)
	REFERENCES Size(IDSize)
	ON UPDATE CASCADE ON DELETE SET DEFAULT

SELECT * FROM Type

SELECT * FROM Branch

SELECT * FROM Size

SELECT * FROM Color

SELECT * FROM Product

INSERT INTO Product (Name, IDType, IDBranch, IDSize, IDColor, Amount, Unit, Price)
VALUES
(N'Áo hoodie', 4, 3, 2, 2, 50, N'Cái', 750000),
(N'Quần jean', 3, 2, 2, 3, 20, N'Cái', 900000),
(N'Giày thể thao', 6, 4, 4, 3, 10, N'Đôi', 350000),
(N'Mũ', 1, 1, 1, 4, 25, N'Cái', 50000)

