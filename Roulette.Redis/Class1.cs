using Roulette.Model.Gateways;
using Roulette.Model;
using System;
using System.Collections.Generic;

namespace Roulette.Redis
{
    public class RouletteRepository : IRouletteRepository
    {
        public void AddBet(Bet bet)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Model.Roulette> GetAll()
        {
            throw new NotImplementedException();
        }

        public Model.Roulette GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Save(Model.Roulette roulette)
        {
            throw new NotImplementedException();
        }

        public void Update(Model.Roulette roulette)
        {
            throw new NotImplementedException();
        }
    }
}
