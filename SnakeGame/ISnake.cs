namespace SnakeGame
{
    public interface ISnake
    {
        int HeadPositionX { get; }
        int HeadPositionY { get; }
        void MoveRight();
        void MoveLeft();
        void MoveUp();
        void MoveDown();
        void MoveBody();
        void GrowSnakeBody();

        
    }
}
