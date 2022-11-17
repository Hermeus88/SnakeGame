//using System.Threading;

using System.Threading;
using System.Timers;
using Timer = System.Timers.Timer;

namespace SnakeGame
{
    public class Game:IGame
    {
        private Snake snake;
        private IRabbit rabbit;
        private IConsoleInterface consoleInterface;
        private ConsoleGameControl consoleReadKey;

        public Game()
        {
           StartGame();
        }

        public void StartGame()
        {
            IBoard board = new Board(30, 15, 2);
            this.snake = new Snake(board);
            this.rabbit = new Rabbit(board);
            this.consoleInterface = new ConsoleInterface(board);
            this.consoleReadKey = new ConsoleGameControl(snake);
            Timer timer = new Timer(200);
            timer.Elapsed += NextStep;
            timer.AutoReset = true;
            timer.Enabled = true;

        }
        public void NextStep(object source, ElapsedEventArgs e)
        {
            if (snake.HeadPositionX == rabbit.RabbitPositionX && snake.HeadPositionY == rabbit.RabbitPositionY)
            {
                rabbit.CreateRabbit();
                snake.GrowSnakeBody();
            }

            consoleReadKey.ReadKey();
            snake.moveHead();
            consoleInterface.DrawBoard();
        }

    }
}