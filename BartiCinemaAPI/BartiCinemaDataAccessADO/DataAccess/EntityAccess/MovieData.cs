using BartiCinemaDataAccessADO.Entities;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace BartiCinemaDataAccessADO.DataAccess
{
    public class MovieData : IMovieData 
    {
        private readonly IConfiguration _configuration;
        IDataAccess _data = new DataAccess();

        public MovieData(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<MovieDAL>> GetMovies(int? movieId = null, string movieTitle = null, string movieDirector = null)
        {
            SqlMessage sqlMessage = new SqlMessage();
            sqlMessage.SqlBody = "Movie.ufn_GetMovies";
            string connectionString = _configuration.GetConnectionString("BartiCinemaDB");
            sqlMessage.Parameters = new SqlMessageParameter[]
            {
                new SqlMessageParameter(){Name = "@MovieId", Value = movieId},
                new SqlMessageParameter(){Name = "@MovieTitle", Value = movieTitle},
                new SqlMessageParameter(){Name = "@MovieDirector", Value = movieDirector}
            };
            sqlMessage.Type = SqlMessageType.UserDefinedFunction;
            return await _data.LoadData<MovieDAL>(connectionString, sqlMessage);
        }
    }
}
