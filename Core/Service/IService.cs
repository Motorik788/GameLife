using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace Core.Service
{
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        Field GetGameState(int gameId);

        [OperationContract]
        void DeleteGame(int gameId);

        [OperationContract]
        int StartNewGame(int gameId,GameSettings settings = null);

        [OperationContract]
        bool IsGame(int gameId);

        [OperationContract]
        Field ContinueGame(int gameId);

        [OperationContract]
        void StopGame(int gameId);

        [OperationContract]
        IEnumerable<Game> GetAllGames();
    }
}
