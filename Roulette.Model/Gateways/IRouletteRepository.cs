using System;
using System.Collections.Generic;
using System.Text;

namespace Roulette.Model.Gateways
{
    public interface IRouletteRepository
    {
        int Save(Roulette roulette);
        void Update(Roulette roulette);
        IEnumerable<Roulette> GetAll();
        Roulette GetById(int id);
        void AddBet(Bet bet);
    }
}
