CREATE TABLE [dbo].[Inventory] (
    [Inventory_Id]     INT          IDENTITY (1, 1) NOT NULL,
    [Product_Id]       INT          NOT NULL,
    [Product]          VARCHAR (50) NOT NULL,
    [On_Hand]          INT          NOT NULL,
    [Reorder_Level]    INT          NOT NULL,
    [Reorder_Quantity] INT          NOT NULL,
    [On_Order]         INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([Inventory_Id] ASC),
    CONSTRAINT [FK_Inventory_ToTable] FOREIGN KEY ([Product_Id]) REFERENCES [dbo].[Product] ([Product_Id])
);







