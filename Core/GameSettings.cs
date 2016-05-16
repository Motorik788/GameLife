using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.IO;
using System.Xml.Serialization;

namespace LifeTest
{
    public struct Pair<TKey, TValue>
    {
        public TKey Key { get;  set; }
        public TValue Value { get;  set; }
        public Pair(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }
    }

    [XmlRoot]
    public class GameSettings
    {

        public Pair<int, int>[] StartPreset { get; set; }
        [XmlElement]
        public Pair<int, int> Size { get; set; }
        [XmlElement]
        public int MaxCloseCells { get; set; }

        public GameSettings()
        {
            //SetStandartPreset();
        }

        public void Load()
        {
            if (File.Exists(Environment.CurrentDirectory + "/settings.txt"))
            {
                //var ser = new XmlSerializer(typeof(GameSettings));
                //var f = File.OpenRead(Environment.CurrentDirectory + "/settings.xml");
                //var g = ser.Deserialize(f) as GameSettings;
                //Console.WriteLine(g.MaxCloseCells);
                //Console.ReadKey();
                //f.Close();
                JavaScriptSerializer seralizer = new JavaScriptSerializer();
                var file = File.OpenText(Environment.CurrentDirectory + "/settings.txt");
                var setStr = file.ReadToEnd();
                var set = seralizer.Deserialize<GameSettings>(setStr);
                StartPreset = set.StartPreset;
                Size = set.Size;
                MaxCloseCells = set.MaxCloseCells;
                file.Close();
            }
        }

        public void Save()
        {
            //var ser = new XmlSerializer(typeof(GameSettings));
            //var f = File.Create(Environment.CurrentDirectory + "/settings.xml");
            //ser.Serialize(f,this);
            //f.Close();
            JavaScriptSerializer seralizer = new JavaScriptSerializer();
            var strJson = seralizer.Serialize(this);
            var file = File.CreateText(Environment.CurrentDirectory + "/settings.txt");
            file.WriteLine(strJson);
            file.Close();
        }

        public void SetStandartPreset()
        {
            Size = new Pair<int, int>(10, 10);
            var r = new Random();
            Pair<int, int>[] standart = new Pair<int, int>[r.Next(3, Size.Key * Size.Key / 2)];
            for (int i = 0; i < standart.Length; i++)
            {
                standart[i] = new Pair<int, int>(r.Next(0, 9), r.Next(0, 9));
            }

            StartPreset = standart;

            MaxCloseCells = 4;
        }

    }
}
