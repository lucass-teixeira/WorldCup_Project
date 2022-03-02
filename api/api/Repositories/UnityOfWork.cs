using api.Interfaces;
using api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Repositories
{
    public class UnityOfWork : IUnityOfWork
    {
        UserRepository _userRepo;
        GameRepository _gameRepo;
        private readonly WorldCupContext _context;
        public UnityOfWork(WorldCupContext context)
        {
            _context = context;
        }
        public IGame GameRepository 
        {
            get
            {

                return _gameRepo = _gameRepo ?? new GameRepository(_context);
            }
        }

        public IUser UserRepository
        {
            get
            {

                return _userRepo = _userRepo ?? new UserRepository(_context);
            }
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }
    }
}
