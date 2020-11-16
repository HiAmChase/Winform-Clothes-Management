CREATE TRIGGER TRG_InsertBillExportInfo
ON BillExportInfo FOR INSERT
AS
BEGIN
	DECLARE @IDProduct INT,
			@Amount INT,
			@AmountOut INT
	SELECT @IDProduct = IDProduct, @AmountOut = Amount FROM INSERTED
	SELECT @Amount = Amount FROM Product WHERE IDProduct = @IDProduct
	IF (@AmountOut > @Amount)
		ROLLBACK TRANSACTION
	ELSE
		UPDATE Product SET Amount = Amount - @AmountOut WHERE IDProduct = @IDProduct
END

--Example