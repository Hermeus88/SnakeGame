//using System.Threading;

using System.Threading;
using System.Timers;
using Timer = System.Timers.Timer;

namespace SnakeGame
{
    public class Game:IGame
    {
        public Game()
        {
           StartGame();
        }

        public void StartGame()
        {
            IBoard board = new Board(30, 15, 2);
            ISnake snake = new Snake(board);
            IRabbit rabbit = new Rabbit(board);
            IConsoleInterface consoleInterface = new ConsoleInterface(board);
            Step step = new Step(snake, rabbit, consoleInterface);

            Timer timer = new Timer(200);
            timer.Elapsed += step.NextStep;
            timer.AutoReset = true;
            timer.Enabled = true;
        }
    }
}