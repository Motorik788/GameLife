using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Schema;

namespace LifeTest
{
    // [System.Serializable]
    [XmlRoot]
    public class Field
    {
        [XmlArray]
        public ContentBase[][] Cells;
        [XmlArray]
        public List<ContentBase> GameObjects = new List<ContentBase>();
        [XmlElement]
        public int XLenght;
        [XmlElement]
        public int YLenght;
        [XmlElement]
        public int Generation { get; set; }

        private IPresenter presenter { get; set; }
        public Field() { }

        public Field(int x, int y)
        {
            Cells = new ContentBase[x][];
            for (int i = 0; i < x; i++)
            {
                Cells[i] = new ContentBase[y];
            }
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
                for (int i = 0; i < GameObjects.Count; i++)
                {
                    GameObjects[i].Behavior.Do(this);
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
            if (Cells.GetLength(0) > content.PosX)
            {
                if (Cells[content.PosX].Length > content.PosY)
                {
                    Cells[content.PosX][content.PosY] = content;
                    GameObjects.Add(content);
                }
            }

        }


    }
}
