USE QuanLyQuanAo
GO

--Example
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
	P.IDProduct AS [ID],
	P.Name AS [Tên],
	T.Name AS [Loại],
	B.Name AS [Thương Hiệu],
	C.Color AS [Màu Sắc],
	P.Unit AS [Đơn Vị Tính],
	S.Size AS [Kích Thước],
	P.Amount AS [Số Lượng],
	P.Price AS [Đơn Giá]
	FROM Product P
	INNER JOIN Type T ON T.IDType = P.IDType
	INNER JOIN Branch B ON B.IDBranch = P.IDBranch
	INNER JOIN Size S ON S.IDSize = P.IDSize
	INNER JOIN Color C ON C.IDColor = P.IDColor
GO

CREATE PROC USP_GetBranchByProductID
@IDProduct INT
AS
BEGIN
	SELECT 
	B.*
	FROM 
		Product P, Branch B
	WHERE 
		P.IDBranch = B.IDBranch AND IDProduct = @IDProduct
END
GO