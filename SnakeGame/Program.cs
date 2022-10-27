using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SnakeGame
{
    internal class Program
    {
        public static AutoResetEvent autoReset = new AutoResetEvent(false);
        static void Main(string[] args)
        {
            IGame game = new Game();
            autoReset.WaitOne();
        }
    }
}
