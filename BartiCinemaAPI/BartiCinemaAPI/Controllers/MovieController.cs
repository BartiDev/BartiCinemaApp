using BartiCinemaDataAccessADO.DataAccess;
using BartiCinemaDataAccessADO.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BartiCinemaAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieData _movieData;

        public MovieController(IMovieData movieData)
        {
            _movieData = movieData;
        }

        [HttpGet]
        //[ActionName("GetMovies")]
        public async Task<IEnumerable<MovieDAL>> Get(int? id, string title, string director)
        {
            return await _movieData.GetMovies(id, title, director);
        }

        [HttpGet]
        //[ActionName("GetMoviesByScreeningDate")]
        public async Task<IEnumerable<MovieDAL>> GetMoviesByScreeningDate()
        {
            DateTime startTime = new DateTime(2022, 3, 27);
            DateTime endTime = new DateTime(2022, 4, 5);
            return await _movieData.GetMoviesByScreeningDate(startTime, endTime, 1);
        }
    }
}
