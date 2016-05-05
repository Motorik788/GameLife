using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeTest
{
    interface IBehavior
    {
        bool Do(Field field);
        void Die();
    }
}
