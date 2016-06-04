using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using Core.Service;
using System.ServiceModel;

namespace Core
{
    class Program
    {
        public static IService Chanell;
        public static int CurrentGame = -1;

        enum States
        {
            Main,
            Settings,
            GamesVisor
        }

        static States state = States.Main;

        static void StartMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("(S)-Стоп");
            Console.ForegroundColor = ConsoleColor.Gray;
            Game();
            Console.CursorLeft = 0;
            Console.CursorTop = 0;
            Console.WriteLine("(Escape)- Выйти, (S)-Старт, (Enter)-Продолжить, (Space)-Настройки");
        }

        static void Game()
        {
            View.ConsolePresenter pres = new View.ConsolePresenter();
            do
            {
                try
                {
                    pres.Present(Chanell.GetGameState(CurrentGame));
                    Thread.Sleep(300);
                }
                catch (Exception ex)
                {
                    //Console.WriteLine(ex);
                }
            }
            while (Chanell.IsGame(CurrentGame));
        }

        static void Menu()
        {
            bool menu = true;
            GameSettings settings = new GameSettings();
            settings.Load();
            while (menu)
            {
                ConsoleKey key;
                Console.Clear();
                Console.WriteLine("Главное меню");
                Console.WriteLine("(Escape)-Выйти, (S)-Старт, (Enter)-Продолжить, (Space)-Настройки");
                while (state == States.Main)
                {
                    key = Input.GetKey();
                    if (key == ConsoleKey.Escape)
                    {
                        //GameManager.Save();
                        return;
                    }
                    if (key == ConsoleKey.Enter)
                    {
                        state = States.GamesVisor;
                        break;
                    }
                    if (key == ConsoleKey.Spacebar)
                    {
                        state = States.Settings;
                        break;
                    }
                    if (key == ConsoleKey.S)
                    {
                        settings.Load();
                        CurrentGame = Chanell.StartNewGame(CurrentGame, settings);
                        StartMenu();
                    }
                }

                while (state == States.Settings)
                {
                    Console.Clear();
                    Console.WriteLine("Настройки");
                    Console.WriteLine("(1)-Размер поля, (2)- Макс.соседних клеток,(3)- Режим,(4)- Ранд.кол , (Space)-Назад");
                    key = Input.GetKey();
                    if (key == ConsoleKey.Spacebar)
                    {
                        state = States.Main;
                        settings.Save();
                        break;
                    }
                    if (key == ConsoleKey.D1)
                    {
                        lock (Input.ob)
                        {
                            Console.WriteLine("введите размер поля");
                            int x = 0;
                            int y = 0;


                            if (int.TryParse(Console.ReadLine(), out x) && int.TryParse(Console.ReadLine(), out y))
                                settings.Size = new Pair<int, int>(x, y);
                            else
                                x = 10; y = 10;
                            continue;
                        }
                    }
                    if (key == ConsoleKey.D2)
                    {
                        lock (Input.ob)
                        {
                            Console.WriteLine("введите число");
                            int max = 0;

                            if (int.TryParse(Console.ReadLine(), out max))
                                settings.MaxCloseCells = max;
                            else
                                settings.MaxCloseCells = 2;
                        }
                    }
                    if (key == ConsoleKey.D3)
                    {
                        Console.WriteLine("1 - OnlyGrass, 2 - OnlyGrass_2, 3 - MixedGrass, 4 - WithAnimal");
                        lock (Input.ob)
                        {
                            Console.WriteLine("введите число");
                            int mode = 0;

                            if (int.TryParse(Console.ReadLine(), out mode))
                                settings.GameMode = (GameSettings.GameModes)mode;
                            else
                                settings.GameMode = GameSettings.GameModes.OnlyGrass;
                        }
                    }
                    if (key == ConsoleKey.D4)
                    {
                        settings.SetRandomStartPreset();
                        Console.WriteLine("ок!!!!!");
                        Thread.Sleep(250);
                    }
                    Console.Clear();
                }
                while (state == States.GamesVisor)
                {
                    Console.Clear();
                    Console.WriteLine("space - back, enter - выбрать игру");
                    Console.WriteLine("Все игры на сервере:");
                    foreach (var item in Chanell.GetAllGames())
                    {
                        Console.WriteLine("Id {0}\nSize{3} на {4}\nGeneration {1}\ncount GameObjects {2}\n", item.Id,
                            item.CurrentField.Generation, item.CurrentField.GameObjects.Count, item.Settings.Size.Key, item.Settings.Size.Value);
                    }
                    key = Input.GetKey();
                    if (key == ConsoleKey.Spacebar)
                    {
                        state = States.Main;
                        break;
                    }
                    Console.WriteLine("Выберете id игры");
                    int id = -1;

                    // lock (Input.ob)
                    {
                        if (int.TryParse(Console.ReadLine(), out id))
                        {
                            CurrentGame = id;
                        }
                        else continue;
                    }

                    Console.WriteLine("Enter - start, space - delete");
                    key = Input.GetKey();
                    if (key == ConsoleKey.Spacebar)
                    {
                        Chanell.DeleteGame(CurrentGame);
                        continue;
                    }
                    if (key == ConsoleKey.Enter)
                    {
                        Chanell.ContinueGame(CurrentGame);
                        StartMenu();

                    }

                }
            }
        }


        static void Main(string[] args)
        {
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
                Console.WriteLine(ex);
                Console.ReadKey();
            }
            Menu();
        }
    }
}

