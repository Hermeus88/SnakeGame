//using System.Threading;

using System.Threading;
using System.Timers;
using Timer = System.Timers.Timer;

namespace SnakeGame
{
    public class Game
    {

        public Game()
        {
           StartGame();
        }

        private void StartGame()
        {
            Board board = new Board(14, 7, 2);
            Snake snake = new Snake(board);
            Rabbit rabbit = new Rabbit(board);
            ConsoleInterface consoleInterface = new ConsoleInterface(board);
            Step step = new Step(snake, rabbit, consoleInterface);

            
            Timer timer = new Timer(200);
            timer.Elapsed += step.NextStep;
            timer.AutoReset = true;
            timer.Enabled = true;

            
            
            






        }
    }
}