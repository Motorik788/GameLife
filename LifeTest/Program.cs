using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Web.Script.Serialization;
using System.IO;
using System.Data.Entity;


namespace LifeTest
{
    class Program
    {
        enum States
        {
            Main,
            Settings
        }

        public static class Input
        {
            static ConsoleKeyInfo Key;
            public static object ob = new object();

            static Input()
            {
                Thread threadInput = new Thread(Watch);
                threadInput.IsBackground = true;
                threadInput.Start();
                threadInput.Priority = ThreadPriority.AboveNormal;
            }

            static void Watch()
            {
                while (true)
                {
                    lock (ob)
                    {
                        Key = Console.ReadKey(true);
                    }
                }
            }

            public static ConsoleKey GetKey()
            {
                lock (ob)
                {
                    return Key.Key;
                }
            }
        }

        static States state = States.Main;
        delegate void StartGameMenu(IPresenter presenter = null, Field field = null);

        static void StartMenu(IPresenter presenter = null, Field field = null)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("(S)-Стоп");
            Console.ForegroundColor = ConsoleColor.Gray;
            GameManager.Start(presenter, field);
            Console.CursorLeft = 0;
            Console.CursorTop = 0;
            Console.WriteLine("(Escape)-Сохранить и выйти, (S)-Старт, (Enter)-Продолжить, (Space)-Настройки");
        }

        static void Menu()
        {
            bool menu = true;
            while (menu)
            {
                Console.Clear();
                Console.WriteLine("Главное меню");
                Console.WriteLine("(Escape)-Сохранить и выйти, (S)-Старт, (Enter)-Продолжить, (Space)-Настройки");
                while (state == States.Main)
                {
                    if (Input.GetKey() == ConsoleKey.Escape)
                    {
                        GameManager.Save();
                        return;
                    }
                    if (Input.GetKey() == ConsoleKey.Enter)
                    {
                        StartMenu(new View.ConsolePresenter(), GameManager.Load());
                        //Console.Clear();
                        //Console.ForegroundColor = ConsoleColor.Red;
                        //Console.WriteLine("(S)-Стоп");
                        //Console.ForegroundColor = ConsoleColor.Gray;
                        //GameManager.Start(new View.ConsolePresenter(), GameManager.Load());
                        //Console.CursorLeft = 0;
                        //Console.CursorTop = 0;
                        //Console.WriteLine("(Escape)-Сохранить и выйти, (S)-Старт, (Enter)-Продолжить, (Space)-Настройки");

                    }
                    if (Input.GetKey() == ConsoleKey.Spacebar)
                        state = States.Settings;
                    if (Input.GetKey() == ConsoleKey.S)
                    {
                        StartMenu(new View.ConsolePresenter());
                        //Console.Clear();
                        //Console.ForegroundColor = ConsoleColor.Red;
                        //Console.WriteLine("(S)-Стоп");
                        //Console.ForegroundColor = ConsoleColor.Gray;
                        //GameManager.Start(new View.ConsolePresenter());
                        //Console.CursorLeft = 0;
                        //Console.CursorTop = 0;
                        //Console.WriteLine("(Escape)-Сохранить и выйти, (S)-Старт, (Enter)-Продолжить, (Space)-Настройки");
                    }
                }

                while (state == States.Settings)
                {
                    Console.Clear();
                    Console.WriteLine("Настройки");
                    Console.WriteLine("(1)-Размер поля, (2)- Макс.соседних клеток, (Space)-Назад");
                    if (Input.GetKey() == ConsoleKey.Spacebar)
                        state = States.Main;
                    if (Input.GetKey() == ConsoleKey.D1)
                    {
                        lock (Input.ob)
                        {
                            Console.WriteLine("введите размер поля");
                            int x = 0;
                            int y = 0;
                            int.TryParse(Console.ReadLine(), out x);
                            int.TryParse(Console.ReadLine(), out y);
                            GameManager.Settings.Size = new KeyValuePair<int, int>(x, y);
                            continue;
                        }
                    }
                    if (Input.GetKey() == ConsoleKey.D2)
                    {
                        lock (Input.ob)
                        {
                            Console.WriteLine("введите число");
                            int max = int.Parse(Console.ReadLine());
                            GameManager.Settings.MaxCloseCells = max;
                        }
                    }
                    Console.Clear();
                }
            }
        }



        static void Main(string[] args)
        {
            Menu();

        }
    }
}
