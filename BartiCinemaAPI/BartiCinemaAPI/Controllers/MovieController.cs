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
    public class MovieController : ControllerBase
    {
        private readonly IMovieData _movieData;

        public MovieController(IMovieData movieData)
        {
            _movieData = movieData;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieDAL>>> Get(int? id, string title, string director)
        {
            return await _movieData.GetMovies(id, title, director);
        }


    }
}
