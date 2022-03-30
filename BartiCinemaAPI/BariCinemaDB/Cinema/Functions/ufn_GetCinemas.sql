CREATE FUNCTION [Cinema].[ufn_GetCinemas]()
RETURNS TABLE
AS
RETURN
(
	SELECT TOP 1 * FROM Cinema.Cinemas
)