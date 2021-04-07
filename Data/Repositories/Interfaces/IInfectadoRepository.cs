using System.Collections.Generic;
using CoronaVirus.Api.Data.Collections;

namespace CoronaVirus.Api.Data.Repositories.Interfaces
{
    public interface IInfectadoRepository
    {
        Infectado Create(Infectado infectado);
        List<Infectado> Get();
        Infectado Get(string id);
        void Remove(string id);
        void Update(string id, Infectado infectado);
    }
}
