using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

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
        }

        public static void DeleteCell(int posX, int posY)
        {
            CurrentField.GameObjects.Remove(CurrentField.Cells[posX, posY]);
            CurrentField.Cells[posX, posY] = null;
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
            // var serializer = new JavaScriptSerializer();
            // var JsonStr = serializer.Serialize(GameManager.CurrentField);
            // var f = File.CreateText(Environment.CurrentDirectory + "/save.txt");
            // f.Write(JsonStr);
            //f.Close();
            //using (var db = new Model1())
            //{
            //    db.Database.Create();
            //    db.MyEntities.Add(GameManager.Settings);
            //}

            //конфиги думаю в xml запихать

            if (GameManager.CurrentField != null)
            {
                var ser = new BinaryFormatter();
                var f = File.Create(Environment.CurrentDirectory + "/sav.md");
                ser.Serialize(f, GameManager.CurrentField);
                f.Close();
            }
        }

        public static Field Load()
        {
            //var serializer = new JavaScriptSerializer();
            //var f = File.OpenText(Environment.CurrentDirectory + "/save.txt");
            //var field = serializer.Deserialize<Field>(f.ReadToEnd());
            //f.Close();
            var ser = new BinaryFormatter();
            var f = File.Open(Environment.CurrentDirectory + "/sav.md", FileMode.Open);
            var field = ser.Deserialize(f) as Field;
            f.Close();
            return field;
        }
    }
}
