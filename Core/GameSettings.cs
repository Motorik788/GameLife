using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace Core
{
    [DataContract]
    public struct Pair<TKey, TValue>
    {
        [DataMember]
        public TKey Key { get; set; }
        [DataMember]
        public TValue Value { get; set; }

        public Pair(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }
    }

    [XmlRoot]
    [DataContract]
    public class GameSettings
    {
        public enum GameModes
        {
            OnlyGrass = 1,
            OnlyGrass_2,
            MixedGrass,
            WithAnimals
        }

        [DataMember]
        public Pair<int, int>[] StartPreset { get; set; }
        [DataMember]
        [XmlElement]
        public Pair<int, int> Size { get; set; }
        [DataMember]
        [XmlElement]
        public int MaxCloseCells { get; set; }
        [DataMember]
        [XmlElement]
        public GameModes GameMode { get; set; }
        [DataMember]
        [XmlElement]
        public int AnimalBaseEnergy { get; set; }
        [DataMember]
        [XmlElement]
        public int AnimalBaseSpeed { get; set; }
        [DataMember]
        [XmlElement]
        public int AnimalBaseDeathVisible { get; set; }
        [DataMember]
        [XmlElement]
        public int Grass_2_TimeOut { get; set; }


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
                GameMode = set.GameMode;
                AnimalBaseEnergy = set.AnimalBaseEnergy;
                AnimalBaseSpeed = set.AnimalBaseSpeed;
                AnimalBaseDeathVisible = set.AnimalBaseDeathVisible;
                Grass_2_TimeOut = set.Grass_2_TimeOut;
                file.Close();
            }
            else
            {
                SetStandartPreset();
                Save();
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

        public void SetRandomStartPreset()
        {
            var r = new Random();
            Pair<int, int>[] standart = new Pair<int, int>[r.Next(3, Size.Key * Size.Key / 3)];
            for (int i = 0; i < standart.Length; i++)
            {
                standart[i] = new Pair<int, int>(r.Next(0, Size.Key-1), r.Next(0, Size.Value-1));
            }
            StartPreset = standart;
        }

        public void SetStandartPreset()
        {
            Size = new Pair<int, int>(10, 10);
           
            SetRandomStartPreset();
            GameMode = GameModes.OnlyGrass;
            AnimalBaseEnergy = 10;
            AnimalBaseDeathVisible = 2;
            AnimalBaseSpeed = 2;
            MaxCloseCells = 4;
            Grass_2_TimeOut = 4;
        }

    }
}
