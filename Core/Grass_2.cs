using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Grass_2 : ContentBase, IBehavior
    {
        private int IterationDo { get; set; }

        public override IBehavior Behavior
        {
            get
            {
                return this as IBehavior;
            }
        }

        public Grass_2(int x, int y, char ico = '&') : base(x, y, ico)
        {

        }
        public Grass_2() { }
     

        public bool Do(Game Game_field)
        {
            throw new NotImplementedException();
        }

        public void Die(Game game)
        {
            throw new NotImplementedException();
        }
    }
}
