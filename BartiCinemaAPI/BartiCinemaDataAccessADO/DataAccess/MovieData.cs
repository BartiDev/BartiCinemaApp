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

        public List<MovieDAL> GetMovies()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["BartiCinemaDB"].ConnectionString;
            string functionName = "Movie.ufn_GetMovies";
            return _data.LoadData<MovieDAL>(connectionString, functionName);
        }
    }
}
