
use LabDev
go

INSERT INTO CatProductos (NombreProducto,ImagenProducto,PrecioUnitario,ext)
VALUES('TELEVISOR','',2000000,''), ('COMPUTADOR','',3000000,'')
GO


CREATE OR ALTER PROCEDURE GetClientesAll
	AS
BEGIN	

	SELECT C.Id, C.RazonSocial, C.IdTipoCliente, C.FechaCreacion, C.RFC, 
		TC.Id AS IdTipoCliente, TC.Nombre
	FROM TblClientes C
	INNER JOIN CatTipoCliente TC ON TC.Id = C.IdTipoCliente

END

go
CREATE OR ALTER PROCEDURE GetProductosAll
AS
BEGIN	
	SELECT Id, NombreProducto, ImagenProducto, PrecioUnitario, ext 
	FROM CatProductos
END
GO

CREATE OR ALTER PROCEDURE getFacturasPorCliente
	@IdCliente INT
AS
BEGIN
	SELECT Id, FechaEmisionFactura, IdCliente, NumeroFactura, NumeroTotalArticulos, 
			SubTotalFacturas, TotalImpuestos, TotalFactura	
	FROM TblFacturas
	WHERE IdCliente = @IdCliente
END
GO
CREATE OR ALTER PROCEDURE getFacturaPorNumeroFactura
	@NumeroFactura INT
AS
BEGIN
	SELECT Id, FechaEmisionFactura, IdCliente, NumeroFactura, NumeroTotalArticulos, 
			SubTotalFacturas, TotalImpuestos, TotalFactura
	FROM TblFacturas
	WHERE NumeroFactura = @NumeroFactura
END
GO

CREATE OR ALTER PROCEDURE CrearFactura 
	 @FechaEmisionFactura datetime
    ,@IdCliente int
    ,@NumeroFactura int
    ,@NumeroTotalArticulos int
    ,@SubTotalFacturas decimal(18,2)
    ,@TotalImpuestos decimal(18,2)
    ,@TotalFactura decimal(18,2)
	,@Detalles NVARCHAR(MAX)
AS
BEGIN
	BEGIN TRANSACTION
	BEGIN TRY
	
		DECLARE @IdFactura INT 
		INSERT INTO [dbo].[TblFacturas]
				   ([FechaEmisionFactura]
				   ,[IdCliente]
				   ,[NumeroFactura]
				   ,[NumeroTotalArticulos]
				   ,[SubTotalFacturas]
				   ,[TotalImpuestos]
				   ,[TotalFactura])
			 VALUES
				   (@FechaEmisionFactura
				   ,@IdCliente
				   ,@NumeroFactura
				   ,@NumeroTotalArticulos
				   ,@SubTotalFacturas
				   ,@TotalImpuestos
				   ,@TotalFactura)
	
		SET @IdFactura = SCOPE_IDENTITY()

		INSERT INTO TblDetallesFactura(IdFactura, IdProducto, CantidadDeProducto, PrecioUnitarioProducto, SubtotalProducto, Notas)

		SELECT @IdFactura, IdProducto, CantidadDeProducto, PrecioUnitarioProducto, SubtotalProducto, Notas
		FROM OPENJSON(@Detalles)
		WITH (
			IdProducto INT,
			CantidadDeProducto INT,
			PrecioUnitarioProducto DECIMAL(18,2),
			SubtotalProducto DECIMAL(18,2),
			Notas VARCHAR(200)
		);
	
		COMMIT TRANSACTION

	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION		
	END CATCH
END
