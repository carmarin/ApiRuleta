using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Roulette.Model
{
    public class Bet
    {
        public int RouletteId { get; set; }
        public BetTypeEnum BetType { get; set; }
        public int Number { get; set; }
        public ColorEnum Color { get; set; }
        [Range(1, 10000, ErrorMessage = "Value must be between $1 and $10000")]
        public decimal BetValue { get; set; }
        public decimal BetEarnings { get; set; }
    }
}
