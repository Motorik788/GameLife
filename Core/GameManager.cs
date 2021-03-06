﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Core;
using System.Xml.Serialization;



namespace Core
{
    public static class GameManager
    {
        public static List<Game> Games = new List<Game>();

        static GameManager()
        {
            // Load();
        }

        public static void Start(Game game = null, GameSettings settings = null)
        {
            if (game == null)
            {
                game = new Game(settings);
                if (settings != null)
                    game.Settings = settings;
                Games.Add(game);
            }
            else
                game.IsGame = true;
            game.CurrentField.Iteration();
        }


        public static void Save()
        {

            // DataContractJsonSerializer d = new DataContractJsonSerializer(typeof(Field));
            
            BLL.Services.SaveService<DAL.Save> fg = new BLL.Services.SaveService<DAL.Save>(new DAL.EntityFramework.Transaction.UnitOfWork(new DAL.Model1()));
            XmlSerializer s;
            MemoryStream f_ = new MemoryStream();
            foreach (var item in fg.GetAll())
            {
                fg.Delete(item.Id);
            }
            foreach (var item in GameManager.Games)
            {
                f_ = new MemoryStream();
                s = new XmlSerializer(typeof(Field));
                s.Serialize(f_, item.CurrentField);
                var field = Encoding.UTF8.GetString(f_.ToArray());
                f_ = new MemoryStream();
                s = new XmlSerializer(typeof(GameSettings));
                s.Serialize(f_, item.Settings);
                var setting = Encoding.UTF8.GetString(f_.ToArray());
                fg.Add(new DAL.Save(field, setting));
            }
            fg.unitOfWork.Commit();
            //using (var db = new Model1())
            //{
            //    if (db.MyEntities.Count() < 1)
            //        db.MyEntities.Add(new S(Encoding.UTF8.GetString(f_.ToArray())));
            //    else
            //        db.MyEntities.Find(1).Name = Encoding.UTF8.GetString(f_.ToArray());
            //    db.SaveChanges();

            //}

            f_.Close();
            //  Settings.Save();

        }

        public static void Load()
        {

            XmlSerializer serializer;
            MemoryStream stream = null;
            BLL.Services.SaveService<DAL.Save> fg = new BLL.Services.SaveService<DAL.Save>(new DAL.EntityFramework.Transaction.UnitOfWork(new DAL.Model1()));
            fg.unitOfWork.Commit();

            foreach (var item in fg.GetAll())
            {
                serializer = new XmlSerializer(typeof(Field));
                stream = new MemoryStream(Encoding.UTF8.GetBytes(item.Field));
                var field = serializer.Deserialize(stream) as Field;
                stream = new MemoryStream(Encoding.UTF8.GetBytes(item.Setting));
                serializer = new XmlSerializer(typeof(GameSettings));
                var setting = serializer.Deserialize(stream) as GameSettings;
                var game = new Game();
                game.CurrentField = field;
                game.Id = (uint)item.Id;
                game.Settings = setting;
                GameManager.Games.Add(game);
            }
            if (stream != null)
                stream.Close();
            //using (var db = new Model1())
            //{
            //    
            //    var b = new MemoryStream(Encoding.UTF8.GetBytes(db.MyEntities.Find(1).Name));
            //    var field = serializer.Deserialize(b) as Field;
            //    return field;
            //}
        }
    }
}
