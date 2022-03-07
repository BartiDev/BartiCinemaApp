CREATE TABLE [Cinema].[Rooms] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [Name]     NVARCHAR (256) NOT NULL,
    [CinemaId] INT            NOT NULL,
    [SeatsQty] INT            NOT NULL,
    CONSTRAINT [PK_Rooms] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Rooms_Cinemas] FOREIGN KEY ([CinemaId]) REFERENCES [Cinema].[Cinemas] ([Id])
);

