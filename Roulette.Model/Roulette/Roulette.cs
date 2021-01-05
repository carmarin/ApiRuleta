using System;
using System.Collections.Generic;

namespace Roulette.Model
{
    public class Roulette
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public bool IsOpen { get; set; }
        public List<Bet> Bets { get; set; }
    }
}
