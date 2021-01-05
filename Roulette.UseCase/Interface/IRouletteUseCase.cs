using Roulette.Model;
using System;
using System.Collections.Generic;

namespace Roulette.UseCase
{
    public interface IRouletteUseCase
    {
        int CreateRoulette(Model.Roulette roulette);
        bool Open(int rouletteId);
        IEnumerable<Model.Roulette> GetRoulettes();
        void Bet(Bet bet);
        IEnumerable<Bet> CloseBets(int rouletteId);
    }
}
