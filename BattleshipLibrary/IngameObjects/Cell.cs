using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipLibrary.IngameObjects
{
    public interface ICell
    {
        bool Damaged { get; set; }
        Coordinate Coordinate { get; }
    }

    internal class Cell : ICell
    {
        internal Cell()
        {

        }

        internal Cell(Coordinate coordinate)
        {
            Coordinate = coordinate;
        }

        internal Cell(int x, int y)
        {
            Coordinate = new Coordinate(x, y);
        }

        public bool Damaged { get; set; } = false;

        public Coordinate Coordinate { get; private set; }

        public override string ToString()
        {
            return Coordinate.ToString();
        }
    }

    public class BoxCollection
    {
        private ICell[,] _cells;

        public BoxCollection(int column, int row)
        {
            _cells = new Cell[column, row];

            for (int i = 0; i < _cells.GetLength(0); i++)
            {
                for (int j = 0; j < _cells.GetLength(1); j++)
                {
                    _cells[i, j] = new Cell(i, j);
                }
            }
        }

        internal BoxCollection(Cell[,] positions)
        {
            _cells = positions;
        }

        public int GetLength(int dimension)
        {
            return _cells.GetLength(dimension);
        }

        public ICell this[Coordinate coordinate]
        {
            get { return _cells[coordinate.X, coordinate.Y]; }
            set { _cells[coordinate.X, coordinate.Y] = value; }
        }
    }
}
