
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/19/2017 21:03:46
-- Generated from EDMX file: G:\DEVELOPMENT\Information Center\MAIN[.Net4.6.1]]\IC.EFDesignLib\DBModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ICDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Advertising]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Advertising];
GO
IF OBJECT_ID(N'[dbo].[Config]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Config];
GO
IF OBJECT_ID(N'[dbo].[Terminal]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Terminal];
GO
IF OBJECT_ID(N'[dbo].[Product]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Product];
GO
IF OBJECT_ID(N'[dbo].[Store]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Store];
GO
IF OBJECT_ID(N'[dbo].[Currency]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Currency];
GO
IF OBJECT_ID(N'[dbo].[CurrencyRate]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CurrencyRate];
GO
IF OBJECT_ID(N'[dbo].[SystemTranslation]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SystemTranslation];
GO
IF OBJECT_ID(N'[dbo].[ContentTranslation]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ContentTranslation];
GO
IF OBJECT_ID(N'[dbo].[EventLog]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EventLog];
GO
IF OBJECT_ID(N'[dbo].[ProductAction]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductAction];
GO
IF OBJECT_ID(N'[dbo].[ProductLog]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductLog];
GO
IF OBJECT_ID(N'[dbo].[StoreAdvertising]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StoreAdvertising];
GO
IF OBJECT_ID(N'[dbo].[ProductPrice]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductPrice];
GO
IF OBJECT_ID(N'[dbo].[Language]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Language];
GO
IF OBJECT_ID(N'[dbo].[RetailAction]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RetailAction];
GO
IF OBJECT_ID(N'[dbo].[StoreAction]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StoreAction];
GO
IF OBJECT_ID(N'[dbo].[TerminalLanguage]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TerminalLanguage];
GO
IF OBJECT_ID(N'[dbo].[TerminalCurrency]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TerminalCurrency];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Advertising'
CREATE TABLE [dbo].[Advertising] (
    [AdvertisingID] int  NOT NULL,
    [ActivityStatus] tinyint  NOT NULL,
    [Image] varbinary(max)  NOT NULL
);
GO

-- Creating table 'Config'
CREATE TABLE [dbo].[Config] (
    [ConfigID] int  NOT NULL,
    [StoreID] nvarchar(5)  NOT NULL,
    [TerminalID] nvarchar(5)  NOT NULL,
    [ConfigValue] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Terminal'
CREATE TABLE [dbo].[Terminal] (
    [TerminalID] nvarchar(5)  NOT NULL,
    [StoreID] nvarchar(5)  NOT NULL,
    [MacAddress] nvarchar(max)  NOT NULL,
    [IPAddress] nchar(16)  NOT NULL,
    [ActivityStatus] tinyint  NOT NULL,
    [TerminalUID] nvarchar(max)  NOT NULL,
    [TerminalVersion] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Product'
CREATE TABLE [dbo].[Product] (
    [ProductID] int  NOT NULL,
    [BarcodeValue] nvarchar(20)  NOT NULL,
    [ActivityStatus] tinyint  NOT NULL,
    [Article] nvarchar(max)  NOT NULL,
    [CaptionID] int  NOT NULL,
    [DescriptionID] int  NOT NULL,
    [Image] varbinary(max)  NOT NULL
);
GO

-- Creating table 'Store'
CREATE TABLE [dbo].[Store] (
    [StoreID] nvarchar(5)  NOT NULL,
    [CaptionID] int  NOT NULL,
    [Image] varbinary(max)  NOT NULL
);
GO

-- Creating table 'Currency'
CREATE TABLE [dbo].[Currency] (
    [CurrencyCode] nvarchar(5)  NOT NULL,
    [CaptionID] int  NOT NULL,
    [Image] varbinary(max)  NOT NULL
);
GO

-- Creating table 'CurrencyRate'
CREATE TABLE [dbo].[CurrencyRate] (
    [CurrencyCode] nvarchar(5)  NOT NULL,
    [DateBegin] datetime  NOT NULL,
    [RateValue] decimal(20,10)  NOT NULL
);
GO

-- Creating table 'SystemTranslation'
CREATE TABLE [dbo].[SystemTranslation] (
    [TranslationID] int  NOT NULL,
    [LanguageCode] nvarchar(5)  NOT NULL,
    [TranslationValue] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ContentTranslation'
CREATE TABLE [dbo].[ContentTranslation] (
    [TranslationID] int  NOT NULL,
    [LanguageCode] nvarchar(5)  NOT NULL,
    [TranslationValue] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'EventLog'
CREATE TABLE [dbo].[EventLog] (
    [EventID] int IDENTITY(1,1) NOT NULL,
    [TerminalID] nvarchar(5)  NOT NULL,
    [EventDataTime] datetime  NOT NULL,
    [EventType] tinyint  NOT NULL,
    [EventSource] nvarchar(max)  NOT NULL,
    [EventDetails] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ProductAction'
CREATE TABLE [dbo].[ProductAction] (
    [StoreID] nvarchar(5)  NOT NULL,
    [ProductID] int  NOT NULL,
    [RetailActionID] int  NOT NULL
);
GO

-- Creating table 'ProductLog'
CREATE TABLE [dbo].[ProductLog] (
    [ProductLogID] int IDENTITY(1,1) NOT NULL,
    [ProductID] int  NOT NULL,
    [ScanDate] datetime  NOT NULL,
    [LanguageCode] nvarchar(max)  NOT NULL,
    [CurrencyCode] nvarchar(max)  NOT NULL,
    [TerminalID] nvarchar(5)  NOT NULL
);
GO

-- Creating table 'StoreAdvertising'
CREATE TABLE [dbo].[StoreAdvertising] (
    [StoreID] nvarchar(5)  NOT NULL,
    [TerminalID] nvarchar(5)  NOT NULL,
    [AdvertisingID] int  NOT NULL
);
GO

-- Creating table 'ProductPrice'
CREATE TABLE [dbo].[ProductPrice] (
    [StoreID] nvarchar(5)  NOT NULL,
    [ProductID] int  NOT NULL,
    [DateBegin] datetime  NOT NULL,
    [DateEnd] datetime  NOT NULL,
    [PriceValue] decimal(20,10)  NOT NULL
);
GO

-- Creating table 'Language'
CREATE TABLE [dbo].[Language] (
    [LanguageCode] nvarchar(5)  NOT NULL,
    [CaptionID] int  NOT NULL,
    [Image] varbinary(max)  NOT NULL
);
GO

-- Creating table 'RetailAction'
CREATE TABLE [dbo].[RetailAction] (
    [RetailActionID] int  NOT NULL,
    [DateBegin] datetime  NOT NULL,
    [DateEnd] datetime  NOT NULL,
    [ActivityStatus] tinyint  NOT NULL,
    [CaptionID] int  NOT NULL,
    [DescriptionID] int  NOT NULL
);
GO

-- Creating table 'StoreAction'
CREATE TABLE [dbo].[StoreAction] (
    [StoreID] nvarchar(5)  NOT NULL,
    [RetailActionID] int  NOT NULL
);
GO

-- Creating table 'TerminalLanguage'
CREATE TABLE [dbo].[TerminalLanguage] (
    [TerminalID] nvarchar(5)  NOT NULL,
    [StoreID] nvarchar(5)  NOT NULL,
    [LanguageCode] nvarchar(5)  NOT NULL
);
GO

-- Creating table 'TerminalCurrency'
CREATE TABLE [dbo].[TerminalCurrency] (
    [TerminalID] nvarchar(5)  NOT NULL,
    [StoreID] nvarchar(5)  NOT NULL,
    [CurrencyCode] nvarchar(5)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [AdvertisingID] in table 'Advertising'
ALTER TABLE [dbo].[Advertising]
ADD CONSTRAINT [PK_Advertising]
    PRIMARY KEY CLUSTERED ([AdvertisingID] ASC);
GO

-- Creating primary key on [ConfigID], [TerminalID], [StoreID] in table 'Config'
ALTER TABLE [dbo].[Config]
ADD CONSTRAINT [PK_Config]
    PRIMARY KEY CLUSTERED ([ConfigID], [TerminalID], [StoreID] ASC);
GO

-- Creating primary key on [TerminalID], [StoreID] in table 'Terminal'
ALTER TABLE [dbo].[Terminal]
ADD CONSTRAINT [PK_Terminal]
    PRIMARY KEY CLUSTERED ([TerminalID], [StoreID] ASC);
GO

-- Creating primary key on [ProductID], [BarcodeValue] in table 'Product'
ALTER TABLE [dbo].[Product]
ADD CONSTRAINT [PK_Product]
    PRIMARY KEY CLUSTERED ([ProductID], [BarcodeValue] ASC);
GO

-- Creating primary key on [StoreID] in table 'Store'
ALTER TABLE [dbo].[Store]
ADD CONSTRAINT [PK_Store]
    PRIMARY KEY CLUSTERED ([StoreID] ASC);
GO

-- Creating primary key on [CurrencyCode] in table 'Currency'
ALTER TABLE [dbo].[Currency]
ADD CONSTRAINT [PK_Currency]
    PRIMARY KEY CLUSTERED ([CurrencyCode] ASC);
GO

-- Creating primary key on [CurrencyCode] in table 'CurrencyRate'
ALTER TABLE [dbo].[CurrencyRate]
ADD CONSTRAINT [PK_CurrencyRate]
    PRIMARY KEY CLUSTERED ([CurrencyCode] ASC);
GO

-- Creating primary key on [TranslationID], [LanguageCode] in table 'SystemTranslation'
ALTER TABLE [dbo].[SystemTranslation]
ADD CONSTRAINT [PK_SystemTranslation]
    PRIMARY KEY CLUSTERED ([TranslationID], [LanguageCode] ASC);
GO

-- Creating primary key on [TranslationID], [LanguageCode] in table 'ContentTranslation'
ALTER TABLE [dbo].[ContentTranslation]
ADD CONSTRAINT [PK_ContentTranslation]
    PRIMARY KEY CLUSTERED ([TranslationID], [LanguageCode] ASC);
GO

-- Creating primary key on [EventID], [TerminalID] in table 'EventLog'
ALTER TABLE [dbo].[EventLog]
ADD CONSTRAINT [PK_EventLog]
    PRIMARY KEY CLUSTERED ([EventID], [TerminalID] ASC);
GO

-- Creating primary key on [ProductID], [RetailActionID], [StoreID] in table 'ProductAction'
ALTER TABLE [dbo].[ProductAction]
ADD CONSTRAINT [PK_ProductAction]
    PRIMARY KEY CLUSTERED ([ProductID], [RetailActionID], [StoreID] ASC);
GO

-- Creating primary key on [ProductLogID], [ProductID] in table 'ProductLog'
ALTER TABLE [dbo].[ProductLog]
ADD CONSTRAINT [PK_ProductLog]
    PRIMARY KEY CLUSTERED ([ProductLogID], [ProductID] ASC);
GO

-- Creating primary key on [StoreID], [TerminalID], [AdvertisingID] in table 'StoreAdvertising'
ALTER TABLE [dbo].[StoreAdvertising]
ADD CONSTRAINT [PK_StoreAdvertising]
    PRIMARY KEY CLUSTERED ([StoreID], [TerminalID], [AdvertisingID] ASC);
GO

-- Creating primary key on [StoreID], [ProductID], [DateBegin] in table 'ProductPrice'
ALTER TABLE [dbo].[ProductPrice]
ADD CONSTRAINT [PK_ProductPrice]
    PRIMARY KEY CLUSTERED ([StoreID], [ProductID], [DateBegin] ASC);
GO

-- Creating primary key on [LanguageCode] in table 'Language'
ALTER TABLE [dbo].[Language]
ADD CONSTRAINT [PK_Language]
    PRIMARY KEY CLUSTERED ([LanguageCode] ASC);
GO

-- Creating primary key on [RetailActionID] in table 'RetailAction'
ALTER TABLE [dbo].[RetailAction]
ADD CONSTRAINT [PK_RetailAction]
    PRIMARY KEY CLUSTERED ([RetailActionID] ASC);
GO

-- Creating primary key on [StoreID], [RetailActionID] in table 'StoreAction'
ALTER TABLE [dbo].[StoreAction]
ADD CONSTRAINT [PK_StoreAction]
    PRIMARY KEY CLUSTERED ([StoreID], [RetailActionID] ASC);
GO

-- Creating primary key on [TerminalID], [LanguageCode], [StoreID] in table 'TerminalLanguage'
ALTER TABLE [dbo].[TerminalLanguage]
ADD CONSTRAINT [PK_TerminalLanguage]
    PRIMARY KEY CLUSTERED ([TerminalID], [LanguageCode], [StoreID] ASC);
GO

-- Creating primary key on [TerminalID], [CurrencyCode], [StoreID] in table 'TerminalCurrency'
ALTER TABLE [dbo].[TerminalCurrency]
ADD CONSTRAINT [PK_TerminalCurrency]
    PRIMARY KEY CLUSTERED ([TerminalID], [CurrencyCode], [StoreID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------