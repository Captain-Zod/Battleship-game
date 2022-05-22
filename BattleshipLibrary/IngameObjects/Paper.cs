using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipLibrary.IngameObjects
{
    internal class Paper : IPaper
    {
        internal Paper(int column, int row)
        {
            Cells = new BoxCollection(column, row);
        }

        public bool Confirmed { get; set; }
        public BoxCollection Cells { get; set; }
        public List<IShip> Ships { get; set; } = new List<IShip>();

        public bool AllShipsDestroyed { get => Ships.All(x => x.Destroyed); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="positions"></param>
        /// <returns>Created and added ship.</returns>
        /// <exception cref="Exception">Position are null or empty || out of paper || Has another ship's part.</exception>
        public IShip AddNewShip(Coordinate[] positions)
        {
            if (positions == null || positions.Length == 0)
                throw new Exception(); // Exceptions because I think such validations must be on a client.

            if (positions.Any(c => OutOfPaper(c)))
                throw new Exception();

            if (positions.Any(c => HasShipPart(c)))
                throw new Exception();

            var ship = new Ship(positions.Select(coord => Cells[coord]).ToArray());
            Ships.Add(ship);

            return ship;
        }

        public bool Hit(Coordinate coordinate)
        {
            Cells[coordinate].Damaged = true;
            return HasShipPart(coordinate);
        }


        public bool TryGetShipByCell(Coordinate coordinate, out IShip? ship)
        {
            ship = Ships.FirstOrDefault(x => x.Positions.Any(y => y.Coordinate == coordinate));
            return ship != null;
        }

        internal bool HasShipPart(Coordinate coordinate)
        {
            return TryGetShipByCell(coordinate, out var unnecessary);
        }

        internal bool OutOfPaper(Coordinate coordinate)
        {
            return coordinate.X > Cells.GetLength(0) || coordinate.Y > Cells.GetLength(1);
        }
    }

    public interface IPaper //todo
    {
        BoxCollection Cells { get; }
        List<IShip> Ships { get; }
        IShip AddNewShip(Coordinate[] positions);
        bool Hit(Coordinate coordinate);
        bool Confirmed { get; set; }
        bool AllShipsDestroyed { get; }
        bool TryGetShipByCell(Coordinate coordinate, out IShip? ship);
    }
}
