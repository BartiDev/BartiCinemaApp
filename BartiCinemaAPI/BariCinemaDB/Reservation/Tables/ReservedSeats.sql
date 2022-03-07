CREATE TABLE [Reservation].[ReservedSeats] (
    [Id]        INT IDENTITY (1, 1) NOT NULL,
    [BookingId] INT NOT NULL,
    [SeatId]    INT NOT NULL,
    CONSTRAINT [PK_ReservedSeats] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ReservedSeats_Bookings] FOREIGN KEY ([BookingId]) REFERENCES [Reservation].[Bookings] ([Id]),
    CONSTRAINT [FK_ReservedSeats_Seats] FOREIGN KEY ([SeatId]) REFERENCES [Cinema].[Seats] ([Id])
);

