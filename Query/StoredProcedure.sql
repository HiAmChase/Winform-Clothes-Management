﻿USE QuanLyQuanAo
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
	P.PriceOut AS [Đơn Giá],
	P.PriceIn
	FROM Product P
	INNER JOIN Type T ON T.IDType = P.IDType
	INNER JOIN Branch B ON B.IDBranch = P.IDBranch
	INNER JOIN Size S ON S.IDSize = P.IDSize
	INNER JOIN Color C ON C.IDColor = P.IDColor
GO

CREATE PROC USP_GetProductByIDAndAmount
@IDProduct INT, @Amount INT
AS
	SELECT 
	P.IDProduct AS [ID],
	P.Name AS [Tên],
	T.Name AS [Loại],
	B.Name AS [Thương Hiệu],
	C.Color AS [Màu Sắc],
	P.Unit AS [Đơn Vị Tính],
	S.Size AS [Kích Thước],
	@Amount AS [Số Lượng],
	P.PriceOut AS [Đơn Giá],
	P.PriceIn
	FROM Product P
	INNER JOIN Type T ON T.IDType = P.IDType
	INNER JOIN Branch B ON B.IDBranch = P.IDBranch
	INNER JOIN Size S ON S.IDSize = P.IDSize
	INNER JOIN Color C ON C.IDColor = P.IDColor
	WHERE IDProduct = @IDProduct
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

CREATE PROC USP_GetBranchBySupplierID
@IDSupplier INT
AS
BEGIN
	SELECT 
	B.*
	FROM 
		Supplier S, Branch B
	WHERE 
		S.IDBranch = B.IDBranch AND IDSupplier = @IDSupplier
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

@Amount INT, @Unit NVARCHAR(50), @PriceOut DECIMAL(19, 4), @PriceIn DECIMAL(19,4)
AS
BEGIN
	DECLARE @IDType INT = (SELECT IDType FROM Type WHERE Name = @Type),
	@IDBranch INT = (SELECT IDBranch FROM Branch WHERE Name = @Branch),
	@IDSize INT = (SELECT IDSize FROM Size WHERE Size = @Size),
	@IDColor INT = (SELECT IDColor FROM Color WHERE Color = @Color)

INSERT INTO Product (Name, IDType, IDBranch, IDSize, IDColor, Amount, Unit, PriceIn, PriceOut)
	VALUES

	(@Name, @IDType, @IDBranch, @IDSize, @IDColor, @Amount, @Unit, @PriceIn, @PriceOut)

END

--Example
EXEC USP_InsertProduct @Name = N'Test', @Type = N'Giày', @Branch = N'Không', @Size = 1,

				@Color = N'Trắng', @Amount = 5, @Unit = N'Đôi', @PriceOut = 10000

GO
CREATE PROC USP_UpdateProduct
@IDProduct INT,@Name NVARCHAR(50), @Type NVARCHAR(50), @Branch NVARCHAR(50), @Size INT, @Color NVARCHAR(50),
@Amount INT, @Unit NVARCHAR(50), @PriceOut DECIMAL(19, 4), @PriceIn DECIMAL(19, 4)
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
		PriceOut = @PriceOut,
		PriceIn = @PriceIn
	WHERE
		IDProduct = @IDProduct
END

--Example
EXEC USP_UpdateProduct @IDProduct = 13, @Name = N'NewTest', @Type = N'Giày', @Branch = N'Balenciaga', @Size = 1,

				@Color = N'Đen', @Amount = 10, @Unit = N'Cái', @PriceOut = 1000000
GO
CREATE PROC USP_DeleteProduct
@IDProduct INT
AS
BEGIN
	DELETE FROM Product WHERE IDProduct = @IDProduct
END

GO

CREATE PROC USP_InsertClient
@Name NVARCHAR(50), @Phone NVARCHAR(50), @Email NVARCHAR(50), @Address NVARCHAR(100)
AS
BEGIN
	INSERT INTO Client (Name, Address, Phone, Email)
	VALUES
	(@Name,@Address, @Phone, @Email)
END
GO

CREATE PROC USP_UpdateClient
@IDClient INT, @Name NVARCHAR(50), @Phone NVARCHAR(50), @Email NVARCHAR(50), @Address NVARCHAR(100)
AS
BEGIN
	UPDATE Client
	SET Name = @Name,
		Phone = @Phone,
		Email = @Email,
		Address = @Address
	WHERE
		IDClient = @IDClient
END
GO

CREATE PROC USP_DeleteClient
@IDClient INT
AS
BEGIN
	DELETE FROM Client WHERE IDClient = @IDClient
END
GO

CREATE PROC USP_GetSupplier
AS
BEGIN
	SELECT S.IDSupplier, 
			S.Name, 
			B.Name AS [Branch], 
			S.Phone, 
			S.Email, 
			S.Address 
	FROM
		Supplier S
	INNER JOIN 
		Branch B
	ON S.IDBranch = B.IDBranch
END
GO

CREATE PROC USP_InsertSupplier
@Name NVARCHAR(50), @Address NVARCHAR(100), @Phone NVARCHAR(50), @Email NVARCHAR(50), @NameBranch NVARCHAR(50)
AS
BEGIN
	DECLARE @IDBranch INT = (SELECT IDBranch FROM Branch WHERE Name = @NameBranch)

	INSERT INTO 
		Supplier(Name, Address , Phone, Email, IDBranch)
	VALUES
		(@Name, @Address, @Phone, @Email, @IDBranch)
END
GO

CREATE PROC USP_UpdateSupplier
@IDSupplier INT, @Name NVARCHAR(50), @Address NVARCHAR(100), 
@Phone NVARCHAR(50), @Email NVARCHAR(50), @NameBranch NVARCHAR(50)
AS
BEGIN
	DECLARE @IDBranch INT = (SELECT IDBranch FROM Branch WHERE Name = @NameBranch)

	UPDATE Supplier
	SET 
		Name = @Name,
		Address = @Address,
		Phone = @Phone,
		Email = @Email,
		IDBranch = @IDBranch
	WHERE IDSupplier = @IDSupplier
END
GO

CREATE PROC USP_DeleteSupplier
@IDSupplier INT
AS
BEGIN
	DELETE FROM Supplier WHERE IDSupplier = @IDSupplier
END
GO

CREATE PROC USP_GetBillProductOut
@IDProduct INT, @Amount INT
AS
BEGIN
	SELECT

		P.IDProduct, P.Name, P.PriceOut, 
		@Amount AS [Amount], 
		P.Amount AS [MaxAmount],
		P.PriceOut * @Amount AS [TotalPrice]
	FROM
		Product P
	WHERE
		P.IDProduct = @IDProduct
END
GO

CREATE PROC USP_GetBillProductIn
@IDProduct INT, @Amount INT
AS
BEGIN
	SELECT
		P.IDProduct, P.Name, P.PriceIn, 
		@Amount AS [Amount], 
		P.PriceIn * @Amount AS [TotalPrice]
	FROM
		Product P
	WHERE
		P.IDProduct = @IDProduct
END
GO

CREATE PROC USP_InsertBillExport
@IDClient INT
AS
BEGIN
	INSERT INTO BillExport(IDClient, DateOut)
	VALUES (@IDClient, GETDATE())
END
GO

CREATE PROC USP_InsertBillExportInfo
@IDBillExport INT, @IDProduct INT, @Amount INT
AS
BEGIN
	INSERT INTO BillExportInfo
	VALUES (@IDBillExport, @IDProduct, @Amount)
END
GO

--new query

--new query
CREATE PROC USP_GetProductBySupplier
@IDSupplier INT
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
	P.PriceIn,
	P.PriceOut AS [Đơn Giá]
	FROM Product P
	INNER JOIN Type T ON T.IDType = P.IDType
	INNER JOIN Branch B ON B.IDBranch = P.IDBranch
	INNER JOIN Size S ON S.IDSize = P.IDSize
	INNER JOIN Color C ON C.IDColor = P.IDColor
	INNER JOIN Supplier SUP ON SUP.IDBranch = B.IDBranch
	WHERE SUP.IDSupplier = @IDSupplier
GO




CREATE PROC USP_Testadmin
@Username NVARCHAR(100) , @Password NVARCHAR(1000)
AS
BEGIN
	SELECT Status From dbo.Staff WHERE Username= @Username AND Password=@Password
END
GO

GO

CREATE PROC USP_InsertStaff
@Username NVARCHAR(100), @Name NVARCHAR(50), @Status INT,@Phone NVARCHAR(50), @Email NVARCHAR(50), @Address NVARCHAR(100)
AS
BEGIN
	INSERT INTO Staff ( Username,Password ,Name,Status,Phone,Email,Address)
	VALUES
	(@Username,N'1',@Name,@Status,@Phone,@Email,@Address)
END
GO

CREATE PROC USP_UpdateStaff
@IDAccount INT,@Status INT ,@Phone NVARCHAR(50), @Email NVARCHAR(50), @Address NVARCHAR(100)
AS
BEGIN
	UPDATE Staff
	SET 
		Status=@Status,
		Phone = @Phone,
		Email = @Email,
		Address = @Address
	WHERE
		IDAccount = @IDAccount
END
GO
<<<<<<< HEAD
=======

CREATE PROC USP_DeleteStaff
@IDAccount INT
AS
BEGIN
	DELETE FROM Staff WHERE IDAccount = @IDAccount
END

GO
CREATE PROC USP_CheckUser
@Username NVARCHAR(100) 
AS
BEGIN
	SELECT * From dbo.Staff WHERE Username= @Username 
END
GO



CREATE PROC USP_UpdatePassword
@Username NVARCHAR(100) , @Password NVARCHAR(1000),@newPassword NVARCHAR(1000)
as
Begin
	UPDATE Staff
	SET 
		Password=@newPassword
	WHERE
		Username =@Username AND Password =@Password

end
>>>>>>> 3706dee03a77cb80054c23319e14c28e5685a2a6
