CREATE TABLE [dbo].[Customers] (
    [Customer_Id]    INT          IDENTITY (1, 1) NOT NULL,
    [Company]        VARCHAR (50) NOT NULL,
    [Last Name]      VARCHAR (50) NOT NULL,
    [First Name]     VARCHAR (50) NOT NULL,
    [Job Title]      VARCHAR (50) NOT NULL,
    [Phone Number]   VARCHAR (50) NOT NULL,
    [Address]        VARCHAR (50) NOT NULL,
    [City]           VARCHAR (50) NOT NULL,
    [State/Province] VARCHAR (50) NOT NULL,
    [Zip]            INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([Customer_Id] ASC)
);

