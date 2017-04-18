CREATE TABLE [dbo].[Orders] (
    [Order_Id]         INT          IDENTITY (1, 1) NOT NULL,
    [Order_Date]       DATE         NOT NULL,
    [Employee]         VARCHAR (50) NOT NULL,
    [Shipping_Address] VARCHAR (50) NOT NULL,
    [Ship_City]        VARCHAR (50) NOT NULL,
    [Ship_State]       VARCHAR (2)  NOT NULL,
    [Zip]              INT          NOT NULL,
    [Order_Total]      FLOAT (53)   NOT NULL,
    [Tax]              FLOAT (53)   NOT NULL,
    [Status]           VARCHAR (50) NOT NULL,
    [Closed_Date]      DATE         NOT NULL,
    PRIMARY KEY CLUSTERED ([Order_Id] ASC)
);



