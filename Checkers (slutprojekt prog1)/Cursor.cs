class Cursor
{
    public Position position;

    public Cursor()
    {
        position.x = 0;
        position.y = 0;    
    }

    Piece selectSquare(Board board)
    {
        return board.squares[position.x, position.y];
    }
    void MoveUp()
    {
        position.y -= 1;
    }
    void MoveDown()
    {
        position.y += 1;
    }
    void MoveRight()
    {
        position.x += 1;
    }
    void MoveLeft()
    {
        position.x -= 1;
    }

    public void MoveCursor(Board board)
    {
        while (true)
        {
            ConsoleKey pressedKey = Console.ReadKey(true).Key;
            switch (pressedKey)
            {
                case ConsoleKey.UpArrow:
                    MoveUp();
                    if (position.y < 0)
                    {
                        position.y = 0;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    MoveDown();
                    if (position.y > 7)
                    {
                        position.y = 7;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    MoveRight();
                    if (position.x > 7)
                    {
                        position.x = 7;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    MoveLeft();
                    if (position.x < 0)
                    {
                        position.x = 0;
                    }
                    break;
                case ConsoleKey.Enter:
                    return;
                    // return selectSquare(board);
                default:
                    Console.WriteLine("You need to use the arrow keys to move, or Enter to select the current square");
                    Console.ReadLine();
                    break;
            }
            Console.Clear();
            board.PrintBoard(position);
        }
    }
}