using api.Interfaces;
using api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Repositories
{
    public class GameRepository : Repository<Game>, IGame
    {
        public GameRepository(WorldCupContext context) : base(context)
        {
        }
    }
}
