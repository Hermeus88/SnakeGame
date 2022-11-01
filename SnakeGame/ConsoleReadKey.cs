using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace SnakeGame
{
    public class ConsoleReadKey
    {
        private ISnake snake;

        private ConsoleKeyInfo presedKey = Console.ReadKey(true);
        private ConsoleKeyInfo previousPresedKey = new ConsoleKeyInfo();

        public ConsoleReadKey(ISnake snake)
        {
            this.snake = snake;
        }

        public void stepReadKey()
        {
            if (Console.KeyAvailable)
            {
                presedKey = Console.ReadKey(true);
            }
            Console.SetCursorPosition(0, 0);

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
        }
    }
}
