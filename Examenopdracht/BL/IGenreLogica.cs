using Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
    public interface IGenreLogica
    {
        Task<List<Genre>> NeemAlleGenres();
        Task<Genre> GeefGenre(int id);
        Task<List<Genre>> GeefGenresVoorBoek(int id);
        Task<int> KoppelGenresVoorBoek(int boekId, List<int> genreIds);
    }
}
