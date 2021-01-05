using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Roulette.Model;
using Roulette.UseCase;

namespace ApiRuletas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RouletteController : ControllerBase
    {
        private readonly ILogger<RouletteController> _logger;
        private readonly IRouletteUseCase _rouletteUseCase;

        public RouletteController(ILogger<RouletteController> logger, IRouletteUseCase rouletteUseCase)
        {
            _logger = logger;
            _rouletteUseCase = rouletteUseCase;
        }

        [HttpGet]
        public IEnumerable<Roulette.Model.Roulette> Get()
        {
            return _rouletteUseCase.GetRoulettes();
        }

        [HttpPost]
        public int Create(Roulette.Model.Roulette roulette)
        {
            return _rouletteUseCase.CreateRoulette(roulette);
        }

        [HttpPost]
        public bool Open(int id)
        {
            return _rouletteUseCase.Open(id);
        }

        [HttpPost]
        public void Bet(Bet bet)
        {
            _rouletteUseCase.Bet(bet);
        }

        [HttpPost]
        public IEnumerable<Bet> CloseBets(int rouletteId)
        {
            return _rouletteUseCase.CloseBets(rouletteId);
        }

    }
}
