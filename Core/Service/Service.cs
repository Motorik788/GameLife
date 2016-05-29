using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Core;


namespace Core.Service
{

    public class Service : IService
    {
        public Field ContinueGame(int gameId)
        {
            var game = GameManager.Games.Find(x => x.Id == gameId);
            if (!game.IsGame)
                Task.Factory.StartNew(() => { GameManager.Start(game); });
            Console.WriteLine("Continue game " + gameId);
            return null;
        }

        public IEnumerable<Game> GetAllGames()
        {
            return GameManager.Games;
        }

        public Field GetGameState(int gameId)
        {
            return GameManager.Games.Find(x => x.Id == gameId).CurrentField;
        }

        public bool IsGame(int gameId)
        {
            return GameManager.Games.Find(x => x.Id == gameId).IsGame;
            // return false;
        }

        public int StartNewGame(int gameId = -1, GameSettings settings = null)
        {
            if (gameId < 0 || GameManager.Games.Exists(x => x.Id == gameId))
                gameId = GameManager.Games.Count;
            Console.WriteLine("Started new game " + gameId);
            // if (GameManager.Games.Exists(x=>x.Id == gameId))
            // GameManager.Games.RemoveAll(x => x.Id == gameId);
            Task.Factory.StartNew(() => { GameManager.Start(settings: settings); });
            return gameId;
        }

        public void StopGame(int gameId)
        {
            GameManager.Games.Find(x => x.Id == gameId).IsGame = false;
            Console.WriteLine("Stoped game " + gameId);
        }
    }
}
