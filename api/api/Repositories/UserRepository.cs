using api.Interfaces;
using api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Repositories
{
    public class UserRepository : Repository<User>, IUser
    {
        public UserRepository(WorldCupContext context) : base(context)
        {
        }
    }
}
