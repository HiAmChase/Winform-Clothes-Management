﻿CREATE DATABASE QuanLyQuanAo
GO

USE QuanLyQuanAo
GO

CREATE TABLE MatHang
(
	MaMatHang NVARCHAR(10) NOT NULL
		CONSTRAINT PK_MaMatHang PRIMARY KEY,
	TenMatHang NVARCHAR(30) NOT NULL DEFAULT N'Chưa đặt tên',
	MaLoai NVARCHAR(10) DEFAULT N'Không',
	MaChiTiet NVARCHAR(10) DEFAULT N'Không',
	MaThuongHieu NVARCHAR(10) DEFAULT N'Không',
	SoLuong INT DEFAULT 1,
	DonViTinh NVARCHAR(10) NOT NULL,
	DonGia DECIMAL(19, 4) DEFAULT 1000
)

CREATE TABLE Loai
(
	MaLoai NVARCHAR(10) NOT NULL
		CONSTRAINT PK_MaLoai PRIMARY KEY,
	TenLoai NVARCHAR(10) NOT NULL
)

CREATE TABLE CTMatHang
(
	MaChiTiet NVARCHAR(10) NOT NULL
		CONSTRAINT PK_MaChiTiet PRIMARY KEY,
	TenLoaiVai NVARCHAR(10),
	KichCo INT,
	MauSac NVARCHAR(10),
)

CREATE TABLE ThuongHieu
(
	MaThuongHieu NVARCHAR(10)
		CONSTRAINT PK_MaThuongHieu PRIMARY KEY,
	TenThuongHieu NVARCHAR(10) NOT NULL
)

CREATE TABLE NhaCungCap
(	
	MaNhaCungCap NVARCHAR(10) NOT NULL
		CONSTRAINT PK_MaNhaCungCap PRIMARY KEY,
	TenNhaCungCap NVARCHAR(20) NOT NULL,
	DiaChi NVARCHAR(20) NOT NULL,
	DienThoai NVARCHAR(10) NOT NULL,
	Email NVARCHAR(20),
	MaThuongHieu NVARCHAR(10) DEFAULT N'Không',
)

CREATE TABLE CTDonNhapHang
(
	MaDonNhap NVARCHAR(10) NOT NULL,
	MaMatHang NVARCHAR(10) NOT NULL,
	SoLuong INT DEFAULT 1,
	CONSTRAINT PK_MaDonNhap_MaMatHang PRIMARY KEY (MaDonNhap, MaMatHang),
)

CREATE TABLE HoaDonNhap
(
	MaDonNhap NVARCHAR(10) NOT NULL
		CONSTRAINT PK_MaDonNhap PRIMARY KEY,
	MaNhaCungCap NVARCHAR(10) NOT NULL,
	NgayGD DATETIME NOT NULL,
)

CREATE TABLE CTDonBanHang
(
	MaDonBan NVARCHAR(10) NOT NULL,
	MaMatHang NVARCHAR(10) NOT NULL,
	SoLuong INT DEFAULT 1,
	CONSTRAINT PK_MaDonBan_MaMatHang PRIMARY KEY (MaDonBan, MaMatHang)
)

CREATE TABLE HoaDonBan
(
	MaDonBan NVARCHAR(10) NOT NULL
		CONSTRAINT PK_MaDonBan PRIMARY KEY,
	MaKhachHang NVARCHAR(10) NOT NULL,
	NgayGD DATETIME NOT NULL,
)

CREATE TABLE KhachHang
(
	MaKhachHang NVARCHAR(10) NOT NULL
		CONSTRAINT PK_MaKhachHang PRIMARY KEY,
	TenKhachHang NVARCHAR(20) NOT NULL,
	DiaChi NVARCHAR(20) NOT NULL,
	DienThoai NVARCHAR(10) NOT NULL,
	Email NVARCHAR(20)
)

ALTER TABLE NhaCungCap
ADD 
	CONSTRAINT FK_NhaCungCap_MaThuongHieu
	FOREIGN KEY (MaThuongHieu) 
	REFERENCES ThuongHieu(MaThuongHieu)
	ON UPDATE CASCADE ON DELETE SET DEFAULT 

ALTER TABLE HoaDonNhap
ADD CONSTRAINT FK_HoaDonNhap_MaNhaCungCap
	FOREIGN KEY (MaNhaCungCap)
	REFERENCES NhaCungCap(MaNhaCungCap)
	ON UPDATE CASCADE

ALTER TABLE HoaDonBan
ADD CONSTRAINT FK_HoaDonBan_MaKhachHang
	FOREIGN KEY (MaKhachHang)
	REFERENCES KhachHang(MaKhachHang)
	ON UPDATE CASCADE

ALTER TABLE CTDonBanHang
ADD CONSTRAINT FK_CTDonBanHang_MaDonBan
	FOREIGN KEY (MaDonBan)
	REFERENCES HoaDonBan(MaDonBan)
	ON UPDATE CASCADE,

    CONSTRAINT FK_CTDonBanHang_MaMatHang
	FOREIGN KEY (MaMatHang)
	REFERENCES MatHang(MaMatHang)
	ON UPDATE CASCADE


ALTER TABLE MatHang
ADD CONSTRAINT FK_MatHang_MaLoai
	FOREIGN KEY (MaLoai)
	REFERENCES Loai(MaLoai)
	ON UPDATE CASCADE ON DELETE SET DEFAULT,

	CONSTRAINT FK_MatHang_MaThuongHieu
	FOREIGN KEY (MaThuongHieu)
	REFERENCES ThuongHieu(MaThuongHieu)
	ON UPDATE CASCADE ON DELETE SET DEFAULT,

	CONSTRAINT FK_MatHang_MaChiTiet
	FOREIGN KEY (MaChiTiet)
	REFERENCES CTMatHang(MaChiTiet)
	ON UPDATE CASCADE ON DELETE SET DEFAULT

ALTER TABLE CTDonNhapHang
ADD CONSTRAINT FK_CTDonNhapHang_MaDonNhap
	FOREIGN KEY (MaDonNhap)
	REFERENCES HoaDonNhap(MaDonNhap)
	ON UPDATE CASCADE,

    CONSTRAINT FK_CTDonNhapHang_MaMatHang
	FOREIGN KEY (MaMatHang)
	REFERENCES MatHang(MaMatHang)

INSERT INTO Loai
VALUES
(N'Không', N'Không')

INSERT INTO ThuongHieu
VALUES
(N'Không', N'Không')
	
INSERT INTO CTMatHang
VALUES
(N'Không', N'Không', 0, 'Không')

INSERT INTO MatHang
VALUES
('1', N'Tên', N'Không', N'Không', N'Không', 1, 'Cái', 303),
('2', N'Test', N'Không', N'Không', N'Không', 2, 'Cái', 105)

SELECT * FROM MatHang

INSERT INTO Loai
VALUES
('AO', N'Áo'),
('QUN', N'Quần')

INSERT INTO CTMatHang
VALUES
('1', N'Vải hoa', 38, N'Cam'),
('2', N'Vải lanh', 50, N'Xanh')

INSERT INTO ThuongHieu
VALUES
('BLG', 'Balenciaga')

INSERT INTO MatHang
VALUES
('3', N'Quần jean', N'QUN', '2', N'Không', 100, 'Cái', 700000),
('4', N'Áo khoác', N'AO', '1', N'BLG', 50, 'Cái', 600000)

SELECT 
	MH.TenMatHang AS Tên,
	L.TenLoai AS Loại,
	CT.TenLoaiVai AS [Loại vải],
	CT.MauSac AS Màu,
	TH.MaThuongHieu AS [Thương hiệu],
	MH.DonViTinh AS [Đơn vị tính],
	MH.SoLuong AS [Số lượng],
	CAST(MH.DonGia AS float) AS [Đơn giá]
FROM 
	MatHang MH
INNER JOIN 
	Loai L
ON 
	MH.MaLoai = L.MaLoai
INNER JOIN
	CTMatHang CT
ON
	MH.MaChiTiet = CT.MaChiTiet
INNER JOIN
	ThuongHieu TH
ON
	MH.MaThuongHieu = TH.MaThuongHieu

