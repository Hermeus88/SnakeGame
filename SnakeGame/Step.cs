using System;
using System.Timers;

namespace SnakeGame
{
    public class Step : IStep
    {
        private ISnake snake;
        private IRabbit rabbit;
        private IConsoleInterface consoleInterface;
       
        private ConsoleKeyInfo presedKey = Console.ReadKey(true);
        private ConsoleKeyInfo previousPresedKey = new ConsoleKeyInfo();

        public Step(ISnake snake,IRabbit rabbit,IConsoleInterface consoleInterface )
        {
            this.consoleInterface = consoleInterface;
            this.snake = snake;
            this.rabbit = rabbit;
        }
           
        public void NextStep(object source, ElapsedEventArgs e)
        { 
            if (Console.KeyAvailable)
            {
                presedKey = Console.ReadKey(true);
            }

            Console.SetCursorPosition(0,0);

            if (snake.HeadPositionX == rabbit.RabbitPositionX && snake.HeadPositionY == rabbit.RabbitPositionY)
            {
                rabbit.CreateRabbit();
                snake.GrowSnakeBody();
            }

            if (presedKey.Key == ConsoleKey.RightArrow && previousPresedKey.Key != ConsoleKey.LeftArrow)
            {
                snake.MoveRight();
            }
            else if (presedKey.Key == ConsoleKey.LeftArrow && previousPresedKey.Key != ConsoleKey.RightArrow)
            {
                snake.MoveLeft();
            }
            else if (presedKey.Key == ConsoleKey.UpArrow && previousPresedKey.Key != ConsoleKey.DownArrow)
            {
                snake.MoveUp();
            }
            else if (presedKey.Key == ConsoleKey.DownArrow && previousPresedKey.Key != ConsoleKey.UpArrow)
            {
                snake.MoveDown();
            }
            else presedKey = previousPresedKey;

            previousPresedKey = presedKey;
            
            consoleInterface.DrawBoard();
        }
    }
}