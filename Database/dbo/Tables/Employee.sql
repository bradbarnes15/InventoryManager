CREATE TABLE [dbo].[Employee] (
    [employee_id]        INT          IDENTITY (1, 1) NOT NULL,
    [first_name]         VARCHAR (50) NOT NULL,
    [last_name]          VARCHAR (50) NOT NULL,
    [username]           NCHAR (10)   NOT NULL,
    [encrypted_password] TEXT         NOT NULL,
    PRIMARY KEY CLUSTERED ([employee_id] ASC)
);

