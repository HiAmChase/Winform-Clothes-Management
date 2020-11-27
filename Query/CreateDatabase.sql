CREATE DATABASE QuanLyQuanAo
GO

USE QuanLyQuanAo
GO
CREATE TABLE Staff
(
	IDAccount INT IDENTITY
		CONSTRAINT PK_IDAccount PRIMARY KEY,
	Username NVARCHAR(100) NOT NULL,
	Password NVARCHAR(1000) NOT NULL,
	Status INT NOT NULL DEFAULT 0,
	Name NVARCHAR(50) NOT NULL,
	Address NVARCHAR(100),
	Phone NVARCHAR(50) NOT NULL,
	Email NVARCHAR(50)
)
GO
INSERT INTO Staff(Username,Password,Status,Name,Address,Phone,Email)
VALUES (N'Vinh',N'1',1,N'Vĩnh',N'Wellington city',N'0354175296',N'typhuso1thegioi@gmail.com'),
		(N'Thinh',N'1',0,N'Thịnh',N'Newyork city',N'0359999999',N'seplonkhotinh@gmail.com')
GO

CREATE TABLE Type
(
	IDType INT IDENTITY
		CONSTRAINT PK_IDType PRIMARY KEY,
	Name NVARCHAR(50) NOT NULL DEFAULT N'Chưa đặt tên'
)
GO

INSERT INTO Type(Name)
VALUES (N'Không'),
	(N'Áo sơ mi'),
	(N'Quần dài'),
	(N'Mũ'),
	(N'Giày'),
	(N'Váy'),
	(N'Áo ấm'),
	(N'Quần jean')


SELECT * From Type


CREATE TABLE Branch
(
	IDBranch INT IDENTITY
		CONSTRAINT PK_IDBranch PRIMARY KEY,
	Name NVARCHAR(50) NOT NULL DEFAULT N'Chưa đặt tên'
)
GO

INSERT INTO Branch(Name)
VALUES (N'Không'),
(N'NIKE'),
(N'GUCCI'),
(N'Adidas'),
(N'North face'),
(N'Lacoste')

SELECT * From Branch

CREATE TABLE Supplier
(	
	IDSupplier INT IDENTITY
		CONSTRAINT PK_IDSupplier PRIMARY KEY,
	Name NVARCHAR(50) NOT NULL,
	Address NVARCHAR(100),
	Phone NVARCHAR(50) NOT NULL,
	Email NVARCHAR(50),
	IDBranch INT DEFAULT 1,
)


INSERT INTO Supplier(Name, Address , Phone, Email, IDBranch)
VALUES
(N'Không', N'Không', N'Không', N'Không', 1),
(N'Ngọc Thịnh', N'29 Trần Xuân Lê', N'0898208980', N'Không', 2),
(N'Văn Vĩnh',N'Lệ Bắc',N'0354175296',N'vanvinhqn2310@gmail.com',3)

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
	Amount INT DEFAULT 1,
)
GO

CREATE TABLE Client
(
	IDClient INT IDENTITY
		CONSTRAINT PK_IDClient PRIMARY KEY,
	Name NVARCHAR(50) NOT NULL,
	Address NVARCHAR(100) NOT NULL,
	Phone NVARCHAR(50) NOT NULL,
	Email NVARCHAR(50)
)


INSERT INTO Client (Name, Address, Phone, Email)
VALUES
(N'Không', N'Không', N'Không', N'Không'),
(N'Ngọc Thịnh', N'29 Trần Xuân Lê', N'0898208980', N'Không'),
(N'Văn Vĩnh',N'Lệ Bắc',N'0354175296',N'vanvinhqn2310@gmail.com')

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
	Amount INT DEFAULT 1,
)

CREATE TABLE Size
(
	IDSize INT IDENTITY
		CONSTRAINT PK_IDSize PRIMARY KEY,
	Size NVARCHAR(10) NOT NULL DEFAULT 'Không'
)
GO

INSERT INTO Size(Size)
VALUES ('Không'), ('S'), ('M'), ('L'), ('XL'), ('XXL')


CREATE TABLE Color
(
	IDColor INT IDENTITY
		CONSTRAINT PK_IDColor PRIMARY KEY,
	Color NVARCHAR(20) NOT NULL DEFAULT N'Không'
)
GO
INSERT INTO Color(Color)
VALUES (N'Không'),
(N'Đỏ'),
(N'Vàng'),
(N'Cam'),
(N'Lục'),
(N'Lam'),
(N'Chàm'),
(N'Tím')

CREATE TABLE Product
(
	IDProduct INT IDENTITY
		CONSTRAINT PK_IDProduct PRIMARY KEY,
	Name NVARCHAR(50) NOT NULL DEFAULT N'Chưa đặt tên',
	IDType INT NOT NULL DEFAULT 1,
	IDSupplier INT NOT NULL DEFAULT 1,
	IDSize INT NOT NULL DEFAULT 1,
	IDColor INT NOT NULL DEFAULT 1,
	Amount INT DEFAULT 1,
	Unit NVARCHAR(50) NOT NULL DEFAULT N'Cái',
	PriceOut DECIMAL(19, 4) DEFAULT 1000,
	PriceIn DECIMAL(19, 4) DEFAULT 1000
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
ADD CONSTRAINT FK_Product_IDSupplier
	FOREIGN KEY (IDSupplier)
	REFERENCES Supplier(IDSupplier),
	
	CONSTRAINT FK_Product_IDType
	FOREIGN KEY (IDType)
	REFERENCES Type(IDType)
	ON UPDATE CASCADE ON DELETE SET DEFAULT,

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

SELECT * FROM Client

SELECT * FROM Supplier

INSERT INTO Product (Name, IDType, IDSupplier, IDSize, IDColor, Amount, Unit, PriceOut, PriceIn)
VALUES
(N'Áo hoodie', 4, 1, 2, 2, 50, N'Cái', 750000,12000),
(N'Quần jean', 3, 2, 2, 3, 20, N'Cái', 900000,10000),
(N'Giày thể thao', 6, 1, 4, 3, 10, N'Đôi', 350000,20000),
(N'Mũ', 1, 2, 1, 4, 25, N'Cái', 50000,20000)
GO


SELECT * FROM Product

SELECT B.* FROM BillExportInfo B

SELECT B.*
FROM
	BillExportInfo B
INNER JOIN
	Product P
ON
	B.IDProduct = P.IDProduct
GO

--DECLARE @Amount INT = 3, @IDProduct INT = 3
--SELECT P.IDProduct, P.Name, P.Price, @Amount, P.Price * @Amount AS [TotalPrice]
--FROM
--	Product P
--WHERE P.IDProduct = @IDProduct
GO

SELECT * FROM staff
go
