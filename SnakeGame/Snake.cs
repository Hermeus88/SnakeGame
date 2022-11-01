using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class Snake:ISnake
    {
        public int HeadPositionX { get; private set; }
        public int HeadPositionY { get; private set; }

        private IBoard brd;

        private int previusHeadPositionX;

        private int previusHeadPositionY;

        public List<Position> SnakeTail = new List<Position>();


        //конструктор  17-23
        public Snake(IBoard board)           
        {
            brd = board;
            this.HeadPositionX = this.previusHeadPositionX = board.Width / 2;
            this.HeadPositionY = this.previusHeadPositionY = board.Height / 2;
            brd[this.HeadPositionX,this.HeadPositionY] = Board.CellStatus.SnakeHead;
            SnakeTail.Add(new Position(this.HeadPositionX, this.HeadPositionY));
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
            //brd[this.HeadPositionX, this.HeadPositionY] = Board.CellStatus.SnakeHead; 

            this.MoveBody();
        }
        public void MoveBody()
        {
            brd[SnakeTail[0].X, SnakeTail[0].Y] = Board.CellStatus.Empty;                             //стираем последнюю часть хвоста
            SnakeTail.RemoveAt(0);                                                                    //удаляем ссылку на последний елемент  хвоста из листа(списка)
                                                                                                      //добавляем в конец списка  
            SnakeTail.Add(new Position(this.HeadPositionX, HeadPositionY));                           
            foreach(var position in SnakeTail)
            {
                brd[position.X,position.Y] = Board.CellStatus.SnakeTail;
            }
            
            brd[this.HeadPositionX, this.HeadPositionY] = Board.CellStatus.SnakeHead;
            this.previusHeadPositionX = this.HeadPositionX;                                           //перезаписываем позиции
            this.previusHeadPositionY = this.HeadPositionY;
        }
        public void GrowSnakeBody()
        {
            SnakeTail.Add(new Position(this.HeadPositionX, this.HeadPositionY));
        }
    }
}
