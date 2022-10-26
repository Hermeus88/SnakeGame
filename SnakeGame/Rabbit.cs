using System;

namespace SnakeGame
{
    interface IRabbit
    {
        void CreateRabbit();
    }
    public class Rabbit: IRabbit
    {
        public int RabbitPositionX { get; set; }
        public int RabbitPositionY { get; set; }

        private Board brd;

        private Random rnd = new Random();

        public Rabbit(Board board)
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