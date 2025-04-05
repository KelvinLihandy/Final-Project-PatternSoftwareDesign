-- MsBrand
CREATE TABLE [dbo].[MsBrand] (
    [BrandID]      INT          IDENTITY (1, 1) NOT NULL,
    [BrandName]    VARCHAR (50) NOT NULL,
    [BrandCountry] VARCHAR (50) NOT NULL,
    [BrandClass]   VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([BrandID] ASC)
);

-- MsCategory
CREATE TABLE [dbo].[MsCategory] (
    [CategoryID]   INT          IDENTITY (1, 1) NOT NULL,
    [CategoryName] VARCHAR (15) NOT NULL,
    PRIMARY KEY CLUSTERED ([CategoryID] ASC)
);

-- MsUser
CREATE TABLE [dbo].[MsUser] (
    [UserID]       INT           IDENTITY (1, 1) NOT NULL,
    [UserName]     VARCHAR (100) NOT NULL,
    [UserPassword] VARCHAR (20)  NOT NULL,
    [UserEmail]    VARCHAR (100) NOT NULL,
    [UserDOB]      DATE          NOT NULL,
    [UserGender]   VARCHAR (10)  NOT NULL,
    [UserRole]     VARCHAR (10)  NOT NULL,
    PRIMARY KEY CLUSTERED ([UserID] ASC)
);

-- MsJewel
CREATE TABLE [dbo].[MsJewel] (
    [JewelID]          INT           IDENTITY (1, 1) NOT NULL,
    [BrandID]          INT           NOT NULL,
    [CategoryID]       INT           NOT NULL,
    [JewelName]        VARCHAR (100) NOT NULL,
    [JewelPrice]       INT           NOT NULL,
    [JewelReleaseYear] INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([JewelID] ASC),
    FOREIGN KEY ([BrandID]) REFERENCES [dbo].[MsBrand] ([BrandID]),
    FOREIGN KEY ([CategoryID]) REFERENCES [dbo].[MsCategory] ([CategoryID])
);

-- Cart
CREATE TABLE [dbo].[Cart] (
    [UserID]   INT NOT NULL,
    [JewelID]  INT NOT NULL,
    [Quantity] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([UserID] ASC, [JewelID] ASC),
    FOREIGN KEY ([JewelID]) REFERENCES [dbo].[MsJewel] ([JewelID]),
    FOREIGN KEY ([UserID]) REFERENCES [dbo].[MsUser] ([UserID])
);

-- TransactionHeader
CREATE TABLE [dbo].[TransactionHeader] (
    [TransactionID]     INT          IDENTITY (1, 1) NOT NULL,
    [UserID]            INT          NOT NULL,
    [TransactionDate]   DATE         NOT NULL,
    [PaymentMethod]     VARCHAR (15) NOT NULL,
    [TransactionStatus] VARCHAR (30) NOT NULL,
    PRIMARY KEY CLUSTERED ([TransactionID] ASC),
    FOREIGN KEY ([UserID]) REFERENCES [dbo].[MsUser] ([UserID])
);

-- TransactionDetail
CREATE TABLE [dbo].[TransactionDetail] (
    [TransactionID] INT NOT NULL,
    [JewelID]       INT NOT NULL,
    [Quantity]      INT NOT NULL,
    PRIMARY KEY CLUSTERED ([TransactionID] ASC, [JewelID] ASC),
    FOREIGN KEY ([JewelID]) REFERENCES [dbo].[MsJewel] ([JewelID]),
    FOREIGN KEY ([TransactionID]) REFERENCES [dbo].[TransactionHeader] ([TransactionID])
);