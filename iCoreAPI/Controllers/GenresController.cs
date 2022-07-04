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

        public GenresController(ILogger<GenresController> logger, ApplicationDbContext context)
        {
            this.logger = logger;
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Genre>>> Get()
        {
            logger.LogInformation("Getting All Genres");
            return await context.Genres.ToListAsync();
            //return new List<Genre>() { new Genre() {Id=1 , Name="Computer" } }; //fro Testing
        }
        [HttpGet("{id}")]
        public ActionResult<Genre> Get(int id)
        {
            logger.LogDebug("Get Action is executed ...");

            throw new NotImplementedException();
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Genre genre)
        {
            context.Add(genre);
            await context.SaveChangesAsync();
            return NoContent();
        }
        [HttpPut]
        public ActionResult put([FromBody] Genre genre)
        {
            throw new NotImplementedException();
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
