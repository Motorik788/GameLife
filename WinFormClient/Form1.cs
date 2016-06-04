using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;
using Core.Service;
using Core;
using System.Threading;


namespace WinFormClient
{
    public partial class Form1 : Form
    {
        public static IService Chanell;
        public static int CurrentGame = -1;
        GameSettings setting;
        View view;
        public static Bitmap bitMap;

        public Form1()
        {
            InitializeComponent();
            try
            {
                //Uri uri = new Uri("http://localhost:4000/LifeService");

                //BasicHttpBinding binding = new BasicHttpBinding("BasicHttpBinding_LifeService");

                //EndpointAddress endpoint = new EndpointAddress(uri);

                //ChannelFactory<IService> factory = new ChannelFactory<IService>(binding, endpoint);


                //Chanell = factory.CreateChannel();
                var cl = new ClientService("BasicHttpBinding_LifeService");
                Chanell = cl.ChannelFactory.CreateChannel();
            }
            catch (Exception ex)
            {

            }

            setting = new GameSettings();
            setting.Load();
            InitSettingControls();
            view = new View();
            bitMap = new Bitmap(userControl12.Size.Width, userControl12.Size.Height);
        }

        void InitSettingControls()
        {
            textSizeX.Text = setting.Size.Key.ToString();
            textSizeY.Text = setting.Size.Value.ToString();
            textCloseCells.Text = setting.MaxCloseCells.ToString();
            textDeathAnimal.Text = setting.AnimalBaseDeathVisible.ToString();
            textEnergy.Text = setting.AnimalBaseEnergy.ToString();
            textGrass_2Time_out.Text = setting.Grass_2_TimeOut.ToString();
            textSpeed.Text = setting.AnimalBaseSpeed.ToString();
        }



        public void Play()
        {
            Task.Run(() =>
            {
                Field field;

                do
                {
                    try
                    {
                        field = Chanell.GetGameState(CurrentGame);

                        BeginInvoke((Action)delegate
                        {
                            if (userControl12 != null)
                                view.Present(field, userControl12);
                            
                            GenerationLabel.Text = string.Format("Generaton {0}", field.Generation);
                            GameObjectsLabel.Text = string.Format("GameObjects {0}", field.GameObjects.Count);
                        });
                        Thread.Sleep(300);
                    }
                    catch (Exception ex) { }
                }
                while (Chanell.IsGame(CurrentGame));
            });
        }

        void StartGame(GameSettings.GameModes mode)
        {
            setting.GameMode = mode;
            try
            {
                CurrentGame = Chanell.StartNewGame(-1, setting);
                Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }



        private void gamesOnServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new TableGames().ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (CurrentGame >= 0)
                    Chanell.StopGame(CurrentGame);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void standartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartGame(GameSettings.GameModes.OnlyGrass);
        }

        private void mixedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartGame(GameSettings.GameModes.OnlyGrass_2);
        }

        private void mixedToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            StartGame(GameSettings.GameModes.MixedGrass);
        }

        private void withAnimalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartGame(GameSettings.GameModes.WithAnimals);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int x = 1;
            int y = 1;
            int cel = 1;
            int speed = 1;
            int energy = 1;
            int death = 1;
            int grass_t = 1;
            if (int.TryParse(textSizeX.Text, out x) && int.TryParse(textSizeY.Text, out y) && int.TryParse(textCloseCells.Text, out cel)
                && int.TryParse(textSpeed.Text, out speed) && int.TryParse(textEnergy.Text, out energy) && int.TryParse(textDeathAnimal.Text, out death)
                && int.TryParse(textGrass_2Time_out.Text, out grass_t))
            {
                setting.Size = new Pair<int, int>(x, y);
                setting.MaxCloseCells = cel;
                setting.AnimalBaseSpeed = speed;
                setting.AnimalBaseEnergy = energy;
                setting.AnimalBaseDeathVisible = death;
                setting.Grass_2_TimeOut = grass_t;
            }
            else
            {
                MessageBox.Show("Error format!");
                return;
            }
            setting.SetRandomStartPreset();
            setting.Save();

        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            setting.Load();
            InitSettingControls();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            setting.SetRandomStartPreset();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            if (bitMap != null)
                g.DrawImage(bitMap, 0, 0);
        }
    }
}
