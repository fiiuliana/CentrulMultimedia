using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CentrulMultimedia.Data;
using CentrulMultimedia.Models;
using CentrulMultimedia.ViewModels;
using Microsoft.Extensions.Logging;
using AutoMapper;

namespace CentrulMultimedia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<FilmsController>_logger;
        private readonly IMapper _mapper;

        
        public FilmsController(ApplicationDbContext context, ILogger<FilmsController> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        /// Returns films depending of the Year of the release
        /// </summary>
        /// <param name="minYearOfRelease">The year of the release</param>
        /// <returns>List of films released in the year = year of release </returns>
        [HttpGet]
        [Route("filter/{minYearOfRelease}")]
        public ActionResult<IEnumerable<Film>> FilterFilms(int minYearOfRelease) 
        {
            var query = _context.Films.Where(f => f.YearOfRelease >= minYearOfRelease);
            //after adding logger
            _logger.LogInformation(query.ToQueryString());
            //Console.WriteLine(query.ToQueryString());            
            return query.ToList();
        }

       
        // GET: api/Films
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Film>>> GetFilms(int? minYearOfRelease) 
        {
            if (minYearOfRelease == null) 
            { 
            return await _context.Films.ToListAsync();
            }
            return await _context.Films.Where(f => f.YearOfRelease >= minYearOfRelease).ToListAsync();
        }

        // GET: api/Films/Comments
        [HttpGet("{id}/Comments")]
        public ActionResult<IEnumerable<FilmsWithCommentsViewModel>> GetCommentsForFilm(int id) 
        {
            var query_v1 = _context.Comments.Where(c => c.Film.Id == id).Include(c => c.Film)     //.Include(c => c.Film).ToList();
                .Select(c => new FilmsWithCommentsViewModel
                {
                    Id = c.Film.Id,
                    Title = c.Film.Title,
                    Description = c.Film.Description,
                    Genre = c.Film.Genre,
                    LengthInMinutes = c.Film.LengthInMinutes,
                    YearOfRelease = c.Film.YearOfRelease,
                    Director = c.Film.Director,
                    DateTime = c.Film.DateTime,
                    Rating = c.Film.Rating,
                    Watched = c.Film.Watched,
                    Comments = c.Film.Comments.Select(pc => new CommentViewModel
                    {
                    Id = pc.Id,                    
                    Content = pc.Content,          
                    DateTime = pc.DateTime,
                    Stars = pc.Stars,
                    })
                });

            var query_v2 = _context.Films.Where(f => f.Id == id).Include(f => f.Comments).Select(f => new FilmsWithCommentsViewModel
            {
                Id = f.Id,
                Title = f.Title,
                Description = f.Description,
                Genre = f.Genre,
                LengthInMinutes = f.LengthInMinutes,
                YearOfRelease = f.YearOfRelease,
                Director = f.Director,
                DateTime = f.DateTime,
                Rating = f.Rating,
                Watched = f.Watched,
                Comments = f.Comments.Select(pc => new CommentViewModel
                {
                    Id = pc.Id,
                    Content = pc.Content,
                    DateTime = pc.DateTime,
                    Stars = pc.Stars,
                })
            });

            var query_v3 = _context.Films.Where(f => f.Id == id).Include(f => f.Comments)
                .Select(f => _mapper.Map<FilmsWithCommentsViewModel>(f));


            _logger.LogInformation(query_v1.ToQueryString());
           // return query_v1.ToList();
           // return query_v2.ToList();
            return query_v3.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="comment"></param>
        /// <returns></returns>
        // POST: api/Films/Comments
        [HttpPost("{id}/Comments")]
        public IActionResult PostCommentsForFilm(int id, Comment comment)
        {
            comment.Film = _context.Films.Find(id);
            if (comment.Film == null) {
                return NotFound();
            }

            _context.Comments.Add(comment);
            _context.SaveChanges();

            return Ok();
        }

        /// <summary>
        /// Returns all the films from the database
        /// </summary>
        /// <param name="id">The id of the film</param>
        /// <returns>List of films</returns>
        // GET: api/Films/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FilmViewModel>> GetFilm(int id)
        {
            var film = await _context.Films.FindAsync(id);

            //Deleted after adding Automapper
            //      var filmViewModel =  new FilmViewModel
            //      {
            //      Id = film.Id,
            //      Title = film.Title,
            //      Description = film.Description,
            //      Genre = film.Genre,
            //      LengthInMinutes = film.LengthInMinutes,
            //      YearOfRelease = film.YearOfRelease,
            //      Director = film.Director,
            //      DateTime = film.DateTime,
            //      Rating = film.Rating,
            //      Watched = film.Watched
            //      };

            //Automapper
            var filmViewModel = _mapper.Map<FilmViewModel>(film);

            if (film == null)
            {
                return NotFound();
            }

            return filmViewModel;
        }

        /// <summary>
        /// Updates the films
        /// </summary>
        /// <param name="id">The id of the film</param>
        /// <param name="film">The name of the film</param>
        /// <returns>Return is empty for now</returns>
        // PUT: api/Films/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFilm(int id, Film film)
        {
            if (id != film.Id)
            {
                return BadRequest();
            }

            _context.Entry(film).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FilmExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        /// <summary>
        /// Adds a film to the database
        /// </summary>
        /// <param name="film">The complete infomation about the film</param>
        /// <returns>No return statement</returns>
        // POST: api/Films
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Film>> PostFilm(Film film)
        {
            _context.Films.Add(film);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFilm", new { id = film.Id }, film);
        }

        // DELETE: api/Films/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFilm(int id)
        {
            var film = await _context.Films.FindAsync(id);
            if (film == null)
            {
                return NotFound();
            }

            _context.Films.Remove(film);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FilmExists(int id)
        {
            return _context.Films.Any(e => e.Id == id);
        }
    }
}
