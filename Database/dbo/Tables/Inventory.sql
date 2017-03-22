CREATE TABLE [dbo].[Inventory] (
    [Inventory_Id]     INT          IDENTITY (1, 1) NOT NULL,
    [Product]          VARCHAR (50) NOT NULL,
    [On Hand]          INT          NOT NULL,
    [Reorder Level]    INT          NULL,
    [Reorder Quantity] INT          NULL,
    [On Order]         INT          NULL,
    PRIMARY KEY CLUSTERED ([Inventory_Id] ASC)
);

