create procedure Movie.usp_GetMovies
as
begin
	select top 20 * from Movie.Movies
end