using iCoreAPI.Entities;
using iCoreAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iCoreAPI.Controllers
{
    [Route("api/genres")]
    public class GenresController : ControllerBase
    {
        private readonly IRepository repository;

        public GenresController(IRepository repository)
        {
            this.repository = repository;
        }
        [HttpGet()]
        public ActionResult<List<Genre>> Get()
        {
            return repository.getAllGenre();
        }
        [HttpGet]
        public ActionResult<Genre> Get(int id)
        {
            var genre = repository.getGenreById(id);
            if(genre == null)
            {
                return NotFound();
            }
            return genre;
        }
        [HttpPost]
        public ActionResult Post()
        {
            return NoContent();
        }
        [HttpPut]
        public ActionResult put(int id)
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
