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

        public Grass_2(int x, int y, char ico = '*') : base(x, y, ico)
        {

        }
        public Grass_2() { }


        public bool Do(Game Game_field)
        {
            IterationDo++;
            if (IterationDo == Game_field.Settings.Grass_2_TimeOut)
            {
                IterationDo = 0;
                List<KeyValuePair<int, int>> points = new List<KeyValuePair<int, int>>();
                for (int i = PosY - 1; i <= PosY + 1; i++)
                {
                    for (int j = PosX - 1; j <= PosX + 1; j++)
                    {
                        if (j > -1 && i > -1)
                        {
                            if (j < Game_field.CurrentField.XLenght && i < Game_field.CurrentField.YLenght)
                            {
                                if (!Game_field.CurrentField.Cells[i][j])
                                {
                                    points.Add(new KeyValuePair<int, int>(j, i));
                                }
                            }
                        }
                    }
                }
                if (points.Count > 0)
                {
                    var r = new Random();
                    var p = points[r.Next(0, points.Count)];
                    Game_field.CurrentField.AddCell(new Grass_2(p.Key, p.Value));
                    return true;
                }
            }
            return false;
        }

        public void Die(Game game)
        {
            game.CurrentField.DeleteCell(PosX, PosY);
        }
    }
}
