using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipLibrary.IngameObjects
{
    public struct Coordinate
    {
        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X;
        public int Y;

        public override bool Equals(object? obj) => obj is not null && obj is Coordinate other && this.Equals(other);

        public bool Equals(Coordinate p) => X == p.X && Y == p.Y;

        public override int GetHashCode() => (X, Y).GetHashCode();

        public static bool operator ==(Coordinate lhs, Coordinate rhs) => lhs.Equals(rhs);

        public static bool operator !=(Coordinate lhs, Coordinate rhs) => !(lhs == rhs);

        public override string ToString()
        {
            return RulesAndPropreties.Alphabet[Y].ToString() + (X + 1);
        }
    }
}
