CREATE FUNCTION [Cinema].[ufn_GetScreenings]
(
	@StartTime DATETIME2,
	@EndTime DATETIME2,
	@MovieId INT,
	@CinemaId INT
)
RETURNS TABLE
AS
RETURN
(
	SELECT s.Id
		, s.MovieId
		, s.RoomId
		, s.StartTime
	FROM Cinema.Screenings s
	LEFT JOIN Cinema.Rooms r ON s.RoomId = r.Id
	LEFT JOIN Cinema.Cinemas c on r.CinemaId = c.Id
	WHERE s.StartTime BETWEEN @StartTime AND @EndTime
	AND s.MovieId = ISNULL(@MovieId, s.MovieId)
	AND c.Id = ISNULL(@CinemaId, c.Id)
)