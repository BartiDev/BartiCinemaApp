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
        private readonly IDataAccess _data = new DataAccess();

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

        public async Task<List<MovieDAL>> GetMoviesByScreeningDate(DateTime startTime, DateTime endTime, int cinemaId)
        {
            SqlMessage sqlMessage = new SqlMessage();
            sqlMessage.SqlBody = "Movie.ufn_GetMoviesByScreeningDate";
            string connectionString = _configuration.GetConnectionString("BartiCinemaDB");

            string startTimeString = startTime.ToString("yyyy-MM-dd");
            string endTimeString = endTime.ToString("yyyy-MM-dd");

            sqlMessage.Parameters = new SqlMessageParameter[]
            {
                new SqlMessageParameter(){Name = "@StartTime", Value = startTimeString},
                new SqlMessageParameter(){Name = "@EndTime", Value = endTimeString},
                new SqlMessageParameter(){Name = "@CinemaId", Value = cinemaId}
            };
            sqlMessage.Type = SqlMessageType.UserDefinedFunction;
            return await _data.LoadData<MovieDAL>(connectionString, sqlMessage);
        }
    }
}
