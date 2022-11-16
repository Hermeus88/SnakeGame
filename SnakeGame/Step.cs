using System;
using System.Timers;

namespace SnakeGame
{
    public class Step : IStep
    {
        private Snake snake;
        private IRabbit rabbit;
        private IConsoleInterface consoleInterface;
        private ConsoleReadKey consoleReadKey;

        public Step(IConsoleInterface consoleInterface, ISnake snake, IRabbit rabbit, ConsoleReadKey consoleReadKey)
        {
            this.consoleInterface = consoleInterface;
            this.snake = (Snake)snake;
            this.rabbit = rabbit;
            this.consoleReadKey = consoleReadKey;
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