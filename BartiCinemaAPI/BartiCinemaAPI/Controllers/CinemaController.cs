using BartiCinemaDataAccessADO.DataAccess;
using BartiCinemaDataAccessADO.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BartiCinemaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CinemaController : ControllerBase
    {
        private readonly ICinemaData _cinemaData;

        public CinemaController(ICinemaData cinemaData)
        {
            _cinemaData = cinemaData;
        }

        [HttpGet]
        public async Task<CinemaDAL> Get()
        {
            return await _cinemaData.GetCinema();
        }
    }
}
