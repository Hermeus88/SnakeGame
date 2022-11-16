using System;

namespace SnakeGame
{
    public class Rabbit: IRabbit
    {
        public int RabbitPositionX { get; set; }
        public int RabbitPositionY { get; set; }

        private IBoard brd;

        private Random rnd = new Random();

        public Rabbit(IBoard board)
        {
            this.brd = board;
            this.CreateRabbit();
        }
        public void CreateRabbit()
        {   
            RabbitPositionX = rnd.Next(brd.Left,brd.Right);
            RabbitPositionY = rnd.Next(brd.Top, brd.Bottom);
            brd[RabbitPositionX, RabbitPositionY] = Board.CellStatus.RabbitHead;
        }
    }
}