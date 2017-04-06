CREATE TABLE [dbo].[Product] (
    [Product_Id]   INT          IDENTITY (1, 1) NOT NULL,
    [Product_Code] VARCHAR (20) NOT NULL,
    [Product_Name] NCHAR (10)   NOT NULL,
    [Unit_Cost]    MONEY        NOT NULL,
    [List_Price]   MONEY        NOT NULL,
    [Discontinue]  BIT          DEFAULT ((0)) NOT NULL,
    [Category]     VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Product_Id] ASC)
);



