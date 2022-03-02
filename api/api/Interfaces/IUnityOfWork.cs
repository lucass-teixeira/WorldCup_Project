using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Interfaces
{
    public interface IUnityOfWork
    {
        IGame GameRepository { get; }
        IUser UserRepository { get; }
        void Commit();

    }
}
