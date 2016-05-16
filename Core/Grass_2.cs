using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeTest
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

        public void Die()
        {
            throw new NotImplementedException();
        }

        public bool Do(Field field)
        {
            throw new NotImplementedException();
        }
    }
}
