using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public interface IWalkable
    {
        int Speed { get; set; }
        void Walk(Game game);
    }
}
