using iCoreAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iCoreAPI.Services
{
    public class InMemoryRepository : IRepository
    {
        private List<Genre> _genres;
        public InMemoryRepository()
        {
            _genres = new List<Genre>()
            {
                new Genre(){Id=1, Name="Computers"},
                new Genre(){Id=2 , Name="Mobile"}
            };
        }

        public List<Genre> getAllGenre()
        {
            return _genres;
        }

        public Genre getGenreById(int id)
        {
            return _genres.FirstOrDefault(x => x.Id == id);
        }
    }
}
