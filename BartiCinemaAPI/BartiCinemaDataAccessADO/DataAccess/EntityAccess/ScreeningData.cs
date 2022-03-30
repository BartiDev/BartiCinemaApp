using BartiCinemaDataAccessADO.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BartiCinemaDataAccessADO.DataAccess
{
    public class ScreeningData : IScreeningData
    {
        private readonly IConfiguration _configuration;
        private readonly IDataAccess _data = new DataAccess();

        public ScreeningData(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<ScreeningDAL>> GetScreenings(DateTime startTime, DateTime endTime, int? movieId = null, int? cinemaId = null)
        {
            SqlMessage sqlMessage = new SqlMessage();
            sqlMessage.SqlBody = "Cinema.ufn_GetScreenings";
            string connectionString = _configuration.GetConnectionString("BartiCinemaDB");

            string startTimeString = startTime.ToString("yyyy-MM-dd");
            string endTimeString = endTime.ToString("yyyy-MM-dd");

            sqlMessage.Parameters = new SqlMessageParameter[]
            {
                new SqlMessageParameter(){Name = "@StartTime", Value = startTimeString},
                new SqlMessageParameter(){Name = "@EndTime", Value = endTimeString},
                new SqlMessageParameter(){Name = "@MovieId", Value = movieId},
                new SqlMessageParameter(){Name = "@CinemaId", Value = cinemaId}
            };
            sqlMessage.Type = SqlMessageType.UserDefinedFunction;
            return await _data.LoadData<ScreeningDAL>(connectionString, sqlMessage);
        }
    }
}
