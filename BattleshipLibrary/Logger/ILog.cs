using BattleshipLibrary.IngameObjects;
using BattleshipLibrary.MetaObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipLibrary.Logger
{
    internal interface ILog
    {
        void Reconstruct(GameController controller);
    }

    internal abstract class Log : ILog
    {
        public DateTime DateAndTime { get; }

        //todo
        //public abstract string Text { get; }

        public virtual void Reconstruct(GameController controller)
        {

        }
    }

    internal class HitLog : Log
    {
        public HitLog(Coordinate coordinate, int idPlayerFrom, int idPlayerTo)
        {
            Coordinate = coordinate;
            IdPlayerFrom = idPlayerFrom;
            IdPlayerTo = idPlayerTo;
        }

        public Coordinate Coordinate { get; }
        public int IdPlayerFrom { get; }
        public int IdPlayerTo { get; }

        //public override string Text { get => $"Игрок {PlayerFrom.Name} атаковал {PlayerTo.Name}: [{Coordinate}]"; }

        public override void Reconstruct(GameController controller)
        {
            base.Reconstruct(controller);
            controller.Hit(IdPlayerFrom, Coordinate);
        }
    }

    internal class PlaceLog : Log
    {
        public PlaceLog(Coordinate[] coordinates, int idPlayer, ShipVariant ship)
        {
            Coordinates = coordinates;
            IdPlayer = idPlayer;
            Ship = ship;
        }

        public Coordinate[] Coordinates { get; }
        public int IdPlayer { get; }
        public ShipVariant Ship { get; }

        //public override string Text 
        //{ 
        //    get
        //    {
        //        return $"Игрок {Player.Name} разместил {Ship}. Позиции: [{string.Join(", ", Coordinates)}]";
        //    }
        //}

        public override void Reconstruct(GameController controller)
        {
            base.Reconstruct(controller);
            //todo
            //controller.Players[IdPlayer].PlaceShip(Coordinates);
        }
    }

    internal class GameOverLog : Log
    {
        public GameOverLog(Coordinate coordinate, int idWinner, int idLooser)
        {
            IdWinner = idWinner;
            IdLooser = idLooser;
        }

        public int IdWinner { get; }
        public int IdLooser { get; }

        //public override string Text { get => $"Игрок {Winner.Name} одержал победу над {Looser.Name}."; }
    }
}
