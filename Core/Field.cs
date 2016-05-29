using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Schema;
using System.Runtime.Serialization;

namespace Core
{
    // [System.Serializable]
    [DataContract]
    [XmlRoot]
    public class Field
    {
        [DataMember]
        [XmlArray]
        public ContentBase[][] Cells;
        [DataMember]
        [XmlArray]
        public List<ContentBase> GameObjects = new List<ContentBase>();
        [DataMember]
        [XmlElement]
        public int XLenght;
        [DataMember]
        [XmlElement]
        public int YLenght;
        [DataMember]
        [XmlElement]
        public int Generation { get; set; }

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

        public void Iteration()
        {
            var game = GameManager.Games.Find(x => x.CurrentField == this);
            while (game.IsGame)
            {
                Thread.Sleep(100);
                Generation++;
                for (int i = 0; i < GameObjects.Count; i++)
                {
                    GameObjects[i].Behavior.Do(game);
                }
            }
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
