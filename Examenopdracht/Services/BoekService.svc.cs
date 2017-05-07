using BL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace Services
{

    public class BoekService : IBoekService
    {
        private readonly IBoekLogica _boekLogica = new BoekLogica();

        public Task BewaarBoek(Boek boek)
        {
            return _boekLogica.BewaarBoek(boek);
        }

        /*public Task BewaarBoek(int code)
        {
            return _boekLogica.BewaarBoek(code);
        }*/

        public async Task<List<Boek>> NeemAlleBoeken()
        {

            var alleBoeken = await _boekLogica.NeemAlleBoeken();

            foreach (var b in alleBoeken)
            {
                foreach (var g in b.Genres)
                {
                    g.Boeken = null;
                }
            }

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

        public Task<int> WijzigBoek(Boek boek, List<int> genreIds)
        {
            return _boekLogica.WijzigBoek(boek, genreIds);
        }
    }
}
