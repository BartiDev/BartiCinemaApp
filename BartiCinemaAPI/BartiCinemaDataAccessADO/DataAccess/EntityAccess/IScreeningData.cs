using BartiCinemaDataAccessADO.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BartiCinemaDataAccessADO.DataAccess
{
    public interface IScreeningData
    {
        Task<List<ScreeningDAL>> GetScreenings(DateTime startTime, DateTime endTime, int? movieId = null, int? cinemaId = null);
    }
}