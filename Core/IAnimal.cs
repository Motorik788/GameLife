using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
   public interface IAnimal: IWalkable
    {
        int Energy { get;  }
        void Eat(Game game);
        void Reproduce(Game game);
    }
}
