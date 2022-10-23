using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class Board
    {
        
        public enum CellStatus
        {
            Empty,
            Wall,
            RabbitHead,
            SnakeHead,
            SnakeTail
        }
        private CellStatus[,] array;

        //Индексатор 
        public CellStatus this[int i, int j]
        {
            get { return array[i, j]; }

            set { array[i, j] = value; }
        }

        //свойство 13-15 строчка
        public int Width { get; private set; }
        public int Height { get; private set; }
        public int Frame { get; private set; }

        public int Top { get { return 0 + Frame; }  }
        public int Bottom { get { return Height - Frame - 1; } }
        public int Left { get { return Frame ; } }
        public int Right { get { return Width - Frame - 1; } }


        public Rabbit rabbit;
        public Snake snake;

        //конструктор
        public Board(int Width, int Height, int Frame)
        {
            this.Width = Width;
            this.Height = Height;
            this.Frame = Frame;
            array = new CellStatus[Width, Height];
            CreateWalls();
        }

        //Заполнение рамки
        private void CreateWalls()
        {
            for (int k = 0; k < Frame; k++)
            {
                //LeftLine and RightLine
                for (int i = 0; i < Height; i++)
                {
                    this[k, i] = CellStatus.Wall;                   //Left
                    this[k + Width - Frame, i] = CellStatus.Wall;   //Right
                }
                //TopLine and BottomLine
                for (int i = 0; i < Width; i++)
                {
                    this[i, k] = CellStatus.Wall;                   //Top
                    this[i, k + Height - Frame] = CellStatus.Wall;  //Bottom
                }

            }
          

        }
    }
}
