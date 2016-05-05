using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace LifeTest
{
    [System.Serializable]
    public class Field
    {
        public ContentBase[,] Cells;
        public List<ContentBase> GameObjects = new List<ContentBase>();
        public readonly int XLenght;
        public readonly int YLenght;
        public int Generation { get; set; }

        private IPresenter presenter { get; set; }

        public Field(int x, int y)
        {
            Cells = new ContentBase[x, y];
            XLenght = x;
            YLenght = y;
        }

        public void SetPresenter(IPresenter newPresenter)
        {
            presenter = newPresenter;
        }


        public void Iteration()
        {
            while (GameManager.Game)
            {
                Thread.Sleep(100);
                Generation++;
                foreach (var cell in GameObjects)
                {
                    if ((cell as IBehavior).Do(this))
                        break;
                }
                Update();
            }
        }

        private void Update()
        {
            presenter.Present(this);
            //foreach (var item in GameObjects)
            //{
            //    Console.CursorLeft = item.PosY+1;
            //    Console.CursorTop = item.PosX+2;
            //    Console.Write(item.Icon);
            //}
        }


        public void AddCell(ContentBase content)
        {
            if (Cells.GetLength(0) > content.PosY && Cells.GetLength(1) > content.PosX)
            {
                Cells[content.PosX, content.PosY] = content;
                GameObjects.Add(content);
            }

        }
    }
}
