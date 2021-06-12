using Chess.Figures.Movement;
using Chess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Classes
{
    public class NormalMovementStrategy : IMovementStrategy
    {
        private readonly IDictionary<string, IList<IMovement>> movements = new Dictionary<string, IList<IMovement>>
        {
            { 
                "Pawn", new List<IMovement>
                 {
                     new NormalPawnMovement()
                 }
            },
            { 
                "Bishop", new List<IMovement>
                 {
                     new NormalBishopMovement()
                 }
            },
            { 
                "Knight", new List<IMovement>
                 {
                     new NormalKnightMovement()
                 }
            },
            { 
                "King", new List<IMovement>
                 {
                     new NormalKingMovement()
                 }
            },
            { 
                "Rook", new List<IMovement>
                 {
                     new NormalRookMovement()
                 }
            },
            { 
                "Queen", new List<IMovement>
                 {
                     new NormalBishopMovement(),
                     new NormalRookMovement()
                 }
            },
        };

        public IList<IMovement> GetMovements(string figure)
        {
            return movements[figure];
        }
    }
}
