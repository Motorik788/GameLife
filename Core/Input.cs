using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Core
{
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
}
