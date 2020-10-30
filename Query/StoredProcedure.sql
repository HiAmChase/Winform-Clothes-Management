USE QuanLyQuanAo
GO

CREATE PROC USP_GetProductByProductID
@productID NVARCHAR(10)
AS
BEGIN
	SELECT * FROM MatHang WHERE MaMatHang = @productID
END
GO

--Example
EXEC USP_GetProductByProductID @productID = '2'
GO


CREATE PROC USP_GetProduct
AS
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
	