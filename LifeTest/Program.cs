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
        public static IService chanell;
        public static int currentGame = -1;

        enum States
        {
            Main,
            Settings
        }

        static States state = States.Main;

        static void StartMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("(S)-Стоп");
            Console.ForegroundColor = ConsoleColor.Gray;
            // GameManager.Start(presenter, field);
            Game();
            Console.CursorLeft = 0;
            Console.CursorTop = 0;
            Console.WriteLine("(Escape)-Сохранить и выйти, (S)-Старт, (Enter)-Продолжить, (Space)-Настройки");
        }

        static void Game()
        {
            View.ConsolePresenter pres = new View.ConsolePresenter();
            do
            {
                try
                {
                    pres.Present(chanell.GetGameState(currentGame));
                    Thread.Sleep(120);
                }
                catch(Exception ex)
                {
                    //Console.WriteLine(ex);
                }
            }
            while (chanell.IsGame(currentGame));
        }

        static void Menu()
        {
            bool menu = true;
            GameSettings settings = new GameSettings();
            while (menu)
            {
                Console.Clear();
                Console.WriteLine("Главное меню");
                Console.WriteLine("(Escape)-Сохранить и выйти, (S)-Старт, (Enter)-Продолжить, (Space)-Настройки");
                while (state == States.Main)
                {
                    if (Input.GetKey() == ConsoleKey.Escape)
                    {
                        //GameManager.Save();
                        return;
                    }
                    if (Input.GetKey() == ConsoleKey.Enter)
                    {
                        Console.Clear();
                        Console.WriteLine("Все игры на сервере:");
                        foreach (var item in chanell.GetAllGames())
                        {
                            Console.WriteLine("Id {0}\nSize{3} на {4}\nGeneration {1}\ncount GameObjects {2}\n", item.Id,
                                item.CurrentField.Generation, item.CurrentField.GameObjects.Count,item.Settings.Size.Key,item.Settings.Size.Value);
                        }
                        Console.WriteLine("Выберете id игры");
                        int id = -1;
                        lock (Input.ob)
                        {
                            if (int.TryParse(Console.ReadLine(), out id))
                            {
                                currentGame = id;
                            }
                            else continue;
                        }
                        chanell.ContinueGame(currentGame);
                        StartMenu();
                    }
                    if (Input.GetKey() == ConsoleKey.Spacebar)
                    {
                        state = States.Settings;
                        settings.Load();
                        break;
                    }
                    if (Input.GetKey() == ConsoleKey.S)
                    {
                        //StartMenu(new View.ConsolePresenter());
                        settings.Load();
                        currentGame = chanell.StartNewGame(currentGame,settings);
                        StartMenu();
                    }
                }

                while (state == States.Settings)
                {
                    Console.Clear();
                    Console.WriteLine("Настройки");
                    Console.WriteLine("(1)-Размер поля, (2)- Макс.соседних клеток, (Space)-Назад");
                    if (Input.GetKey() == ConsoleKey.Spacebar)
                    {
                        state = States.Main;
                        settings.Save();
                        break;
                    }
                    if (Input.GetKey() == ConsoleKey.D1)
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
                    if (Input.GetKey() == ConsoleKey.D2)
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
                    Console.Clear();
                }
            }
        }



        static void Main(string[] args)
        {
            try
            {
                Uri uri = new Uri("http://localhost:4000/LifeService");

                BasicHttpBinding binding = new BasicHttpBinding();

                EndpointAddress endpoint = new EndpointAddress(uri);

                ChannelFactory<IService> factory = new ChannelFactory<IService>(binding, endpoint);
                chanell = factory.CreateChannel();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            Menu();
        }
    }
}
