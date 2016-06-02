using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Core
{
    [DataContract]
    public class Game
    {
        [DataMember]
        public uint Id { get; set; }
        [DataMember]
        public Field CurrentField { get; set; }
        [DataMember]
        public bool IsGame;
        [DataMember]
        public GameSettings Settings { get; set; }

        public Game()
        {

        }
        public Game(GameSettings sett = null)
        {
            if (sett == null)
            {
                Settings = new GameSettings();
                Settings.SetStandartPreset();
            }
            else
                Settings = sett;
            CurrentField = new Field(Settings.Size.Key, Settings.Size.Value);
            for (int i = 0; i < Settings.StartPreset.Length; i++)
            {
                if (sett.GameMode == GameSettings.GameModes.OnlyGrass)
                {
                    CurrentField.AddCell(new Grass(Settings.StartPreset[i].Key, Settings.StartPreset[i].Value));
                    continue;
                }
                if (sett.GameMode == GameSettings.GameModes.OnlyGrass_2)
                {
                    CurrentField.AddCell(new Grass_2(Settings.StartPreset[i].Key, Settings.StartPreset[i].Value));
                    continue;
                }
                if (sett.GameMode == GameSettings.GameModes.WithAnimals)
                {
                    if (i == Settings.StartPreset.Length / 3)
                    {
                        CurrentField.AddCell(new Herbivorous_1(Settings.StartPreset[i].Key, Settings.StartPreset[i].Value, Settings.AnimalBaseEnergy, Settings.AnimalBaseSpeed, Settings.AnimalBaseDeathVisible));
                        continue;
                    }
                    CurrentField.AddCell(new Grass_2(Settings.StartPreset[i].Key, Settings.StartPreset[i].Value));

                }
                if (sett.GameMode == GameSettings.GameModes.MixedGrass)
                {
                    if (i < Settings.StartPreset.Length / 2)
                        CurrentField.AddCell(new Grass(Settings.StartPreset[i].Key, Settings.StartPreset[i].Value));
                    else
                        CurrentField.AddCell(new Grass_2(Settings.StartPreset[i].Key, Settings.StartPreset[i].Value));

                }
            }

            Id = (uint)GameManager.Games.Count;
            IsGame = true;
        }


    }
}
