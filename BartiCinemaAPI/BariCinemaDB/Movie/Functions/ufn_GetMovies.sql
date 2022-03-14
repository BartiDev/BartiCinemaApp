
create FUNCTION [Movie].[ufn_GetMovies]
(
	@movieId INT,
	@movieTitle NVARCHAR(100),
	@movieDirector NVARCHAR(50)
)
RETURNS @resultTable TABLE
(
	Id INT,
	Title NVARCHAR(512),
	Director NVARCHAR(256),
	Genres NVARCHAR(256),
	ReleaseDate DATETIME2,
	Description NVARCHAR(2048),
	Certificate NVARCHAR(128),
	ImdbRating DECIMAL(3,1),
	Runtime INT,
	PosterLink NVARCHAR(512)
)
AS
begin
	INSERT @resultTable
	SELECT Id
		 , Title
		 , Director
		 , Genres
		 , ReleaseDate
		 , Description
		 , ISNULL(Certificate, '') as Certificate
		 , ImdbRating
		 , Runtime
		 , PosterLink
	FROM Movie.Movies 
	WHERE Id = ISNULL(@movieId, Id)
	AND Title like CASE WHEN @movieTitle IS NULL THEN Title ELSE '%' + @movieTitle + '%' END
	AND Director like CASE WHEN @movieDirector IS NULL THEN Director ELSE '%' + @movieDirector + '%' END
	RETURN
end