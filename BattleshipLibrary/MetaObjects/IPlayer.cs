using BattleshipLibrary.IngameObjects;

namespace BattleshipLibrary.MetaObjects
{
    internal interface IPlayer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        internal Paper Battlefield { get; set; }

        internal bool PlaceShip(Coordinate[] coordinates);
        internal bool ConfirmPositions();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="coordinate"></param>
        /// <returns>Hit or miss</returns>
        internal bool DoTurn(Coordinate coordinate);
    }
}
