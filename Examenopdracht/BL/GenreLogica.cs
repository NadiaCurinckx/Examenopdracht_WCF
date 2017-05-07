using DA;
using Model;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.Entity;

namespace BL
{
    public    class GenreLogica : IGenreLogica
    {
        private readonly IBoekenDatabase _database = new BoekenDatabase();        

        public Task<List<Genre>> NeemAlleGenres()
        {
            return _database.Genres.ToListAsync();
        }

        public Task<Genre> GeefGenre(Int32 id)
        {

            return _database.Genres.SingleOrDefaultAsync(x => x.Id == id);

        }

        public Task<List<Genre>> GeefGenresVoorBoek(int id)
        {
            return _database.Genres.Where(g => g.Boeken.Select(b => b.Id).Contains(id)).ToListAsync();
        }

        public async Task<int> KoppelGenresVoorBoek(int boekId, List<int> genreIds)
        {
            var boek = await _database.Boeken.Include(x => x.Genres).FirstOrDefaultAsync(b => b.Id == boekId);
            if (boek != null)
            {
                var genres = await _database.Genres.Where(g => genreIds.Contains(g.Id)).ToListAsync();
                foreach (var genre in boek.Genres)
                {
                    genre.Boeken?.Remove(boek);
                }
                boek.Genres = genres;             
            }

            return await _database.SaveChangesAsync();
        }

        //public Task GenreOpslaan(Genre genre)
        //{
        //    _database.Genres.Add(genre);
        //    return _database.SaveChangesAsync();
        //}



        //public async Task GenreWijzigen(Genre genre)
        //{
        //    var huidigGenre = await _database.Genres.SingleOrDefaultAsync(x => x.Id == genre.Id);
        //    if (huidigGenre != null)
        //    {
        //        huidigGenre.Omschrijving = genre.Omschrijving;
        //    }
        //    await _database.SaveChangesAsync();
        //}

        //public async Task GenreVerwijderen(Int32 id)
        //{
        //    var huidigGenre = await _database.Genres.SingleOrDefaultAsync(x => x.Id == id);
        //    if (huidigGenre != null)
        //    {
        //        _database.Genres.Remove(huidigGenre);
        //    }
        //    await _database.SaveChangesAsync();
        //}

    }
}