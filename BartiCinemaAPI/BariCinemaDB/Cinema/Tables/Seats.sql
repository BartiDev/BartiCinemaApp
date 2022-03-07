CREATE TABLE [Cinema].[Seats] (
    [Id]     INT IDENTITY (1, 1) NOT NULL,
    [Row]    INT NOT NULL,
    [Number] INT NOT NULL,
    [RoomId] INT NOT NULL,
    CONSTRAINT [PK_Seats] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Seats_Rooms] FOREIGN KEY ([RoomId]) REFERENCES [Cinema].[Rooms] ([Id])
);

