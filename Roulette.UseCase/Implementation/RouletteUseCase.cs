using Roulette.Model.Gateways;
using Roulette.Model;
using System;
using System.Collections.Generic;

namespace Roulette.UseCase
{
    public class RouletteUseCase : IRouletteUseCase
    {
        private readonly IRouletteRepository repository;
        public RouletteUseCase(IRouletteRepository repository)
        {
            this.repository = repository;
        }

        public void Bet(Bet bet)
        {
            var roulette = repository.GetById(bet.RouletteId);
            if(roulette == null || !roulette.IsOpen)
            {
                throw new Exception("Roulette is invalid");
            }
            switch (bet.BetType)
            {
                case BetTypeEnum.Color:
                    ColorBet(bet);
                    break;
                case BetTypeEnum.Number:
                    NumberBet(bet);
                    break;
                default:
                    throw new Exception("Bet Not implemented");
            }
            repository.AddBet(bet);
        }

        private void NumberBet(Bet bet)
        {
            if(bet.Number < 0 && bet.Number > 36)
            {
                throw new Exception("Number isn't valid");
            }

        }

        private void ColorBet(Bet bet)
        {
            
        }

        public int CreateRoulette(Roulette.Model.Roulette roulette)
        {
            return repository.Save(roulette);
        }

        public IEnumerable<Model.Roulette> GetRoulettes()
        {
            return repository.GetAll();
        }

        public bool Open(int rouletteId)
        {
            var roulette = repository.GetById(rouletteId);
            if(roulette == null)
            {
                throw new Exception("Roulette dont exists");
            }
            if(roulette.IsOpen)
            {
                throw new Exception("Roulette is open");
            }
            roulette.IsOpen = true;

            return roulette.IsOpen;
        }

        public IEnumerable<Bet> CloseBets(int rouletteId)
        {
            var winner = SelectWinner();
            var roulette = repository.GetById(rouletteId);
            return CalculateBets(roulette.Bets, winner);
        }

        private IEnumerable<Bet> CalculateBets(List<Bet> bets, int winner)
        {
            List<Bet> results = new List<Bet>();
            bool isOdd = winner % 2 == 0;
            foreach(var bet in bets)
            {
                if (bet.BetType == BetTypeEnum.Color)
                {
                    results.Add(CalculateEarningColor(bet, isOdd));
                }
                else
                {
                    results.Add(CalculateEarningNumber(bet, winner));
                }
            }

            return results;
        }

        private Bet CalculateEarningNumber(Bet bet, int winner)
        {
            if (bet.Number == winner)
            {
                bet.BetEarnings = bet.BetValue * 5;
            }
            else
            {
                bet.BetEarnings = 0;
            }

            return bet;
        }

        private Bet CalculateEarningColor(Bet bet, bool isOdd)
        {
            if(bet.Color == ColorEnum.Red && isOdd)
            {
                bet.BetEarnings = bet.BetValue * (decimal)1.8;
            }
            else if (bet.Color == ColorEnum.Black && !isOdd)
            {
                bet.BetEarnings = bet.BetValue * (decimal)1.8;
            }
            bet.BetEarnings = 0;

            return bet;
        }

        private int SelectWinner()
        {
            Random rnd = new Random();
            int winner = rnd.Next(36);
            return winner;
        }
    }
}
