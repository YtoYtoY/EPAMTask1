using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Interfaces
{
    public interface IGameFunction
    {
        IEnumerable<IPlayer> Players { get; }
        void Initialize(IGameInitialization gameInitializationStrategy);
        void Start();
        void WinningConditions();
    }
}
