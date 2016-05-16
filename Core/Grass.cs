using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace LifeTest
{
    public class Grass : ContentBase, IBehavior
    {
        public Grass(int x, int y, char ico = '$') : base(x, y, ico)
        {

        }

        public Grass() { }
        public override IBehavior Behavior
        {
            get
            {
                 return this as IBehavior;
            }          
        }

        public void Die()
        {
            GameManager.DeleteCell(PosX, PosY);

        }

        public bool Do(Field field)
        {
            int max = GameManager.Settings.MaxCloseCells;
            int cells = 0;
            List<KeyValuePair<int, int>> points = new List<KeyValuePair<int, int>>();
            for (int i = PosY - 1; i <= PosY + 1; i++)
            {
                for (int j = PosX - 1; j <= PosX + 1; j++)
                {
                    if (cells < max)
                    {
                        if (j > -1 && j < field.XLenght && i > -1 && i < field.YLenght)
                        {
                            if (field.Cells[j ][i])
                            {
                                cells++;

                            }
                            else
                            {
                                // field.AddCell(new Grass(j, i));
                                points.Add(new KeyValuePair<int, int>(j, i));

                            }
                        }
                    }
                    else
                    {
                        Die();
                        return true;
                    }
                }
            }

            if (points.Count > 0)
            {
                var r = new Random();
                var p = points[r.Next(0, points.Count)];
                field.AddCell(new Grass(p.Key, p.Value));
                return true;
            }
            return false;
        }
    }
}
