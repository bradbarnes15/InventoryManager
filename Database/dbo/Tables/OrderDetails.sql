CREATE TABLE [dbo].[OrderDetails] (
    [OrderDetails_Id] INT          NOT NULL,
    [Order_Id]        INT          NOT NULL,
    [Product]         VARCHAR (50) NOT NULL,
    [Quantity]        INT          NOT NULL,
    [Unit_Price]      FLOAT (53)   NOT NULL,
    [Extended_Price]  FLOAT (53)   NOT NULL,
    [Status]          NCHAR (10)   NOT NULL,
    PRIMARY KEY CLUSTERED ([OrderDetails_Id] ASC),
    CONSTRAINT [FK_OrderDetails_ToTable] FOREIGN KEY ([Order_Id]) REFERENCES [dbo].[Orders] ([Order_Id])
);



