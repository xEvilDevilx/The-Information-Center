/* ===============================================================

    ITEra functionality 
    -----------------------
    Add creating stored procedures
	
    2018/01/31, Created, VTyagunov
 
*/

USE [ICDB]
GO

-- Create SystemTranslationData_ReadProc stored procedure
IF EXISTS (SELECT * FROM dbo.SYSOBJECTS WHERE [id] = OBJECT_ID('SystemTranslationData_ReadProc'))
BEGIN
    DROP PROCEDURE [SystemTranslationData_ReadProc]
END

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [SystemTranslationData_ReadProc]
(
	@IPAddress NCHAR(16),
	@Lang NVARCHAR(5)
)
AS
DECLARE @TerminalID NVARCHAR(5);
DECLARE @StoreID NVARCHAR(5);

CREATE TABLE #SystemTranslationData
(
	BtnUpText NVARCHAR(255),
	BtnDownText NVARCHAR(255),
	BtnSettingsText NVARCHAR(255),
	BtnSharesText NVARCHAR(255),

	LblSettingsText NVARCHAR(255),
	BtnLang NVARCHAR(255),
	BtnCurrency NVARCHAR(255),
	BtnChooseText NVARCHAR(255),
	BtnCancelText NVARCHAR(255),

	LblVendorCodeText NVARCHAR(255),
	LblBarCodeText NVARCHAR(255),
	LblPriceText NVARCHAR(255),

	BtnBackText NVARCHAR(255),

	LblScanBarCodeText NVARCHAR(255),

	LblSharesAndSalesText NVARCHAR(255),

	LblProductNotFoundInDBText NVARCHAR(255)
);

BEGIN
	IF @Lang = '' OR @Lang IS NULL
	BEGIN
		SET @TerminalID = (SELECT T.TerminalID FROM dbo.Terminal AS T WHERE T.IPAddress = @IPAddress);
		SET @StoreID = (SELECT T.StoreID FROM dbo.Terminal AS T WHERE T.IPAddress = @IPAddress);
		SET @Lang = (SELECT C.ConfigValue FROM dbo.Config AS C WHERE C.ConfigID = 1 AND C.StoreID = @StoreID);
	END

	SELECT * INTO #Translations FROM [SystemTranslation] WHERE [LanguageCode] = @Lang;

	INSERT INTO #SystemTranslationData DEFAULT VALUES; 

	UPDATE #SystemTranslationData 
	SET #SystemTranslationData.BtnUpText = #Translations.TranslationValue 
	FROM #Translations, #SystemTranslationData 
	WHERE #Translations.TranslationID = 9;

	UPDATE #SystemTranslationData 
	SET #SystemTranslationData.BtnDownText = #Translations.TranslationValue 
	FROM #Translations, #SystemTranslationData 
	WHERE #Translations.TranslationID = 5;

	UPDATE #SystemTranslationData 
	SET #SystemTranslationData.BtnSettingsText = #Translations.TranslationValue 
	FROM #Translations, #SystemTranslationData 
	WHERE #Translations.TranslationID = 7;

	UPDATE #SystemTranslationData 
	SET #SystemTranslationData.BtnSharesText = #Translations.TranslationValue 
	FROM #Translations, #SystemTranslationData 
	WHERE #Translations.TranslationID = 8;

	UPDATE #SystemTranslationData 
	SET #SystemTranslationData.LblSettingsText = #Translations.TranslationValue 
	FROM #Translations, #SystemTranslationData 
	WHERE #Translations.TranslationID = 11;

	UPDATE #SystemTranslationData 
	SET #SystemTranslationData.BtnLang = #Translations.TranslationValue 
	FROM #Translations, #SystemTranslationData 
	WHERE #Translations.TranslationID = 6;

	UPDATE #SystemTranslationData 
	SET #SystemTranslationData.BtnCurrency = #Translations.TranslationValue 
	FROM #Translations, #SystemTranslationData 
	WHERE #Translations.TranslationID = 4;

	UPDATE #SystemTranslationData 
	SET #SystemTranslationData.BtnChooseText = #Translations.TranslationValue 
	FROM #Translations, #SystemTranslationData 
	WHERE #Translations.TranslationID = 3;
	
	UPDATE #SystemTranslationData 
	SET #SystemTranslationData.BtnCancelText = #Translations.TranslationValue 
	FROM #Translations, #SystemTranslationData 
	WHERE #Translations.TranslationID = 2;

	UPDATE #SystemTranslationData 
	SET #SystemTranslationData.LblVendorCodeText = #Translations.TranslationValue 
	FROM #Translations, #SystemTranslationData 
	WHERE #Translations.TranslationID = 16;

	UPDATE #SystemTranslationData 
	SET #SystemTranslationData.LblBarCodeText = #Translations.TranslationValue 
	FROM #Translations, #SystemTranslationData 
	WHERE #Translations.TranslationID = 10;

	UPDATE #SystemTranslationData 
	SET #SystemTranslationData.LblPriceText = #Translations.TranslationValue 
	FROM #Translations, #SystemTranslationData 
	WHERE #Translations.TranslationID = 12;

	UPDATE #SystemTranslationData 
	SET #SystemTranslationData.BtnBackText = #Translations.TranslationValue 
	FROM #Translations, #SystemTranslationData 
	WHERE #Translations.TranslationID = 1;

	UPDATE #SystemTranslationData 
	SET #SystemTranslationData.LblScanBarCodeText = #Translations.TranslationValue 
	FROM #Translations, #SystemTranslationData 
	WHERE #Translations.TranslationID = 14;

	UPDATE #SystemTranslationData 
	SET #SystemTranslationData.LblSharesAndSalesText = #Translations.TranslationValue 
	FROM #Translations, #SystemTranslationData 
	WHERE #Translations.TranslationID = 15;

	UPDATE #SystemTranslationData 
	SET #SystemTranslationData.LblProductNotFoundInDBText = #Translations.TranslationValue 
	FROM #Translations, #SystemTranslationData 
	WHERE #Translations.TranslationID = 13;

	SELECT * FROM #SystemTranslationData;

	DROP TABLE #SystemTranslationData;
	DROP TABLE #Translations;
END
GO

-- Create DefaultLangCurr_ReadProc stored procedure
IF EXISTS (SELECT * FROM dbo.SYSOBJECTS WHERE [id] = OBJECT_ID('DefaultLangCurr_ReadProc'))
BEGIN
    DROP PROCEDURE [DefaultLangCurr_ReadProc]
END

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [DefaultLangCurr_ReadProc]
(
	@IPAddress NCHAR(16)
)
AS
DECLARE @TerminalID NVARCHAR(5);
DECLARE @StoreID NVARCHAR(5);

CREATE TABLE #DefaultLangCurr
(
	LanguageCode NVARCHAR(5),
	CurrencyCode NVARCHAR(5)
);

BEGIN
	SET @TerminalID = (SELECT T.TerminalID FROM dbo.Terminal AS T WHERE T.IPAddress = @IPAddress);
	SET @StoreID = (SELECT T.StoreID FROM dbo.Terminal AS T WHERE T.IPAddress = @IPAddress);
	INSERT INTO #DefaultLangCurr(LanguageCode) SELECT C.ConfigValue FROM dbo.Config AS C WHERE C.ConfigID = 1 AND C.StoreID = @StoreID;
	UPDATE #DefaultLangCurr SET CurrencyCode = (SELECT C.ConfigValue FROM dbo.Config AS C WHERE C.ConfigID = 2 AND C.StoreID = @StoreID);
	SELECT * FROM #DefaultLangCurr;

	DROP TABLE #DefaultLangCurr;
END
GO

-- Create ProductInfoData_ReadProc stored procedure
IF EXISTS (SELECT * FROM dbo.SYSOBJECTS WHERE [id] = OBJECT_ID('ProductInfoData_ReadProc'))
BEGIN
    DROP PROCEDURE [ProductInfoData_ReadProc]
END

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [ProductInfoData_ReadProc]
(
	@IPAddress NCHAR(16),
	@Barcode NVARCHAR(20),
	@Language NVARCHAR(5),
	@Currency NVARCHAR(5)
)
AS
DECLARE @TerminalID NVARCHAR(5);
DECLARE @StoreID NVARCHAR(5);
DECLARE @StoreCurrency NVARCHAR(5);
DECLARE @Caption NVARCHAR(255);
DECLARE @Description NVARCHAR(MAX);
DECLARE @Price DECIMAL(20, 10);
DECLARE @CurrencyRate DECIMAL(20, 10);
DECLARE @ActualPrice DECIMAL(20, 10);
DECLARE @RetailActionTranslationCaption NVARCHAR(MAX) = '';
DECLARE @RetailActionTranslationDescription NVARCHAR(MAX) = '';
DECLARE @CycleProductID INT = 0;
DECLARE @VendoreCode NVARCHAR(50);
DECLARE @ProductImage VARBINARY(MAX);

CREATE TABLE #ProductInfoData
(
		TextBoxVendorCode NVARCHAR(50),
        TextBoxBarCode NVARCHAR(20),
        TextBoxProductName NVARCHAR(255),
        TextBoxPrice NVARCHAR(100),
        TextBoxProductInfo NVARCHAR(MAX),
        PictureBoxProductImage VARBINARY(MAX),
        ProductSharesNames  NVARCHAR(MAX),
        ProductSharesDesriptions  NVARCHAR(MAX)
);

BEGIN
	SET @TerminalID = (SELECT T.TerminalID FROM dbo.Terminal AS T WHERE T.IPAddress = @IPAddress);
	SET @StoreID = (SELECT T.StoreID FROM dbo.Terminal AS T WHERE T.IPAddress = @IPAddress);

	IF @Language = '' OR @Language IS NULL
		SET @Language = (SELECT C.ConfigValue FROM dbo.Config AS C WHERE C.ConfigID = 1 AND C.StoreID = @StoreID);

	SET @StoreCurrency = (SELECT C.ConfigValue FROM dbo.Config AS C WHERE C.ConfigID = 2 AND C.StoreID = @StoreID);
	IF @Currency = '' OR @Currency IS NULL
		SET @Currency = @StoreCurrency;

	SELECT * INTO #ProductItem FROM [Product] WHERE [Product].[BarcodeValue] = @Barcode;

	SET @VendoreCode = (SELECT [#ProductItem].[Article] FROM [#ProductItem]);
	SET @ProductImage = (SELECT [#ProductItem].[Image] FROM [#ProductItem]);

	SET @Caption = 
	(SELECT [ContentTranslation].[TranslationValue] 
	FROM [ContentTranslation] 
	WHERE [ContentTranslation].[TranslationID] = (SELECT #ProductItem.CaptionID FROM #ProductItem WHERE #ProductItem.BarcodeValue = @Barcode)
	AND [ContentTranslation].[LanguageCode] = @Language);

	SET @Description =
	(SELECT [ContentTranslation].[TranslationValue] 
	FROM [ContentTranslation] 
	WHERE [ContentTranslation].[TranslationID] = (SELECT #ProductItem.DescriptionID FROM #ProductItem WHERE #ProductItem.BarcodeValue = @Barcode)
	AND [ContentTranslation].[LanguageCode] = @Language);

	SELECT * INTO #ProductPriceArray FROM [ProductPrice] 
	WHERE [ProductPrice].[ProductID] = (SELECT #ProductItem.ProductID FROM #ProductItem WHERE #ProductItem.BarcodeValue = @Barcode)
	AND [ProductPrice].[StoreID] = @StoreID
	AND [ProductPrice].[DateBegin] <= (SELECT CURRENT_TIMESTAMP);

	SET @Price = 
	(SELECT #ProductPriceArray.PriceValue FROM #ProductPriceArray WHERE #ProductPriceArray.DateBegin = (SELECT MAX(#ProductPriceArray.DateBegin) FROM #ProductPriceArray));
	
	SELECT * INTO #CurrencyRateArray FROM [CurrencyRate]
	WHERE [CurrencyRate].[CurrencyCode] = @Currency AND [CurrencyRate].[StoreID] = @StoreID;

	-- Now no need to check a last DataBegin

	SET @CurrencyRate = (SELECT [cra].[RateValue] FROM #CurrencyRateArray as cra)

	IF @StoreCurrency = 'EUR'
		SET @ActualPrice = (SELECT @Price * @CurrencyRate)
	ELSE IF @StoreCurrency = 'RUB'
		SET @ActualPrice = (SELECT @Price / @CurrencyRate)

	SELECT * INTO #ProductActions FROM [ProductAction]
		WHERE [ProductAction].[ProductID] = (SELECT ProductID FROM #ProductItem);
			
	WHILE(1 = 1)
	BEGIN
	  SET @CycleProductID = (SELECT MIN(#ProductActions.ProductID)
	  FROM #ProductActions WHERE #ProductActions.ProductID > @CycleProductID);

	  IF @CycleProductID IS NULL BREAK;

	  SELECT * INTO #RetailAction FROM [RetailAction]
	  WHERE [RetailAction].[RetailActionID] = 
	  (SELECT #ProductActions.RetailActionID FROM #ProductActions 
	  WHERE #ProductActions.ProductID = 
	  (SELECT #ProductItem.ProductID FROM #ProductItem WHERE #ProductItem.BarcodeValue = @Barcode))
	  AND [RetailAction].[AccessStatus] != 0
	  AND [RetailAction].[DateEnd] > (SELECT CURRENT_TIMESTAMP);

	  SET @RetailActionTranslationCaption = @RetailActionTranslationCaption + 
		(SELECT [ContentTranslation].[TranslationValue] FROM [ContentTranslation] 
		WHERE [ContentTranslation].[TranslationID] = (SELECT CaptionID FROM #RetailAction)
		AND [ContentTranslation].LanguageCode = @Language) + '|||';

		SET @RetailActionTranslationDescription = @RetailActionTranslationDescription + 
		(SELECT [ContentTranslation].[TranslationValue] FROM [ContentTranslation] 
		WHERE [ContentTranslation].[TranslationID] = (SELECT DescriptionID FROM #RetailAction)
		AND [ContentTranslation].LanguageCode = @Language) + '|||';
	END
	
	IF @RetailActionTranslationCaption != ''
		SET @RetailActionTranslationCaption = (SELECT STUFF(@RetailActionTranslationCaption, LEN(@RetailActionTranslationCaption) - 2, 3, ''));

	IF @RetailActionTranslationDescription != ''
		SET @RetailActionTranslationDescription = (SELECT STUFF(@RetailActionTranslationDescription, LEN(@RetailActionTranslationDescription) - 2, 3, ''));

	INSERT INTO #ProductInfoData VALUES
	(@VendoreCode, 
	@Barcode, 
	@Caption, 
	Format( @ActualPrice ,'N','en-US' ) + @Currency, 
	@Description, 
	@ProductImage, 
	@RetailActionTranslationCaption, 
	@RetailActionTranslationDescription);

	SELECT * FROM #ProductInfoData;

	DROP TABLE #ProductInfoData;
	DROP TABLE #ProductItem;
	DROP TABLE #ProductPriceArray;
	DROP TABLE #CurrencyRateArray;
	DROP TABLE #ProductActions;
	DROP TABLE #RetailAction;
END
GO

-- Create AdvertisingData_ReadProc stored procedure
IF EXISTS (SELECT * FROM dbo.SYSOBJECTS WHERE [id] = OBJECT_ID('AdvertisingData_ReadProc'))
BEGIN
    DROP PROCEDURE [AdvertisingData_ReadProc]
END

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [AdvertisingData_ReadProc]
(
	@IPAddress NCHAR(16)
)
AS
DECLARE @TerminalID NVARCHAR(5);
DECLARE @StoreID NVARCHAR(5);
DECLARE @CycleAdID INT = 0;
DECLARE @AdImage VARBINARY(MAX);

CREATE TABLE #AdvertisingData
(
	AdImage VARBINARY(MAX)
);

BEGIN
	BEGIN
		SET @TerminalID = (SELECT T.TerminalID FROM dbo.Terminal AS T WHERE T.IPAddress = @IPAddress);
		SET @StoreID = (SELECT T.StoreID FROM dbo.Terminal AS T WHERE T.IPAddress = @IPAddress);
	END

	SELECT * INTO #TerminalAdArray FROM [StoreAdvertising] 
	WHERE [StoreAdvertising].[TerminalID] = @TerminalID
	AND [StoreAdvertising].[StoreID] = @StoreID;

	WHILE(1 = 1)
	BEGIN		
	  SET @CycleAdID = (SELECT MIN(#TerminalAdArray.AdvertisingID)
	  FROM #TerminalAdArray WHERE #TerminalAdArray.AdvertisingID > @CycleAdID);

	  IF @CycleAdID IS NULL BREAK;

	  SET @AdImage = (SELECT [Image] FROM [Advertising] 
	  WHERE [Advertising].[AdvertisingID] = @CycleAdID
	  AND [Advertising].[AccessStatus] != 0);

	  INSERT INTO #AdvertisingData VALUES(@AdImage);
	END

	SELECT * FROM #AdvertisingData;

	DROP TABLE #TerminalAdArray;
	DROP TABLE #AdvertisingData;
END
GO

-- Create SharesSalesData_ReadProc stored procedure
IF EXISTS (SELECT * FROM dbo.SYSOBJECTS WHERE [id] = OBJECT_ID('SharesSalesData_ReadProc'))
BEGIN
    DROP PROCEDURE [SharesSalesData_ReadProc]
END

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SharesSalesData_ReadProc]
(
	@IPAddress NCHAR(16),
	@Language NVARCHAR(5)
)
AS
DECLARE @StoreID NVARCHAR(5);
DECLARE @RetailActionTranslationCaption NVARCHAR(MAX) = '';
DECLARE @RetailActionTranslationDescription NVARCHAR(MAX) = '';
DECLARE @CycleSharesID INT = 0;
DECLARE @CaptionID INT = 0;
DECLARE @DescriptionID INT = 0;

CREATE TABLE #SharesSalesData
(
	SharesID INT,
    ShareName  NVARCHAR(MAX),
    ShareDesription  NVARCHAR(MAX)
);

BEGIN
	SET @StoreID = (SELECT T.StoreID FROM dbo.Terminal AS T WHERE T.IPAddress = @IPAddress);

	IF @Language = '' OR @Language IS NULL
		SET @Language = (SELECT C.ConfigValue FROM dbo.Config AS C WHERE C.ConfigID = 1 AND C.StoreID = @StoreID);

	SELECT * INTO [#StoreActions] FROM [StoreAction] WHERE [StoreAction].[StoreID] = @StoreID;

	WHILE(1 = 1)
	BEGIN
	  SET @CycleSharesID = (SELECT MIN(#StoreActions.RetailActionID)
	  FROM #StoreActions WHERE #StoreActions.RetailActionID > @CycleSharesID);

	  IF @CycleSharesID IS NULL BREAK;

	  SET @CaptionID = (SELECT [RetailAction].[CaptionID] FROM [RetailAction] WHERE [RetailAction].[RetailActionID] = @CycleSharesID);
	  SET @DescriptionID = (SELECT [RetailAction].[DescriptionID] FROM [RetailAction] WHERE [RetailAction].[RetailActionID] = @CycleSharesID);
	  	  
	  SET @RetailActionTranslationCaption = 
	  (SELECT [ContentTranslation].[TranslationValue] FROM [ContentTranslation]
	  WHERE [ContentTranslation].[TranslationID] = @CaptionID
	  AND [ContentTranslation].[LanguageCode] = @Language);

	  SET @RetailActionTranslationDescription = 
	  (SELECT [ContentTranslation].[TranslationValue] FROM [ContentTranslation]
	  WHERE [ContentTranslation].[TranslationID] = @DescriptionID
	  AND [ContentTranslation].[LanguageCode] = @Language);

	  INSERT INTO #SharesSalesData VALUES(@CycleSharesID, @RetailActionTranslationCaption, @RetailActionTranslationDescription);
	END	

	SELECT * FROM #SharesSalesData;
END
GO

-- Create LanguageData_ReadProc stored procedure
IF EXISTS (SELECT * FROM dbo.SYSOBJECTS WHERE [id] = OBJECT_ID('LanguageData_ReadProc'))
BEGIN
    DROP PROCEDURE [LanguageData_ReadProc]
END

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[LanguageData_ReadProc]
(
	@IPAddress NCHAR(16),
	@Language NVARCHAR(5)
)
AS
DECLARE @TerminalID NVARCHAR(5);
DECLARE @StoreID NVARCHAR(5);

BEGIN
	SET @TerminalID = (SELECT T.TerminalID FROM dbo.Terminal AS T WHERE T.IPAddress = @IPAddress);
	SET @StoreID = (SELECT T.StoreID FROM dbo.Terminal AS T WHERE T.IPAddress = @IPAddress);

	IF @Language = '' OR @Language IS NULL
		SET @Language = (SELECT C.ConfigValue FROM dbo.Config AS C WHERE C.ConfigID = 1 AND C.StoreID = @StoreID);

	SELECT [TerminalLanguage].[LanguageCode], [Language].[Image], [ContentTranslation].[TranslationValue]
	FROM [TerminalLanguage]
	INNER JOIN [Language] ON [TerminalLanguage].[StoreID] = @StoreID 
	AND [TerminalLanguage].[TerminalID] = @TerminalID 
	AND [TerminalLanguage].[LanguageCode] = [Language].[LanguageCode]
	INNER JOIN [ContentTranslation] ON [Language].[CaptionID] = [ContentTranslation].[TranslationID]
	AND [ContentTranslation].[LanguageCode] = @Language;
END
GO

-- Create CurrencyData_ReadProc stored procedure
IF EXISTS (SELECT * FROM dbo.SYSOBJECTS WHERE [id] = OBJECT_ID('CurrencyData_ReadProc'))
BEGIN
    DROP PROCEDURE [CurrencyData_ReadProc]
END

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CurrencyData_ReadProc]
(
	@IPAddress NCHAR(16),
	@Language NVARCHAR(5)
)
AS
DECLARE @TerminalID NVARCHAR(5);
DECLARE @StoreID NVARCHAR(5);

BEGIN
	SET @TerminalID = (SELECT T.TerminalID FROM dbo.Terminal AS T WHERE T.IPAddress = @IPAddress);
	SET @StoreID = (SELECT T.StoreID FROM dbo.Terminal AS T WHERE T.IPAddress = @IPAddress);

	IF @Language = '' OR @Language IS NULL
		SET @Language = (SELECT C.ConfigValue FROM dbo.Config AS C WHERE C.ConfigID = 1 AND C.StoreID = @StoreID);

	SELECT [TerminalCurrency].[CurrencyCode], [Currency].[Image], [ContentTranslation].[TranslationValue]
	FROM [TerminalCurrency]
	INNER JOIN [Currency] ON [TerminalCurrency].[StoreID] = @StoreID 
	AND [TerminalCurrency].[TerminalID] = @TerminalID 
	AND [TerminalCurrency].[CurrencyCode] = [Currency].[CurrencyCode]
	INNER JOIN [ContentTranslation] ON [Currency].[CaptionID] = [ContentTranslation].[TranslationID]
	AND [ContentTranslation].[LanguageCode] = @Language;
END
GO

-- Create LogoData_ReadProc stored procedure
IF EXISTS (SELECT * FROM dbo.SYSOBJECTS WHERE [id] = OBJECT_ID('LogoData_ReadProc'))
BEGIN
    DROP PROCEDURE [LogoData_ReadProc]
END

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[LogoData_ReadProc]
(
	@IPAddress NCHAR(16)
)
AS
DECLARE @TerminalID NVARCHAR(5);
DECLARE @StoreID NVARCHAR(5);

BEGIN
	SET @TerminalID = (SELECT T.TerminalID FROM dbo.Terminal AS T WHERE T.IPAddress = @IPAddress);
	SET @StoreID = (SELECT T.StoreID FROM dbo.Terminal AS T WHERE T.IPAddress = @IPAddress);

	SELECT [Store].[Image] FROM [Store] WHERE [Store].[StoreID] = @StoreID;
END
GO