CREATE TABLE [dbo].[PurchaseOrders] (
    [PurchaseOrders_Id] INT          IDENTITY (1, 1) NOT NULL,
    [Order_Date]        DATE         NOT NULL,
    [Created_By]        VARCHAR (50) NOT NULL,
    [Created_Date]      DATE         NOT NULL,
    [Shipping_Fee]      FLOAT (53)   NOT NULL,
    [Tax]               FLOAT (53)   NOT NULL,
    [Payment_Date]      DATE         NOT NULL,
    [Payment_Amount]    FLOAT (53)   NOT NULL,
    [Order_Subtotal]    FLOAT (53)   NOT NULL,
    [Order_Total]       FLOAT (53)   NOT NULL,
    [Status]            VARCHAR (20) NOT NULL,
    [Date_Received]     DATE         NOT NULL,
    PRIMARY KEY CLUSTERED ([PurchaseOrders_Id] ASC)
);





