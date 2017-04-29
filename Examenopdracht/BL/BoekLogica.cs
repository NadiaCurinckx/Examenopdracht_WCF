using DA;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;

namespace BL
{
    public class BoekLogica : IBoekLogica
    {
        private readonly IBoekenDatabase _database = new BoekenDatabase();        

        public Task<List<Boek>> NeemAlleBoeken()
        {
            return _database.Boeken.ToListAsync();
        }

        public Task<Boek> NeemBoek(Int32 code)
        {
            return _database.Boeken.SingleOrDefaultAsync(x => x.Id == code);
        }

        /*public Task BewaarBoek(Int32 code)
        {

            var huidigBoek = _database.Boeken.SingleOrDefault(x => x.Id == code);

            if (huidigBoek != null)
            {
                _database.Boeken.Add(huidigBoek);

            }
            return _database.SaveChangesAsync();
        }*/

        public Task BewaarBoek(Boek boek)
        {
            _database.Boeken.Add(boek);
            return _database.SaveChangesAsync();
        }


        public async Task<int> WijzigBoek(Boek boek, List<int> genreIds)
        {
            var huidigBoek = _database.Boeken.SingleOrDefault(x => x.Id == boek.Id);

            if (huidigBoek != null)
            {
                var geselecteerdeGenres = genreIds == null
                    ? new List<Genre>()
                    : _database.Genres.Where(x => genreIds.Contains(x.Id)).ToList();

                huidigBoek.Genres = geselecteerdeGenres;
                huidigBoek.Auteur = boek.Auteur;
                huidigBoek.Titel = boek.Titel;
                huidigBoek.AantalPaginas = boek.AantalPaginas;
            }

            return await _database.SaveChangesAsync();
        }

        public Task VerwijderBoek(Int32 code)
        {
            var huidigBoek = _database.Boeken.SingleOrDefault(x => x.Id == code);

            if (huidigBoek != null)
            {
                _database.Boeken.Remove(huidigBoek);
            }

            return _database.SaveChangesAsync();
        }
    }
}