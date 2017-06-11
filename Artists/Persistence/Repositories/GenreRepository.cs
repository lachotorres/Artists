using Artists.Core.Models;
using Artists.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Artists.Persistence.Repositories
{

    public class GenreRepository : IGenreRepository
    {

        private readonly ApplicationDbContext _context;

        public GenreRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Genre> GetGenres()
        {

            return _context.Genres.ToList();
        }
    }
}