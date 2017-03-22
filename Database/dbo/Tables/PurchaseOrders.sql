CREATE TABLE [dbo].[PurchaseOrders] (
    [PurchaseOrders_Id] INT          IDENTITY (1, 1) NOT NULL,
    [Order Date]        DATE         NOT NULL,
    [Created By]        VARCHAR (50) NOT NULL,
    [Created Date]      DATE         NOT NULL,
    [Shipping Fee]      MONEY        NOT NULL,
    [Taxes]             MONEY        NOT NULL,
    [Payment Date]      DATE         NOT NULL,
    [Payment Amount]    MONEY        NOT NULL,
    [Order Subtotal]    MONEY        NOT NULL,
    [Order Total]       MONEY        NOT NULL,
    PRIMARY KEY CLUSTERED ([PurchaseOrders_Id] ASC)
);

