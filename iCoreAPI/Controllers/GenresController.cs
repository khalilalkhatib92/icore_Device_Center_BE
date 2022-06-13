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
        public List<Genre> Get()
        {
            return repository.getAllGenre();
        }
        [HttpGet]
        public Genre Get(int id)
        {
            var genre = repository.getGenreById(id);
            if(genre == null)
            {
                //return NotFound();
            }
            return genre;
        }
        [HttpPost]
        public void Post()
        {

        }
        [HttpPut]
        public void put(int id)
        {

        }
        [HttpDelete]
        public void Delete(int id)
        {

        }
    }
}
