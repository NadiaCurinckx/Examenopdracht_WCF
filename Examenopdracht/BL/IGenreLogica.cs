using Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
    public  interface IGenreLogica
    {
        Task<List<Genre>> NeemAlleGenres();
        Task<Genre> GeefGenre(int id);

        Task GenreOpslaan(Genre genre);
        Task GenreWijzigen(Genre genre);
        Task GenreVerwijderen(int code);
    }
}
