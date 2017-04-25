using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
   public interface IBoekLogica
    {
        Task<List<Boek>> NeemAlleBoeken();

        Task BewaarBoek(Int32 code);
        Task BewaarBoek(Boek boek);

        Task<Boek> NeemBoek(int code);

        Task<int> WijzigBoek(Boek boek, List<int> genreIds = null);

        Task VerwijderBoek(Int32 code);

    }
}
