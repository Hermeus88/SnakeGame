namespace SnakeGame
{
    public interface IBoard
    {
        int Width  { get; }
        int Height { get; }
        int Frame  { get; }

        int Top    { get; }
        int Bottom { get; }
        int Left   { get; }
        int Right  { get; }

        Board.CellStatus this[int i, int j] { get; set; }

        void CreateWalls();
    }
}
