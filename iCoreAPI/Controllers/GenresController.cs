using AutoMapper;
using iCoreAPI.DTOs;
using iCoreAPI.Entities;
using iCoreAPI.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iCoreAPI.Controllers
{
    [Route("api/genres")]
    [ApiController] // this used for validation.
    public class GenresController : ControllerBase
    {
        private readonly ILogger logger;
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public GenresController(ILogger<GenresController> logger, ApplicationDbContext context, IMapper mapper)
        {
            this.logger = logger;
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<GenreDTO>>> Get()
        {
            logger.LogInformation("Getting All Genres");
            var genres = await context.Genres.OrderBy(x => x.Name).ToListAsync();
            return mapper.Map<List<GenreDTO>>(genres);

            //return await context.Genres.ToListAsync();
            //return new List<Genre>() { new Genre() {Id=1 , Name="Computer" } }; //for Testing
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<GenreDTO>> Get(int id)
        {
            logger.LogDebug("Get Action is executed ...");

            var genre = await context.Genres.FirstOrDefaultAsync(x => x.Id == id);
            if(genre == null)
            {
                return NotFound();
            }
            return mapper.Map<GenreDTO>(genre);
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] GenreCreationDTO genreCreationDTO)
        {
            var genre = mapper.Map<Genre>(genreCreationDTO);
            context.Add(genre);
            await context.SaveChangesAsync();
            return NoContent();
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult> put(int id, [FromBody] GenreCreationDTO genreCreationDTO)
        {
            var genre = mapper.Map<Genre>(genreCreationDTO);
            genre.Id = id;
            context.Entry(genre).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int Id)
        {
            var genre = await context.Genres.FirstOrDefaultAsync(x => x.Id == Id);
            if(genre == null)
            {
                return NotFound();
            }
            context.Remove(genre);
            await context.SaveChangesAsync();
            return NoContent();
            
        }
    }
}
