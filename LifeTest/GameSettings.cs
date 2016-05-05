using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeTest
{
    public class GameSettings
    {
        public KeyValuePair<int, int>[] StartPreset { get; private set; }
        public KeyValuePair<int, int> Size { get; set; }
        public int MaxCloseCells { get; set; }

        public GameSettings()
        {
            SetStandartPreset();
        }

        private void SetStandartPreset()
        {
            KeyValuePair<int, int>[] standart =
                {
                    new KeyValuePair<int, int>(1, 2),
                    new KeyValuePair<int, int>(0, 1),
                    new KeyValuePair<int, int>(7, 3),
                    new KeyValuePair<int, int>(1, 3),
                    new KeyValuePair<int, int>(2, 1),
                    new KeyValuePair<int, int>(3, 1),
                    new KeyValuePair<int, int>(3, 2),
                    new KeyValuePair<int, int>(1, 0),
                    new KeyValuePair<int, int>(4, 0),
                };
            StartPreset = standart;
            Size = new KeyValuePair<int, int>(10, 10);
            MaxCloseCells = 4;
        }

    }
}
