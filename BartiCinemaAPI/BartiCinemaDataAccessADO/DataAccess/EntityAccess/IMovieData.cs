using BartiCinemaDataAccessADO.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BartiCinemaDataAccessADO.DataAccess
{
    public interface IMovieData
    {
        Task<List<MovieDAL>> GetMovies(int? movieId = null, string movieTitle = null, string movieDirector = null);
    }
}