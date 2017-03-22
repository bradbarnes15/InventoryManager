CREATE TABLE [dbo].[Orders] (
    [Order_Id]         INT          IDENTITY (1, 1) NOT NULL,
    [Order Date]       DATE         NOT NULL,
    [Employee]         VARCHAR (50) NOT NULL,
    [Shipping Address] VARCHAR (50) NOT NULL,
    [Ship City]        VARCHAR (50) NOT NULL,
    [Ship State]       VARCHAR (2)  NOT NULL,
    [Zip]              INT          NOT NULL,
    [Order Total]      MONEY        NOT NULL,
    [tax]              MONEY        NOT NULL,
    [Status]           VARCHAR (50) NOT NULL,
    [Closed Date]      DATE         NOT NULL,
    PRIMARY KEY CLUSTERED ([Order_Id] ASC)
);

