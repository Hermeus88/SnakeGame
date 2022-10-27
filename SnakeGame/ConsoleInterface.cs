using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class ConsoleInterface : IConsoleInterface
    {
        public string BortSymbol { get; set; } = "#";
        public string SnakeHeadSymbol { get; set; } = "@";
        public string RabbitSymbol { get; set; } = "*";
        public string SpaceSymbol { get; set; } = " ";
        public string SnakeTailSymbol { get; set; } = "o"; 

        private Board brd;
       
        //конструктор
        public ConsoleInterface(Board brd) 
        {
            this.brd = brd;
            this.DrawBoard();
        }

        public void DrawBoard()
        {
            for (int i = 0; i < brd.Height; i++)
            {
                for (int k = 0; k < brd.Width; k++)
                {
                    Board.CellStatus cellValue = brd[k, i];   //обращение к индексатору

                    switch (cellValue)
                    {
                        case Board.CellStatus.Empty:
                            Console.Write(SpaceSymbol);
                            break;
                        case Board.CellStatus.Wall:
                            Console.Write(BortSymbol);
                            break;
                        case Board.CellStatus.SnakeHead:
                            Console.Write(SnakeHeadSymbol);
                            break;
                        case Board.CellStatus.RabbitHead:
                            Console.Write(RabbitSymbol);
                            break;
                        case Board.CellStatus.SnakeTail:
                            Console.Write(SnakeTailSymbol);
                            break;
                        default:
                            Console.Write(cellValue);
                            break;
                    }

                }
                Console.WriteLine();
            }
            
        }

   
    }
}
