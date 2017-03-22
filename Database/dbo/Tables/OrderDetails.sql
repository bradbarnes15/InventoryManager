CREATE TABLE [dbo].[OrderDetails] (
    [OrderDetails_Id] INT          NOT NULL,
    [Order_Id]        INT          NOT NULL,
    [Product]         VARCHAR (50) NULL,
    [Quantity]        INT          NULL,
    [Unit Price]      MONEY        NULL,
    [Extended Price]  MONEY        NULL,
    [Status]          NCHAR (10)   NULL,
    PRIMARY KEY CLUSTERED ([OrderDetails_Id] ASC),
    CONSTRAINT [FK_OrderDetails_ToTable] FOREIGN KEY ([Order_Id]) REFERENCES [dbo].[Orders] ([Order_Id])
);

