using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Core;
using System.Xml.Serialization;

namespace LifeTest
{
    public static class GameManager
    {
        public static Field CurrentField { get; private set; }
        public static bool Game;
        public static GameSettings Settings { get; set; }

        static GameManager()
        {
            Settings = new GameSettings();
            Settings.SetStandartPreset();
            //Settings.Save();
        }

        public static void DeleteCell(int posX, int posY)
        {
            CurrentField.GameObjects.Remove(CurrentField.Cells[posX][posY]);
            CurrentField.Cells[posX][posY] = null;
        }

        public static void Start(IPresenter presenter = null, Field field = null)
        {
            if (field == null)
            {
                CurrentField = new Field(Settings.Size.Key, Settings.Size.Value);
                foreach (var item in Settings.StartPreset)
                {
                    CurrentField.AddCell(new Grass(item.Key, item.Value));
                }
            }
            else
                CurrentField = field;

            Game = true;
            CurrentField.SetPresenter(presenter);
            CurrentField.Iteration();

        }

        public static void Stop()
        {
            Game = false;
        }
       
        public static void Save()
        {
            // DataContractJsonSerializer d = new DataContractJsonSerializer(typeof(Field));
            XmlSerializer s = new XmlSerializer(typeof(Field));
            var f_ = new MemoryStream();
            s.Serialize(f_, CurrentField);
     
            using (var db = new Model1())
            {
                if (db.MyEntities.Count() < 1)
                    db.MyEntities.Add(new S(Encoding.UTF8.GetString(f_.ToArray())));
                else
                    db.MyEntities.Find(1).Name = Encoding.UTF8.GetString(f_.ToArray());
                db.SaveChanges();              
                f_.Close();
            }
            Settings.Save();

        }

        public static Field Load()
        {
            Settings.Load();
            using (var db = new Model1())
            {
                var serializer =  new XmlSerializer(typeof(Field));
                var b = new MemoryStream(Encoding.UTF8.GetBytes(db.MyEntities.Find(1).Name));
                var field = serializer.Deserialize(b) as Field;              
                return field;
            }                        
        }
    }
}
