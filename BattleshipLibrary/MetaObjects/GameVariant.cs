using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipLibrary.MetaObjects
{
    public class GameVariant
    {
        public GameVariant(string name, int size, IEnumerable<ShipVariant> ships)
        {
            Name = name;
            Size = size;
            Ships = ships;
        }

        public string Name { get; set; }
        public int Size { get; set; }
        public IEnumerable<ShipVariant> Ships { get; }

        public static GameVariant GetClassic()
        {
            var ships = new List<ShipVariant>
            {
                new ShipVariant("Линкор", 4, 1),
                new ShipVariant("Крейсер", 3, 2),
                new ShipVariant("Эсминец", 2, 3),
                new ShipVariant("Торпедный катер", 1, 4)
            };

            return new GameVariant("Классический", 10, ships);
        }

        public override string ToString() => Name;
    }

    public class ShipVariant
    {
        public ShipVariant(string name, int size, int count)
        {
            Name = name;
            Size = size;
            Count = count;
        }
        public string Name { get; set; }
        public int Size { get; set; }
        public int Count { get; set; }

        public override string ToString() => Name;
    }
}
