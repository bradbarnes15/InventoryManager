CREATE TABLE [dbo].[Inventory] (
    [Inventory_Id]     INT          IDENTITY (1, 1) NOT NULL,
    [Product]          VARCHAR (50) NOT NULL,
    [On Hand]          INT          NOT NULL,
    [Reorder Level]    INT          NOT NULL,
    [Reorder Quantity] INT          NOT NULL,
    [On Order]         INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([Inventory_Id] ASC)
);

