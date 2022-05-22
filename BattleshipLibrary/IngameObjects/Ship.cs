using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipLibrary.IngameObjects
{
    public interface IShip
    {
        ICell[] Positions { get; }
        bool Destroyed { get => Positions.All(x => x.Damaged); }
    }

    internal class Ship : IShip
    {
        internal Ship(ICell[] positions)
        {
            Positions = positions;
        }

        public ICell[] Positions { get; private set; }
        public bool Destroyed { get => Positions.All(x => x.Damaged); }
    }
}
