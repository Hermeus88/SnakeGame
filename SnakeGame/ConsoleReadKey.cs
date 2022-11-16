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
        private Snake snake;

        private ConsoleKeyInfo presedKey = Console.ReadKey(true);
        private ConsoleKeyInfo previousPresedKey = new ConsoleKeyInfo();

        public ConsoleReadKey(ISnake snake)
        {
            this.snake = (Snake)snake;
            
        }

        public void ReadKey()
        {
            if (Console.KeyAvailable)
            {
                presedKey = Console.ReadKey(true);
            }
            if (presedKey.Key == ConsoleKey.RightArrow && previousPresedKey.Key != ConsoleKey.LeftArrow)
            {
                snake.moveHead = snake.MoveRight;
            }
            else if (presedKey.Key == ConsoleKey.LeftArrow && previousPresedKey.Key != ConsoleKey.RightArrow)
            {
                snake.moveHead = snake.MoveLeft;
            }
            else if (presedKey.Key == ConsoleKey.UpArrow && previousPresedKey.Key != ConsoleKey.DownArrow)
            {
                snake.moveHead = snake.MoveUp;
            }
            else if (presedKey.Key == ConsoleKey.DownArrow && previousPresedKey.Key != ConsoleKey.UpArrow)
            {
                snake.moveHead = snake.MoveDown;
            }
            else if (presedKey.Key == ConsoleKey.Escape)
            {
                Program.autoReset.Set();
            }
            else presedKey = previousPresedKey;

            previousPresedKey = presedKey;
        }
    }
}
