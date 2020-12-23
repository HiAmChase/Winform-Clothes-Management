use QuanLyQuanAo
GO

INSERT INTO Staff(Username,Password,Status,Name,Address,Phone,Email)
VALUES (N'Vinh',N'1',1,N'Vĩnh',N'Wellington city',N'0354175296',N'typhuso1thegioi@gmail.com'),
		(N'Thinh',N'1',0,N'Thịnh',N'Newyork city',N'0359999999',N'ngocthinh@gmail.com')
GO


INSERT INTO Type(Name)
VALUES (N'Không'),
	(N'Áo'),
	(N'Quần'),
	(N'Mũ'),
	(N'Giày'),
	(N'Váy')
	
GO
INSERT INTO Branch(Name)
VALUES
(N'NIKE'),
(N'GUCCI'),
(N'Adidas'),
(N'North face'),
(N'Lacoste')

GO
INSERT INTO Supplier(Name, Address , Phone, Email, IDBranch)
VALUES
(N'Văn Hảo', N'Duy Châu', N'0908999999', N'vanhao565@gmail.com', 1),
(N'Ngọc Thịnh', N'29 Trần Xuân Lê', N'0898208980', N'Không', 2),
(N'Văn Vĩnh',N'Lệ Bắc',N'0354175296',N'vanvinhqn2310@gmail.com',3),
(N'David Naruto', N'Tokyo', N'0907777777', N'nangao@gmail.com',4),
(N'Hoài Linh',N'Tp Hồ Chí Minh', N'0912345678', N'chuhoailinh@gmail.com',5)

GO

INSERT INTO Client (Name, Address, Phone, Email)
VALUES
(N'Ngọc Thịnh', N'29 Trần Xuân Lê', N'0898208980', N'Không'),
(N'Văn Vĩnh',N'Lệ Bắc',N'0354175296',N'vanvinhqn2310@gmail.com')

GO 

INSERT INTO Size(Size)
VALUES ('S'), ('M'), ('L'), ('XL'), ('XXL')

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

INSERT INTO Product (Name, IDType, IDSupplier, IDSize, IDColor, Amount, Unit, PriceOut, PriceIn)
VALUES
(N'Áo hoodie', 1, 3, 2, 2, 50, N'Cái', 750000,12000),
(N'Quần jean', 2, 4, 2, 3, 20, N'Cái', 900000,10000),
(N'Giày thể thao', 4, 3, 3, 3, 10, N'Đôi', 350000,20000),
(N'Mũ', 3, 4, 4, 4, 25, N'Cái', 50000,20000)