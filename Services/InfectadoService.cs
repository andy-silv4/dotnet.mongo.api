using System.Collections.Generic;
using CoronaVirus.Api.Data.Collections;
using CoronaVirus.Api.Services.Interfaces;
using CoronaVirus.Api.Data.Repositories.Interfaces;

namespace CoronaVirus.Api.Services
{
    public class InfectadoService : IInfectadoService
    {
        private readonly IInfectadoRepository _infectadoRepository;

        public InfectadoService(IInfectadoRepository infectadoRepository)
        {
            _infectadoRepository = infectadoRepository;
        }

        public Infectado Create(Infectado infectado)
        {
            return _infectadoRepository.Create(infectado);
        }

        public List<Infectado> Get()
        {
            return _infectadoRepository.Get();
        }

        public Infectado Get(string id)
        {
            return _infectadoRepository.Get(id);
        }

        public void Remove(string id)
        {
            _infectadoRepository.Remove(id);
        }

        public void Update(string id, Infectado infectado)
        {
            _infectadoRepository.Update(id, infectado);
        }
    }
}