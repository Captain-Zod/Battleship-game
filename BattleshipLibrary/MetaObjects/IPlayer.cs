using BattleshipLibrary.IngameObjects;

namespace BattleshipLibrary.MetaObjects
{
    public interface IPlayer
    {
        int Id { get; set; }
        string Name { get; set; }
        IPaper Battlefield { get; set; }

        bool PlaceShip(Coordinate[] coordinates);
        bool ConfirmPositions();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="coordinate"></param>
        /// <returns>Hit or miss</returns>
        bool DoTurn(Coordinate coordinate);
    }
}
