using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeTest
{
    public class Herbivorous_1 : ContentBase, IBehavior, Core.IAnimal
    {

        public Herbivorous_1(int x, int y, char ico = '@') : base(x, y, ico)
        {

        }
        public Herbivorous_1() { }

        int energy = 10;
        int speed = 2;
        public int Energy
        {
            get
            {
                return energy;
            }
        }

        public int Speed
        {
            get
            {
                return speed;
            }

            set
            {
                speed = value;
            }
        }

        public override IBehavior Behavior
        {
            get
            {
                return this as IBehavior;
            }
        }

        public void Die()
        {
            throw new NotImplementedException();
        }

        public bool Do(Field field)
        {
            throw new NotImplementedException();
        }

        public void Eat()
        {
            throw new NotImplementedException();
        }

        public void Reproduce()
        {
            throw new NotImplementedException();
        }

        public void Walk()
        {
            throw new NotImplementedException();
        }
    }
}
