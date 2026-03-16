class GameLogic //Denna class ska ansvara för logik så som vems tur det är och vad den spelaren ska göra nu.
{
    bool player1sTurn = true;

    public Piece SelectSquare(Cursor cursor, Board board)
    {
        Console.WriteLine("Move the cursor by using arrow keys, select the current square with Enter");

        cursor.position = new Position{x = 0, y = 0};
        
        while (true)
        {
            ConsoleKey pressedKey = Console.ReadKey(true).Key;
            switch (pressedKey)
            {
                case ConsoleKey.UpArrow:
                    cursor.MoveUp();
                    break;
                case ConsoleKey.DownArrow:
                    cursor.MoveDown();
                    break;
                case ConsoleKey.RightArrow:
                    cursor.MoveRight();
                    break;
                case ConsoleKey.LeftArrow:
                    cursor.MoveLeft();
                    break;
                case ConsoleKey.Enter:
                    return cursor.selectSquare(board);
                default:
                    Console.WriteLine("You need to use the arrow keys to move, or Enter to select the current square");
                    break;
            }
            Console.Clear();
            board.PrintBoard(cursor.position);
        }
    }
}