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

        Task<Boek> NeemBoek(int code);

        /*Task BewaarBoek(Int32 code);*/
        Task<Boek> BewaarBoek(Boek boek);

        Task<int> WijzigBoek(Boek boek);

        Task VerwijderBoek(Int32 code);

    }
}
