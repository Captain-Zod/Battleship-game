using BattleshipLibrary.IngameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipLibrary.MetaObjects
{
    public class GameController
    {
        public GameController(GameVariant variant)
        {

        }

        private Dictionary<int, IPlayer> Players { get; set; } = new Dictionary<int, IPlayer>();

        private int _idWhooseTurn;
        private IPlayer WhooseTurnPlayer { get => Players[_idWhooseTurn]; }
        private IPlayer TargetPlayer { get => Players.First(x => x.Key != _idWhooseTurn).Value; }

        private void SwapNextTurner()
        {
            _idWhooseTurn = TargetPlayer.Id;
        }

        public void PlayerConfirmedHisBattlefield(int idPlayer)
        {
            Players[idPlayer].Battlefield.Confirmed = true;
        }

        public HitResult Hit(int id, Coordinate coordinate)
        {
            if (id != _idWhooseTurn)
                throw new Exception();

            var targetPaper = TargetPlayer.Battlefield;

            if (targetPaper.Hit(coordinate))
            {
                if (targetPaper.AllShipsDestroyed)
                    return HitResult.Win;

                targetPaper.TryGetShipByCell(coordinate, out var hittedShip);
                if (hittedShip!.Destroyed)
                    return HitResult.Destroyed;
                return HitResult.Hit;
            }
            return HitResult.Miss;
        }

        public enum HitResult
        {
            Miss,
            Hit,
            Destroyed,
            Win
        }
    }
}
