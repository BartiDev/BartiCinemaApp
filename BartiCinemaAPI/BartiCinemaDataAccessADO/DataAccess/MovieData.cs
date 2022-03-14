using BartiCinemaDataAccessADO.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace BartiCinemaDataAccessADO.DataAccess
{
    public class MovieData
    {
        IDataAccess _data = new DataAccess();

        public List<MovieDAL> GetMovies(int? movieId = null, string movieTitle = null, string movieDirector = null)
        {
            SqlMessage sqlMessage = new SqlMessage();
            sqlMessage.SqlBody = "Movie.ufn_GetMovies";
            string connectionString = ConfigurationManager.ConnectionStrings["BartiCinemaDB"].ConnectionString;
            sqlMessage.Parameters = new SqlMessageParameter[]
            {
                new SqlMessageParameter(){Name = "@MovieId", Value = movieId},
                new SqlMessageParameter(){Name = "@MovieTitle", Value = movieTitle},
                new SqlMessageParameter(){Name = "@MovieDirector", Value = movieDirector}
            };
            sqlMessage.Type = SqlMessageType.UserDefinedFunction;
            return _data.LoadData<MovieDAL>(connectionString, sqlMessage);
        }
    }
}
