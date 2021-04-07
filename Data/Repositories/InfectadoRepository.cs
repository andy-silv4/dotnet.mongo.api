using System.Collections.Generic;
using CoronaVirus.Api.Models;
using MongoDB.Driver;
using System.Linq;
using CoronaVirus.Api.Data.Collections;
using CoronaVirus.Api.Data.Repositories.Interfaces;

namespace CoronaVirus.Api.Data.Repositories
{

    public class InfectadoRepository : IInfectadoRepository
    {
        private readonly IMongoCollection<Infectado> _infectados;

        public InfectadoRepository(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _infectados = database.GetCollection<Infectado>(settings.CollectionName);
        }

        public List<Infectado> Get() =>
            _infectados.Find(infectado => true).ToList();

        public Infectado Get(string id) =>
            _infectados.Find<Infectado>(infectado => infectado.Id == id).FirstOrDefault();

        public Infectado Create(Infectado infectado)
        {
            _infectados.InsertOne(infectado);
            return infectado;
        }

        public void Update(string id, Infectado infectado) =>
            _infectados.ReplaceOne(infectado => infectado.Id == id, infectado);

        public void Remove(string id) =>
            _infectados.DeleteOne(infectado => infectado.Id == id);
    }
}
