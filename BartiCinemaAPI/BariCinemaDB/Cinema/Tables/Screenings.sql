CREATE TABLE [Cinema].[Screenings] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [MovieId]   INT           NOT NULL,
    [RoomId]    INT           NOT NULL,
    [StartTime] DATETIME2 (7) NOT NULL,
    CONSTRAINT [PK_Screenings] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Screenings_Movies] FOREIGN KEY ([MovieId]) REFERENCES [Movie].[Movies] ([Id]),
    CONSTRAINT [FK_Screenings_Rooms] FOREIGN KEY ([RoomId]) REFERENCES [Cinema].[Rooms] ([Id])
);

