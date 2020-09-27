using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using capstone.Data;
using capstone.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace capstone.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class MovieInfoController : ControllerBase
    {

        [HttpGet]
        public IEnumerable<MovieInfo> Get()
        {
            MovieInfo[] movies = null;
            using (var context = new ApplicationDbContext())
            {
                movies = context.MovieInfos.ToArray();
            }
            return movies;

        }
        [HttpPost]
        public MovieInfo Post([FromBody]MovieInfo movies)
        {
            using (var context = new ApplicationDbContext())
            {
                context.MovieInfos.Add(movies);
                context.SaveChanges();
            }
            return movies;
        }
    }
}
