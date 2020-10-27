USE QuanLyQuanAo
GO

CREATE PROC USP_GetProductByProductID
@productID NVARCHAR(10)
AS
BEGIN
	SELECT * FROM MatHang WHERE MaMatHang = @productID
END

EXEC USP_GetProductByProductID @productID = '2'