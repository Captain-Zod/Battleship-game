using BattleshipLibrary.IngameObjects;
using BattleshipLibrary.MetaObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipLibrary
{
    public interface IGameFactory
    {
        IPaper GetPaper();
    }

    public class GameFactory : IGameFactory
    {
        public GameFactory(GameVariant variant)
        {

        }

        public IPaper GetPaper()
        {
            throw new NotImplementedException();
        }
    }
}
