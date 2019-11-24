USE [ICDB]
GO

INSERT INTO [dbo].[Currency] ([CurrencyCode], [CaptionID], [Image]) 
SELECT 'RUB', 4, BulkColumn 
FROM Openrowset( Bulk 'G:\DEVELOPMENT\Information Center\MAIN[.Net4.6.1]\IC.EFDesignLib\bin\Debug\ImagesToLoad\18.png', Single_Blob) as EmployeePicture;

INSERT INTO [dbo].[Currency] ([CurrencyCode], [CaptionID], [Image]) 
SELECT 'USD', 5, BulkColumn 
FROM Openrowset( Bulk 'G:\DEVELOPMENT\Information Center\MAIN[.Net4.6.1]\IC.EFDesignLib\bin\Debug\ImagesToLoad\17.png', Single_Blob) as EmployeePicture;

INSERT INTO [dbo].[Currency] ([CurrencyCode], [CaptionID], [Image]) 
SELECT 'EUR', 6, BulkColumn 
FROM Openrowset( Bulk 'G:\DEVELOPMENT\Information Center\MAIN[.Net4.6.1]\IC.EFDesignLib\bin\Debug\ImagesToLoad\19.png', Single_Blob) as EmployeePicture;

INSERT INTO [dbo].[Currency] ([CurrencyCode], [CaptionID], [Image]) 
SELECT 'CNY', 7, BulkColumn 
FROM Openrowset( Bulk 'G:\DEVELOPMENT\Information Center\MAIN[.Net4.6.1]\IC.EFDesignLib\bin\Debug\ImagesToLoad\20.png', Single_Blob) as EmployeePicture;

GO