using System.Collections.Generic;
using CoronaVirus.Api.Data.Collections;

namespace CoronaVirus.Api.Services.Interfaces
{
    public interface IInfectadoService
    {
        Infectado Create(Infectado infectado);
        List<Infectado> Get();
        Infectado Get(string id);
        void Remove(string id);
        void Update(string id, Infectado infectado);
    }
}
