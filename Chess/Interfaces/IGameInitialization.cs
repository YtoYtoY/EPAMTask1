using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Interfaces
{
    public interface IGameInitialization
    {
        void Initialize(IList<IPlayer> players, IBoard board);
    }
}
