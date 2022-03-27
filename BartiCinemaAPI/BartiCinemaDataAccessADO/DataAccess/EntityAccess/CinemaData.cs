using BartiCinemaDataAccessADO.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BartiCinemaDataAccessADO.DataAccess
{
    public class CinemaData : ICinemaData
    {
        private readonly IConfiguration _configuration;
        private readonly IDataAccess _data = new DataAccess();

        public CinemaData(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<CinemaDAL> GetCinema()
        {
            SqlMessage sqlMessage = new SqlMessage();
            sqlMessage.SqlBody = "Cinema.ufn_GetCinema";
            string connectionString = _configuration.GetConnectionString("BartiCinemaDB");
            sqlMessage.Parameters = new SqlMessageParameter[] { };
            sqlMessage.Type = SqlMessageType.UserDefinedFunction;

            List<CinemaDAL> cinemas = await _data.LoadData<CinemaDAL>(connectionString, sqlMessage);

            return cinemas[0];
        }
    }
}
