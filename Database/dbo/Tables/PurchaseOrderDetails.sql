CREATE TABLE [dbo].[PurchaseOrderDetails] (
    [PurchaseOrderDetails_Id] INT          IDENTITY (1, 1) NOT NULL,
    [Purchase Order Number]   INT          NOT NULL,
    [Product]                 VARCHAR (50) NOT NULL,
    [Quantity]                INT          NOT NULL,
    [Unit Price]              FLOAT        NOT NULL,
    [Extended Price]          FLOAT        NOT NULL,
    [Date Received]           DATE         NOT NULL,
    [Status]                  VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([PurchaseOrderDetails_Id] ASC),
    CONSTRAINT [FK_PurchaseOrderDetails_ToTable] FOREIGN KEY ([Purchase Order Number]) REFERENCES [dbo].[PurchaseOrders] ([PurchaseOrders_Id])
);

