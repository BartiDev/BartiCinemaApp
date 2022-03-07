CREATE TABLE [Customer].[Customers] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [FirstName] NVARCHAR (128) NOT NULL,
    [LastName]  NVARCHAR (128) NOT NULL,
    [Email]     NVARCHAR (256) NOT NULL,
    CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED ([Id] ASC)
);

