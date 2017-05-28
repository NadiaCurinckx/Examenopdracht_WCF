using BL;
using Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public class BoekService : IBoekService
    {
        private readonly IBoekLogica _boekLogica = new BoekLogica();

        public async Task<Boek> BewaarBoek(Boek boek)
        {
            return await _boekLogica.BewaarBoek(boek);
        }

        public async Task<List<Boek>> NeemAlleBoeken()
        {
            var alleBoeken = await _boekLogica.NeemAlleBoeken();
            return alleBoeken;
        }

        public Task<Boek> NeemBoek(int code)
        {
            return _boekLogica.NeemBoek(code);
        }

        public Task VerwijderBoek(int code)
        {
            return _boekLogica.VerwijderBoek(code);
        }

        public Task<int> WijzigBoek(Boek boek)
        {
            return _boekLogica.WijzigBoek(boek);
        }
    }
}