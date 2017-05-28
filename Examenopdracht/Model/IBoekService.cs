using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

namespace Model
{
    [ServiceContract]
    public interface IBoekService
    {
        [OperationContract]
        Task<List<Boek>> NeemAlleBoeken();

        [OperationContract]
        Task<Boek> NeemBoek(Int32 code);

        [OperationContract]
        Task<Boek> BewaarBoek(Boek boek);

        [OperationContract]
        Task<int> WijzigBoek(Boek boek);

        [OperationContract]
        Task VerwijderBoek(Int32 code);
    }
}