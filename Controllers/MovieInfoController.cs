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
        private ApplicationDbContext _context;
        public MovieInfoController(ApplicationDbContext context) {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<MovieInfo> Get()
        {
                var movies = _context.MovieInfos.ToArray();
                return movies;
        }

        [HttpPost]
        public MovieInfo Post([FromBody]MovieInfo movies)
        {
            
            _context.MovieInfos.Add(movies);
            _context.SaveChanges();
           return movies;
        }
    }
}
