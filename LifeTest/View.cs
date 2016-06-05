using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public abstract class View
    {
        [System.Serializable]
        public class ConsolePresenter : IPresenter
        {
            public ConsolePresenter()
            {
                Task.Factory.StartNew
                   (
                       () =>
                       {
                           while (true)
                           {
                               if (Input.GetKey() == ConsoleKey.S)
                               {                                  
                                   Program.Chanell.StopGame(Program.CurrentGame);
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
                for (int i = 0; i < field.YLenght; i++)
                {
                    for (int j = 0; j < field.XLenght; j++)
                    {
                        if (field.Cells[i][j] != null)
                            Console.Write("{0}|", field.Cells[i][j].Icon);
                        else
                            Console.Write(" |");
                    }
                    Console.WriteLine();
                    int g = 0;
                    for (int k = 0; k < field.XLenght * 2; k++)
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
                Console.WriteLine("Поколение {0}, Обьектов {1}", field.Generation, field.GameObjects.Count);
            }
        }
    }
}
