using System;
using System.Timers;

namespace SnakeGame
{
    interface IStep
    {

    }
    public class Step : IStep
    {
        private Snake snake;
        private Rabbit rabbit;
        private ConsoleInterface consoleInterface;
       
        private ConsoleKeyInfo presedKey = Console.ReadKey(true);
        private ConsoleKeyInfo previousPresedKey = new ConsoleKeyInfo();

        public Step(Snake snake,Rabbit rabbit,ConsoleInterface consoleInterface )
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