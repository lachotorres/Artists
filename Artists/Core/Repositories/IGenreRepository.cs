using Artists.Core.Models;
using System.Collections.Generic;

namespace Artists.Core.Repositories
{
    public interface IGenreRepository
    {
        IEnumerable<Genre> GetGenres();
    }
}
