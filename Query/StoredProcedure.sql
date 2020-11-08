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

CREATE PROC USP_GetColorByProductID
@IDProduct INT
AS
BEGIN 
	SELECT 
	C.*
	FROM 
		Product P, Color C
	WHERE 
		P.IDColor = C.IDColor AND IDProduct = @IDProduct
END

GO

CREATE PROC USP_GetTypeByProductID
@IDProduct INT
AS
BEGIN 
	SELECT 
	T.*
	FROM 
		Product P, Type T
	WHERE 
		P.IDType = T.IDType AND IDProduct = @IDProduct
END
GO

CREATE PROC USP_InsertProduct
@Name NVARCHAR(50), @Type NVARCHAR(50), @Branch NVARCHAR(50), @Size INT, @Color NVARCHAR(50),
@Amount INT, @Unit NVARCHAR(50), @Price DECIMAL(19, 4)
AS
BEGIN
	DECLARE @IDType INT = (SELECT IDType FROM Type WHERE Name = @Type),
	@IDBranch INT = (SELECT IDBranch FROM Branch WHERE Name = @Branch),
	@IDSize INT = (SELECT IDSize FROM Size WHERE Size = @Size),
	@IDColor INT = (SELECT IDColor FROM Color WHERE Color = @Color)

	INSERT INTO Product (Name, IDType, IDBranch, IDSize, IDColor, Amount, Unit, Price)
	VALUES
	(@Name, @IDType, @IDBranch, @IDSize, @IDColor, @Amount, @Unit, @Price)

END

--Example
EXEC USP_InsertProduct @Name = N'Test', @Type = N'Giày', @Branch = N'Không', @Size = 1,
				@Color = N'Trắng', @Amount = 5, @Unit = N'Đôi', @Price = 10000

GO

CREATE PROC USP_UpdateProduct
@IDProduct INT,@Name NVARCHAR(50), @Type NVARCHAR(50), @Branch NVARCHAR(50), @Size INT, @Color NVARCHAR(50),
@Amount INT, @Unit NVARCHAR(50), @Price DECIMAL(19, 4)
AS
BEGIN
	DECLARE @IDType INT = (SELECT IDType FROM Type WHERE Name = @Type),
	@IDBranch INT = (SELECT IDBranch FROM Branch WHERE Name = @Branch),
	@IDSize INT = (SELECT IDSize FROM Size WHERE Size = @Size),
	@IDColor INT = (SELECT IDColor FROM Color WHERE Color = @Color)

	UPDATE 
		Product 
	SET Name = @Name, 
		IDType = @IDType, 
		IDBranch = @IDBranch,
		IDSize = @IDSize,
		IDColor = @IDColor,
		Amount = @Amount,
		Unit = @Unit,
		Price = Price
	WHERE
		IDProduct = @IDProduct
END

--Example
EXEC USP_UpdateProduct @IDProduct = 13, @Name = N'NewTest', @Type = N'Giày', @Branch = N'Balenciaga', @Size = 1,
				@Color = N'Đen', @Amount = 10, @Unit = N'Cái', @Price = 1000000
GO

CREATE PROC USP_DeleteProduct
@IDProduct INT
AS
BEGIN
	DELETE FROM Product WHERE IDProduct = @IDProduct
END