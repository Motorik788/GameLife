﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Web.Script.Serialization;
using System.IO;
using System.Data.Entity;
<<<<<<< HEAD
using Core;
=======
>>>>>>> remotes/origin/master


namespace LifeTest
{
    class Program
    {
        enum States
        {
            Main,
            Settings
        }

<<<<<<< HEAD


        static States state = States.Main;
=======
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
>>>>>>> remotes/origin/master

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
<<<<<<< HEAD
                        StartMenu(new View.ConsolePresenter(), GameManager.Load());
                    if (Input.GetKey() == ConsoleKey.Spacebar)
                    {
                        state = States.Settings;
                        GameManager.Settings.Load();
                        break;
                    }
                    if (Input.GetKey() == ConsoleKey.S)
                        StartMenu(new View.ConsolePresenter());
=======
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
>>>>>>> remotes/origin/master
                }

                while (state == States.Settings)
                {
                    Console.Clear();
                    Console.WriteLine("Настройки");
                    Console.WriteLine("(1)-Размер поля, (2)- Макс.соседних клеток, (Space)-Назад");
                    if (Input.GetKey() == ConsoleKey.Spacebar)
<<<<<<< HEAD
                    {
                        state = States.Main;
                        GameManager.Settings.Save();
                        break;
                    }
=======
                        state = States.Main;
>>>>>>> remotes/origin/master
                    if (Input.GetKey() == ConsoleKey.D1)
                    {
                        lock (Input.ob)
                        {
                            Console.WriteLine("введите размер поля");
                            int x = 0;
                            int y = 0;
                            int.TryParse(Console.ReadLine(), out x);
                            int.TryParse(Console.ReadLine(), out y);
<<<<<<< HEAD
                            if (x > 1 && y > 1)
                                GameManager.Settings.Size = new Pair<int, int>(x, y);
                            else
                                x = 10; y = 10;
=======
                            GameManager.Settings.Size = new KeyValuePair<int, int>(x, y);
>>>>>>> remotes/origin/master
                            continue;
                        }
                    }
                    if (Input.GetKey() == ConsoleKey.D2)
                    {
                        lock (Input.ob)
                        {
                            Console.WriteLine("введите число");
<<<<<<< HEAD
                            int max = 0;
                            int.TryParse(Console.ReadLine(), out max);
                            if (max > 0)
                                GameManager.Settings.MaxCloseCells = max;
                            else GameManager.Settings.MaxCloseCells = 2;
=======
                            int max = int.Parse(Console.ReadLine());
                            GameManager.Settings.MaxCloseCells = max;
>>>>>>> remotes/origin/master
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
