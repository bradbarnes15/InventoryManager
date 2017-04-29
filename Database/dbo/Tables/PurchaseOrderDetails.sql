CREATE TABLE [dbo].[PurchaseOrderDetails] (
    [PurchaseOrderDetails_Id] INT          IDENTITY (1, 1) NOT NULL,
    [Purchase_Order_Number]   INT          NOT NULL,
    [Product]                 VARCHAR (50) NOT NULL,
    [Quantity]                INT          NOT NULL,
    [Unit_Price]              FLOAT (53)   NOT NULL,
    [Extended_Price]          FLOAT (53)   NOT NULL,
    PRIMARY KEY CLUSTERED ([PurchaseOrderDetails_Id] ASC)
);







