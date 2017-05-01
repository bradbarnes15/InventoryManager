CREATE TABLE [dbo].[OrderDetails] (
    [OrderDetails_Id] INT          NOT NULL,
    [Order_Id]        INT          NOT NULL,
    [Product]         VARCHAR (50) NOT NULL,
    [Product_Code]    VARCHAR (5)  NOT NULL,
    [Quantity]        INT          NOT NULL,
    [Unit_Price]      FLOAT (53)   NOT NULL,
    [Extended_Price]  FLOAT (53)   NOT NULL,
    PRIMARY KEY CLUSTERED ([OrderDetails_Id] ASC)
);









