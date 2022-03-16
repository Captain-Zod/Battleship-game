using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipLibrary.IngameObjects
{
    internal class Ship
    {
        internal Ship(Cell[] positions)
        {
            Positions = positions;
        }

        internal Cell[] Positions { get; private set; }
        internal bool Destroyed { get => Positions.All(x => x.Damaged); }
    }
}
