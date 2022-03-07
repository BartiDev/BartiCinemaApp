CREATE TABLE [Reservation].[Bookings] (
    [Id]          INT IDENTITY (1, 1) NOT NULL,
    [ScreeningId] INT NOT NULL,
    [CustomerId]  INT NOT NULL,
    CONSTRAINT [PK_Bookings] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Bookings_Customers] FOREIGN KEY ([CustomerId]) REFERENCES [Customer].[Customers] ([Id]),
    CONSTRAINT [FK_Bookings_Screenings] FOREIGN KEY ([ScreeningId]) REFERENCES [Cinema].[Screenings] ([Id])
);

