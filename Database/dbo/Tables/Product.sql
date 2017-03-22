CREATE TABLE [dbo].[Product] (
    [Product_Id]   INT          IDENTITY (1, 1) NOT NULL,
    [Product Code] VARCHAR (20) NOT NULL,
    [Product Name] NCHAR (10)   NOT NULL,
    [Unit Cost]    MONEY        NOT NULL,
    [List Price]   MONEY        NOT NULL,
    [Discontinue]  BIT          NOT NULL,
    [Category]     VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Product_Id] ASC)
);

