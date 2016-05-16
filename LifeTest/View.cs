using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
<<<<<<< HEAD
using Core;

namespace LifeTest
{
   public abstract class View
    {
        [System.Serializable]
        public class ConsolePresenter : IPresenter
        {          
=======

namespace LifeTest
{
    abstract class View
    {
        [System.Serializable]
        public class ConsolePresenter : IPresenter
        {
>>>>>>> remotes/origin/master
            public ConsolePresenter()
            {
                Task.Factory.StartNew
                   (
                       () =>
                       {
                           while (true)
                           {
<<<<<<< HEAD
                               if (Input.GetKey() == ConsoleKey.S)
=======
                               if (Program.Input.GetKey() == ConsoleKey.S)
>>>>>>> remotes/origin/master
                               {
                                   GameManager.Stop();
                                   break;
                               }
                           }
                       }
                );
            }

            public void Present(Field field)
            {
                Console.CursorLeft = 0;
                Console.CursorTop = 1;
                for (int i = 0; i < field.XLenght; i++)
                {
                    for (int j = 0; j < field.YLenght; j++)
                    {
<<<<<<< HEAD
                        if (field.Cells[i ][j])
                            Console.Write("{0}|", field.Cells[i ][j].Icon);
=======
                        if (field.Cells[i, j])
                            Console.Write("{0}|", field.Cells[i, j].Icon);
>>>>>>> remotes/origin/master
                        else
                            Console.Write(" |");
                    }
                    Console.WriteLine();
                    int g = 0;
                    for (int k = 0; k < field.YLenght * 2; k++)
                    {
                        if (g != 1)
                            Console.Write("-");
                        else
                        {
                            Console.Write("|");
                            g = -1;
                        }
                        g++;
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("Поколение {0}, Травы {1}", field.Generation, field.GameObjects.Count);
            }
        }
<<<<<<< HEAD
=======

        public class WinPresenter : IPresenter
        {
            public void Present(Field field)
            {
                throw new NotImplementedException();
            }
        }
>>>>>>> remotes/origin/master
    }
}
