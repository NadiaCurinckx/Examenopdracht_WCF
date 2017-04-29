using BL;
using DA;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Services
{

    public class GenreService : IGenreService
    {
        private readonly IGenreLogica _genreLogica = new GenreLogica();

        public Task<Genre> GeefGenre(int id)
        {
            return _genreLogica.GeefGenre(id);
        }

        public Task<List<Genre>> NeemAlleGenres()
        {
            return _genreLogica.NeemAlleGenres();
        }
    }
}
