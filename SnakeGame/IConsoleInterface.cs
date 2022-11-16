namespace SnakeGame
{
    public interface IConsoleInterface
    {
        string BortSymbol { get;  set; } 
        string SnakeHeadSymbol { get;  set; }
        string RabbitSymbol { get;  set; } 
        string SpaceSymbol { get;  set; }
        string SnakeTailSymbol { get;  set; } 
        void DrawBoard();
    }
}
