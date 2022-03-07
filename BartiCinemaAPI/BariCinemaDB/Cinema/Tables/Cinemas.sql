CREATE TABLE [Cinema].[Cinemas] (
    [Id]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (256) NOT NULL,
    [City] NVARCHAR (128) NOT NULL,
    CONSTRAINT [PK_Cinemas] PRIMARY KEY CLUSTERED ([Id] ASC)
);

