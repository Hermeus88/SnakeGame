using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class Snake
    {
        public int HeadPositionX { get; private set; }
        public int HeadPositionY { get; private set; }
        private Board brd;

        private int tempHeadPositionX;

        private int tempHeadPositionY;


        //конструктор  17-23
        public Snake(Board board)           
        {
            brd = board;
            this.HeadPositionX = board.Width / 2;
            this.HeadPositionY = board.Height / 2;
            brd[this.HeadPositionX,this.HeadPositionY] = Board.CellStatus.SnakeHead;
            this.tempHeadPositionX = this.HeadPositionX;
            this.tempHeadPositionY = this.HeadPositionY;
        }



        public void MoveRight()
        {
            this.HeadPositionX++;
            if (this.HeadPositionX >= brd.Width - brd.Frame)
            {
                this.HeadPositionX = brd.Left;
            }
            this.Move();
        }
        public void MoveLeft()
        {
            this.HeadPositionX--;
            if (this.HeadPositionX < brd.Left)
            {
                this.HeadPositionX = brd.Right;
            }
            this.Move();

        }
        public void MoveDown()
        {

            this.HeadPositionY++;
            if (this.HeadPositionY > brd.Bottom)
            {
                this.HeadPositionY = brd.Top;
            }
            this.Move();

        }
        public void MoveUp()
        {
            this.HeadPositionY--;
            if (this.HeadPositionY < brd.Top)
            {
                this.HeadPositionY = brd.Bottom;
            }
            this.Move();
        }
        private void Move()
        {
            brd[this.tempHeadPositionX, this.tempHeadPositionY] = Board.CellStatus.Empty;
            this.tempHeadPositionX = this.HeadPositionX;
            this.tempHeadPositionY = this.HeadPositionY;
            brd[this.HeadPositionX, this.HeadPositionY] = Board.CellStatus.SnakeHead;
        }

    }
}
