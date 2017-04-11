CREATE TABLE [dbo].[Product_Locations] (
    [Locations_Id]     INT          IDENTITY (1, 1) NOT NULL,
    [Product_Location] VARCHAR (10) NOT NULL,
    [Product_Quantity] INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([Locations_Id] ASC)
);

