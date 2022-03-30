CREATE FUNCTION [Movie].[ufn_GetMoviesByScreeningDate]
(
	@startTime DATETIME2,
	@endTime DATETIME2,
	@cinemaId INT
)
RETURNS TABLE
AS
RETURN
(
	SELECT TOP 10 m.Id
		 , m.Title
		 , m.Director
		 , m.Genres
		 , m.ReleaseDate
		 , m.Description
		 , m.Certificate
		 , m.ImdbRating
		 , m.Runtime
		 , m.PosterLink
	FROM Movie.Movies m
	LEFT JOIN Cinema.Screenings s ON m.Id = s.MovieId
	LEFT JOIN Cinema.Rooms r ON s.RoomId = r.Id
	LEFT JOIN Cinema.Cinemas c ON r.CinemaId = c.Id
	WHERE c.Id = ISNULL(@cinemaId, c.Id)
	AND s.StartTime BETWEEN @startTime AND @endTime
	ORDER BY m.ImdbRating DESC
)