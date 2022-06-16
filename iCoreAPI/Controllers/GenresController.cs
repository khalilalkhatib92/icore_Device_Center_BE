using iCoreAPI.Entities;
using iCoreAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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
        private readonly IRepository repository;
        private readonly ILogger logger;
        // Depndency Injection using Losslly Coupling.
        public GenresController(IRepository repository, ILogger<GenresController> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }
        [HttpGet]
        public async Task<ActionResult<List<Genre>>> Get()
        {
            logger.LogInformation("Getting All Genres");
            return await repository.getAllGenre();
        }
        [HttpGet("{id}")]
        public ActionResult<Genre> Get(int id, [BindRequired] string name)
        {
            logger.LogDebug("Get Action is executed ...");
            var genre = repository.getGenreById(id);
            if(genre == null)
            {
                logger.LogWarning("the genre with id {id} Not Found?!!");
                return NotFound();
            }
            return genre;
        }
        [HttpPost]
        public ActionResult Post([FromBody] Genre genre)
        {
            repository.AddGenre(genre);
            return NoContent();
        }
        [HttpPut]
        public ActionResult put([FromBody] Genre genre)
        {
            return NoContent();
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            return NoContent();
        }
    }
}
