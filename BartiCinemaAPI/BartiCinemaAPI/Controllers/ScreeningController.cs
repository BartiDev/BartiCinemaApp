using BartiCinemaDataAccessADO.DataAccess;
using BartiCinemaDataAccessADO.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BartiCinemaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScreeningController : ControllerBase
    {
        private readonly IScreeningData _screeningData;

        public ScreeningController(IScreeningData screeningData)
        {
            _screeningData = screeningData;
        }

        [HttpGet]
        public async Task<IEnumerable<ScreeningDAL>> GetScreenings(DateTime startTime, DateTime endTime, int? movieId, int? cinemaId)
        {
            return await _screeningData.GetScreenings(startTime, endTime, movieId, cinemaId);
        }
    }
}
