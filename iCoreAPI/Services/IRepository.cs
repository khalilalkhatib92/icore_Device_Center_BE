﻿using iCoreAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iCoreAPI.Services
{
    public interface IRepository
    {
        void AddGenre(Genre genre);
        Task<List<Genre>> getAllGenre();
        Genre getGenreById(int id);
    }
}
